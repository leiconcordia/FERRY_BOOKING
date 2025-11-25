namespace FERRY_BOOKING.Dialogs
{
    partial class TripViewDialog
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
            lblTripDate = new Label();
            label9 = new Label();
            lblArrival = new Label();
            label10 = new Label();
            lblDeparture = new Label();
            lblRoute = new Label();
            lblFerry = new Label();
            lblCompany = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            SeatPanel = new Panel();
            lblFloorStats = new Label();
            tlpSeats = new TableLayoutPanel();
            label6 = new Label();
            flpFloors = new FlowLayoutPanel();
            label5 = new Label();
            panel2 = new Panel();
            btnClose = new Button();
            label7 = new Label();
            label8 = new Label();
            label11 = new Label();
            panel1.SuspendLayout();
            SeatPanel.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(30, 64, 175);
            panel1.Controls.Add(lblTripDate);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(lblArrival);
            panel1.Controls.Add(label10);
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
            panel1.Size = new Size(876, 120);
            panel1.TabIndex = 0;
            // 
            // lblTripDate
            // 
            lblTripDate.AutoSize = true;
            lblTripDate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTripDate.ForeColor = SystemColors.ButtonHighlight;
            lblTripDate.Location = new Point(640, 85);
            lblTripDate.Name = "lblTripDate";
            lblTripDate.Size = new Size(85, 20);
            lblTripDate.TabIndex = 11;
            lblTripDate.Text = "no tripdate";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 10F);
            label9.ForeColor = SystemColors.ButtonHighlight;
            label9.Location = new Point(640, 62);
            label9.Name = "label9";
            label9.Size = new Size(79, 23);
            label9.TabIndex = 10;
            label9.Text = "Trip Date";
            // 
            // lblArrival
            // 
            lblArrival.AutoSize = true;
            lblArrival.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblArrival.ForeColor = SystemColors.ButtonHighlight;
            lblArrival.Location = new Point(495, 85);
            lblArrival.Name = "lblArrival";
            lblArrival.Size = new Size(73, 20);
            lblArrival.TabIndex = 9;
            lblArrival.Text = "no arrival";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 10F);
            label10.ForeColor = SystemColors.ButtonHighlight;
            label10.Location = new Point(495, 62);
            label10.Name = "label10";
            label10.Size = new Size(60, 23);
            label10.TabIndex = 8;
            label10.Text = "Arrival";
            // 
            // lblDeparture
            // 
            lblDeparture.AutoSize = true;
            lblDeparture.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDeparture.ForeColor = SystemColors.ButtonHighlight;
            lblDeparture.Location = new Point(330, 85);
            lblDeparture.Name = "lblDeparture";
            lblDeparture.Size = new Size(100, 20);
            lblDeparture.TabIndex = 7;
            lblDeparture.Text = "no departure";
            // 
            // lblRoute
            // 
            lblRoute.AutoSize = true;
            lblRoute.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblRoute.ForeColor = SystemColors.ButtonHighlight;
            lblRoute.Location = new Point(170, 85);
            lblRoute.Name = "lblRoute";
            lblRoute.Size = new Size(73, 20);
            lblRoute.TabIndex = 6;
            lblRoute.Text = "no Route";
            // 
            // lblFerry
            // 
            lblFerry.AutoSize = true;
            lblFerry.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFerry.ForeColor = SystemColors.ButtonHighlight;
            lblFerry.Location = new Point(20, 85);
            lblFerry.Name = "lblFerry";
            lblFerry.Size = new Size(69, 20);
            lblFerry.TabIndex = 5;
            lblFerry.Text = "No ferry";
            // 
            // lblCompany
            // 
            lblCompany.AutoSize = true;
            lblCompany.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblCompany.ForeColor = Color.FromArgb(255, 193, 7);
            lblCompany.Location = new Point(20, 20);
            lblCompany.Name = "lblCompany";
            lblCompany.Size = new Size(128, 28);
            lblCompany.TabIndex = 4;
            lblCompany.Text = "no Company";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(330, 62);
            label4.Name = "label4";
            label4.Size = new Size(88, 23);
            label4.TabIndex = 3;
            label4.Text = "Departure";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(170, 62);
            label3.Name = "label3";
            label3.Size = new Size(55, 23);
            label3.TabIndex = 2;
            label3.Text = "Route";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(20, 62);
            label2.Name = "label2";
            label2.Size = new Size(48, 23);
            label2.TabIndex = 1;
            label2.Text = "Ferry";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(20, 0);
            label1.Name = "label1";
            label1.Size = new Size(72, 20);
            label1.TabIndex = 0;
            label1.Text = "Company";
            // 
            // SeatPanel
            // 
            SeatPanel.BackColor = SystemColors.ButtonHighlight;
            SeatPanel.Controls.Add(lblFloorStats);
            SeatPanel.Controls.Add(tlpSeats);
            SeatPanel.Controls.Add(label6);
            SeatPanel.Controls.Add(flpFloors);
            SeatPanel.Controls.Add(label5);
            SeatPanel.Location = new Point(12, 138);
            SeatPanel.Name = "SeatPanel";
            SeatPanel.Size = new Size(876, 560);
            SeatPanel.TabIndex = 1;
            // 
            // lblFloorStats
            // 
            lblFloorStats.AutoSize = true;
            lblFloorStats.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFloorStats.ForeColor = Color.FromArgb(11, 94, 235);
            lblFloorStats.Location = new Point(19, 140);
            lblFloorStats.Name = "lblFloorStats";
            lblFloorStats.Size = new Size(266, 23);
            lblFloorStats.TabIndex = 12;
            lblFloorStats.Text = "Floor Statistics will appear here";
            // 
            // tlpSeats
            // 
            tlpSeats.ColumnCount = 2;
            tlpSeats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpSeats.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpSeats.Location = new Point(19, 170);
            tlpSeats.Name = "tlpSeats";
            tlpSeats.RowCount = 2;
            tlpSeats.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpSeats.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpSeats.Size = new Size(840, 380);
            tlpSeats.TabIndex = 11;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ButtonHighlight;
            label6.Font = new Font("Segoe UI", 9F);
            label6.ForeColor = SystemColors.AppWorkspace;
            label6.Location = new Point(19, 38);
            label6.Name = "label6";
            label6.Size = new Size(270, 20);
            label6.TabIndex = 10;
            label6.Text = "View booked and available seats status.";
            // 
            // flpFloors
            // 
            flpFloors.Location = new Point(19, 76);
            flpFloors.Name = "flpFloors";
            flpFloors.Size = new Size(840, 55);
            flpFloors.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(11, 94, 235);
            label5.Location = new Point(19, 10);
            label5.Name = "label5";
            label5.Size = new Size(221, 28);
            label5.TabIndex = 8;
            label5.Text = "Ferry Seats - Deck View";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonHighlight;
            panel2.Controls.Add(btnClose);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label11);
            panel2.Location = new Point(12, 704);
            panel2.Name = "panel2";
            panel2.Size = new Size(876, 60);
            panel2.TabIndex = 2;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(30, 64, 175);
            btnClose.ForeColor = SystemColors.ButtonHighlight;
            btnClose.Location = new Point(748, 10);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(111, 40);
            btnClose.TabIndex = 3;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label7.Location = new Point(19, 10);
            label7.Name = "label7";
            label7.Size = new Size(60, 20);
            label7.TabIndex = 2;
            label7.Text = "Legend";
            // 
            // label8
            // 
            label8.BackColor = Color.DarkRed;
            label8.ForeColor = Color.White;
            label8.Location = new Point(19, 33);
            label8.Name = "label8";
            label8.Size = new Size(100, 23);
            label8.TabIndex = 0;
            label8.Text = "Booked";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            label11.BackColor = Color.LightGreen;
            label11.ForeColor = Color.Black;
            label11.Location = new Point(125, 33);
            label11.Name = "label11";
            label11.Size = new Size(100, 23);
            label11.TabIndex = 1;
            label11.Text = "Available";
            label11.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TripViewDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 776);
            Controls.Add(panel2);
            Controls.Add(SeatPanel);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "TripViewDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Trip View - Ferry Seat Layout";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            SeatPanel.ResumeLayout(false);
            SeatPanel.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
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
        private Label label5;
        private FlowLayoutPanel flpFloors;
        private Label label6;
        private TableLayoutPanel tlpSeats;
        private Label lblFloorStats;
        private Panel panel2;
        private Label label8;
        private Label label11;
        private Label label7;
        private Button btnClose;
        private Label lblArrival;
        private Label label10;
        private Label lblTripDate;
        private Label label9;
    }
}
