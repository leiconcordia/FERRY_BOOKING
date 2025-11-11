namespace FERRY_BOOKING.UC_Staff
{
    partial class PassengerInfoControl
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
            txtFullName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtAge = new TextBox();
            txtPhone = new TextBox();
            cmbGender = new ComboBox();
            cmbDiscount = new ComboBox();
            label5 = new Label();
            btnUploadID = new Button();
            lblSeat = new Label();
            SuspendLayout();
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(26, 84);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(260, 27);
            txtFullName.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(11, 94, 235);
            label1.Location = new Point(26, 58);
            label1.Name = "label1";
            label1.Size = new Size(93, 23);
            label1.TabIndex = 2;
            label1.Text = "Full name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(11, 94, 235);
            label2.Location = new Point(24, 133);
            label2.Name = "label2";
            label2.Size = new Size(52, 23);
            label2.TabIndex = 3;
            label2.Text = "Age: ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(11, 94, 235);
            label3.Location = new Point(232, 128);
            label3.Name = "label3";
            label3.Size = new Size(74, 23);
            label3.TabIndex = 4;
            label3.Text = "Gender:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(11, 94, 235);
            label4.Location = new Point(24, 189);
            label4.Name = "label4";
            label4.Size = new Size(154, 23);
            label4.TabIndex = 5;
            label4.Text = "Contact Number: ";
            // 
            // txtAge
            // 
            txtAge.Location = new Point(72, 127);
            txtAge.Name = "txtAge";
            txtAge.Size = new Size(96, 27);
            txtAge.TabIndex = 6;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(24, 225);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(260, 27);
            txtPhone.TabIndex = 7;
            // 
            // cmbGender
            // 
            cmbGender.FormattingEnabled = true;
            cmbGender.Location = new Point(312, 128);
            cmbGender.Name = "cmbGender";
            cmbGender.Size = new Size(151, 28);
            cmbGender.TabIndex = 8;
            // 
            // cmbDiscount
            // 
            cmbDiscount.FormattingEnabled = true;
            cmbDiscount.Location = new Point(31, 315);
            cmbDiscount.Name = "cmbDiscount";
            cmbDiscount.Size = new Size(151, 28);
            cmbDiscount.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(11, 94, 235);
            label5.Location = new Point(31, 279);
            label5.Name = "label5";
            label5.Size = new Size(128, 23);
            label5.TabIndex = 10;
            label5.Text = "Discount Type:";
            // 
            // btnUploadID
            // 
            btnUploadID.BackColor = Color.FromArgb(11, 94, 235);
            btnUploadID.ForeColor = SystemColors.ButtonHighlight;
            btnUploadID.Location = new Point(188, 301);
            btnUploadID.Name = "btnUploadID";
            btnUploadID.Size = new Size(107, 54);
            btnUploadID.TabIndex = 11;
            btnUploadID.Text = "Upload ID";
            btnUploadID.UseVisualStyleBackColor = false;
            // 
            // lblSeat
            // 
            lblSeat.AutoSize = true;
            lblSeat.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSeat.ForeColor = Color.FromArgb(11, 94, 235);
            lblSeat.Location = new Point(26, 18);
            lblSeat.Name = "lblSeat";
            lblSeat.Size = new Size(50, 23);
            lblSeat.TabIndex = 12;
            lblSeat.Text = "Seat:";
          
            // 
            // PassengerInfoControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblSeat);
            Controls.Add(btnUploadID);
            Controls.Add(label5);
            Controls.Add(cmbDiscount);
            Controls.Add(cmbGender);
            Controls.Add(txtPhone);
            Controls.Add(txtAge);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtFullName);
            Name = "PassengerInfoControl";
            Size = new Size(493, 466);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtFullName;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtAge;
        private TextBox txtPhone;
        private ComboBox cmbGender;
        private ComboBox cmbDiscount;
        private Label label5;
        private Button btnUploadID;
        private Label lblSeat;

    }
}
