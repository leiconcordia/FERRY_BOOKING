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
            btnRegisterFerry = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(btnRegisterFerry);
            panel1.Location = new Point(128, 27);
            panel1.Name = "panel1";
            panel1.Size = new Size(1497, 470);
            panel1.TabIndex = 0;
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
            Size = new Size(1656, 551);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnRegisterFerry;
    }
}
