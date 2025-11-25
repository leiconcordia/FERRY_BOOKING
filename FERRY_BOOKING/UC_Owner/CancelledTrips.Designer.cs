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
            dgvCancelledTrips = new DataGridView();
            lblInstruction = new Label();
            lblTitle = new Label();
            btnRefresh = new Button();
            pnlHeader = new Panel();
            ((System.ComponentModel.ISupportInitialize)dgvCancelledTrips).BeginInit();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            // 
            // dgvCancelledTrips
            // 
            dgvCancelledTrips.AllowUserToAddRows = false;
            dgvCancelledTrips.AllowUserToDeleteRows = false;
            dgvCancelledTrips.BackgroundColor = Color.White;
            dgvCancelledTrips.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCancelledTrips.Location = new Point(95, 127);
            dgvCancelledTrips.Margin = new Padding(3, 4, 3, 4);
            dgvCancelledTrips.Name = "dgvCancelledTrips";
            dgvCancelledTrips.ReadOnly = true;
            dgvCancelledTrips.RowHeadersVisible = false;
            dgvCancelledTrips.RowHeadersWidth = 51;
            dgvCancelledTrips.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCancelledTrips.Size = new Size(1289, 707);
            dgvCancelledTrips.TabIndex = 1;
            dgvCancelledTrips.CellContentClick += dgvCancelledTrips_CellContentClick;
            // 
            // lblInstruction
            // 
            lblInstruction.AutoSize = true;
            lblInstruction.Font = new Font("Segoe UI", 10F, FontStyle.Italic);
            lblInstruction.ForeColor = Color.FromArgb(100, 100, 100);
            lblInstruction.Location = new Point(23, 100);
            lblInstruction.Name = "lblInstruction";
            lblInstruction.Size = new Size(594, 23);
            lblInstruction.TabIndex = 2;
            lblInstruction.Text = "Click the 🔍 View Details button to see affected passengers and process refunds";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(23, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(210, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Cancelled Trips";
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.FromArgb(11, 94, 215);
            btnRefresh.Location = new Point(1367, 17);
            btnRefresh.Margin = new Padding(3, 4, 3, 4);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(126, 40);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Refresh";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.FromArgb(11, 94, 215);
            pnlHeader.Controls.Add(btnRefresh);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1519, 84);
            pnlHeader.TabIndex = 0;
            // 
            // CancelledTrips
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            Controls.Add(lblInstruction);
            Controls.Add(dgvCancelledTrips);
            Controls.Add(pnlHeader);
            Margin = new Padding(3, 4, 3, 4);
            Name = "CancelledTrips";
            Size = new Size(1519, 551);
            ((System.ComponentModel.ISupportInitialize)dgvCancelledTrips).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgvCancelledTrips;
        private Label lblInstruction;
        private Label lblTitle;
        private Button btnRefresh;
        private Panel pnlHeader;
    }
}
