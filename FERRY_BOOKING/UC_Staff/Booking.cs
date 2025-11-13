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
        private void LoadFerries()
        {
            try
            {
                DatabaseHelper db = new DatabaseHelper();
                string query = "SELECT FerryID, TripID, Company, Ferry, Route, Time, Status, SeatsAndPrice FROM vw_FerrySearch WHERE 1=1";
                List<SqlParameter> parameters = new List<SqlParameter>();

                // Filter by company if not "All"
                if (cbFerryCompany.SelectedItem != null && cbFerryCompany.Text != "All")
                {
                    query += " AND Company = @company";
                    parameters.Add(new SqlParameter("@company", cbFerryCompany.Text));
                }

                // Filter by route if not "All"
                if (cbRoute.SelectedItem != null && cbRoute.Text != "All")
                {
                    query += " AND Route = @route";
                    parameters.Add(new SqlParameter("@route", cbRoute.Text));
                }

                DataTable dt = db.ExecuteDataTable(query, parameters.ToArray());
                dgvFerries.DataSource = dt;

                // Hide ID columns but keep them in the DataGridView for reference
                if (dgvFerries.Columns.Contains("FerryID"))
                {
                    dgvFerries.Columns["FerryID"].Visible = false;
                    dgvFerries.Columns["FerryID"].ReadOnly = true;
                }

                if (dgvFerries.Columns.Contains("TripID"))
                {
                    dgvFerries.Columns["TripID"].Visible = false;
                    dgvFerries.Columns["TripID"].ReadOnly = true;
                }

                // Autosize for multi-line Seats
                dgvFerries.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgvFerries.Columns["SeatsAndPrice"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                // Add Action button (if not exists)
                if (!dgvFerries.Columns.Contains("Action"))
                {
                    DataGridViewButtonColumn btn = new DataGridViewButtonColumn();
                    btn.HeaderText = "Action";
                    btn.Name = "Action";
                    btn.Text = "Book";
                    btn.UseColumnTextForButtonValue = true;
                    dgvFerries.Columns.Add(btn);
                }

                // Move Action to the rightmost column
                dgvFerries.Columns["Action"].DisplayIndex = dgvFerries.Columns.Count - 1;

                // Ensure event is attached
                dgvFerries.CellContentClick -= dgvFerries_CellContentClick;
                dgvFerries.CellContentClick += dgvFerries_CellContentClick;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading ferries: " + ex.Message);
            }
        }




        private void btnSearchFerries_Click(object sender, EventArgs e)
        {
            LoadFerries();
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

