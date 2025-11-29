using FERRY_BOOKING.DATABASE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FERRY_BOOKING.UC_Staff
{
    public partial class ManageBookings : UserControl
    {
        private DatabaseHelper db = new DatabaseHelper();
        private DataTable allBookingsData;

        public ManageBookings()
        {
            InitializeComponent();
            LoadAllBookings();
        }

        private void LoadAllBookings()
        {
            try
            {
                string query = @"
                    SELECT 
                        b.BookingID,
                        b.BookingRef AS [Booking Ref],
                        t.TripDate,
                        FORMAT(t.TripDate, 'MMM dd, yyyy') AS [Travel Date],
                        STRING_AGG(bp.FullName, ', ') AS Passengers,
                        COUNT(DISTINCT bp.PassengerID) AS Seats,
                        FORMAT(b.TotalAmount, 'C', 'en-PH') AS Amount,
                        CASE 
                            WHEN b.BookingStatus = 'Cancelled' THEN 'Cancelled'
                            WHEN t.TripStatus = 'Cancelled' THEN 'Cancelled'
                            WHEN t.TripDate < CAST(GETDATE() AS DATE) THEN 'Completed'
                            WHEN t.TripDate = CAST(GETDATE() AS DATE) THEN 'Today'
                            ELSE 'Upcoming'
                        END AS Status,
                        u.CompanyName + ' - ' + f.FerryName AS [Ferry],
                        r.Origin + ' → ' + r.Destination AS Route,
                        b.BookingDate,
                        FORMAT(b.BookingDate, 'MMM dd, yyyy hh:mm tt') AS [Booking Date]
                    FROM Booking b
                    INNER JOIN Trip t ON b.TripID = t.TripID
                    INNER JOIN Ferry f ON t.FerryID = f.FerryID
                    INNER JOIN Users u ON f.OwnerID = u.UserID
                    INNER JOIN Route r ON t.RouteID = r.RouteID
                    LEFT JOIN BookingPassenger bp ON b.BookingID = bp.BookingID
                    GROUP BY 
                        b.BookingID,
                        b.BookingRef,
                        t.TripDate,
                        b.TotalAmount,
                        b.BookingStatus,
                        t.TripStatus,
                        u.CompanyName,
                        f.FerryName,
                        r.Origin,
                        r.Destination,
                        b.BookingDate
                    ORDER BY b.BookingDate DESC";

                allBookingsData = db.ExecuteDataTable(query);
                dgvManageBookings.DataSource = allBookingsData;

                ConfigureDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading bookings: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ConfigureDataGridView()
        {
            // Hide columns
            if (dgvManageBookings.Columns.Contains("BookingID"))
                dgvManageBookings.Columns["BookingID"].Visible = false;

            if (dgvManageBookings.Columns.Contains("Ferry"))
                dgvManageBookings.Columns["Ferry"].Visible = false;

            if (dgvManageBookings.Columns.Contains("Route"))
                dgvManageBookings.Columns["Route"].Visible = false;

            if (dgvManageBookings.Columns.Contains("Booking Date"))
                dgvManageBookings.Columns["Booking Date"].Visible = false;

            if (dgvManageBookings.Columns.Contains("TripDate"))
                dgvManageBookings.Columns["TripDate"].Visible = false;

            if (dgvManageBookings.Columns.Contains("BookingDate"))
                dgvManageBookings.Columns["BookingDate"].Visible = false;

            // Auto size columns
            dgvManageBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Set specific column widths
            if (dgvManageBookings.Columns.Contains("Booking Ref"))
                dgvManageBookings.Columns["Booking Ref"].FillWeight = 80;

            if (dgvManageBookings.Columns.Contains("Travel Date"))
                dgvManageBookings.Columns["Travel Date"].FillWeight = 90;

            if (dgvManageBookings.Columns.Contains("Passengers"))
                dgvManageBookings.Columns["Passengers"].FillWeight = 150;

            if (dgvManageBookings.Columns.Contains("Seats"))
                dgvManageBookings.Columns["Seats"].FillWeight = 50;

            if (dgvManageBookings.Columns.Contains("Amount"))
                dgvManageBookings.Columns["Amount"].FillWeight = 70;

            if (dgvManageBookings.Columns.Contains("Status"))
                dgvManageBookings.Columns["Status"].FillWeight = 70;

            // Add Actions column using DataGridViewTextBoxColumn (not button) for custom painting
            if (!dgvManageBookings.Columns.Contains("Actions"))
            {
                DataGridViewTextBoxColumn actionsColumn = new DataGridViewTextBoxColumn
                {
                    Name = "Actions",
                    HeaderText = "Actions",
                    ReadOnly = true,
                    Width = 100,
                    AutoSizeMode = DataGridViewAutoSizeColumnMode.None
                };
                dgvManageBookings.Columns.Add(actionsColumn);
            }

            // Set row height for better icon visibility
            dgvManageBookings.RowTemplate.Height = 50;

            // Attach event handlers (only once)
            dgvManageBookings.CellFormatting -= DgvManageBookings_CellFormatting;
            dgvManageBookings.CellFormatting += DgvManageBookings_CellFormatting;

            dgvManageBookings.CellPainting -= DgvManageBookings_CellPainting;
            dgvManageBookings.CellPainting += DgvManageBookings_CellPainting;

            dgvManageBookings.CellClick -= dgvManageBookings_CellClick;
            dgvManageBookings.CellClick += dgvManageBookings_CellClick;
        }

        private void DgvManageBookings_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0 && 
                dgvManageBookings.Columns[e.ColumnIndex].Name == "Actions")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                // Load your icons from Resources
                Image viewIcon = Properties.Resources.research;    // Eye/Research icon for View
                Image deleteIcon = Properties.Resources.delete;    // Trash icon for Delete

                int iconSize = 35;
                int padding = 10;
                // total width of icons + gaps (2 icons + 1 gap)
                int totalWidth = (iconSize * 2) + padding;

                // calculate starting X to center the block
                int startX = e.CellBounds.X + (e.CellBounds.Width - totalWidth) / 2;

                // vertical center
                int y = e.CellBounds.Y + (e.CellBounds.Height - iconSize) / 2;

                // Draw icons spaced horizontally
                e.Graphics.DrawImage(viewIcon, startX, y, iconSize, iconSize);
                e.Graphics.DrawImage(deleteIcon, startX + iconSize + padding, y, iconSize, iconSize);

                e.Handled = true;
            }
        }

        private void DgvManageBookings_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && dgvManageBookings.Columns[e.ColumnIndex].Name == "Status" && e.Value != null)
            {
                string status = e.Value.ToString();
                DataGridViewCell cell = dgvManageBookings.Rows[e.RowIndex].Cells[e.ColumnIndex];

                switch (status)
                {
                    case "Completed":
                        cell.Style.ForeColor = Color.Gray;
                        break;
                    case "Today":
                        cell.Style.ForeColor = Color.Green;
                        cell.Style.Font = new Font(dgvManageBookings.Font, FontStyle.Bold);
                        break;
                    case "Upcoming":
                        cell.Style.ForeColor = Color.Blue;
                        break;
                    case "Cancelled":
                        cell.Style.ForeColor = Color.Red;
                        break;
                }
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterBookings();
        }

        private void DateFilterMode_CheckedChanged(object sender, EventArgs e)
        {
            FilterBookings();
        }

        private void monthCalendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            FilterBookings();
        }

        private void btnClearFilter_Click(object sender, EventArgs e)
        {
            // 1. Reset the UI controls
            // (Note: To prevent double-triggering if you have events on these controls, 
            // you might want to temporarily detach events, but for now, this order is fine).
            rbFilterAll.Checked = true;
            monthCalendar.SetDate(DateTime.Today);
            txtSearch.Clear();

            // 2. Clear the actual filter on the data view immediately
            if (allBookingsData != null)
            {
                allBookingsData.DefaultView.RowFilter = string.Empty;
            }

            // 3. Re-apply the logic (which will now see empty filters)
            FilterBookings();
        }

        private void FilterBookings()
        {
            if (allBookingsData == null) return;

            string searchText = txtSearch.Text.Trim().ToLower();
            DataView dv = allBookingsData.DefaultView;
            List<string> filters = new List<string>();

            // ... (Your existing Search Filter logic here) ...
            if (!string.IsNullOrEmpty(searchText))
            {
                filters.Add(string.Format(
                    "([Booking Ref] LIKE '%{0}%' OR Passengers LIKE '%{0}%')",
                    searchText.Replace("'", "''")));
            }

            // ... (Your existing Date Filter logic here) ...
            // IMPORTANT: Ensure rbFilterAll is ignored or handled implicitly by not adding to 'filters'
            if (rbFilterDay.Checked)
            {
                DateTime selectedDate = monthCalendar.SelectionStart.Date;
                filters.Add(string.Format(
                    "TripDate >= #{0}# AND TripDate < #{1}#",
                    selectedDate.ToString("MM/dd/yyyy"),
                    selectedDate.AddDays(1).ToString("MM/dd/yyyy")));
            }
            else if (rbFilterMonth.Checked)
            {
                DateTime selectedDate = monthCalendar.SelectionStart;
                DateTime firstDay = new DateTime(selectedDate.Year, selectedDate.Month, 1);
                DateTime lastDay = firstDay.AddMonths(1);

                filters.Add(string.Format(
                    "TripDate >= #{0}# AND TripDate < #{1}#",
                    firstDay.ToString("MM/dd/yyyy"),
                    lastDay.ToString("MM/dd/yyyy")));
            }

            // --- CRITICAL CHANGE BELOW ---

            if (filters.Count > 0)
            {
                // Apply the combined filters
                dv.RowFilter = string.Join(" AND ", filters);
            }
            else
            {
                // EXPLICITLY clear the filter if the list is empty
                dv.RowFilter = string.Empty;
            }

            // Always bind the DataView (dv), not the raw table. 
            // This keeps the behavior consistent.
            dgvManageBookings.DataSource = dv;

            ConfigureDataGridView();
        }

        private void dgvManageBookings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (dgvManageBookings.Columns[e.ColumnIndex].Name == "Actions")
            {
                int w = dgvManageBookings.Columns[e.ColumnIndex].Width / 2; // Divide by 2 for two icons
                int x = dgvManageBookings.PointToClient(Cursor.Position).X -
                        dgvManageBookings.GetColumnDisplayRectangle(e.ColumnIndex, true).X;

                long bookingID = Convert.ToInt64(dgvManageBookings.Rows[e.RowIndex].Cells["BookingID"].Value);
                string bookingRef = dgvManageBookings.Rows[e.RowIndex].Cells["Booking Ref"].Value.ToString();
                string status = dgvManageBookings.Rows[e.RowIndex].Cells["Status"].Value.ToString();

                if (x < w)      // VIEW (left half) - Research icon
                {
                    ViewBookingDetails(bookingID, bookingRef);
                }
                else            // DELETE/CANCEL (right half)
                {
                    // Check if booking is upcoming - allow cancellation
                    if (status == "Upcoming" || status == "Today")
                    {
                        CancelBooking(bookingID, bookingRef);
                    }
                    else
                    {
                        DeleteBooking(bookingID, bookingRef);
                    }
                }
            }
        }

        private void CancelBooking(long bookingID, string bookingRef)
        {
            try
            {
                // Check if booking is for a future trip
                string checkQuery = @"
                    SELECT t.TripID, t.TripDate, t.TripStatus, b.TotalAmount, b.BookingStatus
                    FROM Booking b
                    INNER JOIN Trip t ON b.TripID = t.TripID
                    WHERE b.BookingID = @BookingID";

                SqlParameter[] checkParams = { new SqlParameter("@BookingID", bookingID) };
                DataTable dt = db.ExecuteDataTable(checkQuery, checkParams);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Booking not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime tripDate = Convert.ToDateTime(dt.Rows[0]["TripDate"]);
                string tripStatus = dt.Rows[0]["TripStatus"].ToString();
                int tripID = Convert.ToInt32(dt.Rows[0]["TripID"]);
                decimal totalAmount = Convert.ToDecimal(dt.Rows[0]["TotalAmount"]);
                string bookingStatus = dt.Rows[0]["BookingStatus"]?.ToString() ?? "";

                if (bookingStatus == "Cancelled")
                {
                    MessageBox.Show("This booking has already been cancelled.", "Cannot Cancel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (tripStatus == "Cancelled")
                {
                    MessageBox.Show("This trip has already been cancelled.", "Cannot Cancel", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (tripDate < DateTime.Today)
                {
                    MessageBox.Show("Cannot cancel past bookings.", "Cancel Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Calculate refund amount (e.g., 80% refund)
                decimal refundAmount = totalAmount * 0.80m;

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to cancel booking {bookingRef}?\n\n" +
                    $"Original Amount: ₱{totalAmount:N2}\n" +
                    $"Refund Amount (80%): ₱{refundAmount:N2}\n" +
                    $"Cancellation Fee (20%): ₱{(totalAmount - refundAmount):N2}\n\n" +
                    "This will:\n" +
                    "- Mark the booking as cancelled\n" +
                    "- Release all booked seats\n" +
                    "- Process a refund for the customer\n\n" +
                    "Do you want to proceed?",
                    "Confirm Cancellation",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Release booked seats
                    string releaseSeatsQuery = @"
                        DELETE FROM BookedSeats 
                        WHERE TripID = @TripID 
                        AND SeatNumber IN (
                            SELECT SeatCode FROM BookingPassenger WHERE BookingID = @BookingID
                        )";

                    SqlParameter[] releaseParams = { 
                        new SqlParameter("@BookingID", bookingID),
                        new SqlParameter("@TripID", tripID)
                    };

                    db.ExecuteNonQuery(releaseSeatsQuery, releaseParams);

                    // Update booking status to cancelled
                    string updateBookingQuery = @"
                        UPDATE Booking 
                        SET BookingStatus = 'Cancelled'
                        WHERE BookingID = @BookingID";
                    
                    SqlParameter[] updateParams = { new SqlParameter("@BookingID", bookingID) };
                    db.ExecuteNonQuery(updateBookingQuery, updateParams);
                    
                    // Insert cancellation record
                    string insertCancellationQuery = @"
                        INSERT INTO Cancellation (BookingID, CancellationDate, RefundAmount, Reason, Status)
                        VALUES (@BookingID, GETDATE(), @RefundAmount, 'Cancelled by Staff', 'Pending')";

                    SqlParameter[] cancellationParams = { 
                        new SqlParameter("@BookingID", bookingID),
                        new SqlParameter("@RefundAmount", refundAmount)
                    };

                    try
                    {
                        db.ExecuteNonQuery(insertCancellationQuery, cancellationParams);
                    }
                    catch
                    {
                        // If Cancellation table doesn't exist, just mark it
                    }

                    MessageBox.Show(
                        $"Booking cancelled successfully!\n\n" +
                        $"Refund Amount: ₱{refundAmount:N2}\n" +
                        "The refund will be processed shortly.",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    LoadAllBookings(); // Refresh the grid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error cancelling booking: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ViewBookingDetails(long bookingID, string bookingRef)
        {
            try
            {
                using (var detailsForm = new Dialogs.BookingDetailsDialog(bookingID, bookingRef))
                {
                    detailsForm.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading booking details: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteBooking(long bookingID, string bookingRef)
        {
            try
            {
                // Check if booking is for a future trip
                string checkQuery = @"
                    SELECT t.TripDate, t.TripStatus
                    FROM Booking b
                    INNER JOIN Trip t ON b.TripID = t.TripID
                    WHERE b.BookingID = @BookingID";

                SqlParameter[] checkParams = { new SqlParameter("@BookingID", bookingID) };
                DataTable dt = db.ExecuteDataTable(checkQuery, checkParams);

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("Booking not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DateTime tripDate = Convert.ToDateTime(dt.Rows[0]["TripDate"]);
                string tripStatus = dt.Rows[0]["TripStatus"].ToString();

                if (tripDate < DateTime.Today || tripStatus == "Cancelled")
                {
                    MessageBox.Show("Cannot delete past or cancelled bookings.", "Delete Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"Are you sure you want to delete booking {bookingRef}?\n\n" +
                    "This will:\n" +
                    "- Remove all passenger records\n" +
                    "- Release all booked seats\n" +
                    "- Delete the booking permanently\n\n" +
                    "This action cannot be undone!",
                    "Confirm Deletion",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // Get TripID for deleting booked seats
                    string getTripQuery = "SELECT TripID FROM Booking WHERE BookingID = @BookingID";
                    SqlParameter[] getTripParams = { new SqlParameter("@BookingID", bookingID) };
                    int tripID = Convert.ToInt32(db.ExecuteScalar(getTripQuery, getTripParams));

                    // Delete in order: BookedSeats, BookingPassenger, Booking
                    string deleteBookedSeatsQuery = @"
                        DELETE FROM BookedSeats 
                        WHERE TripID = @TripID 
                        AND SeatNumber IN (
                            SELECT SeatCode FROM BookingPassenger WHERE BookingID = @BookingID
                        )";

                    string deletePassengersQuery = "DELETE FROM BookingPassenger WHERE BookingID = @BookingID";
                    string deleteBookingQuery = "DELETE FROM Booking WHERE BookingID = @BookingID";

                    SqlParameter[] deleteParams = { 
                        new SqlParameter("@BookingID", bookingID),
                        new SqlParameter("@TripID", tripID)
                    };

                    db.ExecuteNonQuery(deleteBookedSeatsQuery, deleteParams);
                    db.ExecuteNonQuery(deletePassengersQuery, new SqlParameter[] { new SqlParameter("@BookingID", bookingID) });
                    db.ExecuteNonQuery(deleteBookingQuery, new SqlParameter[] { new SqlParameter("@BookingID", bookingID) });

                    MessageBox.Show("Booking deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllBookings(); // Refresh the grid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting booking: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
