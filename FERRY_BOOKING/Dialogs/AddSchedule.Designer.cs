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
            cbRoute = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            dtpDepartureTime = new DateTimePicker();
            dtpArrivalTime = new DateTimePicker();
            label6 = new Label();
            btnMon = new Button();
            btnTue = new Button();
            btnWed = new Button();
            btnThu = new Button();
            btnFri = new Button();
            btnSat = new Button();
            btnSun = new Button();
            btnSelectAll = new Button();
            btnAddSchedule = new Button();
            btnCancel = new Button();
            label7 = new Label();
            cbStatus = new ComboBox();
            flpFloorPrice = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // cbFerry
            // 
            cbFerry.FormattingEnabled = true;
            cbFerry.Location = new Point(12, 77);
            cbFerry.Name = "cbFerry";
            cbFerry.Size = new Size(242, 28);
            cbFerry.TabIndex = 47;
            cbFerry.SelectedIndexChanged += cbFerry_SelectedIndexChanged;

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
            // cbRoute
            // 
            cbRoute.FormattingEnabled = true;
            cbRoute.Location = new Point(275, 77);
            cbRoute.Name = "cbRoute";
            cbRoute.Size = new Size(242, 28);
            cbRoute.TabIndex = 52;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(11, 94, 235);
            label3.Location = new Point(12, 131);
            label3.Name = "label3";
            label3.Size = new Size(113, 20);
            label3.TabIndex = 53;
            label3.Text = "Departure Time";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(11, 94, 235);
            label4.Location = new Point(275, 131);
            label4.Name = "label4";
            label4.Size = new Size(89, 20);
            label4.TabIndex = 54;
            label4.Text = "Arrival Time";
            // 
            // dtpDepartureTime
            // 
            dtpDepartureTime.CustomFormat = "hh:mm tt";
            dtpDepartureTime.DropDownAlign = LeftRightAlignment.Right;
            dtpDepartureTime.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtpDepartureTime.Format = DateTimePickerFormat.Time;
            dtpDepartureTime.Location = new Point(12, 154);
            dtpDepartureTime.Name = "dtpDepartureTime";
            dtpDepartureTime.ShowUpDown = true;
            dtpDepartureTime.Size = new Size(242, 34);
            dtpDepartureTime.TabIndex = 55;
            dtpDepartureTime.ValueChanged += dtpDepartureTime_ValueChanged;

            // 
            // dtpArrivalTime
            // 
            dtpArrivalTime.DropDownAlign = LeftRightAlignment.Right;
            dtpArrivalTime.Font = new Font("Segoe UI", 12F);
            dtpArrivalTime.Format = DateTimePickerFormat.Time;
            dtpArrivalTime.Location = new Point(275, 154);
            dtpArrivalTime.Name = "dtpArrivalTime";
            dtpArrivalTime.Size = new Size(242, 34);
            dtpArrivalTime.TabIndex = 56;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(11, 94, 235);
            label6.Location = new Point(12, 203);
            label6.Name = "label6";
            label6.Size = new Size(112, 20);
            label6.TabIndex = 57;
            label6.Text = "Operating Days";
            // 
            // btnMon
            // 
            btnMon.BackColor = Color.FromArgb(0, 0, 192);
            btnMon.ForeColor = Color.FromArgb(255, 193, 7);
            btnMon.Location = new Point(12, 226);
            btnMon.Name = "btnMon";
            btnMon.Size = new Size(58, 29);
            btnMon.TabIndex = 58;
            btnMon.Text = "Mon";
            btnMon.UseVisualStyleBackColor = false;
            btnMon.Click += btnMon_Click;
            // 
            // btnTue
            // 
            btnTue.BackColor = Color.FromArgb(0, 0, 192);
            btnTue.ForeColor = Color.FromArgb(255, 193, 7);
            btnTue.Location = new Point(76, 226);
            btnTue.Name = "btnTue";
            btnTue.Size = new Size(58, 29);
            btnTue.TabIndex = 59;
            btnTue.Text = "Tue";
            btnTue.UseVisualStyleBackColor = false;
            btnTue.Click += btnTue_Click;
            // 
            // btnWed
            // 
            btnWed.BackColor = Color.FromArgb(0, 0, 192);
            btnWed.ForeColor = Color.FromArgb(255, 193, 7);
            btnWed.Location = new Point(140, 226);
            btnWed.Name = "btnWed";
            btnWed.Size = new Size(58, 29);
            btnWed.TabIndex = 60;
            btnWed.Text = "Wed";
            btnWed.UseVisualStyleBackColor = false;
            btnWed.Click += btnWed_Click;
            // 
            // btnThu
            // 
            btnThu.BackColor = Color.FromArgb(0, 0, 192);
            btnThu.ForeColor = Color.FromArgb(255, 193, 7);
            btnThu.Location = new Point(204, 226);
            btnThu.Name = "btnThu";
            btnThu.Size = new Size(58, 29);
            btnThu.TabIndex = 61;
            btnThu.Text = "Thu";
            btnThu.UseVisualStyleBackColor = false;
            btnThu.Click += btnThu_Click;
            // 
            // btnFri
            // 
            btnFri.BackColor = Color.FromArgb(0, 0, 192);
            btnFri.ForeColor = Color.FromArgb(255, 193, 7);
            btnFri.Location = new Point(268, 226);
            btnFri.Name = "btnFri";
            btnFri.Size = new Size(58, 29);
            btnFri.TabIndex = 62;
            btnFri.Text = "Fri";
            btnFri.UseVisualStyleBackColor = false;
            btnFri.Click += btnFri_Click;
            // 
            // btnSat
            // 
            btnSat.BackColor = Color.FromArgb(0, 0, 192);
            btnSat.ForeColor = Color.FromArgb(255, 193, 7);
            btnSat.Location = new Point(332, 226);
            btnSat.Name = "btnSat";
            btnSat.Size = new Size(58, 29);
            btnSat.TabIndex = 63;
            btnSat.Text = "Sat";
            btnSat.UseVisualStyleBackColor = false;
            btnSat.Click += btnSat_Click;
            // 
            // btnSun
            // 
            btnSun.BackColor = Color.FromArgb(0, 0, 192);
            btnSun.ForeColor = Color.FromArgb(255, 193, 7);
            btnSun.Location = new Point(396, 226);
            btnSun.Name = "btnSun";
            btnSun.Size = new Size(58, 29);
            btnSun.TabIndex = 64;
            btnSun.Text = "Sat";
            btnSun.UseVisualStyleBackColor = false;
            btnSun.Click += btnSun_Click;
            // 
            // btnSelectAll
            // 
            btnSelectAll.BackColor = Color.White;
            btnSelectAll.ForeColor = Color.FromArgb(255, 193, 7);
            btnSelectAll.Location = new Point(424, 194);
            btnSelectAll.Name = "btnSelectAll";
            btnSelectAll.Size = new Size(93, 29);
            btnSelectAll.TabIndex = 65;
            btnSelectAll.Text = "Select All";
            btnSelectAll.UseVisualStyleBackColor = false;
            btnSelectAll.Click += btnSelectAll_Click;
            // 
            // btnAddSchedule
            // 
            btnAddSchedule.BackColor = Color.FromArgb(11, 94, 235);
            btnAddSchedule.ForeColor = SystemColors.ButtonHighlight;
            btnAddSchedule.Location = new Point(404, 442);
            btnAddSchedule.Name = "btnAddSchedule";
            btnAddSchedule.Size = new Size(113, 44);
            btnAddSchedule.TabIndex = 67;
            btnAddSchedule.Text = "Add Schedule";
            btnAddSchedule.UseVisualStyleBackColor = false;
            btnAddSchedule.Click += btnAddSchedule_Click;
            // 
            // btnCancel
            // 
            btnCancel.ForeColor = Color.FromArgb(11, 94, 235);
            btnCancel.Location = new Point(320, 442);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(77, 44);
            btnCancel.TabIndex = 66;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(11, 94, 235);
            label7.Location = new Point(12, 369);
            label7.Name = "label7";
            label7.Size = new Size(49, 20);
            label7.TabIndex = 68;
            label7.Text = "Status";
            // 
            // cbStatus
            // 
            cbStatus.FormattingEnabled = true;
            cbStatus.Location = new Point(12, 392);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(505, 28);
            cbStatus.TabIndex = 69;
            // 
            // flpFloorPrice
            // 
            flpFloorPrice.Location = new Point(12, 274);
            flpFloorPrice.Name = "flpFloorPrice";
            flpFloorPrice.Size = new Size(505, 92);
            flpFloorPrice.TabIndex = 70;
            // 
            // AddSchedule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(533, 494);
            Controls.Add(flpFloorPrice);
            Controls.Add(cbStatus);
            Controls.Add(label7);
            Controls.Add(btnAddSchedule);
            Controls.Add(btnCancel);
            Controls.Add(btnSelectAll);
            Controls.Add(btnSun);
            Controls.Add(btnSat);
            Controls.Add(btnFri);
            Controls.Add(btnThu);
            Controls.Add(btnWed);
            Controls.Add(btnTue);
            Controls.Add(btnMon);
            Controls.Add(label6);
            Controls.Add(dtpArrivalTime);
            Controls.Add(dtpDepartureTime);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cbRoute);
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
        private ComboBox cbRoute;
        private Label label3;
        private Label label4;
        private DateTimePicker dtpDepartureTime;
        private DateTimePicker dtpArrivalTime;
        private Label label6;
        private Button btnMon;
        private Button btnTue;
        private Button btnWed;
        private Button btnThu;
        private Button btnFri;
        private Button btnSat;
        private Button btnSun;
        private Button btnSelectAll;
        private Button btnAddSchedule;
        private Button btnCancel;
        private Label label7;
        private ComboBox cbStatus;
        private FlowLayoutPanel flpFloorPrice;
    }
}