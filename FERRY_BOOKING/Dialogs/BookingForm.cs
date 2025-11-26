using FERRY_BOOKING.DATABASE;
using FERRY_BOOKING.UC_Staff;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

        // fields at top of BookingForm
        private string _company;
        private string _ferry;
        private string _route;
        private string _departure;
        private string _arrival;
        private string _origin;
        private string _destination;
        private string _tripDate;


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

                decimal seatPrice = db.GetTripFloorPrice(this.TripID, floorNumber);

                // show price to user or store it
                lblPrice.Text = seatPrice.ToString("C", new System.Globalization.CultureInfo("fil-PH"));



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
                var td = db.GetFerryTripDetails(FerryID, TripID);

                // store everything
                _company = td.Company;
                _ferry = td.FerryName;
                _route = td.Route;
                _departure = td.DepartureTime;
                _arrival = td.ArrivalTime;      // new field you just added
                _origin = td.Origin;           // new
                _destination = td.Destination;      // new
                _tripDate = td.TripDate;         // new

                // bind only what you currently show
                lblCompany.Text = _company;
                lblFerry.Text = _ferry;
                lblRoute.Text = _route;
                lblDeparture.Text = _departure;

                this.Text = $"Booking - {_ferry}";

                // Optional: Update form title or other controls
                this.Text = $"Booking - {td.FerryName}";
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

                    // store original color
                    Color originalColor = SystemColors.Control;
                    seat.BackColor = originalColor;

                    // Mark booked seats (cannot be selected)
                    if (bookedSeats.Contains(seatCode))
                    {
                        seat.BackColor = Color.DarkRed;
                        seat.ForeColor = Color.White;
                        seat.Enabled = false;
                    }
                    else
                    {
                        // ⭐ Restore previously selected seats on this floor
                        if (selectedSeatsByFloor.ContainsKey(floorNumber) &&
                            selectedSeatsByFloor[floorNumber].Contains(seatCode))
                        {
                            seat.BackColor = Color.LightGreen;
                        }
                    }

                    // --- Seat Click Event ---
                    seat.Click += (s, e) =>
                    {
                        Button clickedSeat = (Button)s;
                        string code = clickedSeat.Tag.ToString();

                        decimal seatPrice = db.GetTripFloorPrice(this.TripID, floorNumber);


                        // Ensure dictionary contains floor entry
                        if (!selectedSeatsByFloor.ContainsKey(floorNumber))
                            selectedSeatsByFloor[floorNumber] = new HashSet<string>();

                        // UNSELECT seat
                        if (clickedSeat.BackColor == Color.LightGreen)
                        {
                            clickedSeat.BackColor = originalColor;
                            selectedSeatsByFloor[floorNumber].Remove(code);

                            var passengerControl = flpPassengerInfo.Controls
                                .OfType<PassengerInfoControl>()
                                .FirstOrDefault(p => p.SeatCode == code);

                            if (passengerControl != null)
                            {
                                flpPassengerInfo.Controls.Remove(passengerControl);
                                passengerControl.Dispose();
                                UpdateTotalPrice();
                            }

                            return;
                        }

                        // SELECT seat
                        clickedSeat.BackColor = Color.LightGreen;
                        selectedSeatsByFloor[floorNumber].Add(code);

                        PassengerInfoControl passengerForm = new PassengerInfoControl(code, seatPrice)
                        {
                            SeatCode = code
                        };

                        flpPassengerInfo.Controls.Add(passengerForm);
                        passengerForm.PriceChanged += (() => UpdateTotalPrice());
                        UpdateTotalPrice();

                        PassengerPanel.Visible = true;
                    };

                    tlpSeats.Controls.Add(seat, c, r);
                    seatCounter++;
                }
            }

        }

        // BookingForm
        private void UpdateTotalPrice()
        {
            decimal total = flpPassengerInfo.Controls
                                           .OfType<PassengerInfoControl>()
                                           .Sum(p => p.Price);

            lblTotalPrice.Text = total.ToString("C", new CultureInfo("fil-PH"));
        }


        private Button firstFloorButton = null; // store reference

        // Stores selected seat codes per floor
        private Dictionary<int, HashSet<string>> selectedSeatsByFloor = new Dictionary<int, HashSet<string>>();


        private void GenerateFloorButtons(int ferryID)
        {
            flpFloors.Controls.Clear();

            DataTable dtFloors = db.GetFloors(ferryID);

            foreach (DataRow floor in dtFloors.Rows)
            {
                int floorNumber = Convert.ToInt32(floor["FloorNumber"]);
                int rows = Convert.ToInt32(floor["Rows"]);
                int cols = Convert.ToInt32(floor["Columns"]);

                // Local copies to avoid closure issues
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
                    // Reset highlight for all floor buttons
                    foreach (Button btn in flpFloors.Controls.OfType<Button>())
                    {
                        btn.BackColor = SystemColors.Control;
                        btn.ForeColor = Color.Black;
                    }

                    // Highlight selected button
                    btnFloor.BackColor = Color.Green;
                    btnFloor.ForeColor = Color.White;

                    UpdateTotalPrice();

                    // Load the seat plan for the selected floor
                    GenerateSeatPlan(flrNum, flrRows, flrCols);


                    decimal seatPrice = db.GetTripFloorPrice(this.TripID, flrNum);

                    // show price to user or store it
                    lblPrice.Text = seatPrice.ToString("C", new System.Globalization.CultureInfo("fil-PH"));

                };

                flpFloors.Controls.Add(btnFloor);

                // Save first floor button (optional)
                if (firstFloorButton == null)
                    firstFloorButton = btnFloor;
            }
        }



        private string GenerateBookingRef()
        {
            // 10-digit numeric string : yymm + 6-char random
            var rnd = new Random();
            string datePart = DateTime.Now.ToString("yyMM");
            string randomPart = rnd.Next(0, 1_000_000).ToString("D6");
            return datePart + randomPart;          // e.g. 2511039427
        }


        private void btnGenerateTicket_Click(object sender, EventArgs e)
        {
            // Validate that at least one seat is selected
            if (flpPassengerInfo.Controls.Count == 0)
            {
                MessageBox.Show("Please select at least one seat before generating tickets.",
                               "No Seats Selected",
                               MessageBoxButtons.OK,
                               MessageBoxIcon.Warning);
                return;
            }

            // Validate all passenger information
            foreach (PassengerInfoControl ctrl in flpPassengerInfo.Controls)
            {
                if (!ctrl.ValidateInput(out string errorMessage))
                {
                    MessageBox.Show(errorMessage,
                                   "Validation Error",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Warning);
                    return;
                }
            }

            string bookingRef = GenerateBookingRef();   // 10-digit code you create

            var tickets = new List<TicketData>();

            foreach (PassengerInfoControl ctrl in flpPassengerInfo.Controls)
            {
                tickets.Add(new TicketData
                {
                    FerryID = this.FerryID,
                    TripID = this.TripID,
                    BookingRef = bookingRef,
                    Company = _company,
                    Ferry = _ferry,
                    Origin = _origin,
                    Destination = _destination,
                    Departure = _departure,
                    Arrival = _arrival,
                    TripDate = _tripDate,

                    Seat = ctrl.SeatCode,
                    Name = ctrl.PassengerName,
                    Age = ctrl.PassengerAge,
                    Gender = ctrl.PassengerGender,
                    Discount = ctrl.DiscountType,
                    IDImage = ctrl.IDImageBytes,   // null if None
                    ValidIDImage = ctrl.ValidIDImage, // Required for all
                    ContactNumber = ctrl.ContactNumber, // Required for all
                    Price = ctrl.Price
                });
            }

            // pass the list to your ticket window / printer
            using (var frm = new TicketForm(tickets, bookingRef))
                frm.ShowDialog();
        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public class TicketData
    {
        public int FerryID { get; set; }
        public int TripID { get; set; }
        public string BookingRef { get; set; }   // same for whole group
        public string Company { get; set; }
        public string Ferry { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public string Route => $"{Origin} -> {Destination}";
        public string Departure { get; set; }
        public string Arrival { get; set; }
        public string TripDate { get; set; }

        // per-passenger
        public string Seat { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Discount { get; set; }
        public Image IDImage { get; set; }
        public byte[] ValidIDImage { get; set; }  // New: Required Valid ID
        public string ContactNumber { get; set; }  // New: Required Contact Number
        public decimal Price { get; set; }
    }
    
}
