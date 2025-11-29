namespace FERRY_BOOKING.Dialogs
{
    partial class BookingForm
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
            panel1 = new Panel();
            lblDeparture = new Label();
            lblRoute = new Label();
            lblFerry = new Label();
            lblCompany = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SeatPanel = new Panel();
            btnSelectSeats = new Button();
            nudSelectSeats = new NumericUpDown();
            label9 = new Label();
            lblSeatsAvailable = new Label();
            lblPrice = new Label();
            label = new Label();
            tlpSeats = new TableLayoutPanel();
            label6 = new Label();
            flpFloors = new FlowLayoutPanel();
            label5 = new Label();
            PassengerPanel = new Panel();
            lblTotalPrice = new Label();
            label8 = new Label();
            btnCancel = new Button();
            btnGenerateTicket = new Button();
            label7 = new Label();
            flpPassengerInfo = new FlowLayoutPanel();
            panel1.SuspendLayout();
            SeatPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudSelectSeats).BeginInit();
            PassengerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(30, 64, 175);
            panel1.Controls.Add(lblDeparture);
            panel1.Controls.Add(lblRoute);
            panel1.Controls.Add(lblFerry);
            panel1.Controls.Add(lblCompany);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1103, 82);
            panel1.TabIndex = 0;
            // 
            // lblDeparture
            // 
            lblDeparture.AutoSize = true;
            lblDeparture.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDeparture.ForeColor = SystemColors.ButtonHighlight;
            lblDeparture.Location = new Point(863, 52);
            lblDeparture.Name = "lblDeparture";
            lblDeparture.Size = new Size(100, 20);
            lblDeparture.TabIndex = 7;
            lblDeparture.Text = "no departure";
            // 
            // lblRoute
            // 
            lblRoute.AutoSize = true;
            lblRoute.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRoute.ForeColor = SystemColors.ButtonHighlight;
            lblRoute.Location = new Point(635, 52);
            lblRoute.Name = "lblRoute";
            lblRoute.Size = new Size(73, 20);
            lblRoute.TabIndex = 6;
            lblRoute.Text = "no Route";
            // 
            // lblFerry
            // 
            lblFerry.AutoSize = true;
            lblFerry.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblFerry.ForeColor = SystemColors.ButtonHighlight;
            lblFerry.Location = new Point(340, 52);
            lblFerry.Name = "lblFerry";
            lblFerry.Size = new Size(69, 20);
            lblFerry.TabIndex = 5;
            lblFerry.Text = "No ferry";
            // 
            // lblCompany
            // 
            lblCompany.AutoSize = true;
            lblCompany.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCompany.ForeColor = SystemColors.ButtonHighlight;
            lblCompany.Location = new Point(71, 52);
            lblCompany.Name = "lblCompany";
            lblCompany.Size = new Size(97, 20);
            lblCompany.TabIndex = 4;
            lblCompany.Text = "no Company";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(863, 10);
            label4.Name = "label4";
            label4.Size = new Size(100, 28);
            label4.TabIndex = 3;
            label4.Text = "Departure";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(635, 10);
            label3.Name = "label3";
            label3.Size = new Size(63, 28);
            label3.TabIndex = 2;
            label3.Text = "Route";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(340, 10);
            label2.Name = "label2";
            label2.Size = new Size(56, 28);
            label2.TabIndex = 1;
            label2.Text = "Ferry";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(71, 10);
            label1.Name = "label1";
            label1.Size = new Size(96, 28);
            label1.TabIndex = 0;
            label1.Text = "Company";
            // 
            // SeatPanel
            // 
            SeatPanel.BackColor = SystemColors.ButtonHighlight;
            SeatPanel.Controls.Add(btnSelectSeats);
            SeatPanel.Controls.Add(nudSelectSeats);
            SeatPanel.Controls.Add(label9);
            SeatPanel.Controls.Add(lblSeatsAvailable);
            SeatPanel.Controls.Add(lblPrice);
            SeatPanel.Controls.Add(label);
            SeatPanel.Controls.Add(tlpSeats);
            SeatPanel.Controls.Add(label6);
            SeatPanel.Controls.Add(flpFloors);
            SeatPanel.Controls.Add(label5);
            SeatPanel.Location = new Point(12, 116);
            SeatPanel.Name = "SeatPanel";
            SeatPanel.Size = new Size(537, 583);
            SeatPanel.TabIndex = 1;
            // 
            // btnSelectSeats
            // 
            btnSelectSeats.BackColor = Color.FromArgb(30, 64, 175);
            btnSelectSeats.ForeColor = SystemColors.ButtonHighlight;
            btnSelectSeats.Location = new Point(393, 146);
            btnSelectSeats.Name = "btnSelectSeats";
            btnSelectSeats.Size = new Size(119, 32);
            btnSelectSeats.TabIndex = 17;
            btnSelectSeats.Text = "Select Seats";
            btnSelectSeats.UseVisualStyleBackColor = false;
            btnSelectSeats.Click += btnSelectSeats_Click;
            // 
            // nudSelectSeats
            // 
            nudSelectSeats.Location = new Point(288, 149);
            nudSelectSeats.Maximum = new decimal(new int[] { 50, 0, 0, 0 });
            nudSelectSeats.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSelectSeats.Name = "nudSelectSeats";
            nudSelectSeats.Size = new Size(99, 27);
            nudSelectSeats.TabIndex = 16;
            nudSelectSeats.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudSelectSeats.ValueChanged += nudSelectSeats_ValueChanged;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(223, 151);
            label9.Name = "label9";
            label9.Size = new Size(59, 20);
            label9.TabIndex = 15;
            label9.Text = "Select: ";
            // 
            // lblSeatsAvailable
            // 
            lblSeatsAvailable.AutoSize = true;
            lblSeatsAvailable.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSeatsAvailable.Location = new Point(288, 7);
            lblSeatsAvailable.Name = "lblSeatsAvailable";
            lblSeatsAvailable.Size = new Size(153, 23);
            lblSeatsAvailable.TabIndex = 14;
            lblSeatsAvailable.Text = "Seats Available: 0";
            // 
            // lblPrice
            // 
            lblPrice.AutoSize = true;
            lblPrice.Location = new Point(60, 151);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(17, 20);
            lblPrice.TabIndex = 13;
            lblPrice.Text = "0";
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(19, 151);
            label.Name = "label";
            label.Size = new Size(48, 20);
            label.TabIndex = 12;
            label.Text = "Price: ";
            // 
            // tlpSeats
            // 
            tlpSeats.ColumnCount = 2;
            tlpSeats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpSeats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpSeats.Location = new Point(19, 184);
            tlpSeats.Name = "tlpSeats";
            tlpSeats.RowCount = 2;
            tlpSeats.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpSeats.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpSeats.Size = new Size(493, 396);
            tlpSeats.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ButtonHighlight;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.AppWorkspace;
            label6.Location = new Point(19, 38);
            label6.Name = "label6";
            label6.Size = new Size(262, 23);
            label6.TabIndex = 10;
            label6.Text = "Click on available seats to select. ";
            // 
            // flpFloors
            // 
            flpFloors.Location = new Point(19, 76);
            flpFloors.Name = "flpFloors";
            flpFloors.Size = new Size(493, 67);
            flpFloors.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ActiveCaptionText;
            label5.Location = new Point(19, 15);
            label5.Name = "label5";
            label5.Size = new Size(252, 23);
            label5.TabIndex = 8;
            label5.Text = "Select Seats - Ferry Deck Layout";
            // 
            // PassengerPanel
            // 
            PassengerPanel.BackColor = SystemColors.ButtonHighlight;
            PassengerPanel.Controls.Add(lblTotalPrice);
            PassengerPanel.Controls.Add(label8);
            PassengerPanel.Controls.Add(btnCancel);
            PassengerPanel.Controls.Add(btnGenerateTicket);
            PassengerPanel.Controls.Add(label7);
            PassengerPanel.Controls.Add(flpPassengerInfo);
            PassengerPanel.Location = new Point(578, 116);
            PassengerPanel.Name = "PassengerPanel";
            PassengerPanel.Size = new Size(537, 583);
            PassengerPanel.TabIndex = 2;
            // 
            // lblTotalPrice
            // 
            lblTotalPrice.AutoSize = true;
            lblTotalPrice.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTotalPrice.Location = new Point(105, 533);
            lblTotalPrice.Name = "lblTotalPrice";
            lblTotalPrice.Size = new Size(20, 23);
            lblTotalPrice.TabIndex = 15;
            lblTotalPrice.Text = "0";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(18, 534);
            label8.Name = "label8";
            label8.Size = new Size(81, 20);
            label8.TabIndex = 14;
            label8.Text = "Total Price:";
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.ForeColor = SystemColors.ButtonHighlight;
            btnCancel.Location = new Point(266, 519);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(90, 52);
            btnCancel.TabIndex = 13;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // btnGenerateTicket
            // 
            btnGenerateTicket.BackColor = Color.FromArgb(30, 64, 175);
            btnGenerateTicket.ForeColor = SystemColors.ButtonHighlight;
            btnGenerateTicket.Location = new Point(362, 519);
            btnGenerateTicket.Name = "btnGenerateTicket";
            btnGenerateTicket.Size = new Size(148, 52);
            btnGenerateTicket.TabIndex = 12;
            btnGenerateTicket.Text = "Generate Ticket";
            btnGenerateTicket.UseVisualStyleBackColor = false;
            btnGenerateTicket.Click += btnGenerateTicket_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(11, 94, 235);
            label7.Location = new Point(17, 7);
            label7.Name = "label7";
            label7.Size = new Size(185, 28);
            label7.TabIndex = 11;
            label7.Text = "Passenger Details ";
            // 
            // flpPassengerInfo
            // 
            flpPassengerInfo.AutoScroll = true;
            flpPassengerInfo.FlowDirection = FlowDirection.TopDown;
            flpPassengerInfo.Location = new Point(17, 38);
            flpPassengerInfo.Name = "flpPassengerInfo";
            flpPassengerInfo.Size = new Size(493, 466);
            flpPassengerInfo.TabIndex = 10;
            flpPassengerInfo.WrapContents = false;
            // 
            // BookingForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1127, 712);
            Controls.Add(PassengerPanel);
            Controls.Add(SeatPanel);
            Controls.Add(panel1);
            Name = "BookingForm";
            Text = "BookingForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            SeatPanel.ResumeLayout(false);
            SeatPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudSelectSeats).EndInit();
            PassengerPanel.ResumeLayout(false);
            PassengerPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label lblCompany;
        private Label lblDeparture;
        private Label lblRoute;
        private Label lblFerry;
        private Panel SeatPanel;
        private Panel PassengerPanel;
        private Label label5;
        private FlowLayoutPanel flpFloors;
        private Label label6;
        private TableLayoutPanel tlpSeats;
        private FlowLayoutPanel flpPassengerInfo;
        private Label label7;
        private Button btnGenerateTicket;
        private Button btnCancel;
        private Label lblTotalPrice;
        private Label label8;
        private Label label;
        private Label lblPrice;
        private Label lblSeatsAvailable;
        private NumericUpDown nudSelectSeats;
        private Label label9;
        private Button btnSelectSeats;
    }
}