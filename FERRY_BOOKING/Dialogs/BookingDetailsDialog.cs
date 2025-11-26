using FERRY_BOOKING.DATABASE;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace FERRY_BOOKING.Dialogs
{
    public partial class BookingDetailsDialog : Form
    {
        private long bookingID;
        private string bookingRef;

        public BookingDetailsDialog(long bookingID, string bookingRef)
        {
            InitializeComponent();
            this.bookingID = bookingID;
            this.bookingRef = bookingRef;

            LoadBookingDetails();
        }

        private void LoadBookingDetails()
        {
            try
            {
                DatabaseHelper db = new DatabaseHelper();

                string query = @"
                    SELECT 
                        b.BookingRef,
                        b.BookingDate,
                        b.TotalAmount,
                        t.TripDate,
                        t.DepartureTime,
                        t.ArrivalTime,
                        t.TripStatus,
                        f.FerryName,
                        u.CompanyName,
                        r.Origin,
                        r.Destination,
                        bp.FullName,
                        bp.Age,
                        bp.Gender,
                        bp.SeatCode,
                        bp.Price,
                        bp.Discount
                    FROM Booking b
                    INNER JOIN Trip t ON b.TripID = t.TripID
                    INNER JOIN Ferry f ON t.FerryID = f.FerryID
                    INNER JOIN Users u ON f.OwnerID = u.UserID
                    INNER JOIN Route r ON t.RouteID = r.RouteID
                    LEFT JOIN BookingPassenger bp ON b.BookingID = bp.BookingID
                    WHERE b.BookingID = @BookingID";

                SqlParameter[] parameters = { new SqlParameter("@BookingID", bookingID) };
                DataTable dt = db.ExecuteDataTable(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow firstRow = dt.Rows[0];

                    // Header information
                    lblBookingRef.Text = firstRow["BookingRef"].ToString();
                    lblBookingDate.Text = Convert.ToDateTime(firstRow["BookingDate"]).ToString("MMM dd, yyyy hh:mm tt");

                    // Ferry & Route information
                    lblFerry.Text = $"{firstRow["CompanyName"]} - {firstRow["FerryName"]}";
                    lblRoute.Text = $"{firstRow["Origin"]} → {firstRow["Destination"]}";

                    // Trip information
                    lblTripDate.Text = Convert.ToDateTime(firstRow["TripDate"]).ToString("MMM dd, yyyy");

                    // Handle TimeSpan for departure/arrival
                    DateTime dep = Convert.ToDateTime(firstRow["DepartureTime"]);
                    DateTime arr = Convert.ToDateTime(firstRow["ArrivalTime"]);

                    lblDeparture.Text = dep.ToString("hh:mm tt");
                    lblArrival.Text = arr.ToString("hh:mm tt");

                    // Status
                    string status = firstRow["TripStatus"]?.ToString() ?? "Active";
                    lblStatus.Text = status;
                    
                    // Color code status
                    switch (status)
                    {
                        case "Cancelled":
                            lblStatus.ForeColor = Color.Red;
                            break;
                        case "Completed":
                            lblStatus.ForeColor = Color.Gray;
                            break;
                        default:
                            lblStatus.ForeColor = Color.Green;
                            break;
                    }

                    // Payment information
                    lblTotalAmount.Text = Convert.ToDecimal(firstRow["TotalAmount"]).ToString("C2", new System.Globalization.CultureInfo("fil-PH"));
                    lblPassengerCount.Text = dt.Rows.Count.ToString();

                    // Load passengers into DataGridView
                    LoadPassengers(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading booking details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadPassengers(DataTable dt)
        {
            dgvPassengers.Rows.Clear();
            dgvPassengers.Columns.Clear();

            dgvPassengers.Columns.Add("FullName", "Passenger Name");
            dgvPassengers.Columns.Add("SeatCode", "Seat");
            dgvPassengers.Columns.Add("Age", "Age");
            dgvPassengers.Columns.Add("Gender", "Gender");
            dgvPassengers.Columns.Add("Discount", "Discount");
            dgvPassengers.Columns.Add("Price", "Price");

            foreach (DataRow row in dt.Rows)
            {
                dgvPassengers.Rows.Add(
                    row["FullName"].ToString(),
                    row["SeatCode"].ToString(),
                    row["Age"].ToString(),
                    row["Gender"].ToString(),
                    row["Discount"] != DBNull.Value ? row["Discount"].ToString() : "None",
                    Convert.ToDecimal(row["Price"]).ToString("C2", new System.Globalization.CultureInfo("fil-PH"))
                );
            }

            dgvPassengers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPassengers.Columns["Age"].FillWeight = 40;
            dgvPassengers.Columns["Gender"].FillWeight = 50;
            dgvPassengers.Columns["SeatCode"].FillWeight = 50;
            dgvPassengers.Columns["Discount"].FillWeight = 60;
            dgvPassengers.Columns["Price"].FillWeight = 60;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}