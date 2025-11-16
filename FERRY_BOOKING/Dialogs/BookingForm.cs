using FERRY_BOOKING.DATABASE;
using FERRY_BOOKING.UC_Staff;
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
        public partial class BookingForm : Form
        {
            public int FerryID { get; private set; }
            public int TripID { get; private set; }
           

        private DATABASE.StaffHelper db = new DATABASE.StaffHelper();

        public BookingForm(int ferryID, int tripID)
        {
            InitializeComponent();

            this.FerryID = ferryID;
            this.TripID = tripID;

            LoadFerryTripDetails();
            // 1. Get the list of seats already booked for THIS trip
          
            // ✅ Only call once
            GenerateFloorButtons(this.FerryID);
            // ✅ Auto load first floor seatplan
            DataTable dt = db.GetFloors(this.FerryID);
            if (dt.Rows.Count > 0)
            {
              
                int floorNumber = Convert.ToInt32(dt.Rows[0]["FloorNumber"]);
                int rows = Convert.ToInt32(dt.Rows[0]["Rows"]);
                int cols = Convert.ToInt32(dt.Rows[0]["Columns"]);

                GenerateSeatPlan(floorNumber, rows, cols);
                


                // ✅ Highlight the first floor button
                if (firstFloorButton != null)
                {
                    firstFloorButton.BackColor = Color.Green;
                    firstFloorButton.ForeColor = Color.White;
                }
            }

        }


        private void LoadFerryTripDetails()
        {
            try
            {
                // Get the ferry trip details from database
                var tripDetails = db.GetFerryTripDetails(FerryID, TripID);

                // Update the labels with the retrieved data
                lblCompany.Text = tripDetails.Company;
                lblFerry.Text = tripDetails.FerryName;
                lblRoute.Text = tripDetails.Route;
                lblDeparture.Text = tripDetails.DepartureTime;

                // Optional: Update form title or other controls
                this.Text = $"Booking - {tripDetails.FerryName}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading trip details: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Set default values in case of error
                lblCompany.Text = "N/A";
                lblFerry.Text = "N/A";
                lblRoute.Text = "N/A";
                lblDeparture.Text = "N/A";
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
            ;

            string ferryCode = db.GetFerryCode(this.FerryID);
            int seatCounter = 1;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Button seat = new Button
                    {
                        Dock = DockStyle.Fill,
                        Margin = new Padding(5)
                    };

                    string seatCode = $"{floorNumber}{ferryCode}-{seatCounter:D3}";
                    seat.Text = seatCode;
                    seat.Tag = seatCode;

                    // Store original color
                    Color originalColor = SystemColors.Control;
                    seat.BackColor = originalColor;

                    // Mark booked seats
                    if (bookedSeats.Contains(seatCode))
                    {
                        seat.BackColor = Color.DarkRed;
                        seat.ForeColor = Color.White;
                        seat.Enabled = false;
                    }

                    // Seat click event
                    seat.Click += (s, e) =>
                    {
                        Button clickedSeat = (Button)s;
                        string code = clickedSeat.Tag.ToString();

                        // Unselect seat
                        if (clickedSeat.BackColor == Color.LightGreen)
                        {
                            clickedSeat.BackColor = originalColor;

                            var passengerControl = flpPassengerInfo.Controls
                                .OfType<PassengerInfoControl>()
                                .FirstOrDefault(p => p.SeatCode == code);

                            if (passengerControl != null)
                            {
                                flpPassengerInfo.Controls.Remove(passengerControl);
                                passengerControl.Dispose();
                            }

                            return;
                        }

                        // Select seat
                        clickedSeat.BackColor = Color.LightGreen;

                        PassengerInfoControl passengerForm = new PassengerInfoControl(code)
                        {
                            SeatCode = code
                        };
                        flpPassengerInfo.Controls.Add(passengerForm);

                        PassengerPanel.Visible = true;
                    };

                    tlpSeats.Controls.Add(seat, c, r);
                    seatCounter++;
                }
            }
        }




        private Button firstFloorButton = null; // store reference

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

                btnFloor.Click += (s, e) =>
                {
                    foreach (Button btn in flpFloors.Controls.OfType<Button>())
                    {
                        btn.BackColor = SystemColors.Control;
                        btn.ForeColor = Color.Black;
                    }

                    btnFloor.BackColor = Color.Green;
                    btnFloor.ForeColor = Color.White;

                    GenerateSeatPlan(flrNum, flrRows, flrCols);
                };

                flpFloors.Controls.Add(btnFloor);

                // save first floor btn + values
                if (firstFloorButton == null)
                    firstFloorButton = btnFloor;
            }
        }







    }

}
