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
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false></param>
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
            panel1 = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            panel2 = new Panel();
            cbRoute = new ComboBox();
            label2 = new Label();
            cbFerry = new ComboBox();
            label5 = new Label();
            panel3 = new Panel();
            dtpArrivalTime = new DateTimePicker();
            label4 = new Label();
            dtpDepartureTime = new DateTimePicker();
            label3 = new Label();
            panel4 = new Panel();
            dtpEndDate = new DateTimePicker();
            label9 = new Label();
            dtpStartDate = new DateTimePicker();
            label8 = new Label();
            panel5 = new Panel();
            btnSelectAll = new Button();
            btnSun = new Button();
            btnSat = new Button();
            btnFri = new Button();
            btnThu = new Button();
            btnWed = new Button();
            btnTue = new Button();
            btnMon = new Button();
            label6 = new Label();
            panel6 = new Panel();
            flpFloorPrice = new FlowLayoutPanel();
            lblFloorPrice = new Label();
            panel7 = new Panel();
            cbStatus = new ComboBox();
            label7 = new Label();
            panel8 = new Panel();
            btnAddSchedule = new Button();
            btnCancel = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            panel8.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(11, 94, 235);
            panel1.Controls.Add(lblSubtitle);
            panel1.Controls.Add(lblTitle);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(818, 100);
            panel1.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.White;
            lblSubtitle.Location = new Point(20, 65);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(276, 23);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Set up departure times and pricing";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 19);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(288, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Create New Schedule";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(cbRoute);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(cbFerry);
            panel2.Controls.Add(label5);
            panel2.Location = new Point(20, 108);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(760, 107);
            panel2.TabIndex = 1;
            // 
            // cbRoute
            // 
            cbRoute.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRoute.Font = new Font("Segoe UI", 10F);
            cbRoute.FormattingEnabled = true;
            cbRoute.Location = new Point(390, 56);
            cbRoute.Margin = new Padding(3, 4, 3, 4);
            cbRoute.Name = "cbRoute";
            cbRoute.Size = new Size(350, 31);
            cbRoute.TabIndex = 3;
            cbRoute.SelectedIndexChanged += cbRoute_SelectedIndexChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(11, 94, 235);
            label2.Location = new Point(390, 19);
            label2.Name = "label2";
            label2.Size = new Size(57, 23);
            label2.TabIndex = 2;
            label2.Text = "Route";
            // 
            // cbFerry
            // 
            cbFerry.DropDownStyle = ComboBoxStyle.DropDownList;
            cbFerry.Font = new Font("Segoe UI", 10F);
            cbFerry.FormattingEnabled = true;
            cbFerry.Location = new Point(15, 56);
            cbFerry.Margin = new Padding(3, 4, 3, 4);
            cbFerry.Name = "cbFerry";
            cbFerry.Size = new Size(350, 31);
            cbFerry.TabIndex = 1;
            cbFerry.SelectedIndexChanged += cbFerry_SelectedIndexChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(11, 94, 235);
            label5.Location = new Point(15, 19);
            label5.Name = "label5";
            label5.Size = new Size(52, 23);
            label5.TabIndex = 0;
            label5.Text = "Ferry";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(dtpArrivalTime);
            panel3.Controls.Add(label4);
            panel3.Controls.Add(dtpDepartureTime);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(20, 223);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(760, 112);
            panel3.TabIndex = 2;
            // 
            // dtpArrivalTime
            // 
            dtpArrivalTime.CustomFormat = "";
            dtpArrivalTime.Font = new Font("Segoe UI", 10F);
            dtpArrivalTime.Format = DateTimePickerFormat.Time;
            dtpArrivalTime.Location = new Point(390, 56);
            dtpArrivalTime.Margin = new Padding(3, 4, 3, 4);
            dtpArrivalTime.Name = "dtpArrivalTime";
            dtpArrivalTime.ShowUpDown = true;
            dtpArrivalTime.Size = new Size(350, 30);
            dtpArrivalTime.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(11, 94, 235);
            label4.Location = new Point(390, 19);
            label4.Name = "label4";
            label4.Size = new Size(109, 23);
            label4.TabIndex = 2;
            label4.Text = "Arrival Time";
            // 
            // dtpDepartureTime
            // 
            dtpDepartureTime.CustomFormat = "";
            dtpDepartureTime.Font = new Font("Segoe UI", 10F);
            dtpDepartureTime.Format = DateTimePickerFormat.Time;
            dtpDepartureTime.Location = new Point(15, 56);
            dtpDepartureTime.Margin = new Padding(3, 4, 3, 4);
            dtpDepartureTime.Name = "dtpDepartureTime";
            dtpDepartureTime.ShowUpDown = true;
            dtpDepartureTime.Size = new Size(350, 30);
            dtpDepartureTime.TabIndex = 1;
            dtpDepartureTime.ValueChanged += dtpDepartureTime_ValueChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(11, 94, 235);
            label3.Location = new Point(15, 19);
            label3.Name = "label3";
            label3.Size = new Size(137, 23);
            label3.TabIndex = 0;
            label3.Text = "Departure Time";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(dtpEndDate);
            panel4.Controls.Add(label9);
            panel4.Controls.Add(dtpStartDate);
            panel4.Controls.Add(label8);
            panel4.Location = new Point(20, 343);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(760, 124);
            panel4.TabIndex = 3;
            // 
            // dtpEndDate
            // 
            dtpEndDate.CustomFormat = "MMMM dd, yyyy";
            dtpEndDate.Font = new Font("Segoe UI", 10F);
            dtpEndDate.Format = DateTimePickerFormat.Custom;
            dtpEndDate.Location = new Point(390, 56);
            dtpEndDate.Margin = new Padding(3, 4, 3, 4);
            dtpEndDate.MinDate = new DateTime(2025, 11, 27, 0, 0, 0, 0);
            dtpEndDate.Name = "dtpEndDate";
            dtpEndDate.Size = new Size(350, 30);
            dtpEndDate.TabIndex = 3;
            dtpEndDate.Value = new DateTime(2025, 11, 27, 0, 0, 0, 0);
            dtpEndDate.ValueChanged += dtpEndDate_ValueChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label9.ForeColor = Color.FromArgb(11, 94, 235);
            label9.Location = new Point(390, 19);
            label9.Name = "label9";
            label9.Size = new Size(83, 23);
            label9.TabIndex = 2;
            label9.Text = "End Date";
            // 
            // dtpStartDate
            // 
            dtpStartDate.CustomFormat = "MMMM dd, yyyy";
            dtpStartDate.Font = new Font("Segoe UI", 10F);
            dtpStartDate.Format = DateTimePickerFormat.Custom;
            dtpStartDate.Location = new Point(15, 56);
            dtpStartDate.Margin = new Padding(3, 4, 3, 4);
            dtpStartDate.MinDate = new DateTime(2025, 11, 27, 0, 0, 0, 0);
            dtpStartDate.Name = "dtpStartDate";
            dtpStartDate.Size = new Size(350, 30);
            dtpStartDate.TabIndex = 1;
            dtpStartDate.Value = new DateTime(2025, 11, 27, 0, 0, 0, 0);
            dtpStartDate.ValueChanged += dtpStartDate_ValueChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(11, 94, 235);
            label8.Location = new Point(15, 19);
            label8.Name = "label8";
            label8.Size = new Size(93, 23);
            label8.TabIndex = 0;
            label8.Text = "Start Date";
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(btnSelectAll);
            panel5.Controls.Add(btnSun);
            panel5.Controls.Add(btnSat);
            panel5.Controls.Add(btnFri);
            panel5.Controls.Add(btnThu);
            panel5.Controls.Add(btnWed);
            panel5.Controls.Add(btnTue);
            panel5.Controls.Add(btnMon);
            panel5.Controls.Add(label6);
            panel5.Location = new Point(20, 475);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(760, 112);
            panel5.TabIndex = 4;
            // 
            // btnSelectAll
            // 
            btnSelectAll.BackColor = Color.FromArgb(11, 94, 235);
            btnSelectAll.FlatStyle = FlatStyle.Flat;
            btnSelectAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSelectAll.ForeColor = Color.White;
            btnSelectAll.Location = new Point(645, 56);
            btnSelectAll.Margin = new Padding(3, 4, 3, 4);
            btnSelectAll.Name = "btnSelectAll";
            btnSelectAll.Size = new Size(95, 44);
            btnSelectAll.TabIndex = 8;
            btnSelectAll.Text = "Select All";
            btnSelectAll.UseVisualStyleBackColor = false;
            btnSelectAll.Click += btnSelectAll_Click;
            // 
            // btnSun
            // 
            btnSun.BackColor = Color.LightGray;
            btnSun.FlatStyle = FlatStyle.Flat;
            btnSun.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSun.Location = new Point(555, 56);
            btnSun.Margin = new Padding(3, 4, 3, 4);
            btnSun.Name = "btnSun";
            btnSun.Size = new Size(80, 44);
            btnSun.TabIndex = 7;
            btnSun.Text = "Sun";
            btnSun.UseVisualStyleBackColor = false;
            btnSun.Click += btnSun_Click;
            // 
            // btnSat
            // 
            btnSat.BackColor = Color.LightGray;
            btnSat.FlatStyle = FlatStyle.Flat;
            btnSat.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSat.Location = new Point(465, 56);
            btnSat.Margin = new Padding(3, 4, 3, 4);
            btnSat.Name = "btnSat";
            btnSat.Size = new Size(80, 44);
            btnSat.TabIndex = 6;
            btnSat.Text = "Sat";
            btnSat.UseVisualStyleBackColor = false;
            btnSat.Click += btnSat_Click;
            // 
            // btnFri
            // 
            btnFri.BackColor = Color.LightGray;
            btnFri.FlatStyle = FlatStyle.Flat;
            btnFri.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnFri.Location = new Point(375, 56);
            btnFri.Margin = new Padding(3, 4, 3, 4);
            btnFri.Name = "btnFri";
            btnFri.Size = new Size(80, 44);
            btnFri.TabIndex = 5;
            btnFri.Text = "Fri";
            btnFri.UseVisualStyleBackColor = false;
            btnFri.Click += btnFri_Click;
            // 
            // btnThu
            // 
            btnThu.BackColor = Color.LightGray;
            btnThu.FlatStyle = FlatStyle.Flat;
            btnThu.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThu.Location = new Point(285, 56);
            btnThu.Margin = new Padding(3, 4, 3, 4);
            btnThu.Name = "btnThu";
            btnThu.Size = new Size(80, 44);
            btnThu.TabIndex = 4;
            btnThu.Text = "Thu";
            btnThu.UseVisualStyleBackColor = false;
            btnThu.Click += btnThu_Click;
            // 
            // btnWed
            // 
            btnWed.BackColor = Color.LightGray;
            btnWed.FlatStyle = FlatStyle.Flat;
            btnWed.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnWed.Location = new Point(195, 56);
            btnWed.Margin = new Padding(3, 4, 3, 4);
            btnWed.Name = "btnWed";
            btnWed.Size = new Size(80, 44);
            btnWed.TabIndex = 3;
            btnWed.Text = "Wed";
            btnWed.UseVisualStyleBackColor = false;
            btnWed.Click += btnWed_Click;
            // 
            // btnTue
            // 
            btnTue.BackColor = Color.LightGray;
            btnTue.FlatStyle = FlatStyle.Flat;
            btnTue.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnTue.Location = new Point(105, 56);
            btnTue.Margin = new Padding(3, 4, 3, 4);
            btnTue.Name = "btnTue";
            btnTue.Size = new Size(80, 44);
            btnTue.TabIndex = 2;
            btnTue.Text = "Tue";
            btnTue.UseVisualStyleBackColor = false;
            btnTue.Click += btnTue_Click;
            // 
            // btnMon
            // 
            btnMon.BackColor = Color.LightGray;
            btnMon.FlatStyle = FlatStyle.Flat;
            btnMon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnMon.Location = new Point(15, 56);
            btnMon.Margin = new Padding(3, 4, 3, 4);
            btnMon.Name = "btnMon";
            btnMon.Size = new Size(80, 44);
            btnMon.TabIndex = 1;
            btnMon.Text = "Mon";
            btnMon.UseVisualStyleBackColor = false;
            btnMon.Click += btnMon_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(11, 94, 235);
            label6.Location = new Point(15, 19);
            label6.Name = "label6";
            label6.Size = new Size(135, 23);
            label6.TabIndex = 0;
            label6.Text = "Operating Days";
            // 
            // panel6
            // 
            panel6.BackColor = Color.White;
            panel6.BorderStyle = BorderStyle.FixedSingle;
            panel6.Controls.Add(flpFloorPrice);
            panel6.Controls.Add(lblFloorPrice);
            panel6.Location = new Point(20, 595);
            panel6.Margin = new Padding(3, 4, 3, 4);
            panel6.Name = "panel6";
            panel6.Size = new Size(760, 150);
            panel6.TabIndex = 5;
            // 
            // flpFloorPrice
            // 
            flpFloorPrice.Location = new Point(15, 56);
            flpFloorPrice.Margin = new Padding(3, 4, 3, 4);
            flpFloorPrice.Name = "flpFloorPrice";
            flpFloorPrice.Size = new Size(730, 81);
            flpFloorPrice.TabIndex = 1;
            // 
            // lblFloorPrice
            // 
            lblFloorPrice.AutoSize = true;
            lblFloorPrice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFloorPrice.ForeColor = Color.FromArgb(11, 94, 235);
            lblFloorPrice.Location = new Point(15, 19);
            lblFloorPrice.Name = "lblFloorPrice";
            lblFloorPrice.Size = new Size(193, 23);
            lblFloorPrice.TabIndex = 0;
            lblFloorPrice.Text = "Floor Pricing (per seat)";
            // 
            // panel7
            // 
            panel7.BackColor = Color.White;
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(cbStatus);
            panel7.Controls.Add(label7);
            panel7.Location = new Point(20, 753);
            panel7.Margin = new Padding(3, 4, 3, 4);
            panel7.Name = "panel7";
            panel7.Size = new Size(760, 99);
            panel7.TabIndex = 6;
            // 
            // cbStatus
            // 
            cbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbStatus.Font = new Font("Segoe UI", 10F);
            cbStatus.FormattingEnabled = true;
            cbStatus.Items.AddRange(new object[] { "Active", "Inactive" });
            cbStatus.Location = new Point(15, 56);
            cbStatus.Margin = new Padding(3, 4, 3, 4);
            cbStatus.Name = "cbStatus";
            cbStatus.Size = new Size(730, 31);
            cbStatus.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(11, 94, 235);
            label7.Location = new Point(15, 19);
            label7.Name = "label7";
            label7.Size = new Size(60, 23);
            label7.TabIndex = 0;
            label7.Text = "Status";
            // 
            // panel8
            // 
            panel8.BackColor = Color.WhiteSmoke;
            panel8.Controls.Add(btnAddSchedule);
            panel8.Controls.Add(btnCancel);
            panel8.Dock = DockStyle.Bottom;
            panel8.Location = new Point(0, 853);
            panel8.Margin = new Padding(3, 4, 3, 4);
            panel8.Name = "panel8";
            panel8.Size = new Size(818, 110);
            panel8.TabIndex = 7;
            // 
            // btnAddSchedule
            // 
            btnAddSchedule.BackColor = Color.FromArgb(11, 94, 235);
            btnAddSchedule.FlatStyle = FlatStyle.Flat;
            btnAddSchedule.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnAddSchedule.ForeColor = Color.White;
            btnAddSchedule.Location = new Point(670, 19);
            btnAddSchedule.Margin = new Padding(3, 4, 3, 4);
            btnAddSchedule.Name = "btnAddSchedule";
            btnAddSchedule.Size = new Size(120, 50);
            btnAddSchedule.TabIndex = 1;
            btnAddSchedule.Text = "Save";
            btnAddSchedule.UseVisualStyleBackColor = false;
            btnAddSchedule.Click += btnAddSchedule_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(11, 94, 235);
            btnCancel.Location = new Point(540, 19);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 50);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // AddSchedule
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(818, 963);
            Controls.Add(panel8);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AddSchedule";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Create Schedule";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel8.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox cbRoute;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbFerry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DateTimePicker dtpArrivalTime;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDepartureTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnSun;
        private System.Windows.Forms.Button btnSat;
        private System.Windows.Forms.Button btnFri;
        private System.Windows.Forms.Button btnThu;
        private System.Windows.Forms.Button btnWed;
        private System.Windows.Forms.Button btnTue;
        private System.Windows.Forms.Button btnMon;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.FlowLayoutPanel flpFloorPrice;
        private System.Windows.Forms.Label lblFloorPrice;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.ComboBox cbStatus;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button btnAddSchedule;
        private System.Windows.Forms.Button btnCancel;
    }
}