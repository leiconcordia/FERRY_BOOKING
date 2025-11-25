using FERRY_BOOKING.DATABASE;
using FERRY_BOOKING.Dialogs;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace FERRY_BOOKING.UC_Owner
{
    public partial class CancelledTrips : UserControl
    {
        private DatabaseHelper db = new DatabaseHelper();
        private int OwnerID;

        public CancelledTrips()
        {
            InitializeComponent();
        }

        public void SetOwnerID(int ownerID)
        {
            this.OwnerID = ownerID;
            LoadCancelledTrips();
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
                        CancellationReason AS Reason,
                        TotalPassengersAffected AS Passengers,
                        TotalRefundAmount AS RefundAmount,
                        CancellationDate AS CancelledOn,
                        RefundCompletionStatus AS Status
                    FROM vw_CancelledTrips
                    WHERE OwnerID = @OwnerID
                    ORDER BY CancellationDate DESC";

                SqlParameter[] parameters = { new SqlParameter("@OwnerID", OwnerID) };
                DataTable dt = db.ExecuteDataTable(query, parameters);

                dgvCancelledTrips.DataSource = dt;

                // Hide CancellationID
                if (dgvCancelledTrips.Columns.Contains("CancellationID"))
                    dgvCancelledTrips.Columns["CancellationID"].Visible = false;

                // Format columns
                FormatColumns();

                // Add Action column with icon
                AddActionColumn();

                // Apply cell formatting for status colors
                dgvCancelledTrips.CellFormatting += DgvCancelledTrips_CellFormatting;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading cancelled trips: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatColumns()
        {
            dgvCancelledTrips.SuspendLayout();
            
            try
            {
                if (dgvCancelledTrips.Columns.Contains("TripDate"))
                {
                    dgvCancelledTrips.Columns["TripDate"].HeaderText = "Trip Date";
                    dgvCancelledTrips.Columns["TripDate"].DefaultCellStyle.Format = "MMM dd, yyyy";
                    dgvCancelledTrips.Columns["TripDate"].Width = 120;
                }

                if (dgvCancelledTrips.Columns.Contains("FerryName"))
                {
                    dgvCancelledTrips.Columns["FerryName"].HeaderText = "Ferry";
                    dgvCancelledTrips.Columns["FerryName"].Width = 150;
                }

                if (dgvCancelledTrips.Columns.Contains("Route"))
                {
                    dgvCancelledTrips.Columns["Route"].Width = 200;
                }

                if (dgvCancelledTrips.Columns.Contains("Reason"))
                {
                    dgvCancelledTrips.Columns["Reason"].MinimumWidth = 200;
                    dgvCancelledTrips.Columns["Reason"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                if (dgvCancelledTrips.Columns.Contains("Passengers"))
                {
                    dgvCancelledTrips.Columns["Passengers"].Width = 90;
                    dgvCancelledTrips.Columns["Passengers"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                if (dgvCancelledTrips.Columns.Contains("RefundAmount"))
                {
                    dgvCancelledTrips.Columns["RefundAmount"].HeaderText = "Refund Amount";
                    dgvCancelledTrips.Columns["RefundAmount"].DefaultCellStyle.Format = "₱#,##0.00";
                    dgvCancelledTrips.Columns["RefundAmount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                    dgvCancelledTrips.Columns["RefundAmount"].Width = 130;
                }

                if (dgvCancelledTrips.Columns.Contains("CancelledOn"))
                {
                    dgvCancelledTrips.Columns["CancelledOn"].HeaderText = "Cancelled On";
                    dgvCancelledTrips.Columns["CancelledOn"].DefaultCellStyle.Format = "MMM dd, yyyy hh:mm tt";
                    dgvCancelledTrips.Columns["CancelledOn"].Width = 160;
                }

                if (dgvCancelledTrips.Columns.Contains("Status"))
                {
                    dgvCancelledTrips.Columns["Status"].Width = 100;
                }
            }
            finally
            {
                dgvCancelledTrips.ResumeLayout();
            }
        }

        private void AddActionColumn()
        {
            if (dgvCancelledTrips.Columns.Contains("btnViewDetails"))
            {
                dgvCancelledTrips.Columns.Remove("btnViewDetails");
            }

            DataGridViewButtonColumn btnViewDetails = new DataGridViewButtonColumn();
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.HeaderText = "Action";
            btnViewDetails.Text = "🔍 View Details";
            btnViewDetails.UseColumnTextForButtonValue = true;
            btnViewDetails.Width = 120;
            btnViewDetails.FlatStyle = FlatStyle.Flat;
            dgvCancelledTrips.Columns.Add(btnViewDetails);
        }

        private void DgvCancelledTrips_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvCancelledTrips.Columns[e.ColumnIndex].Name == "Status")
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

        private void dgvCancelledTrips_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvCancelledTrips.Columns[e.ColumnIndex].Name == "btnViewDetails")
            {
                int cancellationID = Convert.ToInt32(dgvCancelledTrips.Rows[e.RowIndex].Cells["CancellationID"].Value);
                string ferryName = dgvCancelledTrips.Rows[e.RowIndex].Cells["FerryName"].Value.ToString();
                string route = dgvCancelledTrips.Rows[e.RowIndex].Cells["Route"].Value.ToString();
                DateTime tripDate = Convert.ToDateTime(dgvCancelledTrips.Rows[e.RowIndex].Cells["TripDate"].Value);
                string reason = dgvCancelledTrips.Rows[e.RowIndex].Cells["Reason"].Value.ToString();

                            // Show details dialog using the new form
                CancellationDetailsDialog dialog = new CancellationDetailsDialog(
                    cancellationID, OwnerID, ferryName, route, tripDate, reason);
                dialog.ShowDialog();

                // Refresh the main grid after dialog closes
                LoadCancelledTrips();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCancelledTrips();
            MessageBox.Show("Data refreshed successfully!", "Refresh",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
