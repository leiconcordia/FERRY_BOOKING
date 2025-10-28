namespace FERRY_BOOKING.Forms
{
    partial class StaffLoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel cardPanel;
        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button tabLoginButton;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnSignIn;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            cardPanel = new Panel();
            logoPictureBox = new PictureBox();
            lblTitle = new Label();
            tabLoginButton = new Button();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnSignIn = new Button();
            cardPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            SuspendLayout();
            // 
            // cardPanel
            // 
            cardPanel.Anchor = AnchorStyles.None;
            cardPanel.BackColor = Color.White;
            cardPanel.Controls.Add(logoPictureBox);
            cardPanel.Controls.Add(lblTitle);
            cardPanel.Controls.Add(tabLoginButton);
            cardPanel.Controls.Add(lblUsername);
            cardPanel.Controls.Add(txtUsername);
            cardPanel.Controls.Add(lblPassword);
            cardPanel.Controls.Add(txtPassword);
            cardPanel.Controls.Add(btnSignIn);
            cardPanel.Location = new Point(416, 66);
            cardPanel.Name = "cardPanel";
            cardPanel.Size = new Size(520, 560);
            cardPanel.TabIndex = 0;
            // 
            // logoPictureBox
            // 
            logoPictureBox.Image = Properties.Resources.Ferry_Logo;
            logoPictureBox.Location = new Point(200, 30);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(120, 120);
            logoPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            logoPictureBox.TabIndex = 0;
            logoPictureBox.TabStop = false;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(35, 35, 35);
            lblTitle.Location = new Point(160, 160);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(219, 28);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Ferry Booking System";
            // 
            // tabLoginButton
            // 
            tabLoginButton.BackColor = Color.Gray;
            tabLoginButton.FlatAppearance.BorderSize = 0;
            tabLoginButton.FlatStyle = FlatStyle.Flat;
            tabLoginButton.ForeColor = Color.Black;
            tabLoginButton.Location = new Point(147, 227);
            tabLoginButton.Name = "tabLoginButton";
            tabLoginButton.Size = new Size(220, 36);
            tabLoginButton.TabIndex = 3;
            tabLoginButton.Text = "Login";
            tabLoginButton.UseVisualStyleBackColor = false;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(50, 50, 50);
            lblUsername.Location = new Point(40, 290);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(80, 20);
            lblUsername.TabIndex = 5;
            lblUsername.Text = "Username";
            // 
            // txtUsername
            // 
            txtUsername.BorderStyle = BorderStyle.FixedSingle;
            txtUsername.Font = new Font("Segoe UI", 9F);
            txtUsername.ForeColor = Color.Gray;
            txtUsername.Location = new Point(40, 310);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(440, 27);
            txtUsername.TabIndex = 6;
            // 
            // lblPassword
            // 
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(50, 50, 50);
            lblPassword.Location = new Point(40, 350);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(76, 20);
            lblPassword.TabIndex = 7;
            lblPassword.Text = "Password";
            // 
            // txtPassword
            // 
            txtPassword.BorderStyle = BorderStyle.FixedSingle;
            txtPassword.Font = new Font("Segoe UI", 9F);
            txtPassword.ForeColor = Color.Gray;
            txtPassword.Location = new Point(40, 370);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(440, 27);
            txtPassword.TabIndex = 8;
            // 
            // btnSignIn
            // 
            btnSignIn.BackColor = Color.FromArgb(15, 15, 20);
            btnSignIn.FlatAppearance.BorderSize = 0;
            btnSignIn.FlatStyle = FlatStyle.Flat;
            btnSignIn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSignIn.ForeColor = Color.White;
            btnSignIn.Location = new Point(40, 420);
            btnSignIn.Name = "btnSignIn";
            btnSignIn.Size = new Size(440, 44);
            btnSignIn.TabIndex = 9;
            btnSignIn.Text = "Sign In";
            btnSignIn.UseVisualStyleBackColor = false;
            btnSignIn.Click += btnSignIn_Click;
            // 
            // StaffLoginForm
            // 
            BackgroundImage = Properties.Resources.Ferry_BG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1352, 693);
            Controls.Add(cardPanel);
            Name = "StaffLoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Staff Login";
            WindowState = FormWindowState.Maximized;
            Load += StaffLoginForm_Load;
            Resize += StaffLoginForm_Resize;
            cardPanel.ResumeLayout(false);
            cardPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            ResumeLayout(false);
        }
        #endregion
    }
}
