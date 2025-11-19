namespace FERRY_BOOKING.UC_Ferry
{
    partial class ScheduleAndRoute
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
            btnSched = new Button();
            btnRoute = new Button();
            PanelRoutesAndSchedules = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(btnSched);
            panel1.Controls.Add(btnRoute);
            panel1.Location = new Point(125, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1496, 47);
            panel1.TabIndex = 0;
            // 
            // btnSched
            // 
            btnSched.Location = new Point(754, 9);
            btnSched.Name = "btnSched";
            btnSched.Size = new Size(742, 29);
            btnSched.TabIndex = 1;
            btnSched.Text = "Schedules";
            btnSched.UseVisualStyleBackColor = true;
            btnSched.Click += btnSched_Click;
            // 
            // btnRoute
            // 
            btnRoute.Location = new Point(3, 9);
            btnRoute.Name = "btnRoute";
            btnRoute.Size = new Size(745, 29);
            btnRoute.TabIndex = 0;
            btnRoute.Text = "Routes";
            btnRoute.UseVisualStyleBackColor = true;
            btnRoute.Click += btnRoute_Click;
            // 
            // PanelRoutesAndSchedules
            // 
            PanelRoutesAndSchedules.BackColor = SystemColors.ButtonHighlight;
            PanelRoutesAndSchedules.Location = new Point(125, 53);
            PanelRoutesAndSchedules.Name = "PanelRoutesAndSchedules";
            PanelRoutesAndSchedules.Size = new Size(1496, 469);
            PanelRoutesAndSchedules.TabIndex = 2;
            // 
            // ScheduleAndRoute
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(PanelRoutesAndSchedules);
            Controls.Add(panel1);
            Name = "ScheduleAndRoute";
            Size = new Size(1656, 551);
            Load += ScheduleAndRoute_Load;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnSched;
        private Button btnRoute;
        private Panel PanelRoutesAndSchedules;
    }
}
