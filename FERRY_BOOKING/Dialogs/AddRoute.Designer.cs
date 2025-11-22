namespace FERRY_BOOKING.Dialogs
{
    partial class AddRoute
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
            btnAddRoute = new Button();
            btnCancel = new Button();
            nudHours = new NumericUpDown();
            nudDistance = new NumericUpDown();
            label6 = new Label();
            label4 = new Label();
            tbDestinationPort = new TextBox();
            tbOriginPort = new TextBox();
            label3 = new Label();
            label2 = new Label();
            cbFerry = new ComboBox();
            label5 = new Label();
            label1 = new Label();
            lblCompanyNameFleet = new Label();
            nudMin = new NumericUpDown();
            label7 = new Label();
            label8 = new Label();
            ((System.ComponentModel.ISupportInitialize)nudHours).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDistance).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudMin).BeginInit();
            SuspendLayout();
            // 
            // btnAddRoute
            // 
            btnAddRoute.BackColor = Color.FromArgb(11, 94, 235);
            btnAddRoute.ForeColor = SystemColors.ButtonHighlight;
            btnAddRoute.Location = new Point(277, 323);
            btnAddRoute.Name = "btnAddRoute";
            btnAddRoute.Size = new Size(113, 44);
            btnAddRoute.TabIndex = 56;
            btnAddRoute.Text = "Add Route";
            btnAddRoute.UseVisualStyleBackColor = false;
            btnAddRoute.Click += btnAddRoute_Click;
            // 
            // btnCancel
            // 
            btnCancel.ForeColor = Color.FromArgb(11, 94, 235);
            btnCancel.Location = new Point(193, 323);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(77, 44);
            btnCancel.TabIndex = 55;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // nudHours
            // 
            nudHours.Location = new Point(205, 285);
            nudHours.Name = "nudHours";
            nudHours.Size = new Size(50, 27);
            nudHours.TabIndex = 54;
            // 
            // nudDistance
            // 
            nudDistance.Location = new Point(9, 260);
            nudDistance.Name = "nudDistance";
            nudDistance.Size = new Size(150, 27);
            nudDistance.TabIndex = 53;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(11, 94, 235);
            label6.Location = new Point(203, 236);
            label6.Name = "label6";
            label6.Size = new Size(132, 20);
            label6.TabIndex = 52;
            label6.Text = "Est. Duration (min)";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(11, 94, 235);
            label4.Location = new Point(8, 236);
            label4.Name = "label4";
            label4.Size = new Size(100, 20);
            label4.TabIndex = 51;
            label4.Text = "Distance (km)";
            // 
            // tbDestinationPort
            // 
            tbDestinationPort.Location = new Point(203, 176);
            tbDestinationPort.Name = "tbDestinationPort";
            tbDestinationPort.Size = new Size(163, 27);
            tbDestinationPort.TabIndex = 50;
            // 
            // tbOriginPort
            // 
            tbOriginPort.Location = new Point(8, 176);
            tbOriginPort.Name = "tbOriginPort";
            tbOriginPort.Size = new Size(163, 27);
            tbOriginPort.TabIndex = 49;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(11, 94, 235);
            label3.Location = new Point(203, 153);
            label3.Name = "label3";
            label3.Size = new Size(115, 20);
            label3.TabIndex = 48;
            label3.Text = "Destination Port";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(11, 94, 235);
            label2.Location = new Point(8, 153);
            label2.Name = "label2";
            label2.Size = new Size(80, 20);
            label2.TabIndex = 47;
            label2.Text = "Origin Port";
            // 
            // cbFerry
            // 
            cbFerry.FormattingEnabled = true;
            cbFerry.Location = new Point(8, 94);
            cbFerry.Name = "cbFerry";
            cbFerry.Size = new Size(382, 28);
            cbFerry.TabIndex = 46;
            cbFerry.SelectedIndexChanged += cbFerry_SelectedIndexChanged;

            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(11, 94, 235);
            label5.Location = new Point(8, 71);
            label5.Name = "label5";
            label5.Size = new Size(45, 20);
            label5.TabIndex = 45;
            label5.Text = "Ferry ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(1, 31);
            label1.Name = "label1";
            label1.Size = new Size(292, 20);
            label1.TabIndex = 44;
            label1.Text = "Manage your ferry fleet and configurations";
            // 
            // lblCompanyNameFleet
            // 
            lblCompanyNameFleet.AutoSize = true;
            lblCompanyNameFleet.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCompanyNameFleet.ForeColor = Color.FromArgb(11, 94, 235);
            lblCompanyNameFleet.Location = new Point(-2, -25);
            lblCompanyNameFleet.Name = "lblCompanyNameFleet";
            lblCompanyNameFleet.Size = new Size(161, 56);
            lblCompanyNameFleet.TabIndex = 43;
            lblCompanyNameFleet.Text = "\r\nAdd New Route";
            // 
            // nudMin
            // 
            nudMin.Location = new Point(285, 285);
            nudMin.Name = "nudMin";
            nudMin.Size = new Size(50, 27);
            nudMin.TabIndex = 57;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(11, 94, 235);
            label7.Location = new Point(205, 262);
            label7.Name = "label7";
            label7.Size = new Size(48, 20);
            label7.TabIndex = 58;
            label7.Text = "Hours";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(11, 94, 235);
            label8.Location = new Point(285, 262);
            label8.Name = "label8";
            label8.Size = new Size(34, 20);
            label8.TabIndex = 59;
            label8.Text = "Min";
            // 
            // AddRoute
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(402, 389);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(nudMin);
            Controls.Add(btnAddRoute);
            Controls.Add(btnCancel);
            Controls.Add(nudHours);
            Controls.Add(nudDistance);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(tbDestinationPort);
            Controls.Add(tbOriginPort);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(cbFerry);
            Controls.Add(label5);
            Controls.Add(label1);
            Controls.Add(lblCompanyNameFleet);
            Name = "AddRoute";
            Text = "Route";
            ((System.ComponentModel.ISupportInitialize)nudHours).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDistance).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudMin).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAddRoute;
        private Button btnCancel;
        private NumericUpDown nudHours;
        private NumericUpDown nudDistance;
        private Label label6;
        private Label label4;
        private TextBox tbDestinationPort;
        private TextBox tbOriginPort;
        private Label label3;
        private Label label2;
        private ComboBox cbFerry;
        private Label label5;
        private Label label1;
        private Label lblCompanyNameFleet;
        private NumericUpDown nudMin;
        private Label label7;
        private Label label8;
    }
}