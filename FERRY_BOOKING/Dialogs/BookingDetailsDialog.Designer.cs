namespace FERRY_BOOKING.Dialogs
{
    partial class BookingDetailsDialog
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            panel1 = new Panel();
            lblBookingDate = new Label();
            lblBookingDateLabel = new Label();
            lblBookingRef = new Label();
            lblBookingRefLabel = new Label();
            lblTitle = new Label();
            panel2 = new Panel();
            lblRoute = new Label();
            lblRouteLabel = new Label();
            lblFerry = new Label();
            lblFerryLabel = new Label();
            panel3 = new Panel();
            lblStatus = new Label();
            lblStatusLabel = new Label();
            lblArrival = new Label();
            lblArrivalLabel = new Label();
            lblDeparture = new Label();
            lblDepartureLabel = new Label();
            lblTripDate = new Label();
            lblTripDateLabel = new Label();
            panel4 = new Panel();
            lblPassengerCount = new Label();
            lblPassengerCountLabel = new Label();
            lblTotalAmount = new Label();
            lblTotalAmountLabel = new Label();
            panel5 = new Panel();
            dgvPassengers = new DataGridView();
            lblPassengersLabel = new Label();
            panel6 = new Panel();
            btnClose = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPassengers).BeginInit();
            panel6.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(11, 94, 235);
            panel1.Controls.Add(lblBookingDate);
            panel1.Controls.Add(lblBookingDateLabel);
            panel1.Controls.Add(lblBookingRef);
            panel1.Controls.Add(lblBookingRefLabel);
            panel1.Controls.Add(lblTitle);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 120);
            panel1.TabIndex = 0;
            // 
            // lblBookingDate
            // 
            lblBookingDate.AutoSize = true;
            lblBookingDate.Font = new Font("Segoe UI", 10F);
            lblBookingDate.ForeColor = Color.White;
            lblBookingDate.Location = new Point(540, 77);
            lblBookingDate.Name = "lblBookingDate";
            lblBookingDate.Size = new Size(17, 23);
            lblBookingDate.TabIndex = 4;
            lblBookingDate.Text = "-";
            // 
            // lblBookingDateLabel
            // 
            lblBookingDateLabel.AutoSize = true;
            lblBookingDateLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBookingDateLabel.ForeColor = Color.White;
            lblBookingDateLabel.Location = new Point(400, 77);
            lblBookingDateLabel.Name = "lblBookingDateLabel";
            lblBookingDateLabel.Size = new Size(127, 23);
            lblBookingDateLabel.TabIndex = 3;
            lblBookingDateLabel.Text = "Booking Date:";
            // 
            // lblBookingRef
            // 
            lblBookingRef.AutoSize = true;
            lblBookingRef.Font = new Font("Segoe UI", 10F);
            lblBookingRef.ForeColor = Color.White;
            lblBookingRef.Location = new Point(200, 77);
            lblBookingRef.Name = "lblBookingRef";
            lblBookingRef.Size = new Size(17, 23);
            lblBookingRef.TabIndex = 2;
            lblBookingRef.Text = "-";
            // 
            // lblBookingRefLabel
            // 
            lblBookingRefLabel.AutoSize = true;
            lblBookingRefLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBookingRefLabel.ForeColor = Color.White;
            lblBookingRefLabel.Location = new Point(20, 77);
            lblBookingRefLabel.Name = "lblBookingRefLabel";
            lblBookingRefLabel.Size = new Size(175, 23);
            lblBookingRefLabel.TabIndex = 1;
            lblBookingRefLabel.Text = "Booking Reference:";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 19);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(220, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Booking Details";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lblRoute);
            panel2.Controls.Add(lblRouteLabel);
            panel2.Controls.Add(lblFerry);
            panel2.Controls.Add(lblFerryLabel);
            panel2.Location = new Point(20, 128);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(760, 100);
            panel2.TabIndex = 1;
            // 
            // lblRoute
            // 
            lblRoute.AutoSize = true;
            lblRoute.Font = new Font("Segoe UI", 11F);
            lblRoute.Location = new Point(15, 65);
            lblRoute.Name = "lblRoute";
            lblRoute.Size = new Size(18, 25);
            lblRoute.TabIndex = 3;
            lblRoute.Text = "-";
            // 
            // lblRouteLabel
            // 
            lblRouteLabel.AutoSize = true;
            lblRouteLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRouteLabel.ForeColor = Color.FromArgb(11, 94, 235);
            lblRouteLabel.Location = new Point(15, 38);
            lblRouteLabel.Name = "lblRouteLabel";
            lblRouteLabel.Size = new Size(62, 23);
            lblRouteLabel.TabIndex = 2;
            lblRouteLabel.Text = "Route:";
            // 
            // lblFerry
            // 
            lblFerry.AutoSize = true;
            lblFerry.Font = new Font("Segoe UI", 11F);
            lblFerry.Location = new Point(80, 12);
            lblFerry.Name = "lblFerry";
            lblFerry.Size = new Size(18, 25);
            lblFerry.TabIndex = 1;
            lblFerry.Text = "-";
            // 
            // lblFerryLabel
            // 
            lblFerryLabel.AutoSize = true;
            lblFerryLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFerryLabel.ForeColor = Color.FromArgb(11, 94, 235);
            lblFerryLabel.Location = new Point(15, 12);
            lblFerryLabel.Name = "lblFerryLabel";
            lblFerryLabel.Size = new Size(57, 23);
            lblFerryLabel.TabIndex = 0;
            lblFerryLabel.Text = "Ferry:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lblStatus);
            panel3.Controls.Add(lblStatusLabel);
            panel3.Controls.Add(lblArrival);
            panel3.Controls.Add(lblArrivalLabel);
            panel3.Controls.Add(lblDeparture);
            panel3.Controls.Add(lblDepartureLabel);
            panel3.Controls.Add(lblTripDate);
            panel3.Controls.Add(lblTripDateLabel);
            panel3.Location = new Point(20, 236);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(760, 100);
            panel3.TabIndex = 2;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblStatus.ForeColor = Color.Green;
            lblStatus.Location = new Point(580, 60);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(19, 25);
            lblStatus.TabIndex = 7;
            lblStatus.Text = "-";
            // 
            // lblStatusLabel
            // 
            lblStatusLabel.AutoSize = true;
            lblStatusLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatusLabel.ForeColor = Color.FromArgb(11, 94, 235);
            lblStatusLabel.Location = new Point(580, 19);
            lblStatusLabel.Name = "lblStatusLabel";
            lblStatusLabel.Size = new Size(97, 23);
            lblStatusLabel.TabIndex = 6;
            lblStatusLabel.Text = "Trip Status:";
            // 
            // lblArrival
            // 
            lblArrival.AutoSize = true;
            lblArrival.Font = new Font("Segoe UI", 11F);
            lblArrival.Location = new Point(390, 60);
            lblArrival.Name = "lblArrival";
            lblArrival.Size = new Size(18, 25);
            lblArrival.TabIndex = 5;
            lblArrival.Text = "-";
            // 
            // lblArrivalLabel
            // 
            lblArrivalLabel.AutoSize = true;
            lblArrivalLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblArrivalLabel.ForeColor = Color.FromArgb(11, 94, 235);
            lblArrivalLabel.Location = new Point(390, 19);
            lblArrivalLabel.Name = "lblArrivalLabel";
            lblArrivalLabel.TabIndex = 4;
            lblArrivalLabel.Text = "Arrival:";
            // 
            // lblDeparture
            // 
            lblDeparture.AutoSize = true;
            lblDeparture.Font = new Font("Segoe UI", 11F);
            lblDeparture.Location = new Point(200, 60);
            lblDeparture.Name = "lblDeparture";
            lblDeparture.Size = new Size(18, 25);
            lblDeparture.TabIndex = 3;
            lblDeparture.Text = "-";
            // 
            // lblDepartureLabel
            // 
            lblDepartureLabel.AutoSize = true;
            lblDepartureLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDepartureLabel.ForeColor = Color.FromArgb(11, 94, 235);
            lblDepartureLabel.Location = new Point(200, 19);
            lblDepartureLabel.Name = "lblDepartureLabel";
            lblDepartureLabel.Size = new Size(98, 23);
            lblDepartureLabel.TabIndex = 2;
            lblDepartureLabel.Text = "Departure:";
            // 
            // lblTripDate
            // 
            lblTripDate.AutoSize = true;
            lblTripDate.Font = new Font("Segoe UI", 11F);
            lblTripDate.Location = new Point(15, 60);
            lblTripDate.Name = "lblTripDate";
            lblTripDate.Size = new Size(18, 25);
            lblTripDate.TabIndex = 1;
            lblTripDate.Text = "-";
            // 
            // lblTripDateLabel
            // 
            lblTripDateLabel.AutoSize = true;
            lblTripDateLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTripDateLabel.ForeColor = Color.FromArgb(11, 94, 235);
            lblTripDateLabel.Location = new Point(15, 19);
            lblTripDateLabel.Name = "lblTripDateLabel";
            lblTripDateLabel.Size = new Size(90, 23);
            lblTripDateLabel.TabIndex = 0;
            lblTripDateLabel.Text = "Trip Date:";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(lblPassengerCount);
            panel4.Controls.Add(lblPassengerCountLabel);
            panel4.Controls.Add(lblTotalAmount);
            panel4.Controls.Add(lblTotalAmountLabel);
            panel4.Location = new Point(20, 344);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(760, 80);
            panel4.TabIndex = 3;
            // 
            // lblPassengerCount
            // 
            lblPassengerCount.AutoSize = true;
            lblPassengerCount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblPassengerCount.ForeColor = Color.Blue;
            lblPassengerCount.Location = new Point(580, 38);
            lblPassengerCount.Name = "lblPassengerCount";
            lblPassengerCount.Size = new Size(24, 28);
            lblPassengerCount.TabIndex = 3;
            lblPassengerCount.Text = "0";
            // 
            // lblPassengerCountLabel
            // 
            lblPassengerCountLabel.AutoSize = true;
            lblPassengerCountLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPassengerCountLabel.ForeColor = Color.FromArgb(11, 94, 235);
            lblPassengerCountLabel.Location = new Point(580, 12);
            lblPassengerCountLabel.Name = "lblPassengerCountLabel";
            lblPassengerCountLabel.Size = new Size(157, 23);
            lblPassengerCountLabel.TabIndex = 2;
            lblPassengerCountLabel.Text = "Passenger Count:";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalAmount.ForeColor = Color.Green;
            lblTotalAmount.Location = new Point(15, 38);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(72, 28);
            lblTotalAmount.TabIndex = 1;
            lblTotalAmount.Text = "₱ 0.00";
            // 
            // lblTotalAmountLabel
            // 
            lblTotalAmountLabel.AutoSize = true;
            lblTotalAmountLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalAmountLabel.ForeColor = Color.FromArgb(11, 94, 235);
            lblTotalAmountLabel.Location = new Point(15, 12);
            lblTotalAmountLabel.Name = "lblTotalAmountLabel";
            lblTotalAmountLabel.Size = new Size(125, 23);
            lblTotalAmountLabel.TabIndex = 0;
            lblTotalAmountLabel.Text = "Total Amount:";
            // 
            // panel5
            // 
            panel5.BackColor = Color.White;
            panel5.BorderStyle = BorderStyle.FixedSingle;
            panel5.Controls.Add(dgvPassengers);
            panel5.Controls.Add(lblPassengersLabel);
            panel5.Location = new Point(20, 432);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(760, 300);
            panel5.TabIndex = 4;
            // 
            // dgvPassengers
            // 
            dgvPassengers.AllowUserToAddRows = false;
            dgvPassengers.AllowUserToDeleteRows = false;
            dgvPassengers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPassengers.BackgroundColor = Color.White;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(11, 94, 235);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvPassengers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvPassengers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvPassengers.DefaultCellStyle = dataGridViewCellStyle2;
            dgvPassengers.EnableHeadersVisualStyles = false;
            dgvPassengers.Location = new Point(15, 56);
            dgvPassengers.Margin = new Padding(3, 4, 3, 4);
            dgvPassengers.Name = "dgvPassengers";
            dgvPassengers.ReadOnly = true;
            dgvPassengers.RowHeadersVisible = false;
            dgvPassengers.RowHeadersWidth = 51;
            dgvPassengers.Size = new Size(730, 230);
            dgvPassengers.TabIndex = 1;
            // 
            // lblPassengersLabel
            // 
            lblPassengersLabel.AutoSize = true;
            lblPassengersLabel.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblPassengersLabel.ForeColor = Color.FromArgb(11, 94, 235);
            lblPassengersLabel.Location = new Point(15, 12);
            lblPassengersLabel.Name = "lblPassengersLabel";
            lblPassengersLabel.Size = new Size(109, 25);
            lblPassengersLabel.TabIndex = 0;
            lblPassengersLabel.Text = "Passengers";
            // 
            // panel6
            // 
            panel6.BackColor = Color.WhiteSmoke;
            panel6.Controls.Add(btnClose);
            panel6.Dock = DockStyle.Bottom;
            panel6.Location = new Point(0, 740);
            panel6.Margin = new Padding(3, 4, 3, 4);
            panel6.Name = "panel6";
            panel6.Size = new Size(800, 80);
            panel6.TabIndex = 5;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(11, 94, 235);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(670, 15);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(110, 50);
            btnClose.TabIndex = 0;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // BookingDetailsDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(800, 820);
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
            Name = "BookingDetailsDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Booking Details";
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
            ((System.ComponentModel.ISupportInitialize)dgvPassengers).EndInit();
            panel6.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblTitle;
        private Label lblBookingRefLabel;
        private Label lblBookingRef;
        private Label lblBookingDateLabel;
        private Label lblBookingDate;
        private Panel panel2;
        private Label lblFerryLabel;
        private Label lblFerry;
        private Label lblRouteLabel;
        private Label lblRoute;
        private Panel panel3;
        private Label lblTripDateLabel;
        private Label lblTripDate;
        private Label lblDepartureLabel;
        private Label lblDeparture;
        private Label lblArrivalLabel;
        private Label lblArrival;
        private Label lblStatusLabel;
        private Label lblStatus;
        private Panel panel4;
        private Label lblTotalAmountLabel;
        private Label lblTotalAmount;
        private Label lblPassengerCountLabel;
        private Label lblPassengerCount;
        private Panel panel5;
        private Label lblPassengersLabel;
        private DataGridView dgvPassengers;
        private Panel panel6;
        private Button btnClose;
    }
}