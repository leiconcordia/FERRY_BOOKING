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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.cbFerry = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tbOriginPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbDestinationPort = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.nudDistance = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.nudHours = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.nudMin = new System.Windows.Forms.NumericUpDown();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAddRoute = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHours)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.lblSubtitle);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 80);
            this.panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(238, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Add Ferry Route";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.White;
            this.lblSubtitle.Location = new System.Drawing.Point(20, 52);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(316, 23);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Configure ferry routes and destinations";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cbFerry);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(20, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(560, 80);
            this.panel2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.label5.Location = new System.Drawing.Point(15, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 23);
            this.label5.TabIndex = 0;
            this.label5.Text = "Ferry";
            // 
            // cbFerry
            // 
            this.cbFerry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFerry.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbFerry.FormattingEnabled = true;
            this.cbFerry.Location = new System.Drawing.Point(15, 40);
            this.cbFerry.Name = "cbFerry";
            this.cbFerry.Size = new System.Drawing.Size(530, 31);
            this.cbFerry.TabIndex = 1;
            this.cbFerry.SelectedIndexChanged += new System.EventHandler(this.cbFerry_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tbDestinationPort);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.tbOriginPort);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Location = new System.Drawing.Point(20, 195);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(560, 100);
            this.panel3.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Origin Port";
            // 
            // tbOriginPort
            // 
            this.tbOriginPort.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbOriginPort.Location = new System.Drawing.Point(15, 45);
            this.tbOriginPort.Name = "tbOriginPort";
            this.tbOriginPort.PlaceholderText = "e.g., Manila";
            this.tbOriginPort.Size = new System.Drawing.Size(250, 30);
            this.tbOriginPort.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.label3.Location = new System.Drawing.Point(295, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Destination Port";
            // 
            // tbDestinationPort
            // 
            this.tbDestinationPort.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tbDestinationPort.Location = new System.Drawing.Point(295, 45);
            this.tbDestinationPort.Name = "tbDestinationPort";
            this.tbDestinationPort.PlaceholderText = "e.g., Cebu";
            this.tbDestinationPort.Size = new System.Drawing.Size(250, 30);
            this.tbDestinationPort.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.nudMin);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Controls.Add(this.nudHours);
            this.panel4.Controls.Add(this.label7);
            this.panel4.Controls.Add(this.nudDistance);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(20, 310);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(560, 100);
            this.panel4.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.label4.Location = new System.Drawing.Point(15, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(123, 23);
            this.label4.TabIndex = 0;
            this.label4.Text = "Distance (km)";
            // 
            // nudDistance
            // 
            this.nudDistance.DecimalPlaces = 2;
            this.nudDistance.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudDistance.Increment = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.nudDistance.Location = new System.Drawing.Point(15, 45);
            this.nudDistance.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.nudDistance.Name = "nudDistance";
            this.nudDistance.Size = new System.Drawing.Size(150, 30);
            this.nudDistance.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.label7.Location = new System.Drawing.Point(220, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(162, 23);
            this.label7.TabIndex = 2;
            this.label7.Text = "Est. Duration (hrs)";
            // 
            // nudHours
            // 
            this.nudHours.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudHours.Location = new System.Drawing.Point(220, 45);
            this.nudHours.Maximum = new decimal(new int[] {
            48,
            0,
            0,
            0});
            this.nudHours.Name = "nudHours";
            this.nudHours.Size = new System.Drawing.Size(80, 30);
            this.nudHours.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.label8.ForeColor = System.Drawing.Color.Gray;
            this.label8.Location = new System.Drawing.Point(310, 50);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = ":";
            // 
            // nudMin
            // 
            this.nudMin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.nudMin.Increment = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.nudMin.Location = new System.Drawing.Point(335, 45);
            this.nudMin.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.nudMin.Name = "nudMin";
            this.nudMin.Size = new System.Drawing.Size(80, 30);
            this.nudMin.TabIndex = 5;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel5.Controls.Add(this.btnAddRoute);
            this.panel5.Controls.Add(this.btnCancel);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel5.Location = new System.Drawing.Point(0, 430);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(600, 70);
            this.panel5.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.btnCancel.Location = new System.Drawing.Point(360, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(110, 40);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddRoute
            // 
            this.btnAddRoute.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.btnAddRoute.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddRoute.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddRoute.ForeColor = System.Drawing.Color.White;
            this.btnAddRoute.Location = new System.Drawing.Point(480, 15);
            this.btnAddRoute.Name = "btnAddRoute";
            this.btnAddRoute.Size = new System.Drawing.Size(110, 40);
            this.btnAddRoute.TabIndex = 1;
            this.btnAddRoute.Text = "Save";
            this.btnAddRoute.UseVisualStyleBackColor = false;
            this.btnAddRoute.Click += new System.EventHandler(this.btnAddRoute_Click);
            // 
            // AddRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(600, 500);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddRoute";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add Ferry Route";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDistance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHours)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudMin)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbFerry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tbDestinationPort;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbOriginPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.NumericUpDown nudMin;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudHours;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown nudDistance;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnAddRoute;
        private System.Windows.Forms.Button btnCancel;
    }
}