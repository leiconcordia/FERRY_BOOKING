namespace FERRY_BOOKING.Dialogs
{
    partial class ScheduleViewDialog
    {
        private System.ComponentModel.IContainer components = null;

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
            pnlHeader = new Panel();
            lblTitle = new Label();
            pnlScheduleInfo = new Panel();
            lblDateRange = new Label();
            lblDaysOfWeek = new Label();
            lblArrival = new Label();
            lblDeparture = new Label();
            lblRoute = new Label();
            lblFerryName = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            pnlCalendar = new Panel();
            lblInstruction = new Label();
            monthCalendar = new MonthCalendar();
            pnlFloorInfo = new Panel();
            btnCancelTrip = new Button();
            btnViewSeats = new Button();
            lblSelectedDate = new Label();
            dgvFloorInfo = new DataGridView();
            label7 = new Label();
            btnClose = new Button();
            pnlHeader.SuspendLayout();
            pnlScheduleInfo.SuspendLayout();
            pnlCalendar.SuspendLayout();
            pnlFloorInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFloorInfo).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(11, 94, 215);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(4, 5, 4, 5);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1333, 92);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(27, 23);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(222, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Schedule View";
            // 
            // pnlScheduleInfo
            // 
            pnlScheduleInfo.BorderStyle = BorderStyle.FixedSingle;
            pnlScheduleInfo.Controls.Add(lblDateRange);
            pnlScheduleInfo.Controls.Add(lblDaysOfWeek);
            pnlScheduleInfo.Controls.Add(lblArrival);
            pnlScheduleInfo.Controls.Add(lblDeparture);
            pnlScheduleInfo.Controls.Add(lblRoute);
            pnlScheduleInfo.Controls.Add(lblFerryName);
            pnlScheduleInfo.Controls.Add(label6);
            pnlScheduleInfo.Controls.Add(label5);
            pnlScheduleInfo.Controls.Add(label4);
            pnlScheduleInfo.Controls.Add(label3);
            pnlScheduleInfo.Controls.Add(label2);
            pnlScheduleInfo.Controls.Add(label1);
            pnlScheduleInfo.Location = new Point(27, 102);
            pnlScheduleInfo.Margin = new Padding(4, 5, 4, 5);
            pnlScheduleInfo.Name = "pnlScheduleInfo";
            pnlScheduleInfo.Size = new Size(1279, 161);
            pnlScheduleInfo.TabIndex = 1;
            // 
            // lblDateRange
            // 
            lblDateRange.AutoSize = true;
            lblDateRange.Font = new Font("Segoe UI", 10F);
            lblDateRange.Location = new Point(800, 123);
            lblDateRange.Margin = new Padding(4, 0, 4, 0);
            lblDateRange.Name = "lblDateRange";
            lblDateRange.Size = new Size(31, 23);
            lblDateRange.TabIndex = 11;
            lblDateRange.Text = "---";
            // 
            // lblDaysOfWeek
            // 
            lblDaysOfWeek.AutoSize = true;
            lblDaysOfWeek.Font = new Font("Segoe UI", 10F);
            lblDaysOfWeek.Location = new Point(800, 77);
            lblDaysOfWeek.Margin = new Padding(4, 0, 4, 0);
            lblDaysOfWeek.Name = "lblDaysOfWeek";
            lblDaysOfWeek.Size = new Size(31, 23);
            lblDaysOfWeek.TabIndex = 10;
            lblDaysOfWeek.Text = "---";
            // 
            // lblArrival
            // 
            lblArrival.AutoSize = true;
            lblArrival.Font = new Font("Segoe UI", 10F);
            lblArrival.Location = new Point(800, 31);
            lblArrival.Margin = new Padding(4, 0, 4, 0);
            lblArrival.Name = "lblArrival";
            lblArrival.Size = new Size(31, 23);
            lblArrival.TabIndex = 9;
            lblArrival.Text = "---";
            // 
            // lblDeparture
            // 
            lblDeparture.AutoSize = true;
            lblDeparture.Font = new Font("Segoe UI", 10F);
            lblDeparture.Location = new Point(200, 123);
            lblDeparture.Margin = new Padding(4, 0, 4, 0);
            lblDeparture.Name = "lblDeparture";
            lblDeparture.Size = new Size(31, 23);
            lblDeparture.TabIndex = 8;
            lblDeparture.Text = "---";
            // 
            // lblRoute
            // 
            lblRoute.AutoSize = true;
            lblRoute.Font = new Font("Segoe UI", 10F);
            lblRoute.Location = new Point(200, 77);
            lblRoute.Margin = new Padding(4, 0, 4, 0);
            lblRoute.Name = "lblRoute";
            lblRoute.Size = new Size(31, 23);
            lblRoute.TabIndex = 7;
            lblRoute.Text = "---";
            // 
            // lblFerryName
            // 
            lblFerryName.AutoSize = true;
            lblFerryName.Font = new Font("Segoe UI", 10F);
            lblFerryName.Location = new Point(200, 31);
            lblFerryName.Margin = new Padding(4, 0, 4, 0);
            lblFerryName.Name = "lblFerryName";
            lblFerryName.Size = new Size(31, 23);
            lblFerryName.TabIndex = 6;
            lblFerryName.Text = "---";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.Location = new Point(640, 123);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(108, 23);
            label6.TabIndex = 5;
            label6.Text = "Date Range:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.Location = new Point(640, 77);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(140, 23);
            label5.TabIndex = 4;
            label5.Text = "Operating Days:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.Location = new Point(640, 31);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(114, 23);
            label4.TabIndex = 3;
            label4.Text = "Arrival Time:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(27, 123);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(142, 23);
            label3.TabIndex = 2;
            label3.Text = "Departure Time:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(27, 77);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(62, 23);
            label2.TabIndex = 1;
            label2.Text = "Route:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.Location = new Point(27, 31);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(57, 23);
            label1.TabIndex = 0;
            label1.Text = "Ferry:";
            // 
            // pnlCalendar
            // 
            pnlCalendar.BorderStyle = BorderStyle.FixedSingle;
            pnlCalendar.Controls.Add(lblInstruction);
            pnlCalendar.Controls.Add(monthCalendar);
            pnlCalendar.Location = new Point(27, 284);
            pnlCalendar.Margin = new Padding(4, 5, 4, 5);
            pnlCalendar.Name = "pnlCalendar";
            pnlCalendar.Size = new Size(466, 526);
            pnlCalendar.TabIndex = 2;
            // 
            // lblInstruction
            // 
            lblInstruction.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblInstruction.ForeColor = Color.Gray;
            lblInstruction.Location = new Point(13, 15);
            lblInstruction.Margin = new Padding(4, 0, 4, 0);
            lblInstruction.Name = "lblInstruction";
            lblInstruction.Size = new Size(440, 62);
            lblInstruction.TabIndex = 1;
            lblInstruction.Text = "Bold dates are operating days. Click to view trip details.";
            lblInstruction.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // monthCalendar
            // 
            monthCalendar.Location = new Point(67, 92);
            monthCalendar.Margin = new Padding(12, 14, 12, 14);
            monthCalendar.Name = "monthCalendar";
            monthCalendar.TabIndex = 0;
            // 
            // pnlFloorInfo
            // 
            pnlFloorInfo.BorderStyle = BorderStyle.FixedSingle;
            pnlFloorInfo.Controls.Add(btnCancelTrip);
            pnlFloorInfo.Controls.Add(btnViewSeats);
            pnlFloorInfo.Controls.Add(lblSelectedDate);
            pnlFloorInfo.Controls.Add(dgvFloorInfo);
            pnlFloorInfo.Controls.Add(label7);
            pnlFloorInfo.Location = new Point(520, 284);
            pnlFloorInfo.Margin = new Padding(4, 5, 4, 5);
            pnlFloorInfo.Name = "pnlFloorInfo";
            pnlFloorInfo.Size = new Size(786, 526);
            pnlFloorInfo.TabIndex = 3;
            // 
            // btnCancelTrip
            // 
            btnCancelTrip.BackColor = Color.FromArgb(220, 53, 69);
            btnCancelTrip.Enabled = false;
            btnCancelTrip.FlatStyle = FlatStyle.Flat;
            btnCancelTrip.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancelTrip.ForeColor = Color.White;
            btnCancelTrip.Location = new Point(360, 446);
            btnCancelTrip.Margin = new Padding(4, 5, 4, 5);
            btnCancelTrip.Name = "btnCancelTrip";
            btnCancelTrip.Size = new Size(187, 54);
            btnCancelTrip.TabIndex = 4;
            btnCancelTrip.Text = "Cancel Trip";
            btnCancelTrip.UseVisualStyleBackColor = false;
            btnCancelTrip.Click += btnCancelTrip_Click;
            // 
            // btnViewSeats
            // 
            btnViewSeats.BackColor = Color.FromArgb(11, 94, 215);
            btnViewSeats.Enabled = false;
            btnViewSeats.FlatStyle = FlatStyle.Flat;
            btnViewSeats.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnViewSeats.ForeColor = Color.White;
            btnViewSeats.Location = new Point(573, 446);
            btnViewSeats.Margin = new Padding(4, 5, 4, 5);
            btnViewSeats.Name = "btnViewSeats";
            btnViewSeats.Size = new Size(187, 54);
            btnViewSeats.TabIndex = 3;
            btnViewSeats.Text = "View Seats";
            btnViewSeats.UseVisualStyleBackColor = false;
            btnViewSeats.Click += btnViewSeats_Click;
            // 
            // lblSelectedDate
            // 
            lblSelectedDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSelectedDate.ForeColor = Color.FromArgb(11, 94, 215);
            lblSelectedDate.Location = new Point(27, 62);
            lblSelectedDate.Margin = new Padding(4, 0, 4, 0);
            lblSelectedDate.Name = "lblSelectedDate";
            lblSelectedDate.Size = new Size(733, 38);
            lblSelectedDate.TabIndex = 2;
            lblSelectedDate.Text = "No date selected";
            lblSelectedDate.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // dgvFloorInfo
            // 
            dgvFloorInfo.AllowUserToAddRows = false;
            dgvFloorInfo.AllowUserToDeleteRows = false;
            dgvFloorInfo.BackgroundColor = Color.White;
            dgvFloorInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFloorInfo.Location = new Point(27, 108);
            dgvFloorInfo.Margin = new Padding(4, 5, 4, 5);
            dgvFloorInfo.Name = "dgvFloorInfo";
            dgvFloorInfo.ReadOnly = true;
            dgvFloorInfo.RowHeadersVisible = false;
            dgvFloorInfo.RowHeadersWidth = 51;
            dgvFloorInfo.Size = new Size(733, 319);
            dgvFloorInfo.TabIndex = 1;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label7.Location = new Point(20, 15);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(241, 28);
            label7.TabIndex = 0;
            label7.Text = "Floor Occupancy Details";
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Gray;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1159, 820);
            btnClose.Margin = new Padding(4, 5, 4, 5);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(147, 62);
            btnClose.TabIndex = 4;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // ScheduleViewDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1333, 890);
            Controls.Add(btnClose);
            Controls.Add(pnlFloorInfo);
            Controls.Add(pnlCalendar);
            Controls.Add(pnlScheduleInfo);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4, 5, 4, 5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ScheduleViewDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Schedule View";
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlScheduleInfo.ResumeLayout(false);
            pnlScheduleInfo.PerformLayout();
            pnlCalendar.ResumeLayout(false);
            pnlFloorInfo.ResumeLayout(false);
            pnlFloorInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFloorInfo).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel pnlScheduleInfo;
        private System.Windows.Forms.Label lblDateRange;
        private System.Windows.Forms.Label lblDaysOfWeek;
        private System.Windows.Forms.Label lblArrival;
        private System.Windows.Forms.Label lblDeparture;
        private System.Windows.Forms.Label lblRoute;
        private System.Windows.Forms.Label lblFerryName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlCalendar;
        private System.Windows.Forms.Label lblInstruction;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private System.Windows.Forms.Panel pnlFloorInfo;
        private System.Windows.Forms.Button btnCancelTrip;
        private System.Windows.Forms.Button btnViewSeats;
        private System.Windows.Forms.Label lblSelectedDate;
        private System.Windows.Forms.DataGridView dgvFloorInfo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnClose;
    }
}
