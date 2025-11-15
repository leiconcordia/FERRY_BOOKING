using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public FerryRegistrationForm(int OwnerID, String CompanyName)
        {
            InitializeComponent();
            this.CompanyName = CompanyName;
            this.OwnerID = OwnerID;

       
            tbCompanyName.Text = CompanyName;
            tbCompanyName.ReadOnly = true;

            RegistrationFormPanel.Controls.Add(flowFloors);

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

                // ✅ Update this floor's capacity label correctly
                lblCap.Text = $"Capacity: {floorCapacity} seats";

                total += floorCapacity;
            }

            // ✅ Ensure you have a Label named lblTotalCapacity somewhere in your form
            lblTotalCapacity.Text = $"Total Capacity: {total} seats";
        }





        private void GenerateFloorInputs(int numberOfFloors)
        {
            flowFloors.Controls.Clear();

            for (int i = 1; i <= numberOfFloors; i++)
            {
                GroupBox group = new GroupBox();
                group.Text = $"Floor {i}";
                group.Width = flowFloors.Width - 90;
                group.Height = 110;
                group.Padding = new Padding(10);


                Label lblRow = new Label();
                lblRow.Text = "Rows:";
                lblRow.AutoSize = true;
                lblRow.Location = new Point(10, 30);

                NumericUpDown nudRow = new NumericUpDown();
                nudRow.Name = $"nudRow_{i}";
                nudRow.Minimum = 1;
                nudRow.Maximum = 50;
                nudRow.Width = 60;
                nudRow.Location = new Point(60, 25);

                Label lblColumn = new Label();
                lblColumn.Text = "Columns:";
                lblColumn.AutoSize = true;
                lblColumn.Location = new Point(140, 30);

                NumericUpDown nudColumn = new NumericUpDown();
                nudColumn.Name = $"nudColumn_{i}";
                nudColumn.Minimum = 1;
                nudColumn.Maximum = 50;
                nudColumn.Width = 60;
                nudColumn.Location = new Point(210, 25);


                // ✅ Floor Capacity Label
                Label lblCapacity = new Label();
                lblCapacity.Name = $"lblCapacity_{i}";
                lblCapacity.Text = "Capacity: 1 seat";
                lblCapacity.AutoSize = true;
                lblCapacity.Location = new Point(160, 60);

                // Event handlers to update capacity instantly
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





        

       
        byte[] coFileBytes;   // Certificate of Ownership
        byte[] vrFileBytes;   // Vessel Registration
        byte[] scFileBytes;   // Safety Certificate
        byte[] idFileBytes;   // ID Photo
        byte[] poFileBytes;   // Purchase Order
        byte[] fpFileBytes;   // Ferry Picture (Image only)


        private void btnCO_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "PDF Files|*.pdf|Word Files|*.docx;*.doc";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                coFileBytes = File.ReadAllBytes(openFile.FileName);
            }
        }

        private void btnVR_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "PDF Files|*.pdf|Word Files|*.docx;*.doc";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                vrFileBytes = File.ReadAllBytes(openFile.FileName);
            }
        }

        private void btnSC_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "PDF Files|*.pdf|Word Files|*.docx;*.doc";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                scFileBytes = File.ReadAllBytes(openFile.FileName);
            }
        }

        private void btnID_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "PDF Files|*.pdf|Word Files|*.docx;*.doc";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                idFileBytes = File.ReadAllBytes(openFile.FileName);
            }
        }   

        private void btnPO_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "PDF Files|*.pdf|Word Files|*.docx;*.doc";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                poFileBytes = File.ReadAllBytes(openFile.FileName);
            }
        }

        private void btnFP_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"; // Picture only

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                fpFileBytes = File.ReadAllBytes(openFile.FileName);
            }
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
                MessageBox.Show("Please upload all required documents.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                this.Close();
            }
            else
            {
                MessageBox.Show("Error occurred while saving ferry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
