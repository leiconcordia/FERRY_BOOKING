namespace FERRY_BOOKING.UC_Ferry
{
    partial class Schedules
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
            lblCompanyNameFleet = new Label();
            label1 = new Label();
            btnAddRoute = new Button();
            dgvSchedule = new DataGridView();
            lblEmptyMessage = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).BeginInit();
            SuspendLayout();
            // 
            // lblCompanyNameFleet
            // 
            lblCompanyNameFleet.AutoSize = true;
            lblCompanyNameFleet.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCompanyNameFleet.ForeColor = Color.FromArgb(11, 94, 235);
            lblCompanyNameFleet.Location = new Point(3, 0);
            lblCompanyNameFleet.Name = "lblCompanyNameFleet";
            lblCompanyNameFleet.Size = new Size(228, 28);
            lblCompanyNameFleet.TabIndex = 2;
            lblCompanyNameFleet.Text = "Schedule Management";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(3, 28);
            label1.Name = "label1";
            label1.Size = new Size(244, 20);
            label1.TabIndex = 3;
            label1.Text = "Manage ferry schedules and pricing";
            // 
            // btnAddRoute
            // 
            btnAddRoute.BackColor = Color.FromArgb(11, 94, 235);
            btnAddRoute.ForeColor = SystemColors.ButtonHighlight;
            btnAddRoute.Location = new Point(1349, 3);
            btnAddRoute.Name = "btnAddRoute";
            btnAddRoute.Size = new Size(144, 45);
            btnAddRoute.TabIndex = 44;
            btnAddRoute.Text = "+  Add Schedule";
            btnAddRoute.UseVisualStyleBackColor = false;
            btnAddRoute.Click += btnAddRoute_Click;
            // 
            // dgvSchedule
            // 
            // make DataGridView look and behave like dgvMyFerries
            dgvSchedule.AllowUserToAddRows = false;
            dgvSchedule.AllowUserToDeleteRows = false;
            dgvSchedule.AllowUserToResizeRows = false;
            dgvSchedule.MultiSelect = false;
            dgvSchedule.ReadOnly = true;
            dgvSchedule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSchedule.RowHeadersVisible = false;
            dgvSchedule.RowTemplate.Height = 50;
            dgvSchedule.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSchedule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSchedule.BackgroundColor = Color.White;
            dgvSchedule.BorderStyle = BorderStyle.None;
            dgvSchedule.EnableHeadersVisualStyles = false;
            dgvSchedule.GridColor = Color.LightGray;
            dgvSchedule.Location = new Point(16, 64);
            dgvSchedule.Name = "dgvSchedule";
            dgvSchedule.RowHeadersWidth = 51;
            dgvSchedule.Size = new Size(1455, 353);
            dgvSchedule.TabIndex = 45;
            // wire paint/click handlers (LoadSchedule will unsubscribe/resubscribe safely)
            dgvSchedule.CellPainting += dgvSchedule_CellPainting;
            dgvSchedule.CellClick += dgvSchedule_CellClick;
            dgvSchedule.CellMouseEnter += dgvSchedule_CellMouseEnter;
            // 
            // lblEmptyMessage
            // 
            lblEmptyMessage.AutoSize = true;
            lblEmptyMessage.BackColor = SystemColors.ButtonFace;
            lblEmptyMessage.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEmptyMessage.ForeColor = SystemColors.AppWorkspace;
            lblEmptyMessage.Location = new Point(498, 210);
            lblEmptyMessage.Name = "lblEmptyMessage";
            lblEmptyMessage.Size = new Size(282, 46);
            lblEmptyMessage.TabIndex = 46;
            lblEmptyMessage.Text = "lblEmptyMessage";
            // 
            // Schedules
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(lblEmptyMessage);
            Controls.Add(dgvSchedule);
            Controls.Add(btnAddRoute);
            Controls.Add(label1);
            Controls.Add(lblCompanyNameFleet);
            Name = "Schedules";
            Size = new Size(1496, 451);
            ((System.ComponentModel.ISupportInitialize)dgvSchedule).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCompanyNameFleet;
        private Label label1;
        private Button btnAddRoute;
        private DataGridView dgvSchedule;
        private Label lblEmptyMessage;
    }
}
