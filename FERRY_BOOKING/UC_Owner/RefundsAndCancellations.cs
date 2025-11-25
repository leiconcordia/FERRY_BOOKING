using FERRY_BOOKING.DATABASE;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace FERRY_BOOKING.UC_Owner
{
    public partial class RefundsAndCancellations : UserControl
    {
        private DatabaseHelper db = new DatabaseHelper();
        private int OwnerID;

        public RefundsAndCancellations()
        {
            InitializeComponent();
        }

        public void SetOwnerID(int ownerID)
        {
            this.OwnerID = ownerID;
            LoadData();
        }

        private void LoadData()
        {
            LoadCancelledTrips();
            LoadPendingRefunds();
            LoadStatistics();
        }

        private void LoadStatistics()
        {
            try
            {
                string query = @"
                    SELECT 
                        TotalCancellations,
                        TotalPassengersAffected,
                        TotalRefundAmount,
                        PendingRefundCount,
                        PendingRefundAmount,
                        CompletedRefundCount,
                        CompletedRefundAmount
                    FROM vw_RefundSummaryByOwner
                    WHERE OwnerID = @OwnerID";

                SqlParameter[] parameters = { new SqlParameter("@OwnerID", OwnerID) };
                DataTable dt = db.ExecuteDataTable(query, parameters);

                if (dt.Rows.Count > 0)
                {
                    DataRow row = dt.Rows[0];
                    lblTotalCancellations.Text = row["TotalCancellations"].ToString();
                    lblTotalPassengers.Text = row["TotalPassengersAffected"].ToString();
                    
                    decimal totalRefund = Convert.ToDecimal(row["TotalRefundAmount"]);
                    lblTotalRefundAmount.Text = $"₱{totalRefund:N2}";
                    
                    int pendingCount = Convert.ToInt32(row["PendingRefundCount"]);
                    decimal pendingAmount = Convert.ToDecimal(row["PendingRefundAmount"]);
                    lblPendingRefunds.Text = $"{pendingCount} (₱{pendingAmount:N2})";
                    
                    int completedCount = Convert.ToInt32(row["CompletedRefundCount"]);
                    decimal completedAmount = Convert.ToDecimal(row["CompletedRefundAmount"]);
                    lblCompletedRefunds.Text = $"{completedCount} (₱{completedAmount:N2})";
                }
                else
                {
                    // No data - set defaults
                    lblTotalCancellations.Text = "0";
                    lblTotalPassengers.Text = "0";
                    lblTotalRefundAmount.Text = "₱0.00";
                    lblPendingRefunds.Text = "0 (₱0.00)";
                    lblCompletedRefunds.Text = "0 (₱0.00)";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading statistics: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadCancelledTrips()
        {
            try
            {
                string query = @"
                    SELECT 
                        CancellationID,
                        TripDate,
                        FerryName,
                        Route,
                        CancellationReason,
                        TotalPassengersAffected AS Passengers,
                        TotalRefundAmount AS RefundAmount,
                        CancellationDate,
                        RefundCompletionStatus AS Status,
                        PendingRefundCount,
                        CompletedRefundCount
                    FROM vw_CancelledTrips
                    WHERE OwnerID = @OwnerID
                    ORDER BY CancellationDate DESC";

                SqlParameter[] parameters = { new SqlParameter("@OwnerID", OwnerID) };
                DataTable dt = db.ExecuteDataTable(query, parameters);

                dgvCancelledTrips.DataSource = dt;

                // Hide IDs
                if (dgvCancelledTrips.Columns.Contains("CancellationID"))
                    dgvCancelledTrips.Columns["CancellationID"].Visible = false;

                // Format columns
                if (dgvCancelledTrips.Columns.Contains("TripDate"))
                {
                    dgvCancelledTrips.Columns["TripDate"].HeaderText = "Trip Date";
                    dgvCancelledTrips.Columns["TripDate"].DefaultCellStyle.Format = "MMM dd, yyyy";
                }

                if (dgvCancelledTrips.Columns.Contains("FerryName"))
                    dgvCancelledTrips.Columns["FerryName"].HeaderText = "Ferry";

                if (dgvCancelledTrips.Columns.Contains("CancellationReason"))
                {
                    dgvCancelledTrips.Columns["CancellationReason"].HeaderText = "Reason";
                    dgvCancelledTrips.Columns["CancellationReason"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if (dgvCancelledTrips.Columns.Contains("RefundAmount"))
                {
                    dgvCancelledTrips.Columns["RefundAmount"].HeaderText = "Refund Amount";
                    dgvCancelledTrips.Columns["RefundAmount"].DefaultCellStyle.Format = "₱#,##0.00";
                    dgvCancelledTrips.Columns["RefundAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if (dgvCancelledTrips.Columns.Contains("CancellationDate"))
                {
                    dgvCancelledTrips.Columns["CancellationDate"].HeaderText = "Cancelled On";
                    dgvCancelledTrips.Columns["CancellationDate"].DefaultCellStyle.Format = "MMM dd, yyyy hh:mm tt";
                }

                if (dgvCancelledTrips.Columns.Contains("PendingRefundCount"))
                    dgvCancelledTrips.Columns["PendingRefundCount"].Visible = false;

                if (dgvCancelledTrips.Columns.Contains("CompletedRefundCount"))
                    dgvCancelledTrips.Columns["CompletedRefundCount"].Visible = false;

                // Color code status
                dgvCancelledTrips.CellFormatting += DgvCancelledTrips_CellFormatting;

                // Auto-size columns
                dgvCancelledTrips.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvCancelledTrips.Columns[dgvCancelledTrips.Columns.Count - 3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading cancelled trips: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvCancelledTrips_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCancelledTrips.Columns[e.ColumnIndex].Name == "Status" && e.RowIndex >= 0)
            {
                string status = e.Value?.ToString();

                switch (status)
                {
                    case "Completed":
                        e.CellStyle.BackColor = Color.LightGreen;
                        e.CellStyle.ForeColor = Color.DarkGreen;
                        e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                        break;
                    case "Incomplete":
                        e.CellStyle.BackColor = Color.LightCoral;
                        e.CellStyle.ForeColor = Color.DarkRed;
                        e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                        break;
                    case "No Refunds":
                        e.CellStyle.BackColor = Color.LightGray;
                        e.CellStyle.ForeColor = Color.DarkGray;
                        break;
                }
            }
        }

        private void LoadPendingRefunds()
        {
            try
            {
                string query = @"
                    SELECT 
                        RefundID,
                        BookingRef,
                        TripDate,
                        FerryName,
                        Route,
                        PassengerNames,
                        PassengerCount,
                        RefundAmount,
                        RefundStatus AS Status,
                        CancellationReason AS Reason,
                        ProcessingPriority AS Priority,
                        DaysSinceCancellation
                    FROM vw_PendingRefunds
                    WHERE OwnerID = @OwnerID
                    ORDER BY 
                        CASE ProcessingPriority
                            WHEN 'High' THEN 1
                            WHEN 'Medium' THEN 2
                            ELSE 3
                        END,
                        CancellationDate";

                SqlParameter[] parameters = { new SqlParameter("@OwnerID", OwnerID) };
                DataTable dt = db.ExecuteDataTable(query, parameters);

                dgvPendingRefunds.DataSource = dt;

                // Hide IDs
                if (dgvPendingRefunds.Columns.Contains("RefundID"))
                    dgvPendingRefunds.Columns["RefundID"].Visible = false;

                if (dgvPendingRefunds.Columns.Contains("DaysSinceCancellation"))
                    dgvPendingRefunds.Columns["DaysSinceCancellation"].Visible = false;

                // Format columns
                if (dgvPendingRefunds.Columns.Contains("BookingRef"))
                {
                    dgvPendingRefunds.Columns["BookingRef"].HeaderText = "Booking Ref";
                    dgvPendingRefunds.Columns["BookingRef"].Width = 100;
                }

                if (dgvPendingRefunds.Columns.Contains("TripDate"))
                {
                    dgvPendingRefunds.Columns["TripDate"].HeaderText = "Trip Date";
                    dgvPendingRefunds.Columns["TripDate"].DefaultCellStyle.Format = "MMM dd, yyyy";
                }

                if (dgvPendingRefunds.Columns.Contains("FerryName"))
                    dgvPendingRefunds.Columns["FerryName"].HeaderText = "Ferry";

                if (dgvPendingRefunds.Columns.Contains("PassengerNames"))
                {
                    dgvPendingRefunds.Columns["PassengerNames"].HeaderText = "Passengers";
                    dgvPendingRefunds.Columns["PassengerNames"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if (dgvPendingRefunds.Columns.Contains("PassengerCount"))
                {
                    dgvPendingRefunds.Columns["PassengerCount"].HeaderText = "Count";
                    dgvPendingRefunds.Columns["PassengerCount"].Width = 60;
                }

                if (dgvPendingRefunds.Columns.Contains("RefundAmount"))
                {
                    dgvPendingRefunds.Columns["RefundAmount"].HeaderText = "Amount";
                    dgvPendingRefunds.Columns["RefundAmount"].DefaultCellStyle.Format = "₱#,##0.00";
                    dgvPendingRefunds.Columns["RefundAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                }

                if (dgvPendingRefunds.Columns.Contains("Reason"))
                    dgvPendingRefunds.Columns["Reason"].Visible = false;

                // Add Process button column
                if (!dgvPendingRefunds.Columns.Contains("btnProcess"))
                {
                    DataGridViewButtonColumn btnProcess = new DataGridViewButtonColumn();
                    btnProcess.Name = "btnProcess";
                    btnProcess.HeaderText = "Action";
                    btnProcess.Text = "Process";
                    btnProcess.UseColumnTextForButtonValue = true;
                    btnProcess.Width = 80;
                    dgvPendingRefunds.Columns.Add(btnProcess);
                }

                // Color code priority and status
                dgvPendingRefunds.CellFormatting += DgvPendingRefunds_CellFormatting;

                dgvPendingRefunds.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                if (dgvPendingRefunds.Columns.Contains("PassengerNames"))
                    dgvPendingRefunds.Columns["PassengerNames"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading pending refunds: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvPendingRefunds_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvPendingRefunds.Columns[e.ColumnIndex].Name == "Priority")
            {
                string priority = e.Value?.ToString();

                switch (priority)
                {
                    case "High":
                        e.CellStyle.BackColor = Color.LightCoral;
                        e.CellStyle.ForeColor = Color.DarkRed;
                        e.CellStyle.Font = new Font(e.CellStyle.Font, FontStyle.Bold);
                        break;
                    case "Medium":
                        e.CellStyle.BackColor = Color.LightGoldenrodYellow;
                        e.CellStyle.ForeColor = Color.DarkOrange;
                        break;
                    case "Normal":
                        e.CellStyle.BackColor = Color.LightGreen;
                        e.CellStyle.ForeColor = Color.DarkGreen;
                        break;
                }
            }

            if (dgvPendingRefunds.Columns[e.ColumnIndex].Name == "Status")
            {
                string status = e.Value?.ToString();

                switch (status)
                {
                    case "Pending":
                        e.CellStyle.BackColor = Color.LightCoral;
                        e.CellStyle.ForeColor = Color.White;
                        break;
                    case "Processed":
                        e.CellStyle.BackColor = Color.LightBlue;
                        e.CellStyle.ForeColor = Color.DarkBlue;
                        break;
                }
            }
        }

        private void dgvPendingRefunds_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvPendingRefunds.Columns[e.ColumnIndex].Name == "btnProcess")
            {
                long refundID = Convert.ToInt64(dgvPendingRefunds.Rows[e.RowIndex].Cells["RefundID"].Value);
                string bookingRef = dgvPendingRefunds.Rows[e.RowIndex].Cells["BookingRef"].Value.ToString();
                decimal amount = Convert.ToDecimal(dgvPendingRefunds.Rows[e.RowIndex].Cells["RefundAmount"].Value);

                ProcessRefund(refundID, bookingRef, amount);
            }
        }

        private void ProcessRefund(long refundID, string bookingRef, decimal amount)
        {
            // Create refund processing dialog
            using (Form refundDialog = new Form())
            {
                refundDialog.Text = $"Process Refund - {bookingRef}";
                refundDialog.Width = 500;
                refundDialog.Height = 350;
                refundDialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                refundDialog.StartPosition = FormStartPosition.CenterParent;
                refundDialog.MaximizeBox = false;
                refundDialog.MinimizeBox = false;

                Label lblAmount = new Label { Left = 20, Top = 20, Width = 450, Text = $"Refund Amount: ₱{amount:N2}", Font = new Font("Segoe UI", 12, FontStyle.Bold) };
                Label lblBooking = new Label { Left = 20, Top = 50, Width = 450, Text = $"Booking Reference: {bookingRef}" };

                Label lblMethod = new Label { Left = 20, Top = 90, Width = 150, Text = "Refund Method:" };
                ComboBox cboMethod = new ComboBox { Left = 180, Top = 87, Width = 290 };
                cboMethod.Items.AddRange(new string[] { "Cash", "Bank Transfer", "GCash", "PayMaya", "Check" });
                cboMethod.SelectedIndex = 0;

                Label lblNotes = new Label { Left = 20, Top = 130, Width = 150, Text = "Processing Notes:" };
                TextBox txtNotes = new TextBox { Left = 20, Top = 155, Width = 450, Height = 80, Multiline = true };

                Button btnComplete = new Button
                {
                    Text = "Complete Refund",
                    Left = 260,
                    Top = 250,
                    Width = 100,
                    Height = 35,
                    BackColor = Color.Green,
                    ForeColor = Color.White,
                    DialogResult = DialogResult.OK
                };

                Button btnCancel = new Button
                {
                    Text = "Cancel",
                    Left = 370,
                    Top = 250,
                    Width = 100,
                    Height = 35,
                    DialogResult = DialogResult.Cancel
                };

                refundDialog.Controls.AddRange(new Control[] { lblAmount, lblBooking, lblMethod, cboMethod, lblNotes, txtNotes, btnComplete, btnCancel });

                if (refundDialog.ShowDialog() == DialogResult.OK)
                {
                    string method = cboMethod.SelectedItem.ToString();
                    string notes = txtNotes.Text;

                    if (UpdateRefundStatus(refundID, method, notes))
                    {
                        MessageBox.Show($"Refund of ₱{amount:N2} has been processed successfully!\n\nMethod: {method}",
                            "Refund Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadData(); // Refresh all data
                    }
                    else
                    {
                        MessageBox.Show("Failed to process refund. Please try again.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool UpdateRefundStatus(long refundID, string method, string notes)
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
                    new SqlParameter("@ProcessedBy", OwnerID),
                    new SqlParameter("@Notes", notes ?? "")
                };

                return db.ExecuteNonQuery(query, parameters) > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating refund status: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnRefundAll_Click(object sender, EventArgs e)
        {
            if (dgvPendingRefunds.Rows.Count == 0)
            {
                MessageBox.Show("No pending refunds to process.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            decimal totalAmount = 0;
            int count = 0;

            foreach (DataGridViewRow row in dgvPendingRefunds.Rows)
            {
                if (row.Cells["Status"].Value.ToString() == "Pending")
                {
                    totalAmount += Convert.ToDecimal(row.Cells["RefundAmount"].Value);
                    count++;
                }
            }

            if (count == 0)
            {
                MessageBox.Show("No pending refunds to process.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult result = MessageBox.Show(
                $"Process ALL {count} pending refunds?\n\nTotal Amount: ₱{totalAmount:N2}\n\nThis action will mark all refunds as Completed with method 'Cash'.",
                "Confirm Bulk Refund",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int processed = 0;
                foreach (DataGridViewRow row in dgvPendingRefunds.Rows)
                {
                    if (row.Cells["Status"].Value.ToString() == "Pending")
                    {
                        long refundID = Convert.ToInt64(row.Cells["RefundID"].Value);
                        if (UpdateRefundStatus(refundID, "Cash", "Bulk refund processing"))
                        {
                            processed++;
                        }
                    }
                }

                MessageBox.Show($"Successfully processed {processed} refunds!\n\nTotal Amount: ₱{totalAmount:N2}",
                    "Bulk Refund Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);

                LoadData();
            }
        }
    }
}
