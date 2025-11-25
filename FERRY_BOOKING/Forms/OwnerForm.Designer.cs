namespace FERRY_BOOKING.Forms
{
    partial class OwnerForm
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
            HeaderPanel = new Panel();
            lblOwnerName = new Label();
            label1 = new Label();
            btnLogout = new Button();
            headerSubtitleLabel = new Label();
            headerTitleLabel = new Label();
            headerLogoPictureBox = new PictureBox();
            panel1 = new Panel();
            FerryOwnerPanel = new Panel();
            navDashboard = new Button();
            navSummary = new Button();
            navSchedule = new Button();
            navFerries = new Button();
            navRefunds = new Button();
            navCancelledTrips = new Button();
            HeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)headerLogoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // HeaderPanel
            // 
            HeaderPanel.BackColor = Color.FromArgb(11, 94, 235);
            HeaderPanel.Controls.Add(lblOwnerName);
            HeaderPanel.Controls.Add(label1);
            HeaderPanel.Controls.Add(btnLogout);
            HeaderPanel.Controls.Add(headerSubtitleLabel);
            HeaderPanel.Controls.Add(headerTitleLabel);
            HeaderPanel.Controls.Add(headerLogoPictureBox);
            HeaderPanel.Location = new Point(0, 16);
            HeaderPanel.Name = "HeaderPanel";
            HeaderPanel.Size = new Size(1786, 72);
            HeaderPanel.TabIndex = 0;
            // 
            // lblOwnerName
            // 
            lblOwnerName.AutoSize = true;
            lblOwnerName.ForeColor = Color.White;
            lblOwnerName.Location = new Point(1569, 10);
            lblOwnerName.Name = "lblOwnerName";
            lblOwnerName.Size = new Size(70, 20);
            lblOwnerName.TabIndex = 7;
            lblOwnerName.Text = "No name";
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(1583, 30);
            label1.Name = "label1";
            label1.Size = new Size(88, 20);
            label1.TabIndex = 6;
            label1.Text = "Ferry Owner";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // btnLogout
            // 
            btnLogout.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnLogout.BackColor = Color.FromArgb(255, 193, 7);
            btnLogout.FlatAppearance.BorderSize = 0;
            btnLogout.FlatStyle = FlatStyle.Flat;
            btnLogout.Font = new Font("Segoe UI", 9F);
            btnLogout.ForeColor = Color.FromArgb(15, 15, 20);
            btnLogout.Location = new Point(1677, 18);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(96, 32);
            btnLogout.TabIndex = 4;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
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
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 193, 7);
            panel1.Location = new Point(0, 82);
            panel1.Name = "panel1";
            panel1.Size = new Size(1786, 10);
            panel1.TabIndex = 1;
            // 
            // FerryOwnerPanel
            // 
            FerryOwnerPanel.BackColor = SystemColors.ButtonFace;
            FerryOwnerPanel.Location = new Point(12, 159);
            FerryOwnerPanel.Name = "FerryOwnerPanel";
            FerryOwnerPanel.Size = new Size(1761, 551);
            FerryOwnerPanel.TabIndex = 2;
            // 
            // navDashboard
            // 
            navDashboard.Location = new Point(116, 124);
            navDashboard.Name = "navDashboard";
            navDashboard.Size = new Size(240, 29);
            navDashboard.TabIndex = 3;
            navDashboard.Text = "Dashboard";
            navDashboard.UseVisualStyleBackColor = true;
            navDashboard.Click += navDashboard_Click;
            // 
            // navSummary
            // 
            navSummary.Location = new Point(1395, 124);
            navSummary.Name = "navSummary";
            navSummary.Size = new Size(240, 29);
            navSummary.TabIndex = 4;
            navSummary.Text = "Booking Summary";
            navSummary.UseVisualStyleBackColor = true;
            navSummary.Click += navSummary_Click;
            // 
            // navSchedule
            // 
            navSchedule.Location = new Point(618, 124);
            navSchedule.Name = "navSchedule";
            navSchedule.Size = new Size(250, 29);
            navSchedule.TabIndex = 5;
            navSchedule.Text = "Routes and Schedule";
            navSchedule.UseVisualStyleBackColor = true;
            navSchedule.Click += navSchedule_Click;
            // 
            // navFerries
            // 
            navFerries.Location = new Point(362, 124);
            navFerries.Name = "navFerries";
            navFerries.Size = new Size(250, 29);
            navFerries.TabIndex = 6;
            navFerries.Text = "My Ferries";
            navFerries.UseVisualStyleBackColor = true;
            navFerries.Click += navFerries_Click;
            // 
            // navRefunds
            // 
            
            navRefunds.ForeColor = Color.Black;
            navRefunds.Location = new Point(1145, 124);
            navRefunds.Name = "navRefunds";
            navRefunds.Size = new Size(244, 29);
            navRefunds.TabIndex = 7;
            navRefunds.Text = "Refunds & Cancellations";
            navRefunds.UseVisualStyleBackColor = true;
            navRefunds.Click += navRefunds_Click;
            // 
            // navCancelledTrips
            // 
            navCancelledTrips.BackColor = SystemColors.Control;
            
            navCancelledTrips.ForeColor = Color.Black;
            navCancelledTrips.Location = new Point(874, 124);
            navCancelledTrips.Name = "navCancelledTrips";
            navCancelledTrips.Size = new Size(265, 29);
            navCancelledTrips.TabIndex = 8;
            navCancelledTrips.Text = "Cancelled Trips";
            navCancelledTrips.UseVisualStyleBackColor = true;
            navCancelledTrips.Click += navCancelledTrips_Click;
            // 
            // OwnerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1785, 739);
            Controls.Add(navCancelledTrips);
            Controls.Add(navRefunds);
            Controls.Add(navFerries);
            Controls.Add(navSchedule);
            Controls.Add(navSummary);
            Controls.Add(navDashboard);
            Controls.Add(FerryOwnerPanel);
            Controls.Add(panel1);
            Controls.Add(HeaderPanel);
            Name = "OwnerForm";
            Text = "OwnerForm";
            Load += FerryOwnerForm_Load;
            HeaderPanel.ResumeLayout(false);
            HeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)headerLogoPictureBox).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel HeaderPanel;
        private PictureBox headerLogoPictureBox;
        private Label headerTitleLabel;
        private Label headerSubtitleLabel;
        private Button btnLogout;
        private Label label1;
        private Panel panel1;
        private Panel FerryOwnerPanel;
        private Button navDashboard;
        private Button navSummary;
        private Button navSchedule;
        private Button navFerries;
        private Label lblOwnerName;
        private Button navRefunds;
        private Button navCancelledTrips;
    }
}