using FERRY_BOOKING.DATABASE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FERRY_BOOKING.Dialogs
{
    public partial class ScheduleViewDialog : Form
    {
        private int ScheduleID;
        private int FerryID;
        private DateTime StartDate;
        private DateTime EndDate;
        private string DaysOfWeek;
        private List<string> OperatingDays;
        private int? SelectedTripID = null;
        private DateTime? SelectedTripDate = null;
        private int OwnerID;

        private DATABASE.DatabaseHelper db = new DATABASE.DatabaseHelper();
        private DATABASE.StaffHelper staffDb = new DATABASE.StaffHelper();

        public ScheduleViewDialog(int scheduleID, int ferryID, DateTime startDate, DateTime endDate, string daysOfWeek)
        {
            InitializeComponent();

            this.ScheduleID = scheduleID;
            this.FerryID = ferryID;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.DaysOfWeek = daysOfWeek;

            // Get OwnerID from session or database
            this.OwnerID = GetOwnerIDFromFerry(ferryID);

            // Parse operating days
            OperatingDays = ParseOperatingDays(daysOfWeek);

            LoadScheduleInfo();
            SetupCalendar();
        }

        private int GetOwnerIDFromFerry(int ferryID)
        {
            try
            {
                string query = "SELECT OwnerID FROM Ferry WHERE FerryID = @FerryID";
                SqlParameter[] parameters = { new SqlParameter("@FerryID", ferryID) };
                object result = db.ExecuteScalar(query, parameters);
                return result != null ? Convert.ToInt32(result) : 0;
            }
            catch
            {
                return 0;
            }
        }

        private List<string> ParseOperatingDays(string daysOfWeek)
        {
            if (string.IsNullOrWhiteSpace(daysOfWeek))
                return new List<string>();

            return daysOfWeek.Split(',')
                .Select(d => d.Trim())
                .ToList();
        }

        private void LoadScheduleInfo()
        {
            try
            {
                string query = @"
                    SELECT 
                        f.FerryName,
                        f.FerryCode,
                        r.Origin + ' -> ' + r.Destination AS Route,
                        s.DepartureTime,
                        s.ArrivalTime,
                        s.DaysOfWeek,
                        s.StartDate,
                        s.EndDate
                    FROM Schedule s
                    JOIN Ferry f ON s.FerryID = f.FerryID
                    JOIN Route r ON s.RouteID = r.RouteID
                    WHERE s.ScheduleID = @ScheduleID";

                SqlParameter[] parameters = { new SqlParameter("@ScheduleID", ScheduleID) };
                DataTable dt = db.ExecuteDataTable(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lblFerryName.Text = row["FerryName"].ToString();
                    lblRoute.Text = row["Route"].ToString();

                    TimeSpan depTime = (TimeSpan)row["DepartureTime"];
                    TimeSpan arrTime = (TimeSpan)row["ArrivalTime"];

                    lblDeparture.Text = DateTime.Today.Add(depTime).ToString("h:mm tt");
                    lblArrival.Text = DateTime.Today.Add(arrTime).ToString("h:mm tt");
                    lblDaysOfWeek.Text = row["DaysOfWeek"].ToString();
                    lblDateRange.Text = $"{Convert.ToDateTime(row["StartDate"]):MMM dd, yyyy} - {Convert.ToDateTime(row["EndDate"]):MMM dd, yyyy}";

                    this.Text = $"Schedule View - {row["FerryName"]}";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading schedule info: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupCalendar()
        {
            // Configure MonthCalendar
            monthCalendar.MinDate = StartDate;
            monthCalendar.MaxDate = EndDate;
            monthCalendar.TodayDate = DateTime.Today >= StartDate && DateTime.Today <= EndDate
                ? DateTime.Today
                : StartDate;

            monthCalendar.DateChanged += MonthCalendar_DateChanged;
            monthCalendar.DateSelected += MonthCalendar_DateSelected;

            // Disable non-operating days (we'll use bold dates for operating days)
            HighlightOperatingDays();
        }

        private void HighlightOperatingDays()
        {
            List<DateTime> operatingDates = new List<DateTime>();

            for (DateTime date = StartDate; date <= EndDate; date = date.AddDays(1))
            {
                string dayName = date.DayOfWeek.ToString();
                if (OperatingDays.Any(d => d.Equals(dayName, StringComparison.OrdinalIgnoreCase)))
                {
                    operatingDates.Add(date);
                }
            }

            if (operatingDates.Count > 0)
            {
                monthCalendar.BoldedDates = operatingDates.ToArray();
            }

            // Show instruction
            lblInstruction.Text = "Bold dates are operating days. Click to view trip details.";
        }

        private void MonthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            // Optional: provide feedback when hovering
        }

        private void MonthCalendar_DateSelected(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = monthCalendar.SelectionStart;

            // Check if selected date is an operating day
            string selectedDayName = selectedDate.DayOfWeek.ToString();
            bool isOperatingDay = OperatingDays.Any(d => d.Equals(selectedDayName, StringComparison.OrdinalIgnoreCase));

            if (!isOperatingDay)
            {
                MessageBox.Show($"{selectedDate:MMMM dd, yyyy} ({selectedDayName}) is not an operating day for this schedule.",
                    "Not Operating", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Load trip for this date
            LoadTripForDate(selectedDate);
        }

        private void LoadTripForDate(DateTime tripDate)
        {
            try
            {
                string query = @"
                    SELECT TripID, FerryID, RouteID, DepartureTime, ArrivalTime, TripDate, TripStatus
                    FROM Trip
                    WHERE FerryID = @FerryID 
                      AND CAST(TripDate AS DATE) = @TripDate";

                SqlParameter[] parameters = {
                    new SqlParameter("@FerryID", FerryID),
                    new SqlParameter("@TripDate", tripDate.Date)
                };

                DataTable dt = db.ExecuteDataTable(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    SelectedTripID = Convert.ToInt32(dt.Rows[0]["TripID"]);
                    SelectedTripDate = tripDate;
                    string tripStatus = dt.Rows[0]["TripStatus"].ToString();

                    if (tripStatus == "Cancelled")
                    {
                        lblSelectedDate.Text = $"Selected: {tripDate:MMMM dd, yyyy (dddd)} - CANCELLED";
                        lblSelectedDate.ForeColor = Color.Red;
                    }
                    else
                    {
                        lblSelectedDate.Text = $"Selected: {tripDate:MMMM dd, yyyy (dddd)}";
                        lblSelectedDate.ForeColor = Color.FromArgb(11, 94, 215);
                    }

                    // Load floor info for this trip
                    LoadFloorInfo(SelectedTripID.Value);

                    // Enable/disable buttons based on trip status and date
                    bool isPastTrip = tripDate.Date < DateTime.Today;
                    bool isCancelled = tripStatus == "Cancelled";

                    btnViewSeats.Enabled = true;
                    btnCancelTrip.Enabled = !isPastTrip && !isCancelled;
                }
                else
                {
                    MessageBox.Show($"No trip found for {tripDate:MMMM dd, yyyy}.\nThis may be a scheduled day but no trip was generated yet.",
                        "No Trip Found", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    lblSelectedDate.Text = "No trip selected";
                    lblSelectedDate.ForeColor = Color.FromArgb(11, 94, 215);
                    dgvFloorInfo.DataSource = null;
                    btnViewSeats.Enabled = false;
                    btnCancelTrip.Enabled = false;
                    SelectedTripID = null;
                    SelectedTripDate = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading trip: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFloorInfo(int tripID)
        {
            try
            {
                string query = @"
                    SELECT 
                        ff.FloorNumber,
                        ff.Capacity AS TotalSeats,
                        ISNULL(bs.BookedCount, 0) AS Booked,
                        (ff.Capacity - ISNULL(bs.BookedCount, 0)) AS Available,
                        tfp.Price,
                        CASE 
                            WHEN ff.Capacity > 0 THEN 
                                CAST(ROUND(ISNULL(bs.BookedCount, 0) * 100.0 / ff.Capacity, 1) AS DECIMAL(5,1))
                            ELSE 0
                        END AS OccupancyPercent
                    FROM FerryFloor ff
                    LEFT JOIN (
                        SELECT 
                            LEFT(SeatNumber, 1) AS FloorNum,
                            COUNT(*) AS BookedCount
                        FROM BookedSeats
                        WHERE TripID = @TripID AND FerryID = @FerryID
                        GROUP BY LEFT(SeatNumber, 1)
                    ) bs ON CAST(ff.FloorNumber AS VARCHAR) = bs.FloorNum
                    LEFT JOIN TripFloorPrice tfp ON tfp.TripID = @TripID 
                        AND tfp.FerryID = ff.FerryID 
                        AND tfp.FloorNumber = ff.FloorNumber
                    WHERE ff.FerryID = @FerryID
                    ORDER BY ff.FloorNumber";

                SqlParameter[] parameters = {
                    new SqlParameter("@TripID", tripID),
                    new SqlParameter("@FerryID", FerryID)
                };

                DataTable dt = db.ExecuteDataTable(query, parameters);

                // Format the data for display
                DataTable displayTable = new DataTable();
                displayTable.Columns.Add("Floor", typeof(string));
                displayTable.Columns.Add("Total", typeof(int));
                displayTable.Columns.Add("Booked", typeof(int));
                displayTable.Columns.Add("Available", typeof(int));
                displayTable.Columns.Add("Price", typeof(string));
                displayTable.Columns.Add("Occupancy", typeof(string));
                displayTable.Columns.Add("Status", typeof(string));

                foreach (DataRow row in dt.Rows)
                {
                    int booked = Convert.ToInt32(row["Booked"]);
                    int total = Convert.ToInt32(row["TotalSeats"]);
                    decimal occupancy = Convert.ToDecimal(row["OccupancyPercent"]);

                    string status = occupancy >= 100 ? "Full" :
                                   occupancy >= 80 ? "Almost Full" :
                                   occupancy >= 50 ? "Half Full" : "Available";

                    displayTable.Rows.Add(
                        $"Floor {row["FloorNumber"]}",
                        total,
                        booked,
                        row["Available"],
                        row["Price"] != DBNull.Value ? $"₱{Convert.ToDecimal(row["Price"]):N2}" : "N/A",
                        $"{occupancy:0.0}%",
                        status
                    );
                }

                dgvFloorInfo.DataSource = displayTable;

                // Style the grid
                dgvFloorInfo.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvFloorInfo.ReadOnly = true;
                dgvFloorInfo.AllowUserToAddRows = false;
                dgvFloorInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                // Color code the status column
                dgvFloorInfo.CellFormatting += DgvFloorInfo_CellFormatting;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading floor info: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvFloorInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvFloorInfo.Columns[e.ColumnIndex].Name == "Status" && e.RowIndex >= 0)
            {
                string status = e.Value?.ToString();

                switch (status)
                {
                    case "Full":
                        e.CellStyle.BackColor = Color.DarkRed;
                        e.CellStyle.ForeColor = Color.White;
                        break;
                    case "Almost Full":
                        e.CellStyle.BackColor = Color.Orange;
                        e.CellStyle.ForeColor = Color.White;
                        break;
                    case "Half Full":
                        e.CellStyle.BackColor = Color.Gold;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                    case "Available":
                        e.CellStyle.BackColor = Color.LightGreen;
                        e.CellStyle.ForeColor = Color.Black;
                        break;
                }
            }
        }

        private void btnCancelTrip_Click(object sender, EventArgs e)
        {
            if (!SelectedTripID.HasValue || !SelectedTripDate.HasValue)
            {
                MessageBox.Show("Please select a trip date first.", "No Trip Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Check if trip is in the past
            if (SelectedTripDate.Value.Date < DateTime.Today)
            {
                MessageBox.Show("Cannot cancel past trips.", "Invalid Operation",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get booking count and total refund amount
            var (passengerCount, totalRefund) = GetTripBookingInfo(SelectedTripID.Value);

            string confirmMessage;
            if (passengerCount > 0)
            {
                confirmMessage = $"This trip has {passengerCount} passenger(s) booked.\n\n" +
                                $"Total refund amount: ₱{totalRefund:N2}\n\n" +
                                $"All passengers will be refunded automatically.\n\n" +
                                $"Are you sure you want to cancel this trip?";
            }
            else
            {
                confirmMessage = $"Are you sure you want to cancel the trip on {SelectedTripDate.Value:MMMM dd, yyyy}?\n\n" +
                                "This action cannot be undone.";
            }

            DialogResult result = MessageBox.Show(confirmMessage, "Confirm Trip Cancellation",
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                // Show reason dialog
                string cancellationReason = PromptForCancellationReason();

                if (string.IsNullOrWhiteSpace(cancellationReason))
                {
                    MessageBox.Show("Cancellation reason is required.", "Missing Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Process cancellation
                if (CancelTrip(SelectedTripID.Value, cancellationReason, passengerCount, totalRefund))
                {
                    MessageBox.Show($"Trip cancelled successfully!\n\n" +
                                  $"Passengers affected: {passengerCount}\n" +
                                  $"Total refund: ₱{totalRefund:N2}\n\n" +
                                  $"Refund status: Pending processing",
                                  "Cancellation Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Reload trip to show updated status
                    LoadTripForDate(SelectedTripDate.Value);
                }
                else
                {
                    MessageBox.Show("Failed to cancel trip. Please try again.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private (int passengerCount, decimal totalRefund) GetTripBookingInfo(int tripID)
        {
            try
            {
                string query = @"
                    SELECT 
                        COUNT(DISTINCT b.BookingID) AS BookingCount,
                        ISNULL(SUM(b.TotalAmount), 0) AS TotalRefund
                    FROM Booking b
                    WHERE b.TripID = @TripID";

                SqlParameter[] parameters = { new SqlParameter("@TripID", tripID) };
                DataTable dt = db.ExecuteDataTable(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    int count = Convert.ToInt32(dt.Rows[0]["BookingCount"]);
                    decimal refund = Convert.ToDecimal(dt.Rows[0]["TotalRefund"]);
                    return (count, refund);
                }

                return (0, 0);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving booking info: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return (0, 0);
            }
        }

        private string PromptForCancellationReason()
        {
            using (Form prompt = new Form())
            {
                prompt.Width = 500;
                prompt.Height = 250;
                prompt.FormBorderStyle = FormBorderStyle.FixedDialog;
                prompt.Text = "Cancellation Reason";
                prompt.StartPosition = FormStartPosition.CenterParent;
                prompt.MaximizeBox = false;
                prompt.MinimizeBox = false;

                Label textLabel = new Label() { Left = 20, Top = 20, Width = 450, Text = "Please provide a reason for cancellation:" };
                TextBox textBox = new TextBox() { Left = 20, Top = 50, Width = 450, Height = 100, Multiline = true };
                Button confirmation = new Button() { Text = "OK", Left = 280, Width = 90, Top = 160, DialogResult = DialogResult.OK };
                Button cancel = new Button() { Text = "Cancel", Left = 380, Width = 90, Top = 160, DialogResult = DialogResult.Cancel };

                confirmation.Click += (sender, e) => { prompt.Close(); };
                cancel.Click += (sender, e) => { prompt.Close(); };

                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(cancel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : string.Empty;
            }
        }

        private bool CancelTrip(int tripID, string reason, int passengerCount, decimal totalRefund)
        {
            using (SqlConnection conn = db.GetConnection())
            {
                conn.Open();
                using (SqlTransaction transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // 1. Update Trip status to Cancelled
                        string updateTripQuery = @"
                            UPDATE Trip 
                            SET TripStatus = 'Cancelled' 
                            WHERE TripID = @TripID";

                        using (SqlCommand cmd = new SqlCommand(updateTripQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@TripID", tripID);
                            cmd.ExecuteNonQuery();
                        }

                        // 2. Insert TripCancellation record
                        string insertCancellationQuery = @"
                            INSERT INTO TripCancellation 
                            (TripID, FerryID, CancellationReason, CancelledBy, TotalPassengersAffected, TotalRefundAmount, NotificationStatus)
                            VALUES (@TripID, @FerryID, @Reason, @CancelledBy, @PassengerCount, @TotalRefund, 'Pending');
                            SELECT SCOPE_IDENTITY();";

                        int cancellationID;
                        using (SqlCommand cmd = new SqlCommand(insertCancellationQuery, conn, transaction))
                        {
                            cmd.Parameters.AddWithValue("@TripID", tripID);
                            cmd.Parameters.AddWithValue("@FerryID", FerryID);
                            cmd.Parameters.AddWithValue("@Reason", reason);
                            cmd.Parameters.AddWithValue("@CancelledBy", OwnerID);
                            cmd.Parameters.AddWithValue("@PassengerCount", passengerCount);
                            cmd.Parameters.AddWithValue("@TotalRefund", totalRefund);

                            cancellationID = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // 3. Create refund records for each booking
                        if (passengerCount > 0)
                        {
                            string getBookingsQuery = @"
                                SELECT BookingID, TotalAmount 
                                FROM Booking 
                                WHERE TripID = @TripID";

                            using (SqlCommand cmd = new SqlCommand(getBookingsQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@TripID", tripID);
                                
                                using (SqlDataReader reader = cmd.ExecuteReader())
                                {
                                    List<(long bookingID, decimal amount)> bookings = new List<(long, decimal)>();
                                    
                                    while (reader.Read())
                                    {
                                        bookings.Add((
                                            Convert.ToInt64(reader["BookingID"]),
                                            Convert.ToDecimal(reader["TotalAmount"])
                                        ));
                                    }
                                    reader.Close();

                                    // Insert refund records
                                    foreach (var booking in bookings)
                                    {
                                        string insertRefundQuery = @"
                                            INSERT INTO BookingRefund 
                                            (BookingID, CancellationID, RefundAmount, RefundStatus, Notes)
                                            VALUES (@BookingID, @CancellationID, @RefundAmount, 'Pending', @Notes)";

                                        using (SqlCommand refundCmd = new SqlCommand(insertRefundQuery, conn, transaction))
                                        {
                                            refundCmd.Parameters.AddWithValue("@BookingID", booking.bookingID);
                                            refundCmd.Parameters.AddWithValue("@CancellationID", cancellationID);
                                            refundCmd.Parameters.AddWithValue("@RefundAmount", booking.amount);
                                            refundCmd.Parameters.AddWithValue("@Notes", $"Trip cancelled: {reason}");
                                            refundCmd.ExecuteNonQuery();
                                        }

                                        // Create notification record
                                        string insertNotificationQuery = @"
                                            INSERT INTO PassengerNotification 
                                            (BookingID, CancellationID, NotificationType, RecipientName, Subject, MessageBody, SentStatus)
                                            VALUES (@BookingID, @CancellationID, 'Cancellation', @RecipientName, @Subject, @MessageBody, 'Pending')";

                                        using (SqlCommand notifCmd = new SqlCommand(insertNotificationQuery, conn, transaction))
                                        {
                                            notifCmd.Parameters.AddWithValue("@BookingID", booking.bookingID);
                                            notifCmd.Parameters.AddWithValue("@CancellationID", cancellationID);
                                            notifCmd.Parameters.AddWithValue("@RecipientName", "Passenger"); // Update with actual name if available
                                            notifCmd.Parameters.AddWithValue("@Subject", $"Trip Cancellation - Refund ₱{booking.amount:N2}");
                                            notifCmd.Parameters.AddWithValue("@MessageBody", 
                                                $"Your trip has been cancelled. Reason: {reason}. Refund of ₱{booking.amount:N2} is being processed.");
                                            notifCmd.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }

                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Error cancelling trip: {ex.Message}", "Database Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
        }

        private void btnViewSeats_Click(object sender, EventArgs e)
        {
            if (SelectedTripID.HasValue)
            {
                // Open TripViewDialog to view actual seats
                var tripViewDialog = new TripViewDialog(SelectedTripID.Value, FerryID);
                tripViewDialog.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a date first.", "No Trip Selected",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
