namespace FERRY_BOOKING.UC_Owner
{
    partial class RefundsAndCancellations
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            btnRefresh = new Button();
            lblTitle = new Label();
            pnlMain = new Panel();
            tabControl = new TabControl();
            tabPendingRefunds = new TabPage();
            btnRefundAll = new Button();
            dgvPendingRefunds = new DataGridView();
            label2 = new Label();
            tabCancelledTrips = new TabPage();
            dgvCancelledTrips = new DataGridView();
            label3 = new Label();
            pnlStatistics = new Panel();
            lblCompletedRefunds = new Label();
            label10 = new Label();
            lblPendingRefunds = new Label();
            label8 = new Label();
            lblTotalRefundAmount = new Label();
            label6 = new Label();
            lblTotalPassengers = new Label();
            label4 = new Label();
            lblTotalCancellations = new Label();
            label1 = new Label();
            lblSubtitle = new Label();
            lblMainTitle = new Label();
            pnlHeader.SuspendLayout();
            pnlMain.SuspendLayout();
            tabControl.SuspendLayout();
            tabPendingRefunds.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPendingRefunds).BeginInit();
            tabCancelledTrips.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCancelledTrips).BeginInit();
            pnlStatistics.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(11, 94, 215);
            pnlHeader.Controls.Add(btnRefresh);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1656, 0);
            pnlHeader.TabIndex = 0;
            pnlHeader.Visible = false;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.FromArgb(11, 94, 215);
            btnRefresh.Location = new Point(1500, 20);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(126, 40);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(23, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(327, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Refunds & Cancellations";
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.White;
            pnlMain.Controls.Add(tabControl);
            pnlMain.Controls.Add(pnlStatistics);
            pnlMain.Controls.Add(lblSubtitle);
            pnlMain.Controls.Add(lblMainTitle);
            pnlMain.Location = new Point(80, 40);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1497, 470);
            pnlMain.TabIndex = 1;
            // 
            // tabControl
            // 
            tabControl.Controls.Add(tabPendingRefunds);
            tabControl.Controls.Add(tabCancelledTrips);
            tabControl.Location = new Point(28, 223);
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.Size = new Size(1456, 220);
            tabControl.TabIndex = 5;
            // 
            // tabPendingRefunds
            // 
            tabPendingRefunds.Controls.Add(btnRefundAll);
            tabPendingRefunds.Controls.Add(dgvPendingRefunds);
            tabPendingRefunds.Controls.Add(label2);
            tabPendingRefunds.Location = new Point(4, 29);
            tabPendingRefunds.Name = "tabPendingRefunds";
            tabPendingRefunds.Padding = new Padding(3);
            tabPendingRefunds.Size = new Size(1448, 187);
            tabPendingRefunds.TabIndex = 0;
            tabPendingRefunds.Text = "Pending Refunds";
            tabPendingRefunds.UseVisualStyleBackColor = true;
            // 
            // btnRefundAll
            // 
            btnRefundAll.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefundAll.BackColor = Color.FromArgb(40, 167, 69);
            btnRefundAll.FlatStyle = FlatStyle.Flat;
            btnRefundAll.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefundAll.ForeColor = Color.White;
            btnRefundAll.Location = new Point(1236, 12);
            btnRefundAll.Name = "btnRefundAll";
            btnRefundAll.Size = new Size(206, 35);
            btnRefundAll.TabIndex = 2;
            btnRefundAll.Text = "💰 Refund All Pending";
            btnRefundAll.UseVisualStyleBackColor = false;
            btnRefundAll.Click += btnRefundAll_Click;
            // 
            // dgvPendingRefunds
            // 
            dgvPendingRefunds.AllowUserToAddRows = false;
            dgvPendingRefunds.AllowUserToDeleteRows = false;
            dgvPendingRefunds.BackgroundColor = Color.White;
            dgvPendingRefunds.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPendingRefunds.Location = new Point(15, 55);
            dgvPendingRefunds.Name = "dgvPendingRefunds";
            dgvPendingRefunds.ReadOnly = true;
            dgvPendingRefunds.RowHeadersVisible = false;
            dgvPendingRefunds.RowHeadersWidth = 51;
            dgvPendingRefunds.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPendingRefunds.Size = new Size(1420, 120);
            dgvPendingRefunds.TabIndex = 1;
            dgvPendingRefunds.CellContentClick += dgvPendingRefunds_CellContentClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.Location = new Point(15, 15);
            label2.Name = "label2";
            label2.Size = new Size(371, 23);
            label2.TabIndex = 0;
            label2.Text = "Refunds Pending Processing (Click to Process)";
            // 
            // tabCancelledTrips
            // 
            tabCancelledTrips.Controls.Add(dgvCancelledTrips);
            tabCancelledTrips.Controls.Add(label3);
            tabCancelledTrips.Location = new Point(4, 29);
            tabCancelledTrips.Name = "tabCancelledTrips";
            tabCancelledTrips.Padding = new Padding(3);
            tabCancelledTrips.Size = new Size(1448, 187);
            tabCancelledTrips.TabIndex = 1;
            tabCancelledTrips.Text = "Cancelled Trips History";
            tabCancelledTrips.UseVisualStyleBackColor = true;
            // 
            // dgvCancelledTrips
            // 
            dgvCancelledTrips.AllowUserToAddRows = false;
            dgvCancelledTrips.AllowUserToDeleteRows = false;
            dgvCancelledTrips.BackgroundColor = Color.White;
            dgvCancelledTrips.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCancelledTrips.Location = new Point(15, 55);
            dgvCancelledTrips.Name = "dgvCancelledTrips";
            dgvCancelledTrips.ReadOnly = true;
            dgvCancelledTrips.RowHeadersVisible = false;
            dgvCancelledTrips.RowHeadersWidth = 51;
            dgvCancelledTrips.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCancelledTrips.Size = new Size(1420, 120);
            dgvCancelledTrips.TabIndex = 1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.Location = new Point(15, 15);
            label3.Name = "label3";
            label3.Size = new Size(247, 23);
            label3.TabIndex = 0;
            label3.Text = "All Cancelled Trips (Historical)";
            // 
            // pnlStatistics
            // 
            pnlStatistics.BackColor = Color.FromArgb(240, 247, 255);
            pnlStatistics.BorderStyle = BorderStyle.FixedSingle;
            pnlStatistics.Controls.Add(lblCompletedRefunds);
            pnlStatistics.Controls.Add(label10);
            pnlStatistics.Controls.Add(lblPendingRefunds);
            pnlStatistics.Controls.Add(label8);
            pnlStatistics.Controls.Add(lblTotalRefundAmount);
            pnlStatistics.Controls.Add(label6);
            pnlStatistics.Controls.Add(lblTotalPassengers);
            pnlStatistics.Controls.Add(label4);
            pnlStatistics.Controls.Add(lblTotalCancellations);
            pnlStatistics.Controls.Add(label1);
            pnlStatistics.Location = new Point(28, 78);
            pnlStatistics.Name = "pnlStatistics";
            pnlStatistics.Size = new Size(1456, 120);
            pnlStatistics.TabIndex = 4;
            // 
            // lblCompletedRefunds
            // 
            lblCompletedRefunds.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblCompletedRefunds.ForeColor = Color.Green;
            lblCompletedRefunds.Location = new Point(1162, 57);
            lblCompletedRefunds.Name = "lblCompletedRefunds";
            lblCompletedRefunds.Size = new Size(240, 40);
            lblCompletedRefunds.TabIndex = 9;
            lblCompletedRefunds.Text = "0";
            lblCompletedRefunds.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            label10.Font = new Font("Segoe UI", 9F);
            label10.ForeColor = Color.Gray;
            label10.Location = new Point(1162, 24);
            label10.Name = "label10";
            label10.Size = new Size(240, 27);
            label10.TabIndex = 8;
            label10.Text = "Completed Refunds";
            label10.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblPendingRefunds
            // 
            lblPendingRefunds.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblPendingRefunds.ForeColor = Color.OrangeRed;
            lblPendingRefunds.Location = new Point(880, 57);
            lblPendingRefunds.Name = "lblPendingRefunds";
            lblPendingRefunds.Size = new Size(240, 40);
            lblPendingRefunds.TabIndex = 7;
            lblPendingRefunds.Text = "0";
            lblPendingRefunds.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.Font = new Font("Segoe UI", 9F);
            label8.ForeColor = Color.Gray;
            label8.Location = new Point(880, 24);
            label8.Name = "label8";
            label8.Size = new Size(240, 27);
            label8.TabIndex = 6;
            label8.Text = "Pending Refunds";
            label8.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalRefundAmount
            // 
            lblTotalRefundAmount.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalRefundAmount.ForeColor = Color.Crimson;
            lblTotalRefundAmount.Location = new Point(598, 57);
            lblTotalRefundAmount.Name = "lblTotalRefundAmount";
            lblTotalRefundAmount.Size = new Size(240, 40);
            lblTotalRefundAmount.TabIndex = 5;
            lblTotalRefundAmount.Text = "₱0.00";
            lblTotalRefundAmount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            label6.Font = new Font("Segoe UI", 9F);
            label6.ForeColor = Color.Gray;
            label6.Location = new Point(598, 24);
            label6.Name = "label6";
            label6.Size = new Size(240, 27);
            label6.TabIndex = 4;
            label6.Text = "Total Refund Amount";
            label6.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalPassengers
            // 
            lblTotalPassengers.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalPassengers.ForeColor = Color.FromArgb(11, 94, 215);
            lblTotalPassengers.Location = new Point(316, 57);
            lblTotalPassengers.Name = "lblTotalPassengers";
            lblTotalPassengers.Size = new Size(240, 40);
            lblTotalPassengers.TabIndex = 3;
            lblTotalPassengers.Text = "0";
            lblTotalPassengers.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.Font = new Font("Segoe UI", 9F);
            label4.ForeColor = Color.Gray;
            label4.Location = new Point(316, 24);
            label4.Name = "label4";
            label4.Size = new Size(240, 27);
            label4.TabIndex = 2;
            label4.Text = "Passengers Affected";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblTotalCancellations
            // 
            lblTotalCancellations.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTotalCancellations.ForeColor = Color.FromArgb(11, 94, 215);
            lblTotalCancellations.Location = new Point(34, 57);
            lblTotalCancellations.Name = "lblTotalCancellations";
            lblTotalCancellations.Size = new Size(240, 40);
            lblTotalCancellations.TabIndex = 1;
            lblTotalCancellations.Text = "0";
            lblTotalCancellations.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 9F);
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(34, 24);
            label1.Name = "label1";
            label1.Size = new Size(240, 27);
            label1.TabIndex = 0;
            label1.Text = "Total Cancellations";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.ForeColor = Color.FromArgb(100, 100, 100);
            lblSubtitle.Location = new Point(28, 43);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(350, 20);
            lblSubtitle.TabIndex = 2;
            lblSubtitle.Text = "Manage refunds and view cancelled trip information";
            // 
            // lblMainTitle
            // 
            lblMainTitle.AutoSize = true;
            lblMainTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblMainTitle.ForeColor = Color.FromArgb(11, 94, 215);
            lblMainTitle.Location = new Point(28, 15);
            lblMainTitle.Name = "lblMainTitle";
            lblMainTitle.Size = new Size(305, 28);
            lblMainTitle.TabIndex = 1;
            lblMainTitle.Text = "Refunds && Cancelled Trips";
            // 
            // RefundsAndCancellations
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(pnlMain);
            Controls.Add(pnlHeader);
            Name = "RefundsAndCancellations";
            Size = new Size(1656, 551);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            tabControl.ResumeLayout(false);
            tabPendingRefunds.ResumeLayout(false);
            tabPendingRefunds.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvPendingRefunds).EndInit();
            tabCancelledTrips.ResumeLayout(false);
            tabCancelledTrips.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCancelledTrips).EndInit();
            pnlStatistics.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Button btnRefresh;
        private Panel pnlMain;
        private Panel pnlStatistics;
        private Label lblTotalCancellations;
        private Label label1;
        private Label lblTotalPassengers;
        private Label label4;
        private Label lblTotalRefundAmount;
        private Label label6;
        private Label lblPendingRefunds;
        private Label label8;
        private Label lblCompletedRefunds;
        private Label label10;
        private TabControl tabControl;
        private TabPage tabPendingRefunds;
        private TabPage tabCancelledTrips;
        private DataGridView dgvPendingRefunds;
        private Label label2;
        private DataGridView dgvCancelledTrips;
        private Label label3;
        private Button btnRefundAll;
        private Label lblSubtitle;
        private Label lblMainTitle;
    }
}
