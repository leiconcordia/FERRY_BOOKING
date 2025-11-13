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
            // Schedules
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btnAddRoute);
            Controls.Add(label1);
            Controls.Add(lblCompanyNameFleet);
            Name = "Schedules";
            Size = new Size(1496, 451);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCompanyNameFleet;
        private Label label1;
        private Button btnAddRoute;
    }
}
