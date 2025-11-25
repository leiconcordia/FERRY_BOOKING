using FERRY_BOOKING.DATABASE;
using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace FERRY_BOOKING.Dialogs
{
    public partial class FerryViewDialog : Form
    {
        private int _ferryId;
        private FerryOwnerHelper _helper = new FerryOwnerHelper();
        private DatabaseHelper _db = new DatabaseHelper();
        private Button _firstFloorButton = null;

        public FerryViewDialog(int ferryId)
        {
            InitializeComponent();
            _ferryId = ferryId;
            LoadFerryDetails();
        }

        private void LoadFerryDetails()
        {
            try
            {
                // Load basic ferry info
                var ferryRow = _helper.GetFerryById(_ferryId);
                if (ferryRow != null)
                {
                    lblFerryName.Text = ferryRow["FerryName"].ToString();
                    lblFerryCode.Text = $"Code: {ferryRow["FerryCode"]}";
                    lblStatus.Text = $"Status: {ferryRow["Status"]}";
                    lblCapacity.Text = $"Total Capacity: {ferryRow["TotalCapacity"]} seats";
                    lblTotalFloors.Text = $"Total Floors: {ferryRow["TotalFloors"]}";
                }

                // Load floor layout
                LoadFloorLayout();

                // Load documents
                LoadDocuments();

                // Generate floor buttons for seat plan
                GenerateFloorButtons();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading ferry details: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadFloorLayout()
        {
            DataTable floors = _helper.GetFerryFloors(_ferryId);
            if (floors != null && floors.Rows.Count > 0)
            {
                dgvFloors.DataSource = floors;
                dgvFloors.Columns["FloorNumber"].HeaderText = "Floor";
                dgvFloors.Columns["Rows"].HeaderText = "Rows";
                dgvFloors.Columns["Columns"].HeaderText = "Columns";
                dgvFloors.Columns["Capacity"].HeaderText = "Capacity";

                dgvFloors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvFloors.ReadOnly = true;
                dgvFloors.AllowUserToAddRows = false;
                dgvFloors.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            }
        }

        private void LoadDocuments()
        {
            var docs = _helper.GetFerryDocuments(_ferryId);
            if (docs != null)
            {
                // Certificate of Ownership
                if (docs["COFile"] != DBNull.Value)
                {
                    btnViewCO.Enabled = true;
                    btnViewCO.Tag = docs["COFile"];
                }

                // Vessel Registration
                if (docs["VRFile"] != DBNull.Value)
                {
                    btnViewVR.Enabled = true;
                    btnViewVR.Tag = docs["VRFile"];
                }

                // Safety Certificate
                if (docs["SCFile"] != DBNull.Value)
                {
                    btnViewSC.Enabled = true;
                    btnViewSC.Tag = docs["SCFile"];
                }

                // Insurance Document
                if (docs["IDFile"] != DBNull.Value)
                {
                    btnViewID.Enabled = true;
                    btnViewID.Tag = docs["IDFile"];
                }

                // Permit to Operate
                if (docs["POFile"] != DBNull.Value)
                {
                    btnViewPO.Enabled = true;
                    btnViewPO.Tag = docs["POFile"];
                }

                // Ferry Picture
                if (docs["FPFile"] != DBNull.Value)
                {
                    byte[] imageBytes = (byte[])docs["FPFile"];
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pbFerryImage.Image = Image.FromStream(ms);
                        pbFerryImage.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                }
            }
        }

        private void GenerateFloorButtons()
        {
            flpFloorButtons.Controls.Clear();

            DataTable floors = _helper.GetFerryFloors(_ferryId);
            if (floors == null || floors.Rows.Count == 0)
            {
                lblSeatPlanInfo.Text = "No floor layout available";
                return;
            }

            foreach (DataRow floor in floors.Rows)
            {
                int floorNumber = Convert.ToInt32(floor["FloorNumber"]);
                int rows = Convert.ToInt32(floor["Rows"]);
                int cols = Convert.ToInt32(floor["Columns"]);

                Button btnFloor = new Button
                {
                    Text = $"Floor {floorNumber}",
                    Width = 100,
                    Height = 40,
                    Margin = new Padding(5),
                    BackColor = SystemColors.Control,
                    ForeColor = Color.Black,
                    FlatStyle = FlatStyle.Flat,
                    Tag = new { FloorNumber = floorNumber, Rows = rows, Columns = cols }
                };

                btnFloor.Click += (s, e) =>
                {
                    // Reset all floor buttons
                    foreach (Button btn in flpFloorButtons.Controls.OfType<Button>())
                    {
                        btn.BackColor = SystemColors.Control;
                        btn.ForeColor = Color.Black;
                    }

                    // Highlight selected floor
                    btnFloor.BackColor = Color.FromArgb(11, 94, 235);
                    btnFloor.ForeColor = Color.White;

                    GenerateSeatPlan(floorNumber, rows, cols);
                };

                flpFloorButtons.Controls.Add(btnFloor);

                // Save first floor button
                if (_firstFloorButton == null)
                    _firstFloorButton = btnFloor;
            }

            // Auto-load first floor
            if (_firstFloorButton != null)
            {
                _firstFloorButton.PerformClick();
            }
        }

        private void GenerateSeatPlan(int floorNumber, int rows, int cols)
        {
            // Clear previous seats
            tlpSeatPlan.Controls.Clear();
            tlpSeatPlan.ColumnStyles.Clear();
            tlpSeatPlan.RowStyles.Clear();

            tlpSeatPlan.ColumnCount = cols;
            tlpSeatPlan.RowCount = rows;
            tlpSeatPlan.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            // Equal column spacing
            for (int c = 0; c < cols; c++)
                tlpSeatPlan.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / cols));

            // Equal row spacing
            for (int r = 0; r < rows; r++)
                tlpSeatPlan.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / rows));

            // Get ferry code for seat naming
            string ferryCode = GetFerryCode(_ferryId);
            int seatCounter = 1;
            int totalSeatsOnFloor = rows * cols;

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    Button seat = new Button
                    {
                        Dock = DockStyle.Fill,
                        Margin = new Padding(3),
                        Enabled = false, // Read-only view
                        FlatStyle = FlatStyle.Flat
                    };

                    string seatCode = $"{floorNumber}{ferryCode}-{seatCounter:D3}";
                    seat.Text = seatCode;
                    seat.Tag = seatCode;

                    // All seats are available (green) in this view
                    seat.BackColor = Color.LightGreen;
                    seat.ForeColor = Color.Black;
                    seat.Font = new Font("Segoe UI", 7F, FontStyle.Bold);

                    tlpSeatPlan.Controls.Add(seat, c, r);
                    seatCounter++;
                }
            }

            // Update floor statistics
            lblSeatPlanInfo.Text = $"Floor {floorNumber} Layout - Total Seats: {totalSeatsOnFloor} ({rows} rows × {cols} columns)";
        }

        private string GetFerryCode(int ferryId)
        {
            try
            {
                string query = "SELECT FerryCode FROM Ferry WHERE FerryID = @FerryID";
                System.Data.SqlClient.SqlParameter[] parameters = 
                { 
                    new System.Data.SqlClient.SqlParameter("@FerryID", ferryId) 
                };
                
                object result = _db.ExecuteScalar(query, parameters);
                return result?.ToString() ?? "UNK";
            }
            catch
            {
                return "UNK";
            }
        }

        private void ViewDocument(byte[] fileBytes, string title)
        {
            try
            {
                // Create temp file
                string tempPath = Path.Combine(Path.GetTempPath(), $"{title}_{DateTime.Now.Ticks}.pdf");
                File.WriteAllBytes(tempPath, fileBytes);

                // Open with default application
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = tempPath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error opening document: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnViewCO_Click(object sender, EventArgs e)
        {
            if (btnViewCO.Tag != null)
                ViewDocument((byte[])btnViewCO.Tag, "Certificate_of_Ownership");
        }

        private void btnViewVR_Click(object sender, EventArgs e)
        {
            if (btnViewVR.Tag != null)
                ViewDocument((byte[])btnViewVR.Tag, "Vessel_Registration");
        }

        private void btnViewSC_Click(object sender, EventArgs e)
        {
            if (btnViewSC.Tag != null)
                ViewDocument((byte[])btnViewSC.Tag, "Safety_Certificate");
        }

        private void btnViewID_Click(object sender, EventArgs e)
        {
            if (btnViewID.Tag != null)
                ViewDocument((byte[])btnViewID.Tag, "Insurance_Document");
        }

        private void btnViewPO_Click(object sender, EventArgs e)
        {
            if (btnViewPO.Tag != null)
                ViewDocument((byte[])btnViewPO.Tag, "Permit_to_Operate");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}