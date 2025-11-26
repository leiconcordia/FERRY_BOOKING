namespace FERRY_BOOKING.UC_Staff
{
    partial class PassengerHistory
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
            label1 = new Label();
            lblCompanyNameFleet = new Label();
            searchPanel = new Panel();
            lblSearch = new Label();
            txtSearch = new TextBox();
            btnRefresh = new Button();
            dgvPassengers = new DataGridView();
            lblRecordCount = new Label();
            searchPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPassengers).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(15, 49);
            label1.Name = "label1";
            label1.Size = new Size(308, 20);
            label1.TabIndex = 7;
            label1.Text = "View all passengers and their booking history";
            // 
            // lblCompanyNameFleet
            // 
            lblCompanyNameFleet.AutoSize = true;
            lblCompanyNameFleet.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCompanyNameFleet.ForeColor = Color.FromArgb(11, 94, 235);
            lblCompanyNameFleet.Location = new Point(15, 12);
            lblCompanyNameFleet.Name = "lblCompanyNameFleet";
            lblCompanyNameFleet.Size = new Size(183, 28);
            lblCompanyNameFleet.TabIndex = 6;
            lblCompanyNameFleet.Text = "Passenger History";
            // 
            // searchPanel
            // 
            searchPanel.BackColor = Color.WhiteSmoke;
            searchPanel.BorderStyle = BorderStyle.FixedSingle;
            searchPanel.Controls.Add(lblSearch);
            searchPanel.Controls.Add(txtSearch);
            searchPanel.Controls.Add(btnRefresh);
            searchPanel.Location = new Point(15, 85);
            searchPanel.Name = "searchPanel";
            searchPanel.Size = new Size(1432, 60);
            searchPanel.TabIndex = 8;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Font = new Font("Segoe UI", 10F);
            lblSearch.Location = new Point(15, 18);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(137, 23);
            lblSearch.TabIndex = 0;
            lblSearch.Text = "🔍 Search Name:";
            // 
            // txtSearch
            // 
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.Location = new Point(158, 15);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Enter passenger name, contact, gender, or discount type...";
            txtSearch.Size = new Size(450, 30);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // btnRefresh
            // 
            btnRefresh.BackColor = Color.FromArgb(40, 167, 69);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(630, 12);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(110, 35);
            btnRefresh.TabIndex = 2;
            btnRefresh.Text = "🔄 Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // dgvPassengers
            // 
            dgvPassengers.AllowUserToAddRows = false;
            dgvPassengers.AllowUserToDeleteRows = false;
            dgvPassengers.BackgroundColor = Color.White;
            dgvPassengers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPassengers.Location = new Point(15, 160);
            dgvPassengers.Name = "dgvPassengers";
            dgvPassengers.ReadOnly = true;
            dgvPassengers.RowHeadersVisible = false;
            dgvPassengers.RowHeadersWidth = 51;
            dgvPassengers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPassengers.Size = new Size(1432, 340);
            dgvPassengers.TabIndex = 9;
            // 
            // lblRecordCount
            // 
            lblRecordCount.AutoSize = true;
            lblRecordCount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRecordCount.ForeColor = Color.FromArgb(11, 94, 235);
            lblRecordCount.Location = new Point(15, 515);
            lblRecordCount.Name = "lblRecordCount";
            lblRecordCount.Size = new Size(168, 23);
            lblRecordCount.TabIndex = 10;
            lblRecordCount.Text = "Total Passengers: 0";
            // 
            // PassengerHistory
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            Controls.Add(lblRecordCount);
            Controls.Add(dgvPassengers);
            Controls.Add(searchPanel);
            Controls.Add(label1);
            Controls.Add(lblCompanyNameFleet);
            Name = "PassengerHistory";
            Size = new Size(1462, 551);
            searchPanel.ResumeLayout(false);
            searchPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPassengers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblCompanyNameFleet;
        private Panel searchPanel;
        private Label lblSearch;
        private TextBox txtSearch;
        private Button btnRefresh;
        private DataGridView dgvPassengers;
        private Label lblRecordCount;
    }
}
