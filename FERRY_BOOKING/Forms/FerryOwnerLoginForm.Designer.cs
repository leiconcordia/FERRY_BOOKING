using System;
using System.Drawing;
using System.Windows.Forms;

namespace FERRY_BOOKING.Forms
{
    partial class FerryOwnerLoginForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel cardPanel;
        private System.Windows.Forms.Panel loginPanel;
        private System.Windows.Forms.Panel registerPanel;

        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button tabLoginButton;
        private System.Windows.Forms.Button tabRegisterButton;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnSignIn;

        // Register controls
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.TextBox txtCompanyName;
        private System.Windows.Forms.Label lblFirstName;
        private System.Windows.Forms.TextBox txtFirstName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.TextBox txtLastName;
        private System.Windows.Forms.Label lblRegTitle;
        private System.Windows.Forms.Label lblRegSubtitle;
        private System.Windows.Forms.Label lblRegUsername;
        private System.Windows.Forms.TextBox txtRegUsername;
        private System.Windows.Forms.Label lblRegPassword;
        private System.Windows.Forms.TextBox txtRegPassword;
        private System.Windows.Forms.Label lblRegConfirm;
        private System.Windows.Forms.TextBox txtRegConfirm;
        private System.Windows.Forms.Button btnRegister;

        // Shared header controls for register panel
        private System.Windows.Forms.PictureBox logoPictureBoxReg;
        private System.Windows.Forms.Button tabLoginButtonReg;
        private System.Windows.Forms.Button tabRegisterButtonReg;

        private System.Windows.Forms.OpenFileDialog openFileDialog1;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            cardPanel = new Panel();
            loginPanel = new Panel();
            logoPictureBox = new PictureBox();
            lblTitle = new Label();
            lblSubtitle = new Label();
            tabLoginButton = new Button();
            tabRegisterButton = new Button();
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnSignIn = new Button();
            registerPanel = new Panel();
            logoPictureBoxReg = new PictureBox();
            lblRegTitle = new Label();
            lblRegSubtitle = new Label();
            tabLoginButtonReg = new Button();
            tabRegisterButtonReg = new Button();
            lblCompanyName = new Label();
            txtCompanyName = new TextBox();
            lblFirstName = new Label();
            txtFirstName = new TextBox();
            lblLastName = new Label();
            txtLastName = new TextBox();
            lblRegUsername = new Label();
            txtRegUsername = new TextBox();
            lblRegPassword = new Label();
            txtRegPassword = new TextBox();
            lblRegConfirm = new Label();
            txtRegConfirm = new TextBox();
            btnRegister = new Button();
            openFileDialog1 = new OpenFileDialog();
            cardPanel.SuspendLayout();
            loginPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).BeginInit();
            registerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBoxReg).BeginInit();
            SuspendLayout();
            // 
            // cardPanel
            // 
            cardPanel.Anchor = AnchorStyles.None;
            cardPanel.BackColor = Color.White;
            cardPanel.Controls.Add(loginPanel);
            cardPanel.Controls.Add(registerPanel);
            cardPanel.Location = new Point(416, 66);
            cardPanel.Name = "cardPanel";
            cardPanel.Size = new Size(520, 700);
            cardPanel.TabIndex = 0;
            // 
            // loginPanel
            // 
            loginPanel.BackColor = Color.Transparent;
            loginPanel.Controls.Add(logoPictureBox);
            loginPanel.Controls.Add(lblTitle);
            loginPanel.Controls.Add(lblSubtitle);
            loginPanel.Controls.Add(tabLoginButton);
            loginPanel.Controls.Add(tabRegisterButton);
            loginPanel.Controls.Add(lblUsername);
            loginPanel.Controls.Add(txtUsername);
            loginPanel.Controls.Add(lblPassword);
            loginPanel.Controls.Add(txtPassword);
            loginPanel.Controls.Add(btnSignIn);
            loginPanel.Dock = DockStyle.Fill;
            loginPanel.Location = new Point(0, 0);
            loginPanel.Name = "loginPanel";
            loginPanel.Size = new Size(520, 700);
            loginPanel.TabIndex = 0;
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
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 9F);
            lblSubtitle.ForeColor = Color.Gray;
            lblSubtitle.Location = new Point(100, 190);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(344, 20);
            lblSubtitle.TabIndex = 2;
            lblSubtitle.Text = "Sign in or create an account to access the platform";
            lblSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabLoginButton
            // 
            tabLoginButton.BackColor = Color.Gainsboro;
            tabLoginButton.FlatAppearance.BorderSize = 0;
            tabLoginButton.FlatStyle = FlatStyle.Flat;
            tabLoginButton.Location = new Point(50, 230);
            tabLoginButton.Name = "tabLoginButton";
            tabLoginButton.Size = new Size(220, 36);
            tabLoginButton.TabIndex = 3;
            tabLoginButton.Text = "Login";
            tabLoginButton.UseVisualStyleBackColor = false;
            tabLoginButton.Click += tabLoginButton_Click;
            // 
            // tabRegisterButton
            // 
            tabRegisterButton.BackColor = Color.WhiteSmoke;
            tabRegisterButton.FlatAppearance.BorderSize = 0;
            tabRegisterButton.FlatStyle = FlatStyle.Flat;
            tabRegisterButton.Location = new Point(270, 230);
            tabRegisterButton.Name = "tabRegisterButton";
            tabRegisterButton.Size = new Size(220, 36);
            tabRegisterButton.TabIndex = 4;
            tabRegisterButton.Text = "Register";
            tabRegisterButton.UseVisualStyleBackColor = false;
            tabRegisterButton.Click += tabRegisterButton_Click;
            // 
            // lblUsername
            // 
            lblUsername.AutoSize = true;
            lblUsername.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUsername.ForeColor = Color.FromArgb(50, 50, 50);
            lblUsername.Location = new Point(40, 290);
            lblUsername.Name = "lblUsername";
            lblUsername.Size = new Size(47, 20);
            lblUsername.TabIndex = 5;
            lblUsername.Text = "Email";
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
            txtPassword.UseSystemPasswordChar = true;
            // 
            // btnSignIn
            // 
            btnSignIn.BackColor = Color.FromArgb(11, 94, 235);
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
            // registerPanel
            // 
            registerPanel.BackColor = Color.Transparent;
            registerPanel.Controls.Add(logoPictureBoxReg);
            registerPanel.Controls.Add(lblRegTitle);
            registerPanel.Controls.Add(lblRegSubtitle);
            registerPanel.Controls.Add(tabLoginButtonReg);
            registerPanel.Controls.Add(tabRegisterButtonReg);
            registerPanel.Controls.Add(lblCompanyName);
            registerPanel.Controls.Add(txtCompanyName);
            registerPanel.Controls.Add(lblFirstName);
            registerPanel.Controls.Add(txtFirstName);
            registerPanel.Controls.Add(lblLastName);
            registerPanel.Controls.Add(txtLastName);
            registerPanel.Controls.Add(lblRegUsername);
            registerPanel.Controls.Add(txtRegUsername);
            registerPanel.Controls.Add(lblRegPassword);
            registerPanel.Controls.Add(txtRegPassword);
            registerPanel.Controls.Add(lblRegConfirm);
            registerPanel.Controls.Add(txtRegConfirm);
            registerPanel.Controls.Add(btnRegister);
            registerPanel.Dock = DockStyle.Fill;
            registerPanel.Location = new Point(0, 0);
            registerPanel.Name = "registerPanel";
            registerPanel.Size = new Size(520, 700);
            registerPanel.TabIndex = 1;
            registerPanel.Visible = false;
            // 
            // logoPictureBoxReg
            // 
            logoPictureBoxReg.Image = Properties.Resources.Ferry_Logo;
            logoPictureBoxReg.Location = new Point(200, 30);
            logoPictureBoxReg.Name = "logoPictureBoxReg";
            logoPictureBoxReg.Size = new Size(120, 120);
            logoPictureBoxReg.SizeMode = PictureBoxSizeMode.Zoom;
            logoPictureBoxReg.TabIndex = 100;
            logoPictureBoxReg.TabStop = false;
            // 
            // lblRegTitle
            // 
            lblRegTitle.AutoSize = true;
            lblRegTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblRegTitle.ForeColor = Color.FromArgb(35, 35, 35);
            lblRegTitle.Location = new Point(160, 160);
            lblRegTitle.Name = "lblRegTitle";
            lblRegTitle.Size = new Size(280, 28);
            lblRegTitle.TabIndex = 101;
            lblRegTitle.Text = "Create Ferry Owner Account";
            lblRegTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblRegSubtitle
            // 
            lblRegSubtitle.AutoSize = true;
            lblRegSubtitle.Font = new Font("Segoe UI", 9F);
            lblRegSubtitle.ForeColor = Color.Gray;
            lblRegSubtitle.Location = new Point(100, 190);
            lblRegSubtitle.Name = "lblRegSubtitle";
            lblRegSubtitle.Size = new Size(351, 20);
            lblRegSubtitle.TabIndex = 102;
            lblRegSubtitle.Text = "Fill the details to register a new ferry owner account";
            lblRegSubtitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // tabLoginButtonReg
            // 
            tabLoginButtonReg.BackColor = Color.WhiteSmoke;
            tabLoginButtonReg.FlatAppearance.BorderSize = 0;
            tabLoginButtonReg.FlatStyle = FlatStyle.Flat;
            tabLoginButtonReg.Location = new Point(50, 230);
            tabLoginButtonReg.Name = "tabLoginButtonReg";
            tabLoginButtonReg.Size = new Size(220, 36);
            tabLoginButtonReg.TabIndex = 110;
            tabLoginButtonReg.Text = "Login";
            tabLoginButtonReg.UseVisualStyleBackColor = false;
            tabLoginButtonReg.Click += tabLoginButton_Click;
            // 
            // tabRegisterButtonReg
            // 
            tabRegisterButtonReg.BackColor = Color.Gainsboro;
            tabRegisterButtonReg.FlatAppearance.BorderSize = 0;
            tabRegisterButtonReg.FlatStyle = FlatStyle.Flat;
            tabRegisterButtonReg.Location = new Point(270, 230);
            tabRegisterButtonReg.Name = "tabRegisterButtonReg";
            tabRegisterButtonReg.Size = new Size(220, 36);
            tabRegisterButtonReg.TabIndex = 111;
            tabRegisterButtonReg.Text = "Register";
            tabRegisterButtonReg.UseVisualStyleBackColor = false;
            tabRegisterButtonReg.Click += tabRegisterButton_Click;
            // 
            // lblCompanyName
            // 
            lblCompanyName.AutoSize = true;
            lblCompanyName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCompanyName.ForeColor = Color.FromArgb(50, 50, 50);
            lblCompanyName.Location = new Point(40, 290);
            lblCompanyName.Name = "lblCompanyName";
            lblCompanyName.Size = new Size(121, 20);
            lblCompanyName.TabIndex = 112;
            lblCompanyName.Text = "Company Name";
            // 
            // txtCompanyName
            // 
            txtCompanyName.BorderStyle = BorderStyle.FixedSingle;
            txtCompanyName.Font = new Font("Segoe UI", 9F);
            txtCompanyName.ForeColor = Color.Gray;
            txtCompanyName.Location = new Point(40, 310);
            txtCompanyName.Name = "txtCompanyName";
            txtCompanyName.Size = new Size(440, 27);
            txtCompanyName.TabIndex = 113;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFirstName.ForeColor = Color.FromArgb(50, 50, 50);
            lblFirstName.Location = new Point(40, 350);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(86, 20);
            lblFirstName.TabIndex = 114;
            lblFirstName.Text = "First Name";
            // 
            // txtFirstName
            // 
            txtFirstName.BorderStyle = BorderStyle.FixedSingle;
            txtFirstName.Font = new Font("Segoe UI", 9F);
            txtFirstName.ForeColor = Color.Gray;
            txtFirstName.Location = new Point(40, 370);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(440, 27);
            txtFirstName.TabIndex = 115;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblLastName.ForeColor = Color.FromArgb(50, 50, 50);
            lblLastName.Location = new Point(40, 410);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(84, 20);
            lblLastName.TabIndex = 116;
            lblLastName.Text = "Last Name";
            // 
            // txtLastName
            // 
            txtLastName.BorderStyle = BorderStyle.FixedSingle;
            txtLastName.Font = new Font("Segoe UI", 9F);
            txtLastName.ForeColor = Color.Gray;
            txtLastName.Location = new Point(40, 430);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(440, 27);
            txtLastName.TabIndex = 117;
            // 
            // lblRegUsername
            // 
            lblRegUsername.AutoSize = true;
            lblRegUsername.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRegUsername.ForeColor = Color.FromArgb(50, 50, 50);
            lblRegUsername.Location = new Point(40, 470);
            lblRegUsername.Name = "lblRegUsername";
            lblRegUsername.Size = new Size(47, 20);
            lblRegUsername.TabIndex = 118;
            lblRegUsername.Text = "Email";
            // 
            // txtRegUsername
            // 
            txtRegUsername.BorderStyle = BorderStyle.FixedSingle;
            txtRegUsername.Font = new Font("Segoe UI", 9F);
            txtRegUsername.ForeColor = Color.Gray;
            txtRegUsername.Location = new Point(40, 490);
            txtRegUsername.Name = "txtRegUsername";
            txtRegUsername.Size = new Size(440, 27);
            txtRegUsername.TabIndex = 119;
            // 
            // lblRegPassword
            // 
            lblRegPassword.AutoSize = true;
            lblRegPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRegPassword.ForeColor = Color.FromArgb(50, 50, 50);
            lblRegPassword.Location = new Point(40, 530);
            lblRegPassword.Name = "lblRegPassword";
            lblRegPassword.Size = new Size(76, 20);
            lblRegPassword.TabIndex = 120;
            lblRegPassword.Text = "Password";
            // 
            // txtRegPassword
            // 
            txtRegPassword.BorderStyle = BorderStyle.FixedSingle;
            txtRegPassword.Font = new Font("Segoe UI", 9F);
            txtRegPassword.ForeColor = Color.Gray;
            txtRegPassword.Location = new Point(40, 550);
            txtRegPassword.Name = "txtRegPassword";
            txtRegPassword.Size = new Size(440, 27);
            txtRegPassword.TabIndex = 121;
            txtRegPassword.UseSystemPasswordChar = true;
            // 
            // lblRegConfirm
            // 
            lblRegConfirm.AutoSize = true;
            lblRegConfirm.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRegConfirm.ForeColor = Color.FromArgb(50, 50, 50);
            lblRegConfirm.Location = new Point(40, 590);
            lblRegConfirm.Name = "lblRegConfirm";
            lblRegConfirm.Size = new Size(137, 20);
            lblRegConfirm.TabIndex = 122;
            lblRegConfirm.Text = "Confirm Password";
            // 
            // txtRegConfirm
            // 
            txtRegConfirm.BorderStyle = BorderStyle.FixedSingle;
            txtRegConfirm.Font = new Font("Segoe UI", 9F);
            txtRegConfirm.ForeColor = Color.Gray;
            txtRegConfirm.Location = new Point(40, 610);
            txtRegConfirm.Name = "txtRegConfirm";
            txtRegConfirm.Size = new Size(440, 27);
            txtRegConfirm.TabIndex = 123;
            txtRegConfirm.UseSystemPasswordChar = true;
            // 
            // btnRegister
            // 
            btnRegister.BackColor = Color.FromArgb(11, 94, 235);
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.FlatStyle = FlatStyle.Flat;
            btnRegister.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnRegister.ForeColor = Color.White;
            btnRegister.Location = new Point(40, 650);
            btnRegister.Name = "btnRegister";
            btnRegister.Size = new Size(440, 44);
            btnRegister.TabIndex = 124;
            btnRegister.Text = "Register";
            btnRegister.UseVisualStyleBackColor = false;
            btnRegister.Click += btnRegister_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // FerryOwnerLoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Ferry_BG;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1352, 800);
            Controls.Add(cardPanel);
            Name = "FerryOwnerLoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ferry Owner Login";
            WindowState = FormWindowState.Maximized;
            Load += FerryOwnerLogin_Load;
            Resize += FerryOwnerLogin_Resize;
            cardPanel.ResumeLayout(false);
            loginPanel.ResumeLayout(false);
            loginPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBox).EndInit();
            registerPanel.ResumeLayout(false);
            registerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logoPictureBoxReg).EndInit();
            ResumeLayout(false);
        }
        #endregion
    }
}