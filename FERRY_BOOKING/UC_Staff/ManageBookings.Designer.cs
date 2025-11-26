namespace FERRY_BOOKING.UC_Staff
{
    partial class ManageBookings
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            label1 = new Label();
            lblCompanyNameFleet = new Label();
            txtSearch = new TextBox();
            lblSearch = new Label();
            dgvManageBookings = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvManageBookings).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(20, 50);
            label1.Name = "label1";
            label1.Size = new Size(247, 20);
            label1.TabIndex = 5;
            label1.Text = "View and manage all ferry bookings";
            // 
            // lblCompanyNameFleet
            // 
            lblCompanyNameFleet.AutoSize = true;
            lblCompanyNameFleet.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCompanyNameFleet.ForeColor = Color.FromArgb(11, 94, 235);
            lblCompanyNameFleet.Location = new Point(20, 13);
            lblCompanyNameFleet.Name = "lblCompanyNameFleet";
            lblCompanyNameFleet.Size = new Size(181, 28);
            lblCompanyNameFleet.TabIndex = 4;
            lblCompanyNameFleet.Text = "Manage Bookings";
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(20, 113);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by Booking Reference or Passenger Name...";
            txtSearch.Size = new Size(1422, 30);
            txtSearch.TabIndex = 6;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSearch.Location = new Point(20, 85);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(56, 20);
            lblSearch.TabIndex = 7;
            lblSearch.Text = "Search";
            // 
            // dgvManageBookings
            // 
            dgvManageBookings.AllowUserToAddRows = false;
            dgvManageBookings.AllowUserToDeleteRows = false;
            dgvManageBookings.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvManageBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvManageBookings.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvManageBookings.BackgroundColor = Color.White;
            dgvManageBookings.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(11, 94, 235);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvManageBookings.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvManageBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(11, 94, 235);
            dataGridViewCellStyle2.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvManageBookings.DefaultCellStyle = dataGridViewCellStyle2;
            dgvManageBookings.EnableHeadersVisualStyles = false;
            dgvManageBookings.Location = new Point(20, 159);
            dgvManageBookings.Name = "dgvManageBookings";
            dgvManageBookings.ReadOnly = true;
            dgvManageBookings.RowHeadersVisible = false;
            dgvManageBookings.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = Color.White;
            dgvManageBookings.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvManageBookings.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvManageBookings.Size = new Size(1422, 372);
            dgvManageBookings.TabIndex = 8;

            // 
            // ManageBookings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(dgvManageBookings);
            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Controls.Add(lblCompanyNameFleet);
            Name = "ManageBookings";
            Size = new Size(1462, 551);
            ((System.ComponentModel.ISupportInitialize)dgvManageBookings).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblCompanyNameFleet;
        private TextBox txtSearch;
        private Label lblSearch;
        private DataGridView dgvManageBookings;
    }
}
