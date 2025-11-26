using FERRY_BOOKING.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FERRY_BOOKING.UC_Staff
{
    public partial class PassengerInfoControl : UserControl
    {

        public string PassengerName => tbFullName.Text.Trim();
        public int PassengerAge => (int)nudAge.Value;
        public string PassengerGender => cmbGender.SelectedItem?.ToString();
        public string PassengerDiscount => cmbDiscount.SelectedItem?.ToString();
        public string ContactNumber => tbPhone.Text.Trim();
        
        public byte[] IDImage { get; private set; }   // Discount ID (optional if discount = None)
        public byte[] ValidIDImage { get; private set; }   // Valid ID (required for all)

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
            Price = SeatPrice;
            string labelPrice = Price.ToString("C", new CultureInfo("fil-PH"));
            lblSeat.Text = $"Seat: {seatCode}";

            cmbGender.Items.AddRange(new string[] { "Male", "Female", "Other" });
            cmbDiscount.Items.AddRange(new string[] { "None", "Senior", "Student", "PWD" });

            btnUploadID.Visible = false; // hide at start
            lblFileName.Visible = false;
            cmbDiscount.SelectedIndexChanged += CmbDiscount_SelectedIndexChanged;

            lblPrice.Text = $"Price: {labelPrice}";
        }
        private void TbPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow Backspace and control keys
            if (char.IsControl(e.KeyChar))
                return;

            // Block non-numeric keys
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return;
            }

            string currentText = tbPhone.Text;

            // Enforce "09" prefix
            if (currentText.Length == 0 && e.KeyChar != '0')
            {
                e.Handled = true; // First digit must be 0
                return;
            }

            if (currentText.Length == 1 && e.KeyChar != '9')
            {
                e.Handled = true; // Second digit must be 9
                return;
            }
        }


        private void TbPhone_TextChanged(object sender, EventArgs e)
        {
            // Enforce max length strictly (in case of pasted text)
            if (tbPhone.Text.Length > 11)
            {
                tbPhone.Text = tbPhone.Text.Substring(0, 11);
                tbPhone.SelectionStart = tbPhone.Text.Length; // keep cursor at end
            }
        }



        private void CmbDiscount_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Show upload button only if discounted
            btnUploadID.Visible = cmbDiscount.SelectedItem.ToString() != "None";
            lblFileName.Visible = cmbDiscount.SelectedItem.ToString() != "None";    
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

                    // 20 % discount on any discount type
                    ApplyDiscount();
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

        private void ApplyDiscount()
        {
            if (IDImage == null || IDImage.Length == 0) return;   // safety

            Price *= 0.80m;                     // 20 % off
            lblPrice.Text = $"Price: {Price.ToString("C", new CultureInfo("fil-PH"))}";

            PriceChanged?.Invoke();
        }

        /// <summary>
        /// Validates that all required fields are filled.
        /// Returns true if valid, false otherwise with error message.
        /// </summary>
        public bool ValidateInput(out string errorMessage)
        {
            errorMessage = string.Empty;

            // Check Full Name
            if (string.IsNullOrWhiteSpace(PassengerName))
            {
                errorMessage = $"Seat {SeatCode}: Full name is required.";
                return false;
            }

            // Check Age (should be > 0, already handled by NumericUpDown minimum)
            if (PassengerAge <= 0)
            {
                errorMessage = $"Seat {SeatCode}: Age must be greater than 0.";
                return false;
            }

            // Check Gender
            if (string.IsNullOrEmpty(PassengerGender))
            {
                errorMessage = $"Seat {SeatCode}: Gender is required.";
                return false;
            }

            // Check Contact Number
            if (string.IsNullOrWhiteSpace(ContactNumber))
            {
                errorMessage = $"Seat {SeatCode}: Contact number is required.";
                return false;
            }

            // Check Discount Type
            if (string.IsNullOrEmpty(PassengerDiscount))
            {
                errorMessage = $"Seat {SeatCode}: Discount type is required.";
                return false;
            }

            // Check Discount ID if discount is not "None"
            if (PassengerDiscount != "None" && (IDImage == null || IDImage.Length == 0))
            {
                errorMessage = $"Seat {SeatCode}: Discount ID is required for {PassengerDiscount} discount.";
                return false;
            }

            // Check Valid ID (required for all passengers)
            if (ValidIDImage == null || ValidIDImage.Length == 0)
            {
                errorMessage = $"Seat {SeatCode}: Valid ID is required.";
                return false;
            }

            return true;
        }
    }
}
