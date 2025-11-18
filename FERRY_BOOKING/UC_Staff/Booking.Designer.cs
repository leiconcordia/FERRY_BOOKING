using System.Windows.Forms;

namespace FERRY_BOOKING.UC_Staff
{
    partial class Booking
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            lblCompanyNameFleet = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cbFerryCompany = new ComboBox();
            cbRoute = new ComboBox();
            dtpTravelDate = new DateTimePicker();
            btnSearchFerries = new Button();
            dgvFerries = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvFerries).BeginInit();
            SuspendLayout();
            // 
            // lblCompanyNameFleet
            // 
            lblCompanyNameFleet.AutoSize = true;
            lblCompanyNameFleet.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCompanyNameFleet.ForeColor = Color.FromArgb(11, 94, 235);
            lblCompanyNameFleet.Location = new Point(22, 23);
            lblCompanyNameFleet.Name = "lblCompanyNameFleet";
            lblCompanyNameFleet.Size = new Size(238, 28);
            lblCompanyNameFleet.TabIndex = 2;
            lblCompanyNameFleet.Text = "Search Available Ferries";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(22, 60);
            label1.Name = "label1";
            label1.Size = new Size(275, 20);
            label1.TabIndex = 3;
            label1.Text = "Find ferries by company, route, and date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(11, 94, 235);
            label2.Location = new Point(22, 105);
            label2.Name = "label2";
            label2.Size = new Size(116, 20);
            label2.TabIndex = 4;
            label2.Text = "Ferry Company";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(11, 94, 235);
            label3.Location = new Point(238, 105);
            label3.Name = "label3";
            label3.Size = new Size(51, 20);
            label3.TabIndex = 5;
            label3.Text = "Route";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(11, 94, 235);
            label4.Location = new Point(463, 106);
            label4.Name = "label4";
            label4.Size = new Size(88, 20);
            label4.TabIndex = 6;
            label4.Text = "Travel Date";
            // 
            // cbFerryCompany
            // 
            cbFerryCompany.FormattingEnabled = true;
            cbFerryCompany.Location = new Point(22, 128);
            cbFerryCompany.Name = "cbFerryCompany";
            cbFerryCompany.Size = new Size(173, 28);
            cbFerryCompany.TabIndex = 7;
            // 
            // cbRoute
            // 
            cbRoute.FormattingEnabled = true;
            cbRoute.Location = new Point(238, 128);
            cbRoute.Name = "cbRoute";
            cbRoute.Size = new Size(173, 28);
            cbRoute.TabIndex = 8;
            // 
            // dtpTravelDate
            // 
            dtpTravelDate.Location = new Point(463, 129);
            dtpTravelDate.Name = "dtpTravelDate";
            dtpTravelDate.Size = new Size(262, 27);
            dtpTravelDate.TabIndex = 9;
            dtpTravelDate.Format = DateTimePickerFormat.Custom;
            dtpTravelDate.ShowUpDown = false;
            dtpTravelDate.CustomFormat = "MMMM dd, yyyy";
            dtpTravelDate.MinDate = new DateTime(2025, 11, 16, 0, 0, 0, 0);

            // 
            // btnSearchFerries
            // 
            btnSearchFerries.BackColor = Color.FromArgb(11, 94, 235);
            btnSearchFerries.ForeColor = SystemColors.ButtonHighlight;
            btnSearchFerries.Location = new Point(1191, 128);
            btnSearchFerries.Name = "btnSearchFerries";
            btnSearchFerries.Size = new Size(247, 48);
            btnSearchFerries.TabIndex = 10;
            btnSearchFerries.Text = "Search Ferries";
            btnSearchFerries.UseVisualStyleBackColor = false;
            btnSearchFerries.Click += btnSearchFerries_Click;

            // 
            // dgvFerries
            // 
            dgvFerries.AllowUserToAddRows = false;
            dgvFerries.AllowUserToDeleteRows = false;
            dgvFerries.AllowUserToResizeRows = false;
            dgvFerries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFerries.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.LightGray;
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            dgvFerries.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgvFerries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(11, 94, 235);
            dataGridViewCellStyle4.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvFerries.DefaultCellStyle = dataGridViewCellStyle4;
            dgvFerries.EnableHeadersVisualStyles = false;
            dgvFerries.Location = new Point(22, 196);
            dgvFerries.MultiSelect = false;
            dgvFerries.Name = "dgvFerries";
            dgvFerries.RowHeadersVisible = false;
            dgvFerries.RowHeadersWidth = 51;
            dgvFerries.RowTemplate.Height = 30;
            dgvFerries.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFerries.Size = new Size(1416, 335);
            dgvFerries.TabIndex = 11;
            dgvFerries.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            // 
            // Booking
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(dgvFerries);
            Controls.Add(btnSearchFerries);
            Controls.Add(dtpTravelDate);
            Controls.Add(cbRoute);
            Controls.Add(cbFerryCompany);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblCompanyNameFleet);
            Name = "Booking";
            Size = new Size(1462, 551);
            ((System.ComponentModel.ISupportInitialize)dgvFerries).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCompanyNameFleet;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cbFerryCompany;
        private ComboBox cbRoute;
        private DateTimePicker dtpTravelDate;
        private Button btnSearchFerries;
        private DataGridView dgvFerries;
    }
}
