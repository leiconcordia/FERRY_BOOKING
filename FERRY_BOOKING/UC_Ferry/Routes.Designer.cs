namespace FERRY_BOOKING.UC_Ferry
{
    partial class Routes
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
            dgvRoutes = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvRoutes).BeginInit();
            SuspendLayout();
            // 
            // lblCompanyNameFleet
            // 
            lblCompanyNameFleet.AutoSize = true;
            lblCompanyNameFleet.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCompanyNameFleet.ForeColor = Color.FromArgb(11, 94, 235);
            lblCompanyNameFleet.Location = new Point(0, 0);
            lblCompanyNameFleet.Name = "lblCompanyNameFleet";
            lblCompanyNameFleet.Size = new Size(199, 28);
            lblCompanyNameFleet.TabIndex = 3;
            lblCompanyNameFleet.Text = "Route Management";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = SystemColors.ControlDarkDark;
            label1.Location = new Point(0, 28);
            label1.Name = "label1";
            label1.Size = new Size(255, 20);
            label1.TabIndex = 4;
            label1.Text = "Manage ferry routes and destinations";
            // 
            // btnAddRoute
            // 
            btnAddRoute.BackColor = Color.FromArgb(11, 94, 235);
            btnAddRoute.ForeColor = SystemColors.ButtonHighlight;
            btnAddRoute.Location = new Point(1349, 3);
            btnAddRoute.Name = "btnAddRoute";
            btnAddRoute.Size = new Size(144, 45);
            btnAddRoute.TabIndex = 43;
            btnAddRoute.Text = "+  Add Route";
            btnAddRoute.UseVisualStyleBackColor = false;
            btnAddRoute.Click += btnAddRoute_Click;
            // 
            // dgvRoutes
            // 
            dgvRoutes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRoutes.Location = new Point(18, 70);
            dgvRoutes.Name = "dgvRoutes";
            dgvRoutes.RowHeadersWidth = 51;
            dgvRoutes.Size = new Size(1455, 353);
            dgvRoutes.TabIndex = 44;
            // 
            // Routes
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dgvRoutes);
            Controls.Add(btnAddRoute);
            Controls.Add(label1);
            Controls.Add(lblCompanyNameFleet);
            Name = "Routes";
            Size = new Size(1496, 451);
            ((System.ComponentModel.ISupportInitialize)dgvRoutes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCompanyNameFleet;
        private Label label1;
        private Button btnAddRoute;
        private DataGridView dgvRoutes;
    }
}
