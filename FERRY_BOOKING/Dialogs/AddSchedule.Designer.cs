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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbRoute = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbFerry = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dtpArrivalTime = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDepartureTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnSun = new System.Windows.Forms.Button();
            this.btnSat = new System.Windows.Forms.Button();
            this.btnFri = new System.Windows.Forms.Button();
            this.btnThu = new System.Windows.Forms.Button();
            this.btnWed = new System.Windows.Forms.Button();
            this.btnTue = new System.Windows.Forms.Button();
            this.btnMon = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.flpFloorPrice = new System.Windows.Forms.FlowLayoutPanel();
            this.lblFloorPrice = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.cbStatus = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.btnAddSchedule = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel8.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(800, 80);
            this.panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(278, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Create New Schedule";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.White;
            this.lblSubtitle.Location = new System.Drawing.Point(20, 52);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(296, 23);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Set up departure times and pricing";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.cbRoute);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.cbFerry);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(20, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(760, 100);
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
            this.cbFerry.Location = new System.Drawing.Point(15, 45);
            this.cbFerry.Name = "cbFerry";
            this.cbFerry.Size = new System.Drawing.Size(350, 31);
            this.cbFerry.TabIndex = 1;
            this.cbFerry.SelectedIndexChanged += new System.EventHandler(this.cbFerry_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.label2.Location = new System.Drawing.Point(390, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Route";
            // 
            // cbRoute
            // 
            this.cbRoute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRoute.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbRoute.FormattingEnabled = true;
            this.cbRoute.Location = new System.Drawing.Point(390, 45);
            this.cbRoute.Name = "cbRoute";
            this.cbRoute.Size = new System.Drawing.Size(350, 31);
            this.cbRoute.TabIndex = 3;
            this.cbRoute.SelectedIndexChanged += new System.EventHandler(this.cbRoute_SelectedIndexChanged);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dtpArrivalTime);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.dtpDepartureTime);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(20, 215);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(760, 100);
            this.panel3.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.label3.Location = new System.Drawing.Point(15, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Departure Time";
            // 
            // dtpDepartureTime
            // 
            this.dtpDepartureTime.CustomFormat = "";
            this.dtpDepartureTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpDepartureTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpDepartureTime.Location = new System.Drawing.Point(15, 45);
            this.dtpDepartureTime.Name = "dtpDepartureTime";
            this.dtpDepartureTime.ShowUpDown = true;
            this.dtpDepartureTime.Size = new System.Drawing.Size(350, 30);
            this.dtpDepartureTime.TabIndex = 1;
            this.dtpDepartureTime.ValueChanged += new System.EventHandler(this.dtpDepartureTime_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.label4.Location = new System.Drawing.Point(390, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 23);
            this.label4.TabIndex = 2;
            this.label4.Text = "Arrival Time";
            // 
            // dtpArrivalTime
            // 
            this.dtpArrivalTime.CustomFormat = "";
            this.dtpArrivalTime.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpArrivalTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpArrivalTime.Location = new System.Drawing.Point(390, 45);
            this.dtpArrivalTime.Name = "dtpArrivalTime";
            this.dtpArrivalTime.ShowUpDown = true;
            this.dtpArrivalTime.Size = new System.Drawing.Size(350, 30);
            this.dtpArrivalTime.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.dtpEndDate);
            this.panel4.Controls.Add(this.label9);
            this.panel4.Controls.Add(this.dtpStartDate);
            this.panel4.Controls.Add(this.label8);
            this.panel4.Location = new System.Drawing.Point(20, 330);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(760, 100);
            this.panel4.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.label8.Location = new System.Drawing.Point(15, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 23);
            this.label8.TabIndex = 0;
            this.label8.Text = "Start Date";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "MMMM dd, yyyy";
            this.dtpStartDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(15, 45);
            this.dtpStartDate.MinDate = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(350, 30);
            this.dtpStartDate.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.label9.Location = new System.Drawing.Point(390, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 23);
            this.label9.TabIndex = 2;
            this.label9.Text = "End Date";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "MMMM dd, yyyy";
            this.dtpEndDate.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(390, 45);
            this.dtpEndDate.MinDate = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(350, 30);
            this.dtpEndDate.TabIndex = 3;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.btnSelectAll);
            this.panel5.Controls.Add(this.btnSun);
            this.panel5.Controls.Add(this.btnSat);
            this.panel5.Controls.Add(this.btnFri);
            this.panel5.Controls.Add(this.btnThu);
            this.panel5.Controls.Add(this.btnWed);
            this.panel5.Controls.Add(this.btnTue);
            this.panel5.Controls.Add(this.btnMon);
            this.panel5.Controls.Add(this.label6);
            this.panel5.Location = new System.Drawing.Point(20, 445);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(760, 90);
            this.panel5.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.label6.Location = new System.Drawing.Point(15, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(139, 23);
            this.label6.TabIndex = 0;
            this.label6.Text = "Operating Days";
            // 
            // btnMon
            // 
            this.btnMon.BackColor = System.Drawing.Color.LightGray;
            this.btnMon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMon.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnMon.Location = new System.Drawing.Point(15, 45);
            this.btnMon.Name = "btnMon";
            this.btnMon.Size = new System.Drawing.Size(80, 35);
            this.btnMon.TabIndex = 1;
            this.btnMon.Text = "Mon";
            this.btnMon.UseVisualStyleBackColor = false;
            this.btnMon.Click += new System.EventHandler(this.btnMon_Click);
            // 
            // btnTue
            // 
            this.btnTue.BackColor = System.Drawing.Color.LightGray;
            this.btnTue.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTue.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnTue.Location = new System.Drawing.Point(105, 45);
            this.btnTue.Name = "btnTue";
            this.btnTue.Size = new System.Drawing.Size(80, 35);
            this.btnTue.TabIndex = 2;
            this.btnTue.Text = "Tue";
            this.btnTue.UseVisualStyleBackColor = false;
            this.btnTue.Click += new System.EventHandler(this.btnTue_Click);
            // 
            // btnWed
            // 
            this.btnWed.BackColor = System.Drawing.Color.LightGray;
            this.btnWed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWed.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnWed.Location = new System.Drawing.Point(195, 45);
            this.btnWed.Name = "btnWed";
            this.btnWed.Size = new System.Drawing.Size(80, 35);
            this.btnWed.TabIndex = 3;
            this.btnWed.Text = "Wed";
            this.btnWed.UseVisualStyleBackColor = false;
            this.btnWed.Click += new System.EventHandler(this.btnWed_Click);
            // 
            // btnThu
            // 
            this.btnThu.BackColor = System.Drawing.Color.LightGray;
            this.btnThu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThu.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnThu.Location = new System.Drawing.Point(285, 45);
            this.btnThu.Name = "btnThu";
            this.btnThu.Size = new System.Drawing.Size(80, 35);
            this.btnThu.TabIndex = 4;
            this.btnThu.Text = "Thu";
            this.btnThu.UseVisualStyleBackColor = false;
            this.btnThu.Click += new System.EventHandler(this.btnThu_Click);
            // 
            // btnFri
            // 
            this.btnFri.BackColor = System.Drawing.Color.LightGray;
            this.btnFri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFri.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnFri.Location = new System.Drawing.Point(375, 45);
            this.btnFri.Name = "btnFri";
            this.btnFri.Size = new System.Drawing.Size(80, 35);
            this.btnFri.TabIndex = 5;
            this.btnFri.Text = "Fri";
            this.btnFri.UseVisualStyleBackColor = false;
            this.btnFri.Click += new System.EventHandler(this.btnFri_Click);
            // 
            // btnSat
            // 
            this.btnSat.BackColor = System.Drawing.Color.LightGray;
            this.btnSat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSat.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSat.Location = new System.Drawing.Point(465, 45);
            this.btnSat.Name = "btnSat";
            this.btnSat.Size = new System.Drawing.Size(80, 35);
            this.btnSat.TabIndex = 6;
            this.btnSat.Text = "Sat";
            this.btnSat.UseVisualStyleBackColor = false;
            this.btnSat.Click += new System.EventHandler(this.btnSat_Click);
            // 
            // btnSun
            // 
            this.btnSun.BackColor = System.Drawing.Color.LightGray;
            this.btnSun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSun.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSun.Location = new System.Drawing.Point(555, 45);
            this.btnSun.Name = "btnSun";
            this.btnSun.Size = new System.Drawing.Size(80, 35);
            this.btnSun.TabIndex = 7;
            this.btnSun.Text = "Sun";
            this.btnSun.UseVisualStyleBackColor = false;
            this.btnSun.Click += new System.EventHandler(this.btnSun_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnSelectAll.ForeColor = System.Drawing.Color.White;
            this.btnSelectAll.Location = new System.Drawing.Point(645, 45);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(95, 35);
            this.btnSelectAll.TabIndex = 8;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.UseVisualStyleBackColor = false;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel6.Controls.Add(this.flpFloorPrice);
            this.panel6.Controls.Add(this.lblFloorPrice);
            this.panel6.Location = new System.Drawing.Point(20, 550);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(760, 120);
            this.panel6.TabIndex = 5;
            // 
            // lblFloorPrice
            // 
            this.lblFloorPrice.AutoSize = true;
            this.lblFloorPrice.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblFloorPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.lblFloorPrice.Location = new System.Drawing.Point(15, 15);
            this.lblFloorPrice.Name = "lblFloorPrice";
            this.lblFloorPrice.Size = new System.Drawing.Size(186, 23);
            this.lblFloorPrice.TabIndex = 0;
            this.lblFloorPrice.Text = "Floor Pricing (per seat)";
            // 
            // flpFloorPrice
            // 
            this.flpFloorPrice.Location = new System.Drawing.Point(15, 45);
            this.flpFloorPrice.Name = "flpFloorPrice";
            this.flpFloorPrice.Size = new System.Drawing.Size(730, 65);
            this.flpFloorPrice.TabIndex = 1;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel7.Controls.Add(this.cbStatus);
            this.panel7.Controls.Add(this.label7);
            this.panel7.Location = new System.Drawing.Point(20, 685);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(760, 80);
            this.panel7.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.label7.Location = new System.Drawing.Point(15, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 23);
            this.label7.TabIndex = 0;
            this.label7.Text = "Status";
            // 
            // cbStatus
            // 
            this.cbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbStatus.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cbStatus.FormattingEnabled = true;
            this.cbStatus.Items.AddRange(new object[] {
            "Active",
            "Inactive"});
            this.cbStatus.Location = new System.Drawing.Point(15, 45);
            this.cbStatus.Name = "cbStatus";
            this.cbStatus.Size = new System.Drawing.Size(730, 31);
            this.cbStatus.TabIndex = 1;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel8.Controls.Add(this.btnAddSchedule);
            this.panel8.Controls.Add(this.btnCancel);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 785);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(800, 70);
            this.panel8.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.btnCancel.Location = new System.Drawing.Point(540, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAddSchedule
            // 
            this.btnAddSchedule.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.btnAddSchedule.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddSchedule.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddSchedule.ForeColor = System.Drawing.Color.White;
            this.btnAddSchedule.Location = new System.Drawing.Point(670, 15);
            this.btnAddSchedule.Name = "btnAddSchedule";
            this.btnAddSchedule.Size = new System.Drawing.Size(120, 40);
            this.btnAddSchedule.TabIndex = 1;
            this.btnAddSchedule.Text = "Save";
            this.btnAddSchedule.UseVisualStyleBackColor = false;
            this.btnAddSchedule.Click += new System.EventHandler(this.btnAddSchedule_Click);
            // 
            // AddSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(800, 855);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddSchedule";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Schedule";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

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