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

namespace FERRY_BOOKING.UC_Ferry
{
    public partial class Summary : UserControl
    {
        public int OwnerID { get; set; }    
        public Summary(int ownerID)
        {

            this.OwnerID = ownerID;
            InitializeComponent();
            LoadFilters();
            LoadBookingSummary(this.OwnerID);
        }

        private void LoadFilters()
        {
            DATABASE.DatabaseHelper db = new DATABASE.DatabaseHelper();

            // Load ferries
            DataTable dtFerry = db.ExecuteDataTable(
                "SELECT DISTINCT FerryName FROM Ferry WHERE OwnerID = @OwnerID",
                new SqlParameter[] { new SqlParameter("@OwnerID", this.OwnerID) }
            );
            cmbFerry.Items.Clear();
            cmbFerry.Items.Add("All"); // first item = All
            foreach (DataRow row in dtFerry.Rows)
                cmbFerry.Items.Add(row["FerryName"].ToString());
            cmbFerry.SelectedIndex = 0;

            // Load routes filtered by ferries of this owner
            string sqlRoute = @"
        SELECT DISTINCT r.Origin + ' -> ' + r.Destination AS Route
        FROM Route r
        JOIN Trip t ON r.RouteID = t.RouteID
        JOIN Ferry f ON t.FerryID = f.FerryID
        WHERE f.OwnerID = @OwnerID
    ";
            DataTable dtRoute = db.ExecuteDataTable(sqlRoute,
                new SqlParameter[] { new SqlParameter("@OwnerID", this.OwnerID) });

            cmbRoute.Items.Clear();
            cmbRoute.Items.Add("All"); // first item = All
            foreach (DataRow row in dtRoute.Rows)
                cmbRoute.Items.Add(row["Route"].ToString());
            cmbRoute.SelectedIndex = 0;
        }



        private void FilterChanged(object sender, EventArgs e)
        {
            // Reload the booking summary with the current filters
            LoadBookingSummary(this.OwnerID);
        }
    

        private void LoadBookingSummary(int ownerID)
        {
            try
            {
                DATABASE.DatabaseHelper db = new DATABASE.DatabaseHelper();

                // Base query
                string query = @"
            SELECT * 
            FROM vw_BookingSummary 
            WHERE OwnerID = @OwnerID
        ";

                // Prepare parameters
                List<SqlParameter> parameters = new List<SqlParameter>
        {
            new SqlParameter("@OwnerID", ownerID)
        };

                // Filter by ferry if selected
                if (cmbFerry.SelectedIndex > 0) // assume first item is "All"
                {
                    query += " AND FerryName = @FerryName";
                    parameters.Add(new SqlParameter("@FerryName", cmbFerry.Text));
                }

                // Filter by route if selected
                if (cmbRoute.SelectedIndex > 0)
                {
                    query += " AND Routes = @Route";
                    parameters.Add(new SqlParameter("@Route", cmbRoute.Text));
                }

                // Filter by date
                DateTime selectedDate = dtpDate.Value.Date;
                query += " AND CAST(TripDate AS DATE) = @TripDate";
                parameters.Add(new SqlParameter("@TripDate", selectedDate));

                DataTable dt = db.ExecuteDataTable(query, parameters.ToArray());

                dgvBookingSummary.DataSource = dt;

                // Optional: set readable headers
                if (dgvBookingSummary.Columns.Contains("FerryName"))
                    dgvBookingSummary.Columns["FerryName"].HeaderText = "Ferry Name";
                if (dgvBookingSummary.Columns.Contains("Routes"))
                    dgvBookingSummary.Columns["Routes"].HeaderText = "Route";
                if (dgvBookingSummary.Columns.Contains("Schedules"))
                    dgvBookingSummary.Columns["Schedules"].HeaderText = "Schedule";
                if (dgvBookingSummary.Columns.Contains("Booked"))
                    dgvBookingSummary.Columns["Booked"].HeaderText = "Booked";
                if (dgvBookingSummary.Columns.Contains("Available"))
                    dgvBookingSummary.Columns["Available"].HeaderText = "Available";
                if (dgvBookingSummary.Columns.Contains("Revenue"))
                    dgvBookingSummary.Columns["Revenue"].HeaderText = "Revenue";

                if (dgvBookingSummary.Columns.Contains("OwnerID"))
                    dgvBookingSummary.Columns["OwnerID"].Visible = false;


                // Add Actions column only once
                if (!dgvBookingSummary.Columns.Contains("Actions"))
                {
                    DataGridViewImageColumn imgCol = new DataGridViewImageColumn
                    {
                        Name = "Actions",
                        HeaderText = "Actions",
                        ImageLayout = DataGridViewImageCellLayout.Normal,
                        Width = 30 // adjust width
                    };
                    dgvBookingSummary.Columns.Add(imgCol);
                }

                // Optional: adjust row height
                dgvBookingSummary.RowTemplate.Height = 30;



                dgvBookingSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvBookingSummary.ReadOnly = true;

                // Handle empty data
                lblEmptyMessage.Visible = dt.Rows.Count == 0;
                dgvBookingSummary.Visible = dt.Rows.Count > 0;
                if (lblEmptyMessage.Visible)
                    lblEmptyMessage.Text = "No booking history available";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading booking summary: " + ex.Message);
            }
        }

        private void dgvBookingSummary_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvBookingSummary.Columns[e.ColumnIndex].Name == "Actions")
            {
                var row = dgvBookingSummary.Rows[e.RowIndex];
                string info = $"Ferry: {row.Cells["FerryName"].Value}\n" +
                              $"Route: {row.Cells["Routes"].Value}\n" +
                              $"Schedule: {row.Cells["Schedule"].Value}\n" +
                              $"Booked: {row.Cells["Booked"].Value}\n" +
                              $"Available: {row.Cells["Available"].Value}\n" +
                              $"Revenue: {row.Cells["Revenue"].Value:C}";

                MessageBox.Show(info, "Booking Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void dgvBookingSummary_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvBookingSummary.Columns[e.ColumnIndex].Name == "Actions")
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.ContentForeground);

                int iconSize = 25; // size you want
                int x = e.CellBounds.Left + (e.CellBounds.Width - iconSize) / 2;
                int y = e.CellBounds.Top + (e.CellBounds.Height - iconSize) / 2;

                e.Graphics.DrawImage(Properties.Resources.eye, new Rectangle(x, y, iconSize, iconSize));
                e.Handled = true;
            }
        }

    }
}
