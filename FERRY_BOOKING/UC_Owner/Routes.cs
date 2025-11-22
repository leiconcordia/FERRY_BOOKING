using FERRY_BOOKING.DATABASE;
using FERRY_BOOKING.Dialogs;
using Microsoft.VisualBasic.ApplicationServices;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FERRY_BOOKING.UC_Ferry
{
    public partial class Routes : UserControl
    {
        private int OwnerID;
        public Routes(int OwnerID)
        {
            InitializeComponent();
            this.OwnerID = OwnerID;
            LoadRoutes(OwnerID);
        }

        private void btnAddRoute_Click(object sender, EventArgs e)
        {
            Dialogs.AddRoute addRouteDialog = new Dialogs.AddRoute(OwnerID);
            addRouteDialog.StartPosition = FormStartPosition.CenterParent;

            var result = addRouteDialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                LoadRoutes(OwnerID);
            }
        }


        private void LoadRoutes(int OwnerID)
        {
            try
            {
                DATABASE.DatabaseHelper db = new DATABASE.DatabaseHelper();
                // Get routes data from the view
                string query = "SELECT * FROM vw_RouteDisplay WHERE OwnerID = @OwnerID;";
                SqlParameter[] parameters = { new SqlParameter("@OwnerID", OwnerID) };

                DataTable dt = db.ExecuteDataTable(query, parameters);

                // Bind to DataGridView
                dgvRoutes.DataSource = dt;

                // Hide RouteID column (it's just an internal key)
               

                // Customize column headers
                if (dgvRoutes.Columns.Contains("Ferry"))
                    dgvRoutes.Columns["Ferry"].HeaderText = "Ferry";

                if (dgvRoutes.Columns.Contains("Route"))
                    dgvRoutes.Columns["Route"].HeaderText = "Route";

                if (dgvRoutes.Columns.Contains("Distance"))
                    dgvRoutes.Columns["Distance"].HeaderText = "Distance (km)";

                if (dgvRoutes.Columns.Contains("Duration"))
                    dgvRoutes.Columns["Duration"].HeaderText = "Duration (hrs)";


                if (dgvRoutes.Columns.Contains("RouteID"))
                    dgvRoutes.Columns["RouteID"].Visible = false;

                if (dgvRoutes.Columns.Contains("OwnerID"))
                    dgvRoutes.Columns["OwnerID"].Visible = false; // <-- Hide OwnerID column

                if (dgvRoutes.Columns.Contains("FerryID"))
                    dgvRoutes.Columns["FerryID"].Visible = false;

                if (dgvRoutes.Columns.Contains("FerryRouteID"))
                    dgvRoutes.Columns["FerryRouteID"].Visible = false; // Hide FerryID


                // ===== Use single "Actions" column like dgvMyFerries (three small buttons painted) =====
                if (!dgvRoutes.Columns.Contains("Actions"))
                {
                    var act = new DataGridViewButtonColumn
                    {
                        Name = "Actions",
                        HeaderText = "Actions",
                        Text = "⋯",
                        UseColumnTextForButtonValue = false,
                        FlatStyle = FlatStyle.Flat,
                        DefaultCellStyle = { ForeColor = Color.White, BackColor = Color.FromArgb(0, 123, 255) }
                    };
                    dgvRoutes.Columns.Add(act);
                }

                // subscribe event handlers (avoid double subscription)
                dgvRoutes.CellPainting -= dgvRoutes_CellPainting;
                dgvRoutes.CellPainting += dgvRoutes_CellPainting;
                dgvRoutes.CellClick -= dgvRoutes_CellClick;
                dgvRoutes.CellClick += dgvRoutes_CellClick;
                dgvRoutes.CellMouseEnter -= dgvRoutes_CellMouseEnter;
                dgvRoutes.CellMouseEnter += dgvRoutes_CellMouseEnter;

                if (dt.Rows.Count == 0)
                {
                    lblEmptyMessage.Visible = true;
                    lblEmptyMessage.Text = "No Routes available";
                    dgvRoutes.Visible = false;
                }
                else
                {
                    lblEmptyMessage.Visible = false;
                    dgvRoutes.Visible = true;
                    dgvRoutes.DataSource = dt;
                }

                // Optional: auto size columns
                dgvRoutes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading routes: " + ex.Message);
            }
        }

        private void dgvRoutes_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == dgvRoutes.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                e.PaintBackground(e.CellBounds, true);

                // Load icons
                Image editIcon = Properties.Resources.edit;     // Pencil icon
                Image deleteIcon = Properties.Resources.delete; // Trash icon

                int iconSize = 25;
                int padding = 8;

                // total width of 2 icons + 1 padding between them
                int totalWidth = (iconSize * 2) + padding;

                // center horizontally
                int startX = e.CellBounds.X + (e.CellBounds.Width - totalWidth) / 2;

                // center vertically
                int y = e.CellBounds.Y + (e.CellBounds.Height - iconSize) / 2;

                // draw EDIT
                e.Graphics.DrawImage(editIcon, startX, y, iconSize, iconSize);

                // draw DELETE
                e.Graphics.DrawImage(deleteIcon, startX + iconSize + padding, y, iconSize, iconSize);

                e.Handled = true;
            }
        }



        private void dgvRoutes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvRoutes.Columns["Actions"].Index && e.RowIndex >= 0)
            {
                var cell = dgvRoutes.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                int clickX = dgvRoutes.PointToClient(Cursor.Position).X - cell.X;

                int iconSize = 30;
                int padding = 8;
                int totalWidth = (iconSize * 2) + padding;

                // compute same startX used in painting
                int startX = (cell.Width - totalWidth) / 2;

                // detect icon clicked
                int relativeX = clickX - startX;

                if (relativeX >= 0 && relativeX < iconSize) // EDIT icon clicked
                {
                    int routeID = Convert.ToInt32(dgvRoutes.Rows[e.RowIndex].Cells["RouteID"].Value);
                    int ferryID = Convert.ToInt32(dgvRoutes.Rows[e.RowIndex].Cells["FerryID"].Value);

                    

                    var editDialog = new Dialogs.AddRoute(routeID, ferryID, this.OwnerID);

                    editDialog.StartPosition = FormStartPosition.CenterParent;

                    if (editDialog.ShowDialog() == DialogResult.OK)
                    {
                        LoadRoutes(OwnerID); // refresh grid
                    }
                }

                else if (relativeX >= iconSize + padding && relativeX < iconSize + padding + iconSize)
                {
                    // DELETE clicked

                    var row = ((DataRowView)dgvRoutes.Rows[e.RowIndex].DataBoundItem).Row;
                    int ferryRouteID = row.Field<int>("FerryRouteID");
                    string routeName = row.Field<string>("Route");

                    var confirm = MessageBox.Show(
                        $"Are you sure you want to delete the route:\n\n{routeName}?",
                        "Confirm Delete",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (confirm == DialogResult.Yes)
                    {
                        FerryOwnerHelper helper = new FerryOwnerHelper();

                        if (helper.DeleteRoute(ferryRouteID))
                        {
                            MessageBox.Show("Route deleted successfully.");
                            LoadRoutes(OwnerID);  // refresh grid
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete route.");
                        }
                    }
                }

            }
        }


        private void dgvRoutes_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvRoutes.Columns.Contains("Actions"))
            {
                dgvRoutes.Cursor = Cursors.Default;
                return;
            }

            if (e.ColumnIndex == dgvRoutes.Columns["Actions"].Index && e.RowIndex >= 0)
                dgvRoutes.Cursor = Cursors.Hand;
            else
                dgvRoutes.Cursor = Cursors.Default;
        }

    }
}
