using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FERRY_BOOKING.Dialogs
{
    public partial class FerryRegistrationForm : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string CompanyName { get; set; }
        
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int OwnerID { get; set; }
        
        private bool _isEditMode = false;
        private int? _ferryId = null;
        private bool _fullEditAllowed = true;
        private bool _partialEditAllowed = false;
        
        // File upload tracking
        private string coFileName = "";
        private string vrFileName = "";
        private string scFileName = "";
        private string idFileName = "";
        private string poFileName = "";
        private string fpFileName = "";
        
        byte[] coFileBytes;   // Certificate of Ownership
        byte[] vrFileBytes;   // Vessel Registration
        byte[] scFileBytes;   // Safety Certificate
        byte[] idFileBytes;   // ID Photo
        byte[] poFileBytes;   // Purchase Order
        byte[] fpFileBytes;   // Ferry Picture (Image only)

        // Constructor for Registration (Add new ferry)
        public FerryRegistrationForm(int OwnerID, String CompanyName)
        {
            InitializeComponent();
            this.CompanyName = CompanyName;
            this.OwnerID = OwnerID;
            this._isEditMode = false;

            tbCompanyName.Text = CompanyName;
            tbCompanyName.ReadOnly = true;
        }

        // Constructor for Edit mode
        public FerryRegistrationForm(int ferryId, int ownerId, string companyName, bool editMode)
        {
            InitializeComponent();
            this._ferryId = ferryId;
            this.OwnerID = ownerId;
            this.CompanyName = companyName;
            this._isEditMode = editMode;

            tbCompanyName.Text = companyName;
            tbCompanyName.ReadOnly = true;

            if (_isEditMode)
            {
                this.Text = "Edit Ferry";
                lblTitle.Text = "Edit Ferry Details";
                lblSubtitle.Text = "Update ferry information and layout";
                btnSave.Text = "Update";
                
                LoadFerryForEdit(ferryId);
            }
            else
            {
                this.Text = "View Ferry";
                lblTitle.Text = "Ferry Details";
                lblSubtitle.Text = "View ferry information and layout";
                btnSave.Visible = false;
                
                LoadFerryForView(ferryId);
            }
        }

        private void LoadFerryForEdit(int ferryId)
        {
            DATABASE.FerryOwnerHelper helper = new DATABASE.FerryOwnerHelper();
            
            // Load basic ferry details
            var ferryRow = helper.GetFerryById(ferryId);
            if (ferryRow != null)
            {
                tbFerryName.Text = ferryRow["FerryName"].ToString();
                tbFerryCode.Text = ferryRow["FerryCode"].ToString();
            }

            // Load floor information
            DataTable floors = helper.GetFerryFloors(ferryId);
            if (floors != null && floors.Rows.Count > 0)
            {
                nudFloorNumbers.Value = floors.Rows.Count;
                GenerateFloorInputs(floors.Rows.Count);

                // Populate floor data
                for (int i = 0; i < floors.Rows.Count; i++)
                {
                    int floorNum = i + 1;
                    var row = flowFloors.Controls.Find($"nudRow_{floorNum}", true).FirstOrDefault() as NumericUpDown;
                    var col = flowFloors.Controls.Find($"nudColumn_{floorNum}", true).FirstOrDefault() as NumericUpDown;

                    if (row != null && col != null)
                    {
                        row.Value = Convert.ToInt32(floors.Rows[i]["Rows"]);
                        col.Value = Convert.ToInt32(floors.Rows[i]["Columns"]);
                    }
                }
                
                UpdateFloorAndTotalCapacity();
            }
            
            // Hide document upload section in edit mode (documents can't be changed)
            panel4.Visible = false;
        }

        private void LoadFerryForView(int ferryId)
        {
            DATABASE.FerryOwnerHelper helper = new DATABASE.FerryOwnerHelper();
            
            // Load basic ferry details
            var ferryRow = helper.GetFerryById(ferryId);
            if (ferryRow != null)
            {
                tbFerryName.Text = ferryRow["FerryName"].ToString();
                tbFerryCode.Text = ferryRow["FerryCode"].ToString();
                
                // Validate and highlight issues
                ValidateViewData(ferryRow);
            }

            // Load floor information
            DataTable floors = helper.GetFerryFloors(ferryId);
            if (floors != null && floors.Rows.Count > 0)
            {
                nudFloorNumbers.Value = floors.Rows.Count;
                GenerateFloorInputs(floors.Rows.Count);

                // Populate floor data
                for (int i = 0; i < floors.Rows.Count; i++)
                {
                    int floorNum = i + 1;
                    var row = flowFloors.Controls.Find($"nudRow_{floorNum}", true).FirstOrDefault() as NumericUpDown;
                    var col = flowFloors.Controls.Find($"nudColumn_{floorNum}", true).FirstOrDefault() as NumericUpDown;

                    if (row != null && col != null)
                    {
                        row.Value = Convert.ToInt32(floors.Rows[i]["Rows"]);
                        col.Value = Convert.ToInt32(floors.Rows[i]["Columns"]);
                    }
                }
                
                UpdateFloorAndTotalCapacity();
                ValidateFloorData(floors);
            }
        }

        private void ValidateViewData(DataRow ferryRow)
        {
            List<string> validationMessages = new List<string>();

            // Validate Ferry Name
            if (string.IsNullOrWhiteSpace(ferryRow["FerryName"].ToString()))
            {
                tbFerryName.BackColor = Color.LightYellow;
                validationMessages.Add("⚠ Ferry Name is empty");
            }

            // Validate Ferry Code
            if (string.IsNullOrWhiteSpace(ferryRow["FerryCode"].ToString()))
            {
                tbFerryCode.BackColor = Color.LightYellow;
                validationMessages.Add("⚠ Ferry Code is empty");
            }

            // Check for unusual ferry code patterns (example validation)
            string code = ferryRow["FerryCode"].ToString();
            if (!string.IsNullOrWhiteSpace(code) && code.Length < 3)
            {
                tbFerryCode.BackColor = Color.LightCoral;
                validationMessages.Add("⚠ Ferry Code seems too short (less than 3 characters)");
            }

            // Display validation summary if there are issues
            if (validationMessages.Count > 0)
            {
                ShowValidationWarning(string.Join("\n", validationMessages));
            }
        }

        private void ValidateFloorData(DataTable floors)
        {
            List<string> floorIssues = new List<string>();
            
            foreach (DataRow floor in floors.Rows)
            {
                int floorNum = Convert.ToInt32(floor["FloorNumber"]);
                int rows = Convert.ToInt32(floor["Rows"]);
                int cols = Convert.ToInt32(floor["Columns"]);
                
                // Validate minimum capacity
                if (rows < 1 || cols < 1)
                {
                    floorIssues.Add($"⚠ Floor {floorNum} has invalid dimensions ({rows}x{cols})");
                }
                
                // Warn about unusually large floors
                if (rows * cols > 200)
                {
                    floorIssues.Add($"ℹ Floor {floorNum} has large capacity ({rows * cols} seats)");
                }
                
                // Warn about unusually small floors
                if (rows * cols < 10)
                {
                    floorIssues.Add($"ℹ Floor {floorNum} has small capacity ({rows * cols} seats)");
                }
            }
            
            if (floorIssues.Count > 0)
            {
                ShowValidationWarning(string.Join("\n", floorIssues));
            }
        }

        private void ShowValidationWarning(string message)
        {
            // Option 1: Show as a non-blocking label at the top of form
            Label lblWarning = new Label
            {
                Text = message,
                AutoSize = false,
                Width = this.Width - 40,
                Height = 60,
                Location = new Point(20, 10),
                BackColor = Color.FromArgb(255, 243, 205),
                ForeColor = Color.FromArgb(133, 100, 4),
                Font = new Font("Segoe UI", 9F),
                Padding = new Padding(10),
                BorderStyle = BorderStyle.FixedSingle
            };
            this.Controls.Add(lblWarning);
            lblWarning.BringToFront();
            
            // Option 2: Show as MessageBox (less recommended for view mode)
            // MessageBox.Show(message, "Data Validation Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void nudFloorNumbers_ValueChanged(object sender, EventArgs e)
        {
            GenerateFloorInputs((int)nudFloorNumbers.Value);
        }

        private void UpdateFloorAndTotalCapacity()
        {
            int total = 0;

            foreach (GroupBox group in flowFloors.Controls.OfType<GroupBox>())
            {
                var nudRow = group.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name.Contains("nudRow"));
                var nudCol = group.Controls.OfType<NumericUpDown>().FirstOrDefault(x => x.Name.Contains("nudColumn"));
                var lblCap = group.Controls.OfType<Label>().FirstOrDefault(x => x.Name.Contains("lblCapacity"));

                if (nudRow != null && nudCol != null && lblCap != null)
                {
                    int floorCapacity = (int)nudRow.Value * (int)nudCol.Value;
                    lblCap.Text = $"Capacity: {floorCapacity} seats";
                    total += floorCapacity;
                }
            }

            lblTotalCapacity.Text = $"Total Capacity: {total} seats";
        }

        private void GenerateFloorInputs(int numberOfFloors)
        {
            flowFloors.Controls.Clear();

            for (int i = 1; i <= numberOfFloors; i++)
            {
                GroupBox group = new GroupBox();
                group.Text = $"Floor {i}";
                group.Width = 580;
                group.Height = 90;
                group.Padding = new Padding(10);
                group.BackColor = Color.WhiteSmoke;
                group.ForeColor = Color.FromArgb(11, 94, 235);
                group.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

                Label lblRow = new Label();
                lblRow.Text = "Rows:";
                lblRow.AutoSize = true;
                lblRow.Location = new Point(15, 35);
                lblRow.Font = new Font("Segoe UI", 9F);
                lblRow.ForeColor = Color.Black;

                NumericUpDown nudRow = new NumericUpDown();
                nudRow.Name = $"nudRow_{i}";
                nudRow.Minimum = 1;
                nudRow.Maximum = 50;
                nudRow.Width = 70;
                nudRow.Location = new Point(70, 32);
                nudRow.Font = new Font("Segoe UI", 9F);

                Label lblColumn = new Label();
                lblColumn.Text = "Columns:";
                lblColumn.AutoSize = true;
                lblColumn.Location = new Point(160, 35);
                lblColumn.Font = new Font("Segoe UI", 9F);
                lblColumn.ForeColor = Color.Black;

                NumericUpDown nudColumn = new NumericUpDown();
                nudColumn.Name = $"nudColumn_{i}";
                nudColumn.Minimum = 1;
                nudColumn.Maximum = 50;
                nudColumn.Width = 70;
                nudColumn.Location = new Point(235, 32);
                nudColumn.Font = new Font("Segoe UI", 9F);

                Label lblCapacity = new Label();
                lblCapacity.Name = $"lblCapacity_{i}";
                lblCapacity.Text = "Capacity: 1 seat";
                lblCapacity.AutoSize = true;
                lblCapacity.Location = new Point(330, 35);
                lblCapacity.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                lblCapacity.ForeColor = Color.FromArgb(11, 94, 235);

                nudRow.ValueChanged += (s, e) => UpdateFloorAndTotalCapacity();
                nudColumn.ValueChanged += (s, e) => UpdateFloorAndTotalCapacity();

                group.Controls.Add(lblRow);
                group.Controls.Add(nudRow);
                group.Controls.Add(lblColumn);
                group.Controls.Add(nudColumn);
                group.Controls.Add(lblCapacity);

                flowFloors.Controls.Add(group);
            }

            UpdateFloorAndTotalCapacity();
        }

        private void btnCO_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "PDF Files|*.pdf|Word Files|*.docx;*.doc";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                coFileBytes = File.ReadAllBytes(openFile.FileName);
                coFileName = Path.GetFileName(openFile.FileName);
                btnCO.Text = "✓ " + TruncateFileName(coFileName);
                btnCO.BackColor = Color.Green;
            }
        }

        private void btnVR_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "PDF Files|*.pdf|Word Files|*.docx;*.doc";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                vrFileBytes = File.ReadAllBytes(openFile.FileName);
                vrFileName = Path.GetFileName(openFile.FileName);
                btnVR.Text = "✓ " + TruncateFileName(vrFileName);
                btnVR.BackColor = Color.Green;
            }
        }

        private void btnSC_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "PDF Files|*.pdf|Word Files|*.docx;*.doc";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                scFileBytes = File.ReadAllBytes(openFile.FileName);
                scFileName = Path.GetFileName(openFile.FileName);
                btnSC.Text = "✓ " + TruncateFileName(scFileName);
                btnSC.BackColor = Color.Green;
            }
        }

        private void btnID_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "PDF Files|*.pdf|Word Files|*.docx;*.doc";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                idFileBytes = File.ReadAllBytes(openFile.FileName);
                idFileName = Path.GetFileName(openFile.FileName);
                btnID.Text = "✓ " + TruncateFileName(idFileName);
                btnID.BackColor = Color.Green;
            }
        }   

        private void btnPO_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "PDF Files|*.pdf|Word Files|*.docx;*.doc";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                poFileBytes = File.ReadAllBytes(openFile.FileName);
                poFileName = Path.GetFileName(openFile.FileName);
                btnPO.Text = "✓ " + TruncateFileName(poFileName);
                btnPO.BackColor = Color.Green;
            }
        }

        private void btnFP_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                fpFileBytes = File.ReadAllBytes(openFile.FileName);
                fpFileName = Path.GetFileName(openFile.FileName);
                btnFP.Text = "✓ " + TruncateFileName(fpFileName);
                btnFP.BackColor = Color.Green;
            }
        }

        private string TruncateFileName(string fileName)
        {
            if (fileName.Length > 15)
                return fileName.Substring(0, 12) + "...";
            return fileName;
        }

        public class FloorLayout
        {
            public int FloorNumber { get; set; }
            public int Rows { get; set; }
            public int Columns { get; set; }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // --- BASIC VALIDATION ---
            if (string.IsNullOrWhiteSpace(tbFerryName.Text) ||
                string.IsNullOrWhiteSpace(tbFerryCode.Text))
            {
                MessageBox.Show("Ferry Name and Code are required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (_isEditMode)
            {
                // UPDATE EXISTING FERRY
                DataTable floors = new DataTable();
                floors.Columns.Add("FloorNumber", typeof(int));
                floors.Columns.Add("Rows", typeof(int));
                floors.Columns.Add("Columns", typeof(int));

                for (int i = 1; i <= nudFloorNumbers.Value; i++)
                {
                    var row = flowFloors.Controls.Find($"nudRow_{i}", true).FirstOrDefault() as NumericUpDown;
                    var col = flowFloors.Controls.Find($"nudColumn_{i}", true).FirstOrDefault() as NumericUpDown;

                    if (row != null && col != null)
                    {
                        floors.Rows.Add(i, (int)row.Value, (int)col.Value);
                    }
                }

                DATABASE.FerryOwnerHelper helper = new DATABASE.FerryOwnerHelper();
                string error;
                
                bool success = helper.UpdateFerry(_ferryId.Value, tbFerryCode.Text.Trim(), tbFerryName.Text.Trim(), floors, out error);

                if (success)
                {
                    MessageBox.Show("Ferry updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(error, "Update Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // REGISTER NEW FERRY
                if (coFileBytes == null || vrFileBytes == null || scFileBytes == null || idFileBytes == null)
                {
                    MessageBox.Show("Please upload all required documents (CO, VR, SC, ID).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // --- GET FLOOR DATA (NO PRICE) ---
                List<FloorLayout> floors = new List<FloorLayout>();
                int totalCapacity = 0;

                for (int i = 1; i <= nudFloorNumbers.Value; i++)
                {
                    var row = flowFloors.Controls.Find($"nudRow_{i}", true).FirstOrDefault() as NumericUpDown;
                    var col = flowFloors.Controls.Find($"nudColumn_{i}", true).FirstOrDefault() as NumericUpDown;

                    if (row == null || col == null)
                        continue;

                    int r = (int)row.Value;
                    int c = (int)col.Value;

                    totalCapacity += r * c;

                    floors.Add(new FloorLayout
                    {
                        FloorNumber = i,
                        Rows = r,
                        Columns = c
                    });
                }

                DATABASE.FerryOwnerHelper FerryHelper = new DATABASE.FerryOwnerHelper();

                // --- INSERT INTO DATABASE ---
                bool success = FerryHelper.RegisterFerry(
                    tbFerryName.Text.Trim(),
                    tbFerryCode.Text.Trim(),
                    floors.Count,
                    totalCapacity,
                    floors,
                    coFileBytes,
                    vrFileBytes,
                    scFileBytes,
                    idFileBytes,
                    poFileBytes,
                    fpFileBytes,
                    this.OwnerID
                );

                if (success)
                {
                    MessageBox.Show("Ferry registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error occurred while saving ferry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
