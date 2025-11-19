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
    public partial class Schedules : UserControl
    {
        public int OwnerID { get; set; }
        public Schedules(int ownerID)
        {
            InitializeComponent();
            OwnerID = ownerID;
            LoadSchedule();
        }

        private void btnAddRoute_Click(object sender, EventArgs e)
        {
            Dialogs.AddSchedule addOwnerDialog = new Dialogs.AddSchedule(OwnerID);
            addOwnerDialog.StartPosition = FormStartPosition.CenterParent;
            addOwnerDialog.ShowDialog();
        }

        private void LoadSchedule()
        {
            try
            {
                DATABASE.DatabaseHelper db = new DATABASE.DatabaseHelper();   
                // 1. Get data from the view
                string query = "SELECT * FROM vw_TripScheduleWithPrices";
                DataTable dt = db.ExecuteDataTable(query); // Replace with your DB helper method

                // 2. Bind to DataGridView
                dgvSchedule.DataSource = dt;

                // 3. Set column headers (optional, for readability)
                //dgvSchedule.Columns["ScheduleID"].HeaderText = "Schedule ID";
                dgvSchedule.Columns["Route"].HeaderText = "Route";
                dgvSchedule.Columns["DepartureTime"].HeaderText = "Departure";
                dgvSchedule.Columns["ArrivalTime"].HeaderText = "Arrival";
                dgvSchedule.Columns["DaysOfWeek"].HeaderText = "Days";
                dgvSchedule.Columns["StartDate"].HeaderText = "Start Date";
                dgvSchedule.Columns["EndDate"].HeaderText = "End Date";
                dgvSchedule.Columns["Price"].HeaderText = "Price";

                // 4. Make Price column multi-line
                dgvSchedule.Columns["Price"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                // 5. Auto-size columns for better readability
                dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                // 6. Adjust row height (increase if more floors exist)
                dgvSchedule.RowTemplate.Height = 50;

                // 7. Optional: prevent user from editing
                dgvSchedule.ReadOnly = true;

                // 8. Optional: add action buttons (View/Edit/Delete)
                if (!dgvSchedule.Columns.Contains("Actions"))
                {
                    DataGridViewButtonColumn actionsCol = new DataGridViewButtonColumn
                    {
                        Name = "Actions",
                        HeaderText = "Actions",
                        Text = "View/Edit/Delete",
                        UseColumnTextForButtonValue = true,
                        Width = 150
                    };
                    dgvSchedule.Columns.Add(actionsCol);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading schedule: " + ex.Message);
            }
        }



    }

}
