using FERRY_BOOKING.DATABASE;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace FERRY_BOOKING.Dialogs
{
    public partial class BookingSummaryDetail : Form
    {
        private int tripID;
        private int ferryID;
        private int ownerID;

        public BookingSummaryDetail(int tripID, int ferryID, int ownerID)
        {
            InitializeComponent();
            this.tripID = tripID;
            this.ferryID = ferryID;
            this.ownerID = ownerID;

            LoadBookingDetails();
        }

        private void LoadBookingDetails()
        {
            try
            {
                DatabaseHelper db = new DatabaseHelper();

                // Get trip details
                string tripQuery = @"
                    SELECT 
                        f.FerryName,
                        f.TotalCapacity,
                        r.Origin + ' → ' + r.Destination AS Route,
                        t.TripDate,
                        t.DepartureTime,
                        t.ArrivalTime
                    FROM Trip t
                    JOIN Ferry f ON t.FerryID = f.FerryID
                    JOIN Route r ON t.RouteID = r.RouteID
                    WHERE t.TripID = @TripID AND f.FerryID = @FerryID";

                SqlParameter[] tripParams = {
                    new SqlParameter("@TripID", tripID),
                    new SqlParameter("@FerryID", ferryID)
                };

                DataTable dtTrip = db.ExecuteDataTable(tripQuery, tripParams);

                if (dtTrip.Rows.Count > 0)
                {
                    DataRow trip = dtTrip.Rows[0];

                    lblFerryName.Text = trip["FerryName"].ToString();
                    lblRoute.Text = trip["Route"].ToString();
                    lblTripDate.Text = Convert.ToDateTime(trip["TripDate"]).ToString("MM/dd/yyyy");
                    
                    // Handle time parsing - can be either TimeSpan or DateTime
                    DateTime depTime, arrTime;
                    
                    if (trip["DepartureTime"] is TimeSpan)
                    {
                        TimeSpan departure = (TimeSpan)trip["DepartureTime"];
                        TimeSpan arrival = (TimeSpan)trip["ArrivalTime"];
                        depTime = DateTime.Today.Add(departure);
                        arrTime = DateTime.Today.Add(arrival);
                    }
                    else
                    {
                        // Handle DateTime type
                        depTime = Convert.ToDateTime(trip["DepartureTime"]);
                        arrTime = Convert.ToDateTime(trip["ArrivalTime"]);
                    }
                    
                    lblSchedule.Text = $"{depTime:h:mm tt} → {arrTime:h:mm tt}";

                    int totalCapacity = Convert.ToInt32(trip["TotalCapacity"]);
                    lblTotalCapacity.Text = totalCapacity.ToString();

                    // Get booked seats count
                    string bookedQuery = @"
                        SELECT COUNT(*) AS BookedCount
                        FROM BookedSeats
                        WHERE TripID = @TripID";

                    SqlParameter[] bookedParams = { new SqlParameter("@TripID", tripID) };
                    object bookedResult = db.ExecuteScalar(bookedQuery, bookedParams);
                    int bookedCount = bookedResult != null && bookedResult != DBNull.Value 
                        ? Convert.ToInt32(bookedResult) 
                        : 0;

                    lblBooked.Text = bookedCount.ToString();
                    lblAvailable.Text = (totalCapacity - bookedCount).ToString();

                    decimal occupancyPercent = totalCapacity > 0 
                        ? (decimal)bookedCount / totalCapacity * 100 
                        : 0;
                    lblOccupancy.Text = occupancyPercent.ToString("0.00") + "%";

                    // Load floor breakdown
                    LoadFloorBreakdown(totalCapacity);

                    // Load revenue
                    LoadRevenue();

                    // Load passenger count (same as booked)
                    lblPassengerCount.Text = bookedCount.ToString();

                    // Load seat numbers/passenger names
                    LoadPassengerList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading booking details: " + ex.Message + "\n\nStack Trace: " + ex.StackTrace, 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFloorBreakdown(int totalCapacity)
        {
            try
            {
                DatabaseHelper db = new DatabaseHelper();

                string floorQuery = @"
                    SELECT 
                        ff.FloorNumber,
                        ff.Capacity,
                        ISNULL(bs.BookedCount, 0) AS Booked
                    FROM FerryFloor ff
                    LEFT JOIN (
                        SELECT 
                            LEFT(SeatNumber, 1) AS FloorNum,
                            COUNT(*) AS BookedCount
                        FROM BookedSeats
                        WHERE TripID = @TripID AND FerryID = @FerryID
                        GROUP BY LEFT(SeatNumber, 1)
                    ) bs ON CAST(ff.FloorNumber AS VARCHAR) = bs.FloorNum
                    WHERE ff.FerryID = @FerryID
                    ORDER BY ff.FloorNumber";

                SqlParameter[] floorParams = {
                    new SqlParameter("@TripID", tripID),
                    new SqlParameter("@FerryID", ferryID)
                };

                DataTable dtFloors = db.ExecuteDataTable(floorQuery, floorParams);

                // Populate DataGridView
                dgvFloorBreakdown.Rows.Clear();
                dgvFloorBreakdown.Columns.Clear();

                dgvFloorBreakdown.Columns.Add("Floor", "Floor");
                dgvFloorBreakdown.Columns.Add("Capacity", "Capacity");
                dgvFloorBreakdown.Columns.Add("Booked", "Booked");
                dgvFloorBreakdown.Columns.Add("Occupancy", "Occupancy %");

                foreach (DataRow row in dtFloors.Rows)
                {
                    int capacity = Convert.ToInt32(row["Capacity"]);
                    int booked = Convert.ToInt32(row["Booked"]);
                    decimal occupancy = capacity > 0 ? (decimal)booked / capacity * 100 : 0;

                    dgvFloorBreakdown.Rows.Add(
                        row["FloorNumber"].ToString(),
                        capacity.ToString(),
                        booked.ToString(),
                        occupancy.ToString("0.00") + "%"
                    );
                }

                dgvFloorBreakdown.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading floor breakdown: " + ex.Message);
            }
        }

        private void LoadRevenue()
        {
            try
            {
                DatabaseHelper db = new DatabaseHelper();

                string revenueQuery = @"
                    SELECT ISNULL(SUM(TotalAmount), 0) AS Revenue
                    FROM Booking
                    WHERE TripID = @TripID";

                SqlParameter[] revenueParams = { new SqlParameter("@TripID", tripID) };
                decimal revenue = Convert.ToDecimal(db.ExecuteScalar(revenueQuery, revenueParams));

                var phCulture = CultureInfo.GetCultureInfo("en-PH");
                lblRevenue.Text = revenue.ToString("C", phCulture);

                // Calculate average price per seat
                int booked = Convert.ToInt32(lblBooked.Text);
                decimal avgPrice = booked > 0 ? revenue / booked : 0;
                lblAvgPrice.Text = avgPrice.ToString("C", phCulture);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading revenue: " + ex.Message);
            }
        }

        private void LoadPassengerList()
        {
            try
            {
                DatabaseHelper db = new DatabaseHelper();

                string passengerQuery = @"
                    SELECT 
                        bs.SeatNumber,
                        bp.FullName
                    FROM BookedSeats bs
                    JOIN Booking b ON bs.TripID = b.TripID
                    JOIN BookingPassenger bp ON b.BookingID = bp.BookingID AND bs.SeatNumber = bp.SeatCode
                    WHERE bs.TripID = @TripID AND bs.FerryID = @FerryID
                    ORDER BY bs.SeatNumber";

                SqlParameter[] passengerParams = {
                    new SqlParameter("@TripID", tripID),
                    new SqlParameter("@FerryID", ferryID)
                };

                DataTable dtPassengers = db.ExecuteDataTable(passengerQuery, passengerParams);

                // Populate DataGridView
                dgvPassengers.Rows.Clear();
                dgvPassengers.Columns.Clear();

                dgvPassengers.Columns.Add("SeatNumber", "Seat Number");
                dgvPassengers.Columns.Add("PassengerName", "Passenger Name");

                foreach (DataRow row in dtPassengers.Rows)
                {
                    dgvPassengers.Rows.Add(
                        row["SeatNumber"].ToString(),
                        row["FullName"].ToString()
                    );
                }

                dgvPassengers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading passenger list: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
