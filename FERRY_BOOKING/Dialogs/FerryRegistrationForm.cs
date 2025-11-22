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
        public string CompanyName { get; set; }
        public int OwnerID { get; set; }
        
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

        public FerryRegistrationForm(int OwnerID, String CompanyName)
        {
            InitializeComponent();
            this.CompanyName = CompanyName;
            this.OwnerID = OwnerID;

            tbCompanyName.Text = CompanyName;
            tbCompanyName.ReadOnly = true;
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
                var nudRow = group.Controls.OfType<NumericUpDown>().First(x => x.Name.Contains("nudRow"));
                var nudCol = group.Controls.OfType<NumericUpDown>().First(x => x.Name.Contains("nudColumn"));
                var lblCap = group.Controls.OfType<Label>().First(x => x.Name.Contains("lblCapacity"));

                int floorCapacity = (int)nudRow.Value * (int)nudCol.Value;
                lblCap.Text = $"Capacity: {floorCapacity} seats";
                total += floorCapacity;
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
