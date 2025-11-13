using FERRY_BOOKING.Dialogs;
using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FERRY_BOOKING.UC_Ferry
{
    public partial class Routes : UserControl
    {
        private int OwnerID;
        public Routes(int OwnerID)
        {
            InitializeComponent();
            this.OwnerID = OwnerID;
            LoadRoutes();
        }

        private void btnAddRoute_Click(object sender, EventArgs e)
        {
            Dialogs.AddRoute addRouteDialog = new Dialogs.AddRoute(OwnerID);
            addRouteDialog.StartPosition = FormStartPosition.CenterParent;
            addRouteDialog.ShowDialog();
        }

        private void LoadRoutes()
        {
            try
            {
                DATABASE.DatabaseHelper db = new DATABASE.DatabaseHelper();
                // Get routes data from the view
                string query = "SELECT * FROM vw_RouteDisplay";
                DataTable dt = db.ExecuteDataTable(query);

                // Bind to DataGridView
                dgvRoutes.DataSource = dt;

                // Hide RouteID column (it's just an internal key)
                if (dgvRoutes.Columns.Contains("RouteID"))
                    dgvRoutes.Columns["RouteID"].Visible = false;

                // Customize column headers
                if (dgvRoutes.Columns.Contains("Ferry"))
                    dgvRoutes.Columns["Ferry"].HeaderText = "Ferry";

                if (dgvRoutes.Columns.Contains("Route"))
                    dgvRoutes.Columns["Route"].HeaderText = "Route";

                if (dgvRoutes.Columns.Contains("Distance"))
                    dgvRoutes.Columns["Distance"].HeaderText = "Distance (km)";

                if (dgvRoutes.Columns.Contains("Duration"))
                    dgvRoutes.Columns["Duration"].HeaderText = "Duration (hrs)";

                // Add action buttons if not already added
                if (!dgvRoutes.Columns.Contains("Edit"))
                {
                    DataGridViewButtonColumn editBtn = new DataGridViewButtonColumn
                    {
                        HeaderText = "",
                        Text = "Edit",
                        Name = "Edit",
                        UseColumnTextForButtonValue = true
                    };
                    dgvRoutes.Columns.Add(editBtn);
                }

                if (!dgvRoutes.Columns.Contains("Delete"))
                {
                    DataGridViewButtonColumn deleteBtn = new DataGridViewButtonColumn
                    {
                        HeaderText = "", // Empty header as requested
                        Text = "Delete",
                        Name = "Delete",
                        UseColumnTextForButtonValue = true
                    };
                    dgvRoutes.Columns.Add(deleteBtn);
                }

                // Optional: auto size columns
                dgvRoutes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading routes: " + ex.Message);
            }
        }



    }
}
