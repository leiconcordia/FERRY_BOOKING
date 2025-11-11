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

            RegistrationFormPanel.Controls.Add(flowFloors);
            RegistrationFormPanel.Controls.Add(flowTrips);

        }

        private void nudFloorNumbers_ValueChanged(object sender, EventArgs e)
        {
            GenerateFloorInputs((int)nudFloorNumbers.Value);
        }

        private void nudTrips_ValueChanged(object sender, EventArgs e)
        {
            GenerateTripsInputs((int)nudTrips.Value);
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

                // ✅ Price Label
                Label lblPrice = new Label();
                lblPrice.Text = "Price:";
                lblPrice.AutoSize = true;
                lblPrice.Location = new Point(10, 60);

                // ✅ Price Input
                NumericUpDown nudPrice = new NumericUpDown();
                nudPrice.Name = $"nudPrice_{i}";
                nudPrice.Minimum = 0;
                nudPrice.Maximum = 10000;
                nudPrice.DecimalPlaces = 2;
                nudPrice.Width = 80;
                nudPrice.Location = new Point(60, 55);

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
                group.Controls.Add(lblPrice);
                group.Controls.Add(nudPrice);
                group.Controls.Add(lblCapacity);

                flowFloors.Controls.Add(group);
            }

            UpdateFloorAndTotalCapacity();
        }





        private void GenerateTripsInputs(int numberOfTrips)
        {
            flowTrips.Controls.Clear();

            string origin = tbOriginPort.Text.Trim();
            string destination = tbDestinationPort.Text.Trim();

            if (string.IsNullOrWhiteSpace(origin) || string.IsNullOrWhiteSpace(destination))
            {
                MessageBox.Show("Please set the Origin and Destination ports first.",
                    "Missing Route", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            for (int i = 1; i <= numberOfTrips; i++)
            {
                GroupBox group = new GroupBox();
                group.Text = $"Trip {i}";
                group.Width = flowTrips.Width - 25;
                group.Height = 110;
                group.Padding = new Padding(10);

                // 🔄 AUTO ALTERNATE ROUTE
                string tripOrigin = (i % 2 == 1) ? origin : destination;
                string tripDestination = (i % 2 == 1) ? destination : origin;

                Label lblRoute = new Label();
                lblRoute.Text = $"{tripOrigin} → {tripDestination}";
                lblRoute.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                lblRoute.AutoSize = true;
                lblRoute.Location = new Point(10, 25);

                Label lblDT = new Label();
                lblDT.Text = "Departure:";
                lblDT.AutoSize = true;
                lblDT.Location = new Point(10, 55);

                DateTimePicker dtDeparture = new DateTimePicker();
                dtDeparture.Name = $"dtDeparture_{i}";
                dtDeparture.Format = DateTimePickerFormat.Time;
                dtDeparture.ShowUpDown = true;
                dtDeparture.Location = new Point(80, 50);
                dtDeparture.Width = 100;

                Label lblAT = new Label();
                lblAT.Text = "Arrival:";
                lblAT.AutoSize = true;
                lblAT.Location = new Point(200, 55);

                DateTimePicker dtArrival = new DateTimePicker();
                dtArrival.Name = $"dtArrival_{i}";
                dtArrival.Format = DateTimePickerFormat.Time;
                dtArrival.ShowUpDown = true;
                dtArrival.Location = new Point(255, 50);
                dtArrival.Width = 100;

                group.Controls.Add(lblRoute);
                group.Controls.Add(lblDT);
                group.Controls.Add(dtDeparture);
                group.Controls.Add(lblAT);
                group.Controls.Add(dtArrival);

                flowTrips.Controls.Add(group);
            }
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
            public decimal Price { get; set; }
        }

        public class TripSchedule
        {
            public int TripNumber { get; set; }
            public string Origin { get; set; }        // NEW
            public string Destination { get; set; }   // NEW
            public DateTime DepartureTime { get; set; }
            public DateTime ArrivalTime { get; set; }
        }





        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // --- VALIDATION ---
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

            // --- GET FLOOR DATA ---
            List<FloorLayout> floors = new List<FloorLayout>();
            int totalCapacity = 0;

            for (int i = 1; i <= nudFloorNumbers.Value; i++)
            {
                var row = flowFloors.Controls.Find($"nudRow_{i}", true).FirstOrDefault() as NumericUpDown;
                var col = flowFloors.Controls.Find($"nudColumn_{i}", true).FirstOrDefault() as NumericUpDown;
                var price = flowFloors.Controls.Find($"nudPrice_{i}", true).FirstOrDefault() as NumericUpDown;

                if (row == null || col == null || price == null)
                    continue;

                totalCapacity += (int)row.Value * (int)col.Value;

                floors.Add(new FloorLayout
                {
                    FloorNumber = i,
                    Rows = (int)row.Value,
                    Columns = (int)col.Value,
                    Price = price.Value
                });
            }

            // --- GET TRIP DATA ---
            List<TripSchedule> trips = new List<TripSchedule>();
            string origin = tbOriginPort.Text.Trim();
            string destination = tbDestinationPort.Text.Trim();

            for (int i = 1; i <= nudTrips.Value; i++)
            {
                var dep = flowTrips.Controls.Find($"dtDeparture_{i}", true).FirstOrDefault() as DateTimePicker;
                var arr = flowTrips.Controls.Find($"dtArrival_{i}", true).FirstOrDefault() as DateTimePicker;

                if (dep == null || arr == null) continue;

                string o = (i % 2 == 1) ? origin : destination;
                string d = (i % 2 == 1) ? destination : origin;

                trips.Add(new TripSchedule { TripNumber = i, Origin = o, Destination = d, DepartureTime = dep.Value, ArrivalTime = arr.Value });
            }

            DATABASE.FerryOwnerHelper FerryHelper = new DATABASE.FerryOwnerHelper();

            // --- INSERT INTO DB ---
            // Pass this.OwnerID as the first parameter to RegisterFerry
            bool success = FerryHelper.RegisterFerry(
                tbFerryName.Text.Trim(),
                tbFerryCode.Text.Trim(),
                floors.Count,
                totalCapacity,
                floors,
                trips,
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
                this.Close();
                MessageBox.Show("Ferry registered successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Error occurred while saving ferry.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

    }
}
