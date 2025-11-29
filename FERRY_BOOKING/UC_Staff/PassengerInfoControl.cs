using FERRY_BOOKING.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO; // Added for MemoryStream
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FERRY_BOOKING.UC_Staff
{
    public partial class PassengerInfoControl : UserControl
    {
        // Store the original base price so we can recalculate correctly
        private decimal _basePrice;

        public string PassengerName => tbFullName.Text.Trim();
        public int PassengerAge => (int)nudAge.Value;
        public string PassengerGender => cmbGender.SelectedItem?.ToString();
        public string PassengerDiscount => cmbDiscount.SelectedItem?.ToString();
        public string ContactNumber => tbPhone.Text.Trim();

        public byte[] IDImage { get; private set; }
        public byte[] ValidIDImage { get; private set; }

        public Image IDImageBytes => IDImage == null ? null
                                  : Image.FromStream(new MemoryStream(IDImage));
        public string DiscountType => cmbDiscount.SelectedItem?.ToString();

        public decimal Price { get; private set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string SeatCode { get; set; }

        public event Action PriceChanged;

        public PassengerInfoControl(string seatCode, decimal SeatPrice)
        {
            InitializeComponent();
            SeatCode = seatCode;
            _basePrice = SeatPrice; // Save the original price
            Price = SeatPrice;

            string labelPrice = Price.ToString("C", new CultureInfo("fil-PH"));
            lblSeat.Text = $"Seat: {seatCode}";
            lblPrice.Text = $"Price: {labelPrice}";

            // Setup ComboBoxes
            cmbGender.Items.AddRange(new string[] { "Male", "Female", "Other" });
            cmbGender.SelectedIndex = 0; // Default to Male or first option

            // Setup Age Defaults (No infants, min age 4)
            nudAge.Minimum = 4;
            nudAge.Maximum = 120;
            nudAge.Value = 18; // Default to an adult age

            // Setup Events
            btnUploadID.Visible = false;
            lblFileName.Visible = false;

            cmbDiscount.SelectedIndexChanged += CmbDiscount_SelectedIndexChanged;
            nudAge.ValueChanged += NudAge_ValueChanged; // Listen for age changes

            // Initialize Discount Options based on the default age (18)
            UpdateDiscountOptions();
        }

        private void NudAge_ValueChanged(object sender, EventArgs e)
        {
            UpdateDiscountOptions();
        }

        private void UpdateDiscountOptions()
        {
            // Remember what was currently selected
            string currentSelection = cmbDiscount.SelectedItem?.ToString();
            int age = (int)nudAge.Value;

            // Stop the event handler temporarily to prevent flickering/logic loops
            cmbDiscount.SelectedIndexChanged -= CmbDiscount_SelectedIndexChanged;

            cmbDiscount.Items.Clear();

            // Always add default options
            cmbDiscount.Items.Add("None");
            cmbDiscount.Items.Add("PWD");

            // Logic: Senior Citizen Act (RA 9994) usually defines Senior as 60+
            if (age >= 60)
            {
                cmbDiscount.Items.Add("Senior");
                // Note: We usually don't add "Student" for 60+ 
            }
            else
            {
                // If under 60, they can be a student
                cmbDiscount.Items.Add("Student");
            }

            // Restore selection if it's still valid, otherwise default to "None"
            if (currentSelection != null && cmbDiscount.Items.Contains(currentSelection))
            {
                cmbDiscount.SelectedItem = currentSelection;
            }
            else
            {
                cmbDiscount.SelectedItem = "None";
            }

            // Re-enable event handler
            cmbDiscount.SelectedIndexChanged += CmbDiscount_SelectedIndexChanged;

            // Trigger visual update (show/hide buttons) based on the new selection
            UpdateUploadButtonVisibility();
        }

        private void UpdateUploadButtonVisibility()
        {
            bool isDiscounted = cmbDiscount.SelectedItem != null && cmbDiscount.SelectedItem.ToString() != "None";
            btnUploadID.Visible = isDiscounted;
            lblFileName.Visible = isDiscounted;
        }

        private void TbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsControl(e.KeyChar)) return;
            if (!char.IsDigit(e.KeyChar)) { e.Handled = true; return; }

            string currentText = tbPhone.Text;

            // Enforce "09" prefix logic
            if (currentText.Length == 0 && e.KeyChar != '0') { e.Handled = true; return; }
            if (currentText.Length == 1 && e.KeyChar != '9') { e.Handled = true; return; }
        }

        private void TbPhone_TextChanged(object sender, EventArgs e)
        {
            if (tbPhone.Text.Length > 11)
            {
                tbPhone.Text = tbPhone.Text.Substring(0, 11);
                tbPhone.SelectionStart = tbPhone.Text.Length;
            }
        }

        private void CmbDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUploadButtonVisibility();

            // Recalculate price immediately when discount changes (to reset price if None is selected)
            CalculatePrice();
        }

        private void btnUploadID_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp";
                dlg.Title = "Select Discount ID picture";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    IDImage = File.ReadAllBytes(dlg.FileName);
                    lblFileName.Text = $"✓ {Path.GetFileName(dlg.FileName)}";
                    btnUploadID.Text = "Change ID";

                    CalculatePrice();
                }
            }
        }

        private void btnUploadValidID_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Image files|*.jpg;*.jpeg;*.png;*.bmp";
                dlg.Title = "Select Valid ID (Required)";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    ValidIDImage = File.ReadAllBytes(dlg.FileName);
                    lblValidIDFileName.Text = $"✓ {Path.GetFileName(dlg.FileName)}";
                    btnUploadValidID.Text = "Change Valid ID";
                }
            }
        }

        private void CalculatePrice()
        {
            // Reset to base price first
            Price = _basePrice;

            string selectedDiscount = cmbDiscount.SelectedItem?.ToString();

            // Only apply discount if "None" is NOT selected AND we have an ID uploaded
            if (selectedDiscount != "None" && IDImage != null && IDImage.Length > 0)
            {
                Price = _basePrice * 0.80m; // 20% off
            }

            lblPrice.Text = $"Price: {Price.ToString("C", new CultureInfo("fil-PH"))}";
            PriceChanged?.Invoke();
        }

        public bool ValidateInput(out string errorMessage)
        {
            errorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(PassengerName))
            {
                errorMessage = $"Seat {SeatCode}: Full name is required.";
                return false;
            }

            // Min age 4 validation check (extra safety)
            if (PassengerAge < 4)
            {
                errorMessage = $"Seat {SeatCode}: Minimum age for a seat booking is 4.";
                return false;
            }

            if (string.IsNullOrEmpty(PassengerGender))
            {
                errorMessage = $"Seat {SeatCode}: Gender is required.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(ContactNumber) || ContactNumber.Length != 11)
            {
                errorMessage = $"Seat {SeatCode}: A valid 11-digit Contact number is required.";
                return false;
            }

            if (string.IsNullOrEmpty(PassengerDiscount))
            {
                errorMessage = $"Seat {SeatCode}: Discount type is required.";
                return false;
            }

            // Specific Logic: If they selected Senior but changed age to < 60 manually somehow
            if (PassengerDiscount == "Senior" && PassengerAge < 60)
            {
                errorMessage = $"Seat {SeatCode}: Senior Citizen discount requires age 60 or above.";
                return false;
            }

            if (PassengerDiscount != "None" && (IDImage == null || IDImage.Length == 0))
            {
                errorMessage = $"Seat {SeatCode}: Discount ID is required for {PassengerDiscount} discount.";
                return false;
            }

            if (ValidIDImage == null || ValidIDImage.Length == 0)
            {
                errorMessage = $"Seat {SeatCode}: Valid ID is required.";
                return false;
            }

            return true;
        }
    }
}