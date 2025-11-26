namespace FERRY_BOOKING.UC_Owner
{
    partial class CancelledTrips
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
            pnlMain = new Panel();
            dgvCancelledTrips = new DataGridView();
            lblInstruction = new Label();
            lblTitle = new Label();
            pnlHeader = new Panel();
            btnRefresh = new Button();
            pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCancelledTrips).BeginInit();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMain
            // 
            pnlMain.BackColor = Color.White;
            pnlMain.Controls.Add(dgvCancelledTrips);
            pnlMain.Controls.Add(lblInstruction);
            pnlMain.Controls.Add(lblTitle);
            pnlMain.Location = new Point(80, 40);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1497, 470);
            pnlMain.TabIndex = 1;
            // 
            // dgvCancelledTrips
            // 
            dgvCancelledTrips.AllowUserToAddRows = false;
            dgvCancelledTrips.AllowUserToDeleteRows = false;
            dgvCancelledTrips.BackgroundColor = Color.White;
            dgvCancelledTrips.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCancelledTrips.Location = new Point(28, 78);
            dgvCancelledTrips.Name = "dgvCancelledTrips";
            dgvCancelledTrips.ReadOnly = true;
            dgvCancelledTrips.RowHeadersVisible = false;
            dgvCancelledTrips.RowHeadersWidth = 51;
            dgvCancelledTrips.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCancelledTrips.Size = new Size(1456, 365);
            dgvCancelledTrips.TabIndex = 3;
            dgvCancelledTrips.CellContentClick += dgvCancelledTrips_CellContentClick;
            // 
            // lblInstruction
            // 
            lblInstruction.AutoSize = true;
            lblInstruction.ForeColor = Color.FromArgb(100, 100, 100);
            lblInstruction.Location = new Point(28, 43);
            lblInstruction.Name = "lblInstruction";
            lblInstruction.Size = new Size(594, 20);
            lblInstruction.TabIndex = 2;
            lblInstruction.Text = "Click the 🔍 View Details button to see affected passengers and process refunds";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.FromArgb(11, 94, 215);
            lblTitle.Location = new Point(28, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(157, 28);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Cancelled Trips";
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(11, 94, 215);
            pnlHeader.Controls.Add(btnRefresh);
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
            // CancelledTrips
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(pnlMain);
            Controls.Add(pnlHeader);
            Name = "CancelledTrips";
            Size = new Size(1656, 551);
            pnlMain.ResumeLayout(false);
            pnlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCancelledTrips).EndInit();
            pnlHeader.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel pnlMain;
        private DataGridView dgvCancelledTrips;
        private Label lblInstruction;
        private Label lblTitle;
        private Button btnRefresh;
        private Panel pnlHeader;
    }
}
