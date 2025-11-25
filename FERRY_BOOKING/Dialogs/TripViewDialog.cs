using FERRY_BOOKING.DATABASE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FERRY_BOOKING.Dialogs
{
    public partial class TripViewDialog : Form
    {
        public int FerryID { get; private set; }
        public int TripID { get; private set; }

        private DATABASE.StaffHelper db = new DATABASE.StaffHelper();

        public TripViewDialog(int tripID, int ferryID)
        {
            InitializeComponent();

            this.FerryID = ferryID;
            this.TripID = tripID;

            LoadTripDetails();
            GenerateFloorButtons(this.FerryID);

            // Auto load first floor seat plan
            DataTable dt = db.GetFloors(this.FerryID);
            if (dt.Rows.Count > 0)
            {
                int floorNumber = Convert.ToInt32(dt.Rows[0]["FloorNumber"]);
                int rows = Convert.ToInt32(dt.Rows[0]["Rows"]);
                int cols = Convert.ToInt32(dt.Rows[0]["Columns"]);

                GenerateSeatPlan(floorNumber, rows, cols);

                // Highlight the first floor button
                if (firstFloorButton != null)
                {
                    firstFloorButton.BackColor = Color.FromArgb(11, 94, 235);
                    firstFloorButton.ForeColor = Color.White;
                }
            }
        }

        private void LoadTripDetails()
        {
            try
            {
                // Get the ferry trip details from database
                var td = db.GetFerryTripDetails(FerryID, TripID);

                lblCompany.Text = td.Company;
                lblFerry.Text = td.FerryName;
                lblRoute.Text = td.Route;
                lblDeparture.Text = td.DepartureTime;
                lblArrival.Text = td.ArrivalTime;
                lblTripDate.Text = td.TripDate;

                this.Text = $"Trip View - {td.FerryName}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading trip details: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);

                lblCompany.Text = "N/A";
                lblFerry.Text = "N/A";
                lblRoute.Text = "N/A";
                lblDeparture.Text = "N/A";
                lblArrival.Text = "N/A";
                lblTripDate.Text = "N/A";
            }
        }

        private void GenerateSeatPlan(int floorNumber, int rows, int cols)
        {
            // Clear previous seats
            tlpSeats.Controls.Clear();
            tlpSeats.ColumnStyles.Clear();
            tlpSeats.RowStyles.Clear();

            tlpSeats.ColumnCount = cols;
            tlpSeats.RowCount = rows;
            tlpSeats.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            // Equal column spacing
            for (int c = 0; c < cols; c++)
                tlpSeats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / cols));

            // Equal row spacing
            for (int r = 0; r < rows; r++)
                tlpSeats.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / rows));

            List<string> bookedSeats = db.GetBookedSeatsForTrip(this.TripID);
            string ferryCode = db.GetFerryCode(this.FerryID);
            int seatCounter = 1;

            // Count booked/available for this floor
            int totalSeatsOnFloor = rows * cols;
            int bookedOnFloor = 0;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Button seat = new Button
                    {
                        Dock = DockStyle.Fill,
                        Margin = new Padding(5),
                        Enabled = false // Read-only view
                    };

                    string seatCode = $"{floorNumber}{ferryCode}-{seatCounter:D3}";
                    seat.Text = seatCode;
                    seat.Tag = seatCode;

                    // Mark booked seats
                    if (bookedSeats.Contains(seatCode))
                    {
                        seat.BackColor = Color.DarkRed;
                        seat.ForeColor = Color.White;
                        bookedOnFloor++;
                    }
                    else
                    {
                        seat.BackColor = Color.LightGreen;
                        seat.ForeColor = Color.Black;
                    }

                    tlpSeats.Controls.Add(seat, c, r);
                    seatCounter++;
                }
            }

            // Update floor statistics
            int availableOnFloor = totalSeatsOnFloor - bookedOnFloor;
            lblFloorStats.Text = $"Floor {floorNumber} - Total: {totalSeatsOnFloor} | Booked: {bookedOnFloor} | Available: {availableOnFloor}";
        }

        private Button firstFloorButton = null;

        private void GenerateFloorButtons(int ferryID)
        {
            flpFloors.Controls.Clear();

            DataTable dtFloors = db.GetFloors(ferryID);

            foreach (DataRow floor in dtFloors.Rows)
            {
                int floorNumber = Convert.ToInt32(floor["FloorNumber"]);
                int rows = Convert.ToInt32(floor["Rows"]);
                int cols = Convert.ToInt32(floor["Columns"]);

                int flrNum = floorNumber;
                int flrRows = rows;
                int flrCols = cols;

                Button btnFloor = new Button();
                btnFloor.Text = $"Floor {floorNumber}";
                btnFloor.Width = 100;
                btnFloor.Height = 40;
                btnFloor.Margin = new Padding(5);
                btnFloor.BackColor = SystemColors.Control;
                btnFloor.ForeColor = Color.Black;

                btnFloor.Click += (s, e) =>
                {
                    // Reset all floor buttons
                    foreach (Button btn in flpFloors.Controls.OfType<Button>())
                    {
                        btn.BackColor = SystemColors.Control;
                        btn.ForeColor = Color.Black;
                    }

                    // Highlight selected floor
                    btnFloor.BackColor = Color.FromArgb(11, 94, 235);
                    btnFloor.ForeColor = Color.White;

                    GenerateSeatPlan(flrNum, flrRows, flrCols);
                };

                flpFloors.Controls.Add(btnFloor);

                // Save first floor button
                if (firstFloorButton == null)
                    firstFloorButton = btnFloor;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
