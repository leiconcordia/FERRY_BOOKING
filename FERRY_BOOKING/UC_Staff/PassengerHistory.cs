using FERRY_BOOKING.DATABASE;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace FERRY_BOOKING.UC_Staff
{
    public partial class PassengerHistory : UserControl
    {
        private DatabaseHelper db = new DatabaseHelper();
        private DataTable allPassengersData;

        public PassengerHistory()
        {
            InitializeComponent();
            LoadPassengerHistory();
        }

        private void LoadPassengerHistory()
        {
            try
            {
                string query = @"
                    SELECT 
                        bp.FullName AS Name,
                        bp.Age,
                        bp.Gender,
                        bp.ContactNumber AS Contact,
                        bp.Discount AS DiscountType,
                        COUNT(DISTINCT b.BookingID) AS TotalTrips
                    FROM BookingPassenger bp
                    INNER JOIN Booking b ON bp.BookingID = b.BookingID
                    WHERE bp.ContactNumber IS NOT NULL
                    GROUP BY bp.FullName, bp.Age, bp.Gender, bp.ContactNumber, bp.Discount
                    ORDER BY COUNT(DISTINCT b.BookingID) DESC, bp.FullName";

                allPassengersData = db.ExecuteDataTable(query);

                if (allPassengersData != null && allPassengersData.Rows.Count > 0)
                {
                    DisplayPassengers(allPassengersData);
                    lblRecordCount.Text = $"Total Passengers: {allPassengersData.Rows.Count}";
                }
                else
                {
                    dgvPassengers.DataSource = null;
                    lblRecordCount.Text = "Total Passengers: 0";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading passenger history: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayPassengers(DataTable data)
        {
            dgvPassengers.DataSource = data;
            FormatDataGridView();
        }

        private void FormatDataGridView()
        {
            if (dgvPassengers.Columns.Count == 0) return;

            dgvPassengers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            if (dgvPassengers.Columns.Contains("Name"))
            {
                dgvPassengers.Columns["Name"].HeaderText = "Passenger Name";
                dgvPassengers.Columns["Name"].FillWeight = 150;
            }

            if (dgvPassengers.Columns.Contains("Age"))
            {
                dgvPassengers.Columns["Age"].FillWeight = 40;
                dgvPassengers.Columns["Age"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvPassengers.Columns.Contains("Gender"))
            {
                dgvPassengers.Columns["Gender"].FillWeight = 60;
                dgvPassengers.Columns["Gender"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvPassengers.Columns.Contains("Contact"))
            {
                dgvPassengers.Columns["Contact"].HeaderText = "Contact Number";
                dgvPassengers.Columns["Contact"].FillWeight = 100;
            }

            if (dgvPassengers.Columns.Contains("DiscountType"))
            {
                dgvPassengers.Columns["DiscountType"].HeaderText = "Discount Type";
                dgvPassengers.Columns["DiscountType"].FillWeight = 80;
                dgvPassengers.Columns["DiscountType"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            if (dgvPassengers.Columns.Contains("TotalTrips"))
            {
                dgvPassengers.Columns["TotalTrips"].HeaderText = "Total Trips";
                dgvPassengers.Columns["TotalTrips"].FillWeight = 70;
                dgvPassengers.Columns["TotalTrips"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgvPassengers.Columns["TotalTrips"].DefaultCellStyle.Font = new Font(dgvPassengers.Font, FontStyle.Bold);
                dgvPassengers.Columns["TotalTrips"].DefaultCellStyle.ForeColor = Color.FromArgb(11, 94, 235);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (allPassengersData == null) return;

            string searchText = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(searchText))
            {
                DisplayPassengers(allPassengersData);
                lblRecordCount.Text = $"Total Passengers: {allPassengersData.Rows.Count}";
                return;
            }

            try
            {
                // Build a filter that escapes single quotes properly
                string filter = $"Name LIKE '%{searchText.Replace("'", "''")}%' " +
                               $"OR Contact LIKE '%{searchText.Replace("'", "''")}%' " +
                               $"OR Gender LIKE '%{searchText.Replace("'", "''")}%' " +
                               $"OR DiscountType LIKE '%{searchText.Replace("'", "''")}%'";

                DataView dv = allPassengersData.DefaultView;
                dv.RowFilter = filter;
                
                DataTable filteredData = dv.ToTable();
                DisplayPassengers(filteredData);
                lblRecordCount.Text = $"Showing {filteredData.Rows.Count} of {allPassengersData.Rows.Count} passengers";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Search error: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            LoadPassengerHistory();
        }
    }
}
