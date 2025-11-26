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
            tbFullName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            tbPhone = new TextBox();
            cmbGender = new ComboBox();
            cmbDiscount = new ComboBox();
            label5 = new Label();
            btnUploadID = new Button();
            lblSeat = new Label();
            nudAge = new NumericUpDown();
            lblPrice = new Label();
            lblFileName = new Label();
            label6 = new Label();
            btnUploadValidID = new Button();
            lblValidIDFileName = new Label();
            ((System.ComponentModel.ISupportInitialize)nudAge).BeginInit();
            SuspendLayout();
            // 
            // tbFullName
            // 
            tbFullName.Location = new Point(26, 84);
            tbFullName.Name = "tbFullName";
            tbFullName.Size = new Size(260, 27);
            tbFullName.TabIndex = 1;
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
            // tbPhone
            // 
            tbPhone.Location = new Point(24, 225);
            tbPhone.Name = "tbPhone";
            tbPhone.Size = new Size(260, 27);
            tbPhone.TabIndex = 7;
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
            btnUploadID.Text = "Upload Discount ID";
            btnUploadID.UseVisualStyleBackColor = false;
            btnUploadID.Click += btnUploadID_Click;
            // 
            // lblSeat
            // 
            lblSeat.AutoSize = true;
            lblSeat.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSeat.ForeColor = Color.FromArgb(255, 193, 7);
            lblSeat.Location = new Point(26, 18);
            lblSeat.Name = "lblSeat";
            lblSeat.Size = new Size(50, 23);
            lblSeat.TabIndex = 12;
            lblSeat.Text = "Seat:";
            // 
            // nudAge
            // 
            nudAge.Location = new Point(76, 133);
            nudAge.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudAge.Name = "nudAge";
            nudAge.Size = new Size(83, 27);
            nudAge.TabIndex = 13;
            nudAge.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrice.ForeColor = Color.FromArgb(255, 193, 7);
            lblPrice.Location = new Point(312, 18);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(50, 23);
            lblPrice.TabIndex = 14;
            lblPrice.Text = "Seat:";
            // 
            // lblFileName
            // 
            lblFileName.AutoSize = true;
            lblFileName.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFileName.ForeColor = Color.Black;
            lblFileName.Location = new Point(31, 371);
            lblFileName.Name = "lblFileName";
            lblFileName.Size = new Size(95, 23);
            lblFileName.TabIndex = 15;
            lblFileName.Text = "File Name:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(11, 94, 235);
            label6.Location = new Point(31, 408);
            label6.Name = "label6";
            label6.Size = new Size(151, 23);
            label6.TabIndex = 16;
            label6.Text = "Valid ID (Required):";
            // 
            // btnUploadValidID
            // 
            btnUploadValidID.BackColor = Color.FromArgb(11, 94, 235);
            btnUploadValidID.ForeColor = SystemColors.ButtonHighlight;
            btnUploadValidID.Location = new Point(188, 396);
            btnUploadValidID.Name = "btnUploadValidID";
            btnUploadValidID.Size = new Size(107, 54);
            btnUploadValidID.TabIndex = 17;
            btnUploadValidID.Text = "Upload Valid ID";
            btnUploadValidID.UseVisualStyleBackColor = false;
            btnUploadValidID.Click += btnUploadValidID_Click;
            // 
            // lblValidIDFileName
            // 
            lblValidIDFileName.AutoSize = true;
            lblValidIDFileName.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblValidIDFileName.ForeColor = Color.Black;
            lblValidIDFileName.Location = new Point(31, 466);
            lblValidIDFileName.Name = "lblValidIDFileName";
            lblValidIDFileName.Size = new Size(118, 23);
            lblValidIDFileName.TabIndex = 18;
            lblValidIDFileName.Text = "No file selected";
            // 
            // PassengerInfoControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblValidIDFileName);
            Controls.Add(btnUploadValidID);
            Controls.Add(label6);
            Controls.Add(lblFileName);
            Controls.Add(lblPrice);
            Controls.Add(nudAge);
            Controls.Add(lblSeat);
            Controls.Add(btnUploadID);
            Controls.Add(label5);
            Controls.Add(cmbDiscount);
            Controls.Add(cmbGender);
            Controls.Add(tbPhone);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbFullName);
            Name = "PassengerInfoControl";
            Size = new Size(482, 510);
            ((System.ComponentModel.ISupportInitialize)nudAge).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox tbFullName;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtAge;
        private TextBox tbPhone;
        private ComboBox cmbGender;
        private ComboBox cmbDiscount;
        private Label label5;
        private Button btnUploadID;
        private Label lblSeat;
        private NumericUpDown nudAge;
        private Label lblPrice;
        private Label lblFileName;
        private Label label6;
        private Button btnUploadValidID;
        private Label lblValidIDFileName;
    }
}
