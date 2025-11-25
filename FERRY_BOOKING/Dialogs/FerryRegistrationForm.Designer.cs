using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace FERRY_BOOKING.Dialogs
{
    partial class FerryRegistrationForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            lblSubtitle = new Label();
            lblTitle = new Label();
            RegistrationFormPanel = new Panel();
            panel4 = new Panel();
            labelfp = new Label();
            btnFP = new Button();
            labelpo = new Label();
            btnPO = new Button();
            label14 = new Label();
            btnID = new Button();
            label15 = new Label();
            btnSC = new Button();
            label16 = new Label();
            btnVR = new Button();
            label13 = new Label();
            btnCO = new Button();
            label12 = new Label();
            panel3 = new Panel();
            lblTotalCapacity = new Label();
            flowFloors = new FlowLayoutPanel();
            lblFloorLayout = new Label();
            panel2 = new Panel();
            nudFloorNumbers = new NumericUpDown();
            label8 = new Label();
            tbFerryCode = new TextBox();
            label7 = new Label();
            tbFerryName = new TextBox();
            label6 = new Label();
            tbCompanyName = new TextBox();
            label5 = new Label();
            label2 = new Label();
            panel5 = new Panel();
            btnSave = new Button();
            btnCancel = new Button();
            panel1.SuspendLayout();
            RegistrationFormPanel.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudFloorNumbers).BeginInit();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(11, 94, 235);
            panel1.Controls.Add(lblSubtitle);
            panel1.Controls.Add(lblTitle);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(700, 100);
            panel1.TabIndex = 0;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.White;
            lblSubtitle.Location = new Point(20, 65);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(396, 23);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Enter ferry details, layout, and required documents";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(20, 19);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(262, 37);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Register New Ferry";
            // 
            // RegistrationFormPanel
            // 
            RegistrationFormPanel.AutoScroll = true;
            RegistrationFormPanel.BackColor = Color.WhiteSmoke;
            RegistrationFormPanel.Controls.Add(panel4);
            RegistrationFormPanel.Controls.Add(panel3);
            RegistrationFormPanel.Controls.Add(panel2);
            RegistrationFormPanel.Dock = DockStyle.Fill;
            RegistrationFormPanel.Location = new Point(0, 100);
            RegistrationFormPanel.Margin = new Padding(3, 4, 3, 4);
            RegistrationFormPanel.Name = "RegistrationFormPanel";
            RegistrationFormPanel.Padding = new Padding(20, 25, 20, 112);
            RegistrationFormPanel.Size = new Size(700, 900);
            RegistrationFormPanel.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.BorderStyle = BorderStyle.FixedSingle;
            panel4.Controls.Add(labelfp);
            panel4.Controls.Add(btnFP);
            panel4.Controls.Add(labelpo);
            panel4.Controls.Add(btnPO);
            panel4.Controls.Add(label14);
            panel4.Controls.Add(btnID);
            panel4.Controls.Add(label15);
            panel4.Controls.Add(btnSC);
            panel4.Controls.Add(label16);
            panel4.Controls.Add(btnVR);
            panel4.Controls.Add(label13);
            panel4.Controls.Add(btnCO);
            panel4.Controls.Add(label12);
            panel4.Location = new Point(20, 650);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(640, 512);
            panel4.TabIndex = 2;
            // 
            // labelfp
            // 
            labelfp.AutoSize = true;
            labelfp.Font = new Font("Segoe UI", 10F);
            labelfp.ForeColor = Color.Black;
            labelfp.Location = new Point(15, 419);
            labelfp.Name = "labelfp";
            labelfp.Size = new Size(98, 23);
            labelfp.TabIndex = 11;
            labelfp.Text = "Ferry Photo";
            // 
            // btnFP
            // 
            btnFP.BackColor = Color.FromArgb(11, 94, 235);
            btnFP.FlatStyle = FlatStyle.Flat;
            btnFP.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnFP.ForeColor = Color.White;
            btnFP.Location = new Point(480, 412);
            btnFP.Margin = new Padding(3, 4, 3, 4);
            btnFP.Name = "btnFP";
            btnFP.Size = new Size(140, 44);
            btnFP.TabIndex = 12;
            btnFP.Text = "Upload Image";
            btnFP.UseVisualStyleBackColor = false;
            btnFP.Click += btnFP_Click;
            // 
            // labelpo
            // 
            labelpo.AutoSize = true;
            labelpo.Font = new Font("Segoe UI", 10F);
            labelpo.ForeColor = Color.Black;
            labelpo.Location = new Point(15, 350);
            labelpo.Name = "labelpo";
            labelpo.Size = new Size(147, 23);
            labelpo.TabIndex = 9;
            labelpo.Text = "Permit to Operate";
            // 
            // btnPO
            // 
            btnPO.BackColor = Color.FromArgb(11, 94, 235);
            btnPO.FlatStyle = FlatStyle.Flat;
            btnPO.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnPO.ForeColor = Color.White;
            btnPO.Location = new Point(480, 344);
            btnPO.Margin = new Padding(3, 4, 3, 4);
            btnPO.Name = "btnPO";
            btnPO.Size = new Size(140, 44);
            btnPO.TabIndex = 10;
            btnPO.Text = "Upload PDF";
            btnPO.UseVisualStyleBackColor = false;
            btnPO.Click += btnPO_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 10F);
            label14.ForeColor = Color.Black;
            label14.Location = new Point(15, 281);
            label14.Name = "label14";
            label14.Size = new Size(169, 23);
            label14.TabIndex = 7;
            label14.Text = "Insurance Document";
            // 
            // btnID
            // 
            btnID.BackColor = Color.FromArgb(11, 94, 235);
            btnID.FlatStyle = FlatStyle.Flat;
            btnID.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnID.ForeColor = Color.White;
            btnID.Location = new Point(480, 275);
            btnID.Margin = new Padding(3, 4, 3, 4);
            btnID.Name = "btnID";
            btnID.Size = new Size(140, 44);
            btnID.TabIndex = 8;
            btnID.Text = "Upload PDF";
            btnID.UseVisualStyleBackColor = false;
            btnID.Click += btnID_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 10F);
            label15.ForeColor = Color.Black;
            label15.Location = new Point(15, 212);
            label15.Name = "label15";
            label15.Size = new Size(138, 23);
            label15.TabIndex = 5;
            label15.Text = "Safety Certificate";
            // 
            // btnSC
            // 
            btnSC.BackColor = Color.FromArgb(11, 94, 235);
            btnSC.FlatStyle = FlatStyle.Flat;
            btnSC.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSC.ForeColor = Color.White;
            btnSC.Location = new Point(480, 206);
            btnSC.Margin = new Padding(3, 4, 3, 4);
            btnSC.Name = "btnSC";
            btnSC.Size = new Size(140, 44);
            btnSC.TabIndex = 6;
            btnSC.Text = "Upload PDF";
            btnSC.UseVisualStyleBackColor = false;
            btnSC.Click += btnSC_Click;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 10F);
            label16.ForeColor = Color.Black;
            label16.Location = new Point(15, 144);
            label16.Name = "label16";
            label16.Size = new Size(285, 23);
            label16.TabIndex = 3;
            label16.Text = "Vessel Registry / MARINA Certificate";
            // 
            // btnVR
            // 
            btnVR.BackColor = Color.FromArgb(11, 94, 235);
            btnVR.FlatStyle = FlatStyle.Flat;
            btnVR.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnVR.ForeColor = Color.White;
            btnVR.Location = new Point(480, 138);
            btnVR.Margin = new Padding(3, 4, 3, 4);
            btnVR.Name = "btnVR";
            btnVR.Size = new Size(140, 44);
            btnVR.TabIndex = 4;
            btnVR.Text = "Upload PDF";
            btnVR.UseVisualStyleBackColor = false;
            btnVR.Click += btnVR_Click;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 10F);
            label13.ForeColor = Color.Black;
            label13.Location = new Point(15, 75);
            label13.Name = "label13";
            label13.Size = new Size(193, 23);
            label13.TabIndex = 1;
            label13.Text = "Certificate of Ownership";
            // 
            // btnCO
            // 
            btnCO.BackColor = Color.FromArgb(11, 94, 235);
            btnCO.FlatStyle = FlatStyle.Flat;
            btnCO.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCO.ForeColor = Color.White;
            btnCO.Location = new Point(480, 69);
            btnCO.Margin = new Padding(3, 4, 3, 4);
            btnCO.Name = "btnCO";
            btnCO.Size = new Size(140, 44);
            btnCO.TabIndex = 2;
            btnCO.Text = "Upload PDF";
            btnCO.UseVisualStyleBackColor = false;
            btnCO.Click += btnCO_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label12.ForeColor = Color.FromArgb(11, 94, 235);
            label12.Location = new Point(15, 19);
            label12.Name = "label12";
            label12.Size = new Size(199, 25);
            label12.TabIndex = 0;
            label12.Text = "Required Documents";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lblTotalCapacity);
            panel3.Controls.Add(flowFloors);
            panel3.Controls.Add(lblFloorLayout);
            panel3.Location = new Point(20, 287);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(640, 338);
            panel3.TabIndex = 1;
            // 
            // lblTotalCapacity
            // 
            lblTotalCapacity.AutoSize = true;
            lblTotalCapacity.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalCapacity.ForeColor = Color.FromArgb(11, 94, 235);
            lblTotalCapacity.Location = new Point(15, 294);
            lblTotalCapacity.Name = "lblTotalCapacity";
            lblTotalCapacity.Size = new Size(169, 28);
            lblTotalCapacity.TabIndex = 2;
            lblTotalCapacity.Text = "Total Capacity: 0";
            // 
            // flowFloors
            // 
            flowFloors.AutoScroll = true;
            flowFloors.FlowDirection = FlowDirection.TopDown;
            flowFloors.Location = new Point(15, 62);
            flowFloors.Margin = new Padding(3, 4, 3, 4);
            flowFloors.Name = "flowFloors";
            flowFloors.Size = new Size(610, 212);
            flowFloors.TabIndex = 1;
            flowFloors.WrapContents = false;
            // 
            // lblFloorLayout
            // 
            lblFloorLayout.AutoSize = true;
            lblFloorLayout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblFloorLayout.ForeColor = Color.FromArgb(11, 94, 235);
            lblFloorLayout.Location = new Point(15, 19);
            lblFloorLayout.Name = "lblFloorLayout";
            lblFloorLayout.Size = new Size(125, 25);
            lblFloorLayout.TabIndex = 0;
            lblFloorLayout.Text = "Floor Layout";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(nudFloorNumbers);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(tbFerryCode);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(tbFerryName);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(tbCompanyName);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(20, 25);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(640, 224);
            panel2.TabIndex = 0;
            // 
            // nudFloorNumbers
            // 
            nudFloorNumbers.Font = new Font("Segoe UI", 10F);
            nudFloorNumbers.Location = new Point(290, 171);
            nudFloorNumbers.Margin = new Padding(3, 4, 3, 4);
            nudFloorNumbers.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudFloorNumbers.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudFloorNumbers.Name = "nudFloorNumbers";
            nudFloorNumbers.Size = new Size(150, 30);
            nudFloorNumbers.TabIndex = 8;
            nudFloorNumbers.Value = new decimal(new int[] { 1, 0, 0, 0 });
            nudFloorNumbers.ValueChanged += nudFloorNumbers_ValueChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(11, 94, 235);
            label8.Location = new Point(290, 143);
            label8.Name = "label8";
            label8.Size = new Size(151, 23);
            label8.TabIndex = 7;
            label8.Text = "Number of Floors";
            // 
            // tbFerryCode
            // 
            tbFerryCode.Font = new Font("Segoe UI", 10F);
            tbFerryCode.Location = new Point(11, 170);
            tbFerryCode.Margin = new Padding(3, 4, 3, 4);
            tbFerryCode.Name = "tbFerryCode";
            tbFerryCode.PlaceholderText = "e.g., MVOQ";
            tbFerryCode.Size = new Size(250, 30);
            tbFerryCode.TabIndex = 6;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(11, 94, 235);
            label7.Location = new Point(15, 143);
            label7.Name = "label7";
            label7.Size = new Size(98, 23);
            label7.TabIndex = 5;
            label7.Text = "Ferry Code";
            // 
            // tbFerryName
            // 
            tbFerryName.Font = new Font("Segoe UI", 10F);
            tbFerryName.Location = new Point(290, 87);
            tbFerryName.Margin = new Padding(3, 4, 3, 4);
            tbFerryName.Name = "tbFerryName";
            tbFerryName.PlaceholderText = "e.g., MV Ocean Queen";
            tbFerryName.Size = new Size(330, 30);
            tbFerryName.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(11, 94, 235);
            label6.Location = new Point(290, 56);
            label6.Name = "label6";
            label6.Size = new Size(104, 23);
            label6.TabIndex = 3;
            label6.Text = "Ferry Name";
            // 
            // tbCompanyName
            // 
            tbCompanyName.BackColor = Color.WhiteSmoke;
            tbCompanyName.Font = new Font("Segoe UI", 10F);
            tbCompanyName.Location = new Point(15, 87);
            tbCompanyName.Margin = new Padding(3, 4, 3, 4);
            tbCompanyName.Name = "tbCompanyName";
            tbCompanyName.ReadOnly = true;
            tbCompanyName.Size = new Size(250, 30);
            tbCompanyName.TabIndex = 2;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(11, 94, 235);
            label5.Location = new Point(15, 56);
            label5.Name = "label5";
            label5.Size = new Size(133, 23);
            label5.TabIndex = 1;
            label5.Text = "Ferry Company";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(11, 94, 235);
            label2.Location = new Point(15, 19);
            label2.Name = "label2";
            label2.Size = new Size(172, 25);
            label2.TabIndex = 0;
            label2.Text = "Ferry Information";
            // 
            // panel5
            // 
            panel5.BackColor = Color.WhiteSmoke;
            panel5.Controls.Add(btnSave);
            panel5.Controls.Add(btnCancel);
            panel5.Dock = DockStyle.Bottom;
            panel5.Location = new Point(0, 867);
            panel5.Margin = new Padding(3, 4, 3, 4);
            panel5.Name = "panel5";
            panel5.Size = new Size(700, 71);
            panel5.TabIndex = 2;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(11, 94, 235);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(580, 19);
            btnSave.Margin = new Padding(3, 4, 3, 4);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(120, 50);
            btnSave.TabIndex = 1;
            btnSave.Text = "Register";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.White;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(11, 94, 235);
            btnCancel.Location = new Point(450, 19);
            btnCancel.Margin = new Padding(3, 4, 3, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 50);
            btnCancel.TabIndex = 0;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // FerryRegistrationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(700, 938);
            Controls.Add(panel5);
            Controls.Add(RegistrationFormPanel);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FerryRegistrationForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ferry Registration";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            RegistrationFormPanel.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudFloorNumbers).EndInit();
            panel5.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel RegistrationFormPanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.NumericUpDown nudFloorNumbers;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbFerryCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbFerryName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbCompanyName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblTotalCapacity;
        private System.Windows.Forms.FlowLayoutPanel flowFloors;
        private System.Windows.Forms.Label lblFloorLayout;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnFP;
        private System.Windows.Forms.Label labelfp;
        private System.Windows.Forms.Button btnPO;
        private System.Windows.Forms.Label labelpo;
        private System.Windows.Forms.Button btnID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnSC;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnVR;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnCO;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}