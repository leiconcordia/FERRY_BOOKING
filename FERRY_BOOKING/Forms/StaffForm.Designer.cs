namespace FERRY_BOOKING.Forms
{
    partial class StaffForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            StaffPanel = new Panel();
            panel1 = new Panel();
            HeaderPanel = new Panel();
            label2 = new Label();
            btnLogout = new Button();
            label1 = new Label();
            headerSubtitleLabel = new Label();
            headerTitleLabel = new Label();
            headerLogoPictureBox = new PictureBox();
            navManageBookings = new Button();
            navPassengerHistory = new Button();
            navBooking = new Button();
            HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)headerLogoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // StaffPanel
            // 
            StaffPanel.BackColor = SystemColors.ButtonFace;
            StaffPanel.Location = new Point(12, 147);
            StaffPanel.Name = "StaffPanel";
            StaffPanel.Size = new Size(1761, 551);
            StaffPanel.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 193, 7);
            panel1.Location = new Point(2, 78);
            panel1.Name = "panel1";
            panel1.Size = new Size(1786, 10);
            panel1.TabIndex = 6;
            // 
            // HeaderPanel
            // 
            HeaderPanel.BackColor = Color.FromArgb(11, 94, 235);
            HeaderPanel.Controls.Add(label2);
            HeaderPanel.Controls.Add(btnLogout);
            HeaderPanel.Controls.Add(label1);
            HeaderPanel.Controls.Add(headerSubtitleLabel);
            HeaderPanel.Controls.Add(headerTitleLabel);
            HeaderPanel.Controls.Add(headerLogoPictureBox);
            HeaderPanel.Location = new Point(2, 12);
            HeaderPanel.Name = "HeaderPanel";
            HeaderPanel.Size = new Size(1786, 72);
            HeaderPanel.TabIndex = 5;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(1629, 31);
            label2.Name = "label2";
            label2.Size = new Size(40, 20);
            label2.TabIndex = 7;
            label2.Text = "Staff";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.BackColor = Color.FromArgb(255, 193, 7);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 9F);
            btnLogout.ForeColor = Color.FromArgb(15, 15, 20);
            btnLogout.Location = new Point(1675, 19);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(96, 32);
            btnLogout.TabIndex = 5;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(3169, 30);
            label1.Name = "label1";
            label1.Size = new Size(88, 20);
            label1.TabIndex = 6;
            label1.Text = "Ferry Owner";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // headerSubtitleLabel
            // 
            headerSubtitleLabel.AutoSize = true;
            headerSubtitleLabel.Font = new Font("Segoe UI", 9F);
            headerSubtitleLabel.ForeColor = Color.FromArgb(220, 220, 220);
            headerSubtitleLabel.Location = new Point(72, 31);
            headerSubtitleLabel.Name = "headerSubtitleLabel";
            headerSubtitleLabel.Size = new Size(130, 20);
            headerSubtitleLabel.TabIndex = 3;
            headerSubtitleLabel.Text = "Ferry Owner Portal";
            // 
            // headerTitleLabel
            // 
            headerTitleLabel.AutoSize = true;
            headerTitleLabel.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            headerTitleLabel.ForeColor = Color.White;
            headerTitleLabel.Location = new Point(72, 3);
            headerTitleLabel.Name = "headerTitleLabel";
            headerTitleLabel.Size = new Size(305, 28);
            headerTitleLabel.TabIndex = 2;
            headerTitleLabel.Text = "FerryLink PH - Booking System";
            // 
            // headerLogoPictureBox
            // 
            headerLogoPictureBox.Image = Properties.Resources.Ferry_Logo;
            headerLogoPictureBox.Location = new Point(3, 3);
            headerLogoPictureBox.Name = "headerLogoPictureBox";
            headerLogoPictureBox.Size = new Size(63, 66);
            headerLogoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            headerLogoPictureBox.TabIndex = 1;
            headerLogoPictureBox.TabStop = false;
            // 
            // navManageBookings
            // 
            navManageBookings.Location = new Point(738, 94);
            navManageBookings.Name = "navManageBookings";
            navManageBookings.Size = new Size(371, 29);
            navManageBookings.TabIndex = 9;
            navManageBookings.Text = "Manage Bookings";
            navManageBookings.UseVisualStyleBackColor = true;
            navManageBookings.Click += navManageBookings_Click;
            // 
            // navPassengerHistory
            // 
            navPassengerHistory.Location = new Point(1115, 94);
            navPassengerHistory.Name = "navPassengerHistory";
            navPassengerHistory.Size = new Size(371, 29);
            navPassengerHistory.TabIndex = 8;
            navPassengerHistory.Text = "Passenger History";
            navPassengerHistory.UseVisualStyleBackColor = true;
            navPassengerHistory.Click += navPassengerHistory_Click;
            // 
            // navBooking
            // 
            navBooking.Location = new Point(361, 94);
            navBooking.Name = "navBooking";
            navBooking.Size = new Size(371, 29);
            navBooking.TabIndex = 7;
            navBooking.Text = "Ferry Search and Booking";
            navBooking.UseVisualStyleBackColor = true;
            navBooking.Click += navBooking_Click;
            // 
            // StaffForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1785, 739);
            Controls.Add(navManageBookings);
            Controls.Add(navPassengerHistory);
            Controls.Add(navBooking);
            Controls.Add(panel1);
            Controls.Add(HeaderPanel);
            Controls.Add(StaffPanel);
            Name = "StaffForm";
            Text = "BookingForm";
            Load += StaffForm_Load;
            HeaderPanel.ResumeLayout(false);
            HeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)headerLogoPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel StaffPanel;
        private Panel panel1;
        private Panel HeaderPanel;
        private Label label1;
        private Label headerSubtitleLabel;
        private Label headerTitleLabel;
        private PictureBox headerLogoPictureBox;
        private Button btnLogout;
        private Label label2;
        private Button navManageBookings;
        private Button navPassengerHistory;
        private Button navBooking;
    }
}