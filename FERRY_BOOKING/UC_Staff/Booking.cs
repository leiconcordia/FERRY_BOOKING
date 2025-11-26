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
            
            // Set the minimum date to today (disable past dates)
            dtpTravelDate.MinDate = DateTime.Today;
            dtpTravelDate.Value = DateTime.Today;
            
            PopulateComboBoxes();
            
            // Load today's upcoming trips by default
            LoadTodaysUpcomingTrips();
        }

        private void PopulateComboBoxes()
        {
            DATABASE.StaffHelper db = new DATABASE.StaffHelper();

            // --- Companies ---
            DataTable companies = db.GetAllFerryCompanies();
            
            if (companies != null && companies.Rows.Count > 0)
            {
                DataRow allCompany = companies.NewRow();
                allCompany["CompanyName"] = "All";
                companies.Rows.InsertAt(allCompany, 0);

                cbFerryCompany.DataSource = companies;
                cbFerryCompany.DisplayMember = "CompanyName";
                cbFerryCompany.SelectedIndex = 0;
            }

            // --- Routes ---
            DataTable routes = db.GetAllRoutes();
            
            // ✅ FIX: Create a new DataTable without constraints for the ComboBox
            DataTable routesForCombo = new DataTable();
            routesForCombo.Columns.Add("RouteID", typeof(int));
            routesForCombo.Columns.Add("RouteDisplay", typeof(string));
            
            // Add "All" option first
            DataRow allRoute = routesForCombo.NewRow();
            allRoute["RouteID"] = 0;
            allRoute["RouteDisplay"] = "All";
            routesForCombo.Rows.Add(allRoute);
            
            // Copy existing routes from database
            if (routes != null)
            {
                foreach (DataRow row in routes.Rows)
                {
                    DataRow newRow = routesForCombo.NewRow();
                    newRow["RouteID"] = row["RouteID"];
                    newRow["RouteDisplay"] = row["RouteDisplay"];
                    routesForCombo.Rows.Add(newRow);
                }
            }

            cbRoute.DataSource = routesForCombo;
            cbRoute.DisplayMember = "RouteDisplay";
            cbRoute.ValueMember = "RouteID";
            cbRoute.SelectedIndex = 0;
        }

        /// <summary>
        /// Loads today's trips that haven't departed yet (upcoming trips only)
        /// </summary>
        private void LoadTodaysUpcomingTrips()
        {
            try
            {
                DatabaseHelper db = new DatabaseHelper();
                
                // Get current DateTime for comparison (time portion only)
                DateTime currentDateTime = DateTime.Now;

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
                        TotalSeats,
                        BookedSeats,
                        AvailableSeats,
                        FerryStatus,
                        FloorPrices
                    FROM vw_FerrySearch
                    WHERE CAST(TripDate AS DATE) = CAST(GETDATE() AS DATE)
                      AND FerryStatus = 'Active'
                      AND CAST(DepartureTime AS TIME) > CAST(@currentTime AS TIME)
                    ORDER BY DepartureTime ASC
                ";

                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@currentTime", SqlDbType.DateTime) { Value = currentDateTime }
                };

                DataTable dt = db.ExecuteDataTable(query, parameters);
                BindDataGridView(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading today's trips: " + ex.Message, "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Loads trips based on search filters
        /// </summary>
        private void LoadTripsForSearch()
        {
            try
            {
                DatabaseHelper db = new DatabaseHelper();
                DateTime selectedDate = dtpTravelDate.Value.Date;
                DateTime today = DateTime.Today;

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
                        TotalSeats,
                        BookedSeats,
                        AvailableSeats,
                        FerryStatus,
                        FloorPrices
                    FROM vw_FerrySearch
                    WHERE CAST(TripDate AS DATE) = @date
                      AND FerryStatus = 'Active'
                ";

                List<SqlParameter> parameters = new List<SqlParameter>
                {
                    new SqlParameter("@date", selectedDate)
                };

                // If searching for today, only show upcoming trips
                if (selectedDate.Date == today)
                {
                    DateTime currentDateTime = DateTime.Now;
                    query += " AND CAST(DepartureTime AS TIME) > CAST(@currentTime AS TIME)";
                    parameters.Add(new SqlParameter("@currentTime", SqlDbType.DateTime) { Value = currentDateTime });
                }

                // Filter by company (if not "All")
                if (cbFerryCompany.SelectedItem != null && cbFerryCompany.Text != "All")
                {
                    query += " AND Company = @company";
                    parameters.Add(new SqlParameter("@company", cbFerryCompany.Text));
                }

                // Filter by route (if not "All")
                if (cbRoute.SelectedValue != null && Convert.ToInt32(cbRoute.SelectedValue) > 0)
                {
                    query += " AND Route = @route";
                    parameters.Add(new SqlParameter("@route", cbRoute.Text));
                }

                query += " ORDER BY DepartureTime ASC";

                DataTable dt = db.ExecuteDataTable(query, parameters.ToArray());
                
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No ferries found matching your search criteria.",
                                   "No Results",
                                   MessageBoxButtons.OK,
                                   MessageBoxIcon.Information);
                }

                BindDataGridView(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading trips: " + ex.Message, "Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Binds data to DataGridView and configures columns
        /// </summary>
        private void BindDataGridView(DataTable dt)
        {
            // Clear existing columns first to avoid duplication
            dgvFerries.DataSource = null;
            dgvFerries.Columns.Clear();
            
            dgvFerries.DataSource = dt;

            // Hide IDs
            if (dgvFerries.Columns.Contains("TripID"))
                dgvFerries.Columns["TripID"].Visible = false;

            if (dgvFerries.Columns.Contains("FerryID"))
                dgvFerries.Columns["FerryID"].Visible = false;

            // Format date column if it exists
            if (dgvFerries.Columns.Contains("TripDate"))
            {
                dgvFerries.Columns["TripDate"].HeaderText = "Date";
                dgvFerries.Columns["TripDate"].DefaultCellStyle.Format = "MMM dd, yyyy";
            }

            // Format time columns - Handle DateTime from database
            if (dgvFerries.Columns.Contains("DepartureTime"))
            {
                dgvFerries.Columns["DepartureTime"].HeaderText = "Departure";
                
                // Add a custom formatter for DateTime to 12-hour format
                dgvFerries.CellFormatting -= dgvFerries_CellFormatting;
                dgvFerries.CellFormatting += dgvFerries_CellFormatting;
            }

            if (dgvFerries.Columns.Contains("ArrivalTime"))
            {
                dgvFerries.Columns["ArrivalTime"].HeaderText = "Arrival";
            }

            // Add Book button column if it doesn't exist
            if (!dgvFerries.Columns.Contains("Action"))
            {
                DataGridViewButtonColumn btnColumn = new DataGridViewButtonColumn
                {
                    HeaderText = "Action",
                    Name = "Action",
                    Text = "Book",
                    UseColumnTextForButtonValue = true,
                    FlatStyle = FlatStyle.Flat
                };
                dgvFerries.Columns.Add(btnColumn);
            }

            // Move Action column to the end
            if (dgvFerries.Columns.Contains("Action"))
            {
                dgvFerries.Columns["Action"].DisplayIndex = dgvFerries.Columns.Count - 1;
                dgvFerries.Columns["Action"].DefaultCellStyle.BackColor = Color.FromArgb(11, 94, 235);
                dgvFerries.Columns["Action"].DefaultCellStyle.ForeColor = Color.White;
            }

            // Set multiline for FloorPrices
            if (dgvFerries.Columns.Contains("FloorPrices"))
            {
                dgvFerries.Columns["FloorPrices"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dgvFerries.Columns["FloorPrices"].HeaderText = "Floor Prices";
            }

            // Attach click event handler
            dgvFerries.CellContentClick -= dgvFerries_CellContentClick;
            dgvFerries.CellContentClick += dgvFerries_CellContentClick;
        }

        // Format DateTime values to 12-hour format with AM/PM (time portion only)
        private void dgvFerries_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.Value == DBNull.Value)
                return;

            // Check if the column is DepartureTime or ArrivalTime
            string columnName = dgvFerries.Columns[e.ColumnIndex].Name;
            if (columnName == "DepartureTime" || columnName == "ArrivalTime")
            {
                try
                {
                    if (e.Value is DateTime dateTime)
                    {
                        // Extract time portion and format as 12-hour with AM/PM
                        e.Value = dateTime.ToString("hh:mm tt");
                        e.FormattingApplied = true;
                    }
                    else if (e.Value is TimeSpan timeSpan)
                    {
                        // Handle TimeSpan if it comes from database
                        DateTime dt = DateTime.Today.Add(timeSpan);
                        e.Value = dt.ToString("hh:mm tt");
                        e.FormattingApplied = true;
                    }
                }
                catch
                {
                    // If formatting fails, leave the original value
                }
            }
        }

        private void btnSearchFerries_Click(object sender, EventArgs e)
        {
            LoadTripsForSearch();
        }

        private void dgvFerries_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the click is on the "Action" button column
            if (e.ColumnIndex >= 0 && 
                e.RowIndex >= 0 &&
                dgvFerries.Columns[e.ColumnIndex].Name == "Action")
            {
                try
                {
                    DataGridViewRow row = dgvFerries.Rows[e.RowIndex];
                    
                    // Validate that we have the required data
                    if (row.Cells["FerryID"].Value == null || 
                        row.Cells["FerryID"].Value == DBNull.Value ||
                        row.Cells["TripID"].Value == null || 
                        row.Cells["TripID"].Value == DBNull.Value)
                    {
                        MessageBox.Show("Invalid ferry or trip data.", "Error",
                                       MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    int ferryID = Convert.ToInt32(row.Cells["FerryID"].Value);
                    int tripID = Convert.ToInt32(row.Cells["TripID"].Value);
                    
                    // Check if there are available seats
                    if (dgvFerries.Columns.Contains("AvailableSeats") && 
                        row.Cells["AvailableSeats"].Value != null && 
                        row.Cells["AvailableSeats"].Value != DBNull.Value)
                    {
                        int availableSeats = Convert.ToInt32(row.Cells["AvailableSeats"].Value);
                        if (availableSeats <= 0)
                        {
                            MessageBox.Show("This trip is fully booked. No seats available.",
                                           "Fully Booked",
                                           MessageBoxButtons.OK,
                                           MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Open the booking form
                    BookingForm bookingForm = new BookingForm(ferryID, tripID);
                    bookingForm.StartPosition = FormStartPosition.CenterParent;
                    
                    if (bookingForm.ShowDialog() == DialogResult.OK)
                    {
                        // Refresh the grid after booking
                        if (dtpTravelDate.Value.Date == DateTime.Today)
                            LoadTodaysUpcomingTrips();
                        else
                            LoadTripsForSearch();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error opening booking form: {ex.Message}", "Error",
                                   MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

