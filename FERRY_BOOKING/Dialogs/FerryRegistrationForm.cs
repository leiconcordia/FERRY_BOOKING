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
        public FerryRegistrationForm()
        {
            InitializeComponent();

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



        private void GenerateFloorInputs(int numberOfFloors)
        {
            flowFloors.Controls.Clear();

            for (int i = 1; i <= numberOfFloors; i++)
            {
                GroupBox group = new GroupBox();
                group.Text = $"Floor {i}";
                group.Width = flowFloors.Width - 30; // adjusts to container
                group.AutoSize = true;
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

                // Add controls to group
                group.Controls.Add(lblRow);
                group.Controls.Add(nudRow);
                group.Controls.Add(lblColumn);
                group.Controls.Add(nudColumn);

                // Add to scrollable panel
                flowFloors.Controls.Add(group);
            }
        }

        private void GenerateTripsInputs(int numberOfTrips)
        {
            flowTrips.Controls.Clear();

            for (int i = 1; i <= numberOfTrips; i++)
            {
                GroupBox group = new GroupBox();
                group.Text = $"Trip {i}";
                group.Width = flowTrips.Width - 25;
                group.Height = 80;
                group.Padding = new Padding(10);

                Label lblDT = new Label();
                lblDT.Text = "Departure Time:";
                lblDT.AutoSize = true;
                lblDT.Location = new Point(10, 30);

                DateTimePicker dtDeparture = new DateTimePicker();
                dtDeparture.Name = $"dtDeparture_{i}";
                dtDeparture.Format = DateTimePickerFormat.Time;
                dtDeparture.ShowUpDown = true;
                dtDeparture.Location = new Point(120, 25);
                dtDeparture.Width = 100;

                Label lblAT = new Label();
                lblAT.Text = "Arrival Time:";
                lblAT.AutoSize = true;
                lblAT.Location = new Point(240, 30);

                DateTimePicker dtArrival = new DateTimePicker();
                dtArrival.Name = $"dtArrival_{i}";
                dtArrival.Format = DateTimePickerFormat.Time;
                dtArrival.ShowUpDown = true;
                dtArrival.Location = new Point(330, 25);
                dtArrival.Width = 100;

                group.Controls.Add(lblDT);
                group.Controls.Add(dtDeparture);
                group.Controls.Add(lblAT);
                group.Controls.Add(dtArrival);

                flowTrips.Controls.Add(group);
            }
        }

        private bool ValidateTrips(int numberOfTrips)
        {
            for (int i = 1; i <= numberOfTrips; i++)
            {
                DateTimePicker dtDep = (DateTimePicker)flowTrips.Controls[$"Trip {i}"]
                    .Controls[$"dtDeparture_{i}"];

                DateTimePicker dtArr = (DateTimePicker)flowTrips.Controls[$"Trip {i}"]
                    .Controls[$"dtArrival_{i}"];

                if (dtArr.Value <= dtDep.Value)
                {
                    MessageBox.Show($"Trip {i}: Arrival time must be later than departure.",
                                    "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            return true;
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
            openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";

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

        public class TripSchedule
        {
            public int TripNumber { get; set; }
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

            if (string.IsNullOrWhiteSpace(tbFerryName.Text))
            {
                MessageBox.Show("Ferry Name is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbFerryName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tbFerryCode.Text))
            {
                MessageBox.Show("Ferry Code is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                tbFerryCode.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(tbOriginPort.Text) || string.IsNullOrWhiteSpace(tbDestinationPort.Text))
            {
                MessageBox.Show("Origin and Destination ports are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate document uploads (optional but recommended)
            if (coFileBytes == null || vrFileBytes == null || scFileBytes == null || idFileBytes == null)
            {
                MessageBox.Show("Please upload all required documents.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- COLLECT FLOOR DATA ---

            List<FloorLayout> floors = new List<FloorLayout>();

            for (int i = 1; i <= nudFloorNumbers.Value; i++)
            {
                var rowControl = flowFloors.Controls.Find($"nudRow_{i}", true).FirstOrDefault() as NumericUpDown;
                var colControl = flowFloors.Controls.Find($"nudColumn_{i}", true).FirstOrDefault() as NumericUpDown;

                if (rowControl == null || colControl == null)
                    continue;

                floors.Add(new FloorLayout
                {
                    FloorNumber = i,
                    Rows = (int)rowControl.Value,
                    Columns = (int)colControl.Value
                });
            }

            // --- COLLECT TRIP DATA ---

            List<TripSchedule> trips = new List<TripSchedule>();

            for (int i = 1; i <= nudTrips.Value; i++)
            {
                var dtDep = flowTrips.Controls.Find($"dtDeparture_{i}", true).FirstOrDefault() as DateTimePicker;
                var dtArr = flowTrips.Controls.Find($"dtArrival_{i}", true).FirstOrDefault() as DateTimePicker;

                if (dtDep == null || dtArr == null)
                    continue;

                // Validate time logic
                if (dtArr.Value.TimeOfDay <= dtDep.Value.TimeOfDay)
                {
                    MessageBox.Show($"Arrival time must be later than departure time for Trip {i}.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                trips.Add(new TripSchedule
                {
                    TripNumber = i,
                    DepartureTime = dtDep.Value,
                    ArrivalTime = dtArr.Value
                });
            }

            // --- Store ferry basic info ---
            string ferryName = tbFerryName.Text.Trim();
            string ferryCode = tbFerryCode.Text.Trim();
            string originPort = tbOriginPort.Text.Trim();
            string destinationPort = tbDestinationPort.Text.Trim();

            // ✅ SUCCESS (DATA GATHERED)
            MessageBox.Show("Data collected successfully! Ready for DB insertion later.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // If needed later:
            // Save to a global object, pass to next form, or serialize.
        }

    }
}
