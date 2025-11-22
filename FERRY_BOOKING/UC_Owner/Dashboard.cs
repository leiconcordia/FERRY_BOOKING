using FERRY_BOOKING.DATABASE;
using FERRY_BOOKING.Dialogs;
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

namespace FERRY_BOOKING.UC_Ferry
{
    public partial class Dashboard : UserControl
    {

        public int OwnerID { get; set; }    
        public Dashboard(int OwnerID)
        {
            InitializeComponent();

            this.OwnerID = OwnerID;

            LoadDashboardSummary();
            LoadTodaysTripDashboard(OwnerID);
        }

        private void LoadDashboardSummary()
        {
            FerryOwnerHelper helper = new FerryOwnerHelper();
            int ownerID = this.OwnerID;

            lblBookings.Text = helper.GetTotalBookingsToday(ownerID).ToString();

            decimal revenue = helper.GetTotalRevenueToday(ownerID);
            var phCulture = CultureInfo.GetCultureInfo("en-PH");
            lblRevenue.Text = revenue.ToString("C", phCulture);

            lblMostBooked.Text = helper.GetMostBookedFerry(ownerID);

            var result = helper.GetAvailableSeatsAndTrips(ownerID);
            lblAvailableSeats.Text = result.availableSeats.ToString();
            lblTripsToday.Text = result.tripsToday.ToString();
        }

        private void LoadTodaysTripDashboard(int ownerID)
        {
            try
            {
                DatabaseHelper db = new DatabaseHelper();

                // Use the view; if you want dynamic OwnerID, you can create a table-valued function
                string query = @"
            SELECT * 
            FROM vw_TodaysTripDashboard
            WHERE OwnerID = @OwnerID";

                SqlParameter[] parameters = { new SqlParameter("@OwnerID", ownerID) };
                DataTable dt = db.ExecuteDataTable(query, parameters);

                dgvTodaysTrip.Rows.Clear();
                dgvTodaysTrip.Columns.Clear();

                // Add necessary columns
                dgvTodaysTrip.Columns.Add("TripID", "Trip ID");
                dgvTodaysTrip.Columns.Add("FerryName", "Ferry Name");
                dgvTodaysTrip.Columns.Add("Route", "Route");
                dgvTodaysTrip.Columns.Add("Schedule", "Schedule");
                dgvTodaysTrip.Columns.Add("FloorBreakdown", "Floor Breakdown");

                dgvTodaysTrip.Columns["TripID"].Visible = false;

                // Add Action column with eye icon
                DataGridViewImageColumn actionCol = new DataGridViewImageColumn();
                actionCol.Name = "Action";
                actionCol.HeaderText = "Action";
                actionCol.Image = Properties.Resources.eye;
                actionCol.ImageLayout = DataGridViewImageCellLayout.Zoom;
                dgvTodaysTrip.Columns.Add(actionCol);
               



                // Populate rows
                foreach (DataRow row in dt.Rows)
                {
                    DateTime departure = Convert.ToDateTime(row["DepartureTime"]);
                    DateTime arrival = Convert.ToDateTime(row["ArrivalTime"]);
                    string schedule = $"{departure:hh:mm tt} -> {arrival:hh:mm tt}";

                    dgvTodaysTrip.Rows.Add(
                        row["TripID"],
                        row["FerryName"],
                        row["Route"],
                        schedule,
                        row["FloorBreakdown"],
                        Properties.Resources.eye
                    );
                }
             

                dgvTodaysTrip.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading today's trips: " + ex.Message);
            }
        }

        private void dgvTodaysTrip_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvTodaysTrip.Columns["Action"].Index)
            {
                int tripID = Convert.ToInt32(dgvTodaysTrip.Rows[e.RowIndex].Cells["TripID"].Value);
                int ferryID = Convert.ToInt32(dgvTodaysTrip.Rows[e.RowIndex].Cells["FerryName"].Value); // Adjust if needed
                int ownerID = Convert.ToInt32(dgvTodaysTrip.Rows[e.RowIndex].Cells["OwnerID"].Value);   // Optional

                //// Open BookingSummaryDetail form
                //BookingSummaryDetail detailForm = new BookingSummaryDetail(tripID, ferryID, ownerID);
                //detailForm.ShowDialog();
            }
        }





    }
}
