using FERRY_BOOKING.DATABASE;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace FERRY_BOOKING.Dialogs
{
    public partial class CancellationDetailsDialog : Form
    {
        private DatabaseHelper db = new DatabaseHelper();
        private int cancellationID;
        private int ownerID;
        private DataGridView dgvPassengers;

        public CancellationDetailsDialog(int cancellationID, int ownerID, string ferryName, string route, DateTime tripDate, string reason)
        {
            this.cancellationID = cancellationID;
            this.ownerID = ownerID;

            InitializeComponent();
            InitializeDialog(ferryName, route, tripDate, reason);
            LoadPassengerData();
        }

        private void InitializeComponent()
        {
            this.Text = "Cancelled Trip Details";
            this.Width = 1100;
            this.Height = 600;
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
        }

        private void InitializeDialog(string ferryName, string route, DateTime tripDate, string reason)
        {
            this.Text = $"Cancelled Trip - {ferryName}";

            // Header panel
            Panel headerPanel = new Panel
            {
                Location = new Point(0, 0),
                Size = new Size(1200, 100),
                BackColor = Color.FromArgb(11, 94, 215)
            };

            Label lblHeader = new Label
            {
                Text = "Cancelled Trip Details",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(20, 10),
                AutoSize = true
            };

            Label lblInfo = new Label
            {
                Text = $"Ferry: {ferryName} | Route: {route} | Date: {tripDate:MMM dd, yyyy}",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.White,
                Location = new Point(20, 45),
                AutoSize = true
            };

            Label lblReason = new Label
            {
                Text = $"Reason: {reason}",
                Font = new Font("Segoe UI", 9, FontStyle.Italic),
                ForeColor = Color.FromArgb(220, 220, 220),
                Location = new Point(20, 70),
                MaximumSize = new Size(850, 0),
                AutoSize = true
            };

            headerPanel.Controls.AddRange(new Control[] { lblHeader, lblInfo, lblReason });

            // Passengers DataGridView
            dgvPassengers = new DataGridView
            {
                Location = new Point(20, 120),
                Size = new Size(1050, 350),
                ReadOnly = true,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                BackgroundColor = Color.White,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None, // CHANGED FROM Fill
                RowHeadersVisible = false
            };

            dgvPassengers.CellFormatting += DgvPassengers_CellFormatting;

            // Buttons panel
            Panel buttonPanel = new Panel
            {
                Location = new Point(0, 490),
                Size = new Size(1100, 60),
                BackColor = Color.WhiteSmoke
            };

            //Button btnRefundAll = new Button
            //{
            //    Text = "💰 Refund All Pending",
            //    Location = new Point(700, 15),
            //    Size = new Size(150, 35),
            //    BackColor = Color.FromArgb(40, 167, 69),
            //    ForeColor = Color.White,
            //    FlatStyle = FlatStyle.Flat,
            //    Font = new Font("Segoe UI", 9, FontStyle.Bold)
            //};
        //    btnRefundAll.Click += BtnRefundAll_Click;

            Button btnClose = new Button
            {
                Text = "Close",
                Location = new Point(870, 15),
                Size = new Size(100, 35),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnClose.Click += (s, e) => this.Close();

            // Summary label (will be populated after data loads)
            Label lblSummary = new Label
            {
                Name = "lblSummary",
                Location = new Point(20, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 94, 215)
            };

            buttonPanel.Controls.AddRange(new Control[] { lblSummary, btnClose });

            // Add all controls to form
            this.Controls.AddRange(new Control[] { headerPanel, dgvPassengers, buttonPanel });
        }

        private void LoadPassengerData()
        {
            try
            {
                // CORRECTED QUERY: Divide RefundAmount by passenger count per booking
                string query = @"
                    SELECT 
                        b.BookingID,
                        b.BookingRef,
                        bp.FullName AS PassengerName,
                        bp.SeatCode,
                        bp.Age,
                        bp.Gender,
                        br.RefundID,
                        -- Get the total refund amount for the booking
                        br.RefundAmount AS TotalBookingRefund,
                        -- Divide by number of passengers in this booking
                        br.RefundAmount / NULLIF((
                            SELECT COUNT(*) 
                            FROM BookingPassenger 
                            WHERE BookingID = b.BookingID
                        ), 0) AS RefundPerPassenger,
                        br.RefundStatus,
                        br.RefundMethod,
                        br.RefundDate,
                        -- Get passenger count for this booking
                        (SELECT COUNT(*) FROM BookingPassenger WHERE BookingID = b.BookingID) AS PassengersInBooking
                    FROM BookingRefund br
                    JOIN Booking b ON br.BookingID = b.BookingID
                    JOIN BookingPassenger bp ON b.BookingID = bp.BookingID
                    WHERE br.CancellationID = @CancellationID
                    ORDER BY b.BookingRef, bp.SeatCode";

                SqlParameter[] parameters = { new SqlParameter("@CancellationID", cancellationID) };
                DataTable dt = db.ExecuteDataTable(query, parameters);

                if (dt == null)
                {
                    MessageBox.Show("Failed to retrieve data from database.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No passenger bookings found for this cancelled trip.", "No Data",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    // Set empty DataTable to prevent null reference
                    dgvPassengers.DataSource = dt;
                    return;
                }

                // Set data source
                dgvPassengers.DataSource = dt;
                
                // Wait for columns to be created
                dgvPassengers.Refresh();
                
                // Now format columns
                FormatColumns();
                UpdateSummary(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading cancellation details: {ex.Message}\n\nStack Trace: {ex.StackTrace}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatColumns()
        {
            // Add null checks
            if (dgvPassengers == null || dgvPassengers.Columns == null || dgvPassengers.Columns.Count == 0)
                return;

            try
            {
                dgvPassengers.SuspendLayout();

                // CRITICAL FIX: Change AutoSizeColumnsMode before formatting columns
                dgvPassengers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

                // Hide IDs
                if (dgvPassengers.Columns.Contains("BookingID") && dgvPassengers.Columns["BookingID"] != null)
                    dgvPassengers.Columns["BookingID"].Visible = false;
                if (dgvPassengers.Columns.Contains("RefundID") && dgvPassengers.Columns["RefundID"] != null)
                    dgvPassengers.Columns["RefundID"].Visible = false;
                if (dgvPassengers.Columns.Contains("PassengersInBooking") && dgvPassengers.Columns["PassengersInBooking"] != null)
                    dgvPassengers.Columns["PassengersInBooking"].Visible = false;
                if (dgvPassengers.Columns.Contains("TotalBookingRefund") && dgvPassengers.Columns["TotalBookingRefund"] != null)
                    dgvPassengers.Columns["TotalBookingRefund"].Visible = false;

                // Format columns
                if (dgvPassengers.Columns.Contains("BookingRef") && dgvPassengers.Columns["BookingRef"] != null)
                {
                    dgvPassengers.Columns["BookingRef"].HeaderText = "Booking Ref";
                    dgvPassengers.Columns["BookingRef"].Width = 100;
                }

                if (dgvPassengers.Columns.Contains("PassengerName") && dgvPassengers.Columns["PassengerName"] != null)
                {
                    dgvPassengers.Columns["PassengerName"].HeaderText = "Passenger Name";
                    dgvPassengers.Columns["PassengerName"].Width = 200;
                }

                if (dgvPassengers.Columns.Contains("SeatCode") && dgvPassengers.Columns["SeatCode"] != null)
                {
                    dgvPassengers.Columns["SeatCode"].HeaderText = "Seat";
                    dgvPassengers.Columns["SeatCode"].Width = 70;
                    dgvPassengers.Columns["SeatCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvPassengers.Columns.Contains("Age") && dgvPassengers.Columns["Age"] != null)
                {
                    dgvPassengers.Columns["Age"].Width = 50;
                    dgvPassengers.Columns["Age"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvPassengers.Columns.Contains("Gender") && dgvPassengers.Columns["Gender"] != null)
                {
                    dgvPassengers.Columns["Gender"].Width = 70;
                    dgvPassengers.Columns["Gender"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvPassengers.Columns.Contains("RefundPerPassenger") && dgvPassengers.Columns["RefundPerPassenger"] != null)
                {
                    dgvPassengers.Columns["RefundPerPassenger"].HeaderText = "Refund Amount";
                    dgvPassengers.Columns["RefundPerPassenger"].DefaultCellStyle.Format = "₱#,##0.00";
                    dgvPassengers.Columns["RefundPerPassenger"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvPassengers.Columns["RefundPerPassenger"].Width = 120;
                }

                if (dgvPassengers.Columns.Contains("RefundStatus") && dgvPassengers.Columns["RefundStatus"] != null)
                {
                    dgvPassengers.Columns["RefundStatus"].HeaderText = "Status";
                    dgvPassengers.Columns["RefundStatus"].Width = 100;
                }

                if (dgvPassengers.Columns.Contains("RefundMethod") && dgvPassengers.Columns["RefundMethod"] != null)
                {
                    dgvPassengers.Columns["RefundMethod"].HeaderText = "Method";
                    dgvPassengers.Columns["RefundMethod"].Width = 90;
                }

                if (dgvPassengers.Columns.Contains("RefundDate") && dgvPassengers.Columns["RefundDate"] != null)
                {
                    dgvPassengers.Columns["RefundDate"].HeaderText = "Refund Date";
                    dgvPassengers.Columns["RefundDate"].DefaultCellStyle.Format = "MMM dd, yyyy";
                    dgvPassengers.Columns["RefundDate"].Width = 120;
                }

                // Set the last column to fill remaining space
                if (dgvPassengers.Columns.Contains("RefundStatus") && dgvPassengers.Columns["RefundStatus"] != null)
                {
                    dgvPassengers.Columns["RefundStatus"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            finally
            {
                dgvPassengers.ResumeLayout();
            }
        }

        private void UpdateSummary(DataTable data)
        {
            int totalPassengers = data.Rows.Count;
            int pendingCount = 0;
            decimal totalRefund = 0;

            // Track unique bookings to avoid counting refund multiple times
            var processedBookings = new System.Collections.Generic.HashSet<int>();

            foreach (DataRow row in data.Rows)
            {
                int bookingID = Convert.ToInt32(row["BookingID"]);
                
                // Only count the booking's refund once (not per passenger)
                if (!processedBookings.Contains(bookingID))
                {
                    processedBookings.Add(bookingID);
                    
                    // Calculate total refund from the booking (multiply back to refund per passenger)
                    int passengersInBooking = Convert.ToInt32(row["PassengersInBooking"]);
                    decimal refundPerPassenger = Convert.ToDecimal(row["RefundPerPassenger"]);
                    totalRefund += refundPerPassenger * passengersInBooking;
                    
                    if (row["RefundStatus"].ToString() == "Pending")
                        pendingCount++;
                }
            }

            Label lblSummary = this.Controls.Find("lblSummary", true)[0] as Label;
            if (lblSummary != null)
            {
                lblSummary.Text = $"Total Passengers: {totalPassengers} | Total Bookings: {processedBookings.Count} | Pending Refunds: {pendingCount} | Total Amount: ₱{totalRefund:N2}";
            }
        }

        private void DgvPassengers_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvPassengers.Columns[e.ColumnIndex].Name == "RefundStatus")
            {
                string status = e.Value?.ToString();
                switch (status)
                {
                    case "Pending":
                        e.CellStyle.BackColor = Color.LightCoral;
                        e.CellStyle.ForeColor = Color.White;
                        e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                        break;
                    case "Completed":
                        e.CellStyle.BackColor = Color.LightGreen;
                        e.CellStyle.ForeColor = Color.DarkGreen;
                        e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                        break;
                    case "Processed":
                        e.CellStyle.BackColor = Color.LightBlue;
                        e.CellStyle.ForeColor = Color.DarkBlue;
                        e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                        break;
                }
            }
        }

        //private void BtnRefundAll_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // Get all pending refunds for this cancellation
        //        string queryPending = @"
        //            SELECT RefundID, RefundAmount, BookingID
        //            FROM BookingRefund
        //            WHERE CancellationID = @CancellationID
        //            AND RefundStatus = 'Pending'";

        //        SqlParameter[] parameters = { new SqlParameter("@CancellationID", cancellationID) };
        //        DataTable dt = db.ExecuteDataTable(queryPending, parameters);

        //        if (dt.Rows.Count == 0)
        //        {
        //            MessageBox.Show("No pending refunds to process.", "Information",
        //                MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            return;
        //        }

        //        decimal totalAmount = 0;
        //        foreach (DataRow row in dt.Rows)
        //        {
        //            totalAmount += Convert.ToDecimal(row["RefundAmount"]);
        //        }

        //        DialogResult result = MessageBox.Show(
        //            $"Process {dt.Rows.Count} pending refunds?\n\nTotal Amount: ₱{totalAmount:N2}\n\nAll refunds will be marked as 'Completed' with method 'Cash'.",
        //            "Confirm Bulk Refund",
        //            MessageBoxButtons.YesNo,
        //            MessageBoxIcon.Question);

        //        if (result == DialogResult.Yes)
        //        {
        //            int processed = 0;
        //            foreach (DataRow row in dt.Rows)
        //            {
        //                long refundID = Convert.ToInt64(row["RefundID"]);
        //                if (ProcessRefund(refundID, "Cash", "Bulk refund processing"))
        //                {
        //                    processed++;
        //                }
        //            }

        //            MessageBox.Show($"Successfully processed {processed} refunds!\n\nTotal Amount: ₱{totalAmount:N2}",
        //                "Refund Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

        //            // Reload data and close
        //            LoadPassengerData();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error processing bulk refund: {ex.Message}", "Error",
        //            MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private bool ProcessRefund(long refundID, string method, string notes)
        {
            try
            {
                string query = @"
                    UPDATE BookingRefund
                    SET RefundStatus = 'Completed',
                        RefundMethod = @Method,
                        RefundDate = GETDATE(),
                        ProcessedBy = @ProcessedBy,
                        ProcessedDate = GETDATE(),
                        Notes = @Notes
                    WHERE RefundID = @RefundID";

                SqlParameter[] parameters = {
                    new SqlParameter("@RefundID", refundID),
                    new SqlParameter("@Method", method),
                    new SqlParameter("@ProcessedBy", ownerID),
                    new SqlParameter("@Notes", notes ?? "")
                };

                return db.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error processing refund: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}