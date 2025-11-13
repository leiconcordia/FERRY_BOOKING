namespace FERRY_BOOKING.Dialogs
{
    partial class AddSchedule
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
            cbFerry = new ComboBox();
            label1 = new Label();
            lblCompanyNameFleet = new Label();
            label5 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // cbFerry
            // 
            cbFerry.FormattingEnabled = true;
            cbFerry.Location = new Point(12, 77);
            cbFerry.Name = "cbFerry";
            cbFerry.Size = new Size(242, 28);
            cbFerry.TabIndex = 47;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(3, 26);
            label1.Name = "label1";
            label1.Size = new Size(239, 20);
            label1.TabIndex = 49;
            label1.Text = "Set up departure times and pricing";
            // 
            // lblCompanyNameFleet
            // 
            lblCompanyNameFleet.AutoSize = true;
            lblCompanyNameFleet.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCompanyNameFleet.ForeColor = Color.FromArgb(11, 94, 235);
            lblCompanyNameFleet.Location = new Point(0, -30);
            lblCompanyNameFleet.Name = "lblCompanyNameFleet";
            lblCompanyNameFleet.Size = new Size(190, 56);
            lblCompanyNameFleet.TabIndex = 48;
            lblCompanyNameFleet.Text = "\r\nAdd New Schedule";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(11, 94, 235);
            label5.Location = new Point(12, 54);
            label5.Name = "label5";
            label5.Size = new Size(45, 20);
            label5.TabIndex = 50;
            label5.Text = "Ferry ";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(11, 94, 235);
            label2.Location = new Point(275, 54);
            label2.Name = "label2";
            label2.Size = new Size(48, 20);
            label2.TabIndex = 51;
            label2.Text = "Route";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(275, 77);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(242, 28);
            comboBox1.TabIndex = 52;
            // 
            // AddSchedule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(533, 498);
            Controls.Add(comboBox1);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(lblCompanyNameFleet);
            Controls.Add(cbFerry);
            Name = "AddSchedule";
            Text = "Schedule";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox cbFerry;
        private Label label1;
        private Label lblCompanyNameFleet;
        private Label label5;
        private Label label2;
        private ComboBox comboBox1;
    }
}