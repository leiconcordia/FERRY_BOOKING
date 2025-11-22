namespace FERRY_BOOKING.UC_Ferry
{
    partial class Summary
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel1 = new Panel();
            cmbFerry = new ComboBox();
            lblEmptyMessage = new Label();
            dgvBookingSummary = new DataGridView();
            label1 = new Label();
            lblCompanyNameFleet = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            cmbRoute = new ComboBox();
            dtpDate = new DateTimePicker();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBookingSummary).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(dtpDate);
            panel1.Controls.Add(cmbRoute);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(cmbFerry);
            panel1.Controls.Add(lblEmptyMessage);
            panel1.Controls.Add(dgvBookingSummary);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblCompanyNameFleet);
            panel1.Location = new Point(80, 40);
            panel1.Name = "panel1";
            panel1.Size = new Size(1497, 470);
            panel1.TabIndex = 1;
            // 
            // cmbFerry
            // 
            cmbFerry.FormattingEnabled = true;
            cmbFerry.Location = new Point(438, 35);
            cmbFerry.Name = "cmbFerry";
            cmbFerry.Size = new Size(128, 28);
            cmbFerry.TabIndex = 49;
            cmbFerry.SelectedIndexChanged += FilterChanged;
            // 
            // lblEmptyMessage
            // 
            lblEmptyMessage.AutoSize = true;
            lblEmptyMessage.BackColor = SystemColors.ButtonFace;
            lblEmptyMessage.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmptyMessage.ForeColor = SystemColors.AppWorkspace;
            lblEmptyMessage.Location = new Point(538, 219);
            lblEmptyMessage.Name = "lblEmptyMessage";
            lblEmptyMessage.Size = new Size(282, 46);
            lblEmptyMessage.TabIndex = 48;
            lblEmptyMessage.Text = "lblEmptyMessage";
            // 
            // dgvBookingSummary
            // 
            dgvBookingSummary.AllowUserToAddRows = false;
            dgvBookingSummary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvBookingSummary.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvBookingSummary.BackgroundColor = Color.White;
            dgvBookingSummary.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(11, 94, 235);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvBookingSummary.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvBookingSummary.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(11, 94, 235);
            dataGridViewCellStyle2.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvBookingSummary.DefaultCellStyle = dataGridViewCellStyle2;
            dgvBookingSummary.EnableHeadersVisualStyles = false;
            dgvBookingSummary.Location = new Point(28, 78);
            dgvBookingSummary.Name = "dgvBookingSummary";
            dgvBookingSummary.RowHeadersVisible = false;
            dgvBookingSummary.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = Color.White;
            dgvBookingSummary.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvBookingSummary.Size = new Size(1456, 365);
            dgvBookingSummary.TabIndex = 3;
            dgvBookingSummary.CellClick += dgvBookingSummary_CellClick;
            dgvBookingSummary.CellPainting += dgvBookingSummary_CellPainting;


            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(28, 43);
            label1.Name = "label1";
            label1.Size = new Size(277, 20);
            label1.TabIndex = 2;
            label1.Text = "Detailed booking statistics for each ferry";
            // 
            // lblCompanyNameFleet
            // 
            lblCompanyNameFleet.AutoSize = true;
            lblCompanyNameFleet.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCompanyNameFleet.ForeColor = Color.FromArgb(11, 94, 235);
            lblCompanyNameFleet.Location = new Point(28, 15);
            lblCompanyNameFleet.Name = "lblCompanyNameFleet";
            lblCompanyNameFleet.Size = new Size(291, 28);
            lblCompanyNameFleet.TabIndex = 1;
            lblCompanyNameFleet.Text = "Ferry-wise Booking Summary";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(11, 94, 235);
            label2.Location = new Point(366, 35);
            label2.Name = "label2";
            label2.Size = new Size(66, 28);
            label2.TabIndex = 50;
            label2.Text = "Ferry:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(11, 94, 235);
            label3.Location = new Point(572, 39);
            label3.Name = "label3";
            label3.Size = new Size(73, 28);
            label3.TabIndex = 51;
            label3.Text = "Route:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(11, 94, 235);
            label4.Location = new Point(785, 36);
            label4.Name = "label4";
            label4.Size = new Size(62, 28);
            label4.TabIndex = 52;
            label4.Text = "Date:";
            // 
            // cmbRoute
            // 
            cmbRoute.FormattingEnabled = true;
            cmbRoute.Location = new Point(651, 35);
            cmbRoute.Name = "cmbRoute";
            cmbRoute.Size = new Size(128, 28);
            cmbRoute.TabIndex = 54;
            cmbRoute.SelectedIndexChanged += FilterChanged;
            // 
            // dtpDate
            // 
            dtpDate.Location = new Point(853, 33);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(250, 27);
            dtpDate.TabIndex = 55;
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "MM/dd/yyyy"; // or "dd/MM/yyyy"
            DateTime selectedDate = dtpDate.Value.Date; // only the date part



            // 
            // Summary
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "Summary";
            Size = new Size(1656, 551);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBookingSummary).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private DataGridView dgvBookingSummary;
        private Label label1;
        private Label lblCompanyNameFleet;
        private Label lblEmptyMessage;
        private ComboBox cmbFerry;
        private Label label4;
        private Label label3;
        private Label label2;
        private DateTimePicker dtpDate;
        private ComboBox cmbRoute;
    }
}
