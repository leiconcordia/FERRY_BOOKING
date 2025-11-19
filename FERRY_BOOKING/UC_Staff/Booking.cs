using FERRY_BOOKING.DATABASE;
using FERRY_BOOKING.Dialogs;
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
    public partial class Booking : UserControl
    {
        public Booking()
        {
            InitializeComponent();
            PopulateComboBoxes();
            LoadAllTrips(); 


        }

        private void PopulateComboBoxes()
        {
            DATABASE.StaffHelper db = new DATABASE.StaffHelper();

            // --- Companies ---
            DataTable companies = db.GetAllFerryCompanies();
            DataRow allCompany = companies.NewRow();
            allCompany["CompanyName"] = "All";
            companies.Rows.InsertAt(allCompany, 0); // add at the top

            cbFerryCompany.DataSource = companies;
            cbFerryCompany.DisplayMember = "CompanyName";


            // Routes
            var routes = db.GetAllRoutes();
          

            cbRoute.DataSource = routes;
            cbRoute.DisplayMember = "RouteDisplay"; // shows Origin --> Destination
            cbRoute.ValueMember = "RouteID";


        }
        private void LoadAllTrips()
        {
            try
            {
                DatabaseHelper db = new DatabaseHelper();

                string query = "SELECT * FROM vw_FerrySearch";

                DataTable dt = db.ExecuteDataTable(query);
                dgvFerries.DataSource = dt;

                // Hide IDs if they exist
                if (dgvFerries.Columns.Contains("TripID"))
                    dgvFerries.Columns["TripID"].Visible = false;

                if (dgvFerries.Columns.Contains("FerryID"))
                    dgvFerries.Columns["FerryID"].Visible = false;

                // Add Book Button
                if (!dgvFerries.Columns.Contains("Action"))
                {
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    btn.HeaderText = "Action";
                    btn.Name = "Action";
                    btn.Text = "Book";
                    btn.UseColumnTextForButtonValue = true;
                    dgvFerries.Columns.Add(btn);
                }

                dgvFerries.Columns["Action"].DisplayIndex = dgvFerries.Columns.Count - 1;

                // Attach event handler
                dgvFerries.CellContentClick -= dgvFerries_CellContentClick;
                dgvFerries.CellContentClick += dgvFerries_CellContentClick;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading trips: " + ex.Message);
            }
        }

        private void LoadTripsForSearch()
        {
            try
            {
                DatabaseHelper db = new DatabaseHelper();

                string query = @"
                SELECT 
                    TripID,
                    FerryID,
                    Company,
                    Ferry,
                    Route,
                    TripDate,
                    DepartureTime,
                    ArrivalTime,
                    AvailableSeats,
                    FerryStatus,
                    FloorPrices
                FROM vw_FerrySearch
                WHERE 1 = 1
        ";

                List<SqlParameter> parameters = new List<SqlParameter>();

                // Filter by company
                if (cbFerryCompany.SelectedItem != null && cbFerryCompany.Text != "All")
                {
                    query += " AND Company = @company";
                    parameters.Add(new SqlParameter("@company", cbFerryCompany.Text));
                }

                // Filter by route
                if (cbRoute.SelectedItem != null && cbRoute.Text != "All")
                {
                    query += " AND Route = @route";
                    parameters.Add(new SqlParameter("@route", cbRoute.Text));
                }

                // Filter by travel date
                query += " AND TripDate = @date";
                parameters.Add(new SqlParameter("@date", dtpTravelDate.Value.Date));
                DataTable dt = db.ExecuteDataTable(query, parameters.ToArray());
                dgvFerries.DataSource = dt;

                // Hide IDs
                if (dgvFerries.Columns.Contains("TripID"))
                    dgvFerries.Columns["TripID"].Visible = false;

                if (dgvFerries.Columns.Contains("FerryID"))
                    dgvFerries.Columns["FerryID"].Visible = false;

                // Add Book button
                if (!dgvFerries.Columns.Contains("Action"))
                {
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    btn.HeaderText = "Action";
                    btn.Name = "Action";
                    btn.Text = "Book";
                    btn.UseColumnTextForButtonValue = true;
                    dgvFerries.Columns.Add(btn);
                }

                dgvFerries.Columns["Action"].DisplayIndex = dgvFerries.Columns.Count - 1;

                dgvFerries.CellContentClick -= dgvFerries_CellContentClick;
                dgvFerries.CellContentClick += dgvFerries_CellContentClick;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading trips: " + ex.Message);
            }
        }





        private void btnSearchFerries_Click(object sender, EventArgs e)
        {
            LoadTripsForSearch();
        }   

        private void dgvFerries_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFerries.Columns[e.ColumnIndex].Name == "Action" && e.RowIndex >= 0)
            {
                int ferryID = Convert.ToInt32(dgvFerries.Rows[e.RowIndex].Cells["FerryID"].Value);
                int tripID = Convert.ToInt32(dgvFerries.Rows[e.RowIndex].Cells["TripID"].Value); 
             

                BookingForm bookingForm = new BookingForm(ferryID, tripID);
                bookingForm.StartPosition = FormStartPosition.CenterParent;
                bookingForm.ShowDialog();
            }
        }

    }





}

