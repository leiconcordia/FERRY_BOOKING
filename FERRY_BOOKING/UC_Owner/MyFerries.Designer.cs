namespace FERRY_BOOKING.UC_Ferry
{
    partial class MyFerries
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
            panel1 = new Panel();
            label1 = new Label();
            lblCompanyNameFleet = new Label();
            btnRegisterFerry = new Button();
            dgvMyFerries = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMyFerries).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(dgvMyFerries);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblCompanyNameFleet);
            panel1.Controls.Add(btnRegisterFerry);
            panel1.Location = new Point(128, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(1497, 470);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(28, 43);
            label1.Name = "label1";
            label1.Size = new Size(292, 20);
            label1.TabIndex = 2;
            label1.Text = "Manage your ferry fleet and configurations";
            // 
            // lblCompanyNameFleet
            // 
            lblCompanyNameFleet.AutoSize = true;
            lblCompanyNameFleet.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCompanyNameFleet.ForeColor = Color.FromArgb(11, 94, 235);
            lblCompanyNameFleet.Location = new Point(28, 15);
            lblCompanyNameFleet.Name = "lblCompanyNameFleet";
            lblCompanyNameFleet.Size = new Size(134, 28);
            lblCompanyNameFleet.TabIndex = 1;
            lblCompanyNameFleet.Text = "No Company";
            // 
            // btnRegisterFerry
            // 
            btnRegisterFerry.BackColor = Color.FromArgb(30, 64, 175);
            btnRegisterFerry.ForeColor = SystemColors.ButtonFace;
            btnRegisterFerry.Location = new Point(1299, 16);
            btnRegisterFerry.Name = "btnRegisterFerry";
            btnRegisterFerry.Size = new Size(185, 42);
            btnRegisterFerry.TabIndex = 0;
            btnRegisterFerry.Text = "+   Register New Ferry";
            btnRegisterFerry.UseVisualStyleBackColor = false;
            btnRegisterFerry.Click += btnRegisterFerry_Click;

            
            // 
            // dgvMyFerries
            // 
            dgvMyFerries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvMyFerries.Location = new Point(28, 78);
            dgvMyFerries.Name = "dgvMyFerries";
            dgvMyFerries.RowHeadersWidth = 51;
            dgvMyFerries.Size = new Size(1456, 365);
            dgvMyFerries.TabIndex = 3;
            dgvMyFerries.RowHeadersVisible = false; // Remove left space
            dgvMyFerries.DefaultCellStyle.ForeColor = Color.FromArgb(11, 94, 235);
            dgvMyFerries.DefaultCellStyle.SelectionForeColor = Color.Black; // Optional
            dgvMyFerries.DefaultCellStyle.SelectionBackColor = Color.LightGray; // Optional
            dgvMyFerries.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvMyFerries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvMyFerries.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            dgvMyFerries.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvMyFerries.EnableHeadersVisualStyles = false; // allow custom header styling
            dgvMyFerries.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(11, 94, 235);
            dgvMyFerries.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvMyFerries.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvMyFerries.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgvMyFerries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvMyFerries.AllowUserToAddRows = false; // prevents blank bottom row
            dgvMyFerries.BackgroundColor = Color.White;
            dgvMyFerries.DefaultCellStyle.BackColor = Color.White;
            dgvMyFerries.RowsDefaultCellStyle.BackColor = Color.White;


            /* wire events once */

            dgvMyFerries.CellPainting += dgvMyFerries_CellPainting;
 
            dgvMyFerries.CellClick += dgvMyFerries_CellClick;

            dgvMyFerries.CellMouseEnter += dgvMyFerries_CellMouseEnter;




            // 
            // MyFerries
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "MyFerries";
            Size = new Size(1656, 551);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMyFerries).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnRegisterFerry;
        private Label lblCompanyNameFleet;
        private Label label1;
        private DataGridView dgvMyFerries;
    }
}
