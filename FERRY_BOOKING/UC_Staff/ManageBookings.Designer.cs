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
            panelDateFilter = new Panel();
            btnClearFilter = new Button();
            monthCalendar = new MonthCalendar();
            rbFilterAll = new RadioButton();
            rbFilterDay = new RadioButton();
            rbFilterMonth = new RadioButton();
            lblDateFilter = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvManageBookings).BeginInit();
            panelDateFilter.SuspendLayout();
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
            txtSearch.Location = new Point(3, 108);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by Booking Reference or Passenger Name...";
            txtSearch.Size = new Size(1182, 30);
            txtSearch.TabIndex = 6;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSearch.Location = new Point(20, 85);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(55, 20);
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
            dgvManageBookings.Size = new Size(1165, 372);
            dgvManageBookings.TabIndex = 8;
            // 
            // panelDateFilter
            // 
            panelDateFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelDateFilter.BorderStyle = BorderStyle.FixedSingle;
            panelDateFilter.Controls.Add(btnClearFilter);
            panelDateFilter.Controls.Add(monthCalendar);
            panelDateFilter.Controls.Add(rbFilterAll);
            panelDateFilter.Controls.Add(rbFilterDay);
            panelDateFilter.Controls.Add(rbFilterMonth);
            panelDateFilter.Controls.Add(lblDateFilter);
            panelDateFilter.Location = new Point(1191, 85);
            panelDateFilter.Name = "panelDateFilter";
            panelDateFilter.Size = new Size(268, 446);
            panelDateFilter.TabIndex = 9;
            // 
            // btnClearFilter
            // 
            btnClearFilter.BackColor = Color.FromArgb(11, 94, 235);
            btnClearFilter.FlatStyle = FlatStyle.Flat;
            btnClearFilter.ForeColor = Color.White;
            btnClearFilter.Location = new Point(36, 406);
            btnClearFilter.Name = "btnClearFilter";
            btnClearFilter.Size = new Size(210, 35);
            btnClearFilter.TabIndex = 5;
            btnClearFilter.Text = "Clear Filter";
            btnClearFilter.UseVisualStyleBackColor = false;
            btnClearFilter.Click += btnClearFilter_Click;
            // 
            // monthCalendar
            // 
            monthCalendar.Location = new Point(-1, 136);
            monthCalendar.MaxSelectionCount = 1;
            monthCalendar.Name = "monthCalendar";
            monthCalendar.TabIndex = 0;
            monthCalendar.DateChanged += monthCalendar_DateChanged;
            // 
            // rbFilterAll
            // 
            rbFilterAll.AutoSize = true;
            rbFilterAll.Checked = true;
            rbFilterAll.Location = new Point(10, 40);
            rbFilterAll.Name = "rbFilterAll";
            rbFilterAll.Size = new Size(113, 24);
            rbFilterAll.TabIndex = 1;
            rbFilterAll.TabStop = true;
            rbFilterAll.Text = "All Bookings";
            rbFilterAll.UseVisualStyleBackColor = true;
            rbFilterAll.CheckedChanged += DateFilterMode_CheckedChanged;
            // 
            // rbFilterDay
            // 
            rbFilterDay.AutoSize = true;
            rbFilterDay.Location = new Point(10, 70);
            rbFilterDay.Name = "rbFilterDay";
            rbFilterDay.Size = new Size(80, 24);
            rbFilterDay.TabIndex = 2;
            rbFilterDay.Text = "Per Day";
            rbFilterDay.UseVisualStyleBackColor = true;
            rbFilterDay.CheckedChanged += DateFilterMode_CheckedChanged;
            // 
            // rbFilterMonth
            // 
            rbFilterMonth.AutoSize = true;
            rbFilterMonth.Location = new Point(10, 100);
            rbFilterMonth.Name = "rbFilterMonth";
            rbFilterMonth.Size = new Size(97, 24);
            rbFilterMonth.TabIndex = 3;
            rbFilterMonth.Text = "Per Month";
            rbFilterMonth.UseVisualStyleBackColor = true;
            rbFilterMonth.CheckedChanged += DateFilterMode_CheckedChanged;
            // 
            // lblDateFilter
            // 
            lblDateFilter.AutoSize = true;
            lblDateFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDateFilter.ForeColor = Color.FromArgb(11, 94, 235);
            lblDateFilter.Location = new Point(10, 10);
            lblDateFilter.Name = "lblDateFilter";
            lblDateFilter.Size = new Size(82, 20);
            lblDateFilter.TabIndex = 4;
            lblDateFilter.Text = "Date Filter";
            // 
            // ManageBookings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(panelDateFilter);
            Controls.Add(dgvManageBookings);
            Controls.Add(lblSearch);
            Controls.Add(txtSearch);
            Controls.Add(label1);
            Controls.Add(lblCompanyNameFleet);
            Name = "ManageBookings";
            Size = new Size(1462, 551);
            ((System.ComponentModel.ISupportInitialize)dgvManageBookings).EndInit();
            panelDateFilter.ResumeLayout(false);
            panelDateFilter.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblCompanyNameFleet;
        private TextBox txtSearch;
        private Label lblSearch;
        private DataGridView dgvManageBookings;
        private Panel panelDateFilter;
        private MonthCalendar monthCalendar;
        private RadioButton rbFilterAll;
        private RadioButton rbFilterDay;
        private RadioButton rbFilterMonth;
        private Label lblDateFilter;
        private Button btnClearFilter;
    }
}
