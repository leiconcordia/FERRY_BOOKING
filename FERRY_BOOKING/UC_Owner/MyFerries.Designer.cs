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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            panel1 = new Panel();
            lblEmptyMessage = new Label();
            dgvMyFerries = new DataGridView();
            label1 = new Label();
            lblCompanyNameFleet = new Label();
            btnRegisterFerry = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMyFerries).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(lblEmptyMessage);
            panel1.Controls.Add(dgvMyFerries);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(lblCompanyNameFleet);
            panel1.Controls.Add(btnRegisterFerry);
            panel1.Location = new Point(128, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(1497, 470);
            panel1.TabIndex = 0;
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
            // dgvMyFerries
            // 
            dgvMyFerries.AllowUserToAddRows = false;
            dgvMyFerries.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvMyFerries.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgvMyFerries.BackgroundColor = Color.White;
            dgvMyFerries.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.White;
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(11, 94, 235);
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvMyFerries.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvMyFerries.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(11, 94, 235);
            dataGridViewCellStyle2.SelectionBackColor = Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = Color.Black;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvMyFerries.DefaultCellStyle = dataGridViewCellStyle2;
            dgvMyFerries.EnableHeadersVisualStyles = false;
            dgvMyFerries.Location = new Point(28, 78);
            dgvMyFerries.Name = "dgvMyFerries";
            dgvMyFerries.RowHeadersVisible = false;
            dgvMyFerries.RowHeadersWidth = 51;
            dataGridViewCellStyle3.BackColor = Color.White;
            dgvMyFerries.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvMyFerries.Size = new Size(1456, 365);
            dgvMyFerries.TabIndex = 3;
            dgvMyFerries.CellClick += dgvMyFerries_CellClick;
            dgvMyFerries.CellMouseEnter += dgvMyFerries_CellMouseEnter;
            dgvMyFerries.CellPainting += dgvMyFerries_CellPainting;
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
            // MyFerries
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "MyFerries";
            Size = new Size(1761, 551);
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
        private Label lblEmptyMessage;
    }
}
