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
            RegistrationFormPanel = new Panel();
            lblTotalCapacity = new Label();
            btnFP = new Button();
            btnPO = new Button();
            btnID = new Button();
            btnSC = new Button();
            btnVR = new Button();
            btnCO = new Button();
            labelfp = new Label();
            labelpo = new Label();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            nudFloorNumbers = new NumericUpDown();
            label8 = new Label();
            tbFerryCode = new TextBox();
            label7 = new Label();
            tbFerryName = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label2 = new Label();
            tbCompanyName = new TextBox();
            label1 = new Label();
            flowFloors = new FlowLayoutPanel();
            btnSave = new Button();
            btnCancel = new Button();
            RegistrationFormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudFloorNumbers).BeginInit();
            SuspendLayout();
            // 
            // RegistrationFormPanel
            // 
            RegistrationFormPanel.AutoScroll = true;
            RegistrationFormPanel.AutoScrollMinSize = new Size(0, 700);
            RegistrationFormPanel.Controls.Add(lblTotalCapacity);
            RegistrationFormPanel.Controls.Add(btnFP);
            RegistrationFormPanel.Controls.Add(btnPO);
            RegistrationFormPanel.Controls.Add(btnID);
            RegistrationFormPanel.Controls.Add(btnSC);
            RegistrationFormPanel.Controls.Add(btnVR);
            RegistrationFormPanel.Controls.Add(btnCO);
            RegistrationFormPanel.Controls.Add(labelfp);
            RegistrationFormPanel.Controls.Add(labelpo);
            RegistrationFormPanel.Controls.Add(label16);
            RegistrationFormPanel.Controls.Add(label15);
            RegistrationFormPanel.Controls.Add(label14);
            RegistrationFormPanel.Controls.Add(label13);
            RegistrationFormPanel.Controls.Add(label12);
            RegistrationFormPanel.Controls.Add(nudFloorNumbers);
            RegistrationFormPanel.Controls.Add(label8);
            RegistrationFormPanel.Controls.Add(tbFerryCode);
            RegistrationFormPanel.Controls.Add(label7);
            RegistrationFormPanel.Controls.Add(tbFerryName);
            RegistrationFormPanel.Controls.Add(label6);
            RegistrationFormPanel.Controls.Add(label5);
            RegistrationFormPanel.Controls.Add(label2);
            RegistrationFormPanel.Controls.Add(tbCompanyName);
            RegistrationFormPanel.Controls.Add(label1);
            RegistrationFormPanel.Controls.Add(flowFloors);
            RegistrationFormPanel.Location = new Point(7, 3);
            RegistrationFormPanel.Name = "RegistrationFormPanel";
            RegistrationFormPanel.Size = new Size(500, 577);
            RegistrationFormPanel.TabIndex = 23;
            // 
            // lblTotalCapacity
            // 
            lblTotalCapacity.AutoSize = true;
            lblTotalCapacity.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotalCapacity.Location = new Point(3, 304);
            lblTotalCapacity.Name = "lblTotalCapacity";
            lblTotalCapacity.Size = new Size(131, 31);
            lblTotalCapacity.TabIndex = 56;
            lblTotalCapacity.Text = "Capacity : 0";
            // 
            // btnFP
            // 
            btnFP.BackColor = Color.FromArgb(11, 94, 235);
            btnFP.ForeColor = Color.White;
            btnFP.Location = new Point(306, 688);
            btnFP.Name = "btnFP";
            btnFP.Size = new Size(112, 40);
            btnFP.TabIndex = 55;
            btnFP.Text = "Upload Image";
            btnFP.UseVisualStyleBackColor = false;
            btnFP.Click += btnFP_Click;
            // 
            // btnPO
            // 
            btnPO.BackColor = Color.FromArgb(11, 94, 235);
            btnPO.ForeColor = Color.White;
            btnPO.Location = new Point(306, 622);
            btnPO.Name = "btnPO";
            btnPO.Size = new Size(112, 40);
            btnPO.TabIndex = 54;
            btnPO.Text = "Upload File";
            btnPO.UseVisualStyleBackColor = false;
            btnPO.Click += btnPO_Click;
            // 
            // btnID
            // 
            btnID.BackColor = Color.FromArgb(11, 94, 235);
            btnID.ForeColor = Color.White;
            btnID.Location = new Point(306, 565);
            btnID.Name = "btnID";
            btnID.Size = new Size(112, 40);
            btnID.TabIndex = 53;
            btnID.Text = "Upload File";
            btnID.UseVisualStyleBackColor = false;
            btnID.Click += btnID_Click;
            // 
            // btnSC
            // 
            btnSC.BackColor = Color.FromArgb(11, 94, 235);
            btnSC.ForeColor = Color.White;
            btnSC.Location = new Point(306, 509);
            btnSC.Name = "btnSC";
            btnSC.Size = new Size(112, 40);
            btnSC.TabIndex = 52;
            btnSC.Text = "Upload File";
            btnSC.UseVisualStyleBackColor = false;
            btnSC.Click += btnSC_Click;
            // 
            // btnVR
            // 
            btnVR.BackColor = Color.FromArgb(11, 94, 235);
            btnVR.ForeColor = Color.White;
            btnVR.Location = new Point(306, 450);
            btnVR.Name = "btnVR";
            btnVR.Size = new Size(112, 40);
            btnVR.TabIndex = 51;
            btnVR.Text = "Upload File";
            btnVR.UseVisualStyleBackColor = false;
            btnVR.Click += btnVR_Click;
            // 
            // btnCO
            // 
            btnCO.BackColor = Color.FromArgb(11, 94, 235);
            btnCO.ForeColor = Color.White;
            btnCO.Location = new Point(306, 391);
            btnCO.Name = "btnCO";
            btnCO.Size = new Size(112, 40);
            btnCO.TabIndex = 50;
            btnCO.Text = "Upload File";
            btnCO.UseVisualStyleBackColor = false;
            btnCO.Click += btnCO_Click;
            // 
            // labelfp
            // 
            labelfp.AutoSize = true;
            labelfp.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelfp.ForeColor = Color.FromArgb(11, 94, 235);
            labelfp.Location = new Point(3, 688);
            labelfp.Name = "labelfp";
            labelfp.Size = new Size(84, 20);
            labelfp.TabIndex = 49;
            labelfp.Text = "Ferry Photo";
            // 
            // labelpo
            // 
            labelpo.AutoSize = true;
            labelpo.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            labelpo.ForeColor = Color.FromArgb(11, 94, 235);
            labelpo.Location = new Point(3, 632);
            labelpo.Name = "labelpo";
            labelpo.Size = new Size(131, 20);
            labelpo.TabIndex = 48;
            labelpo.Text = "Permit to Operate ";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label16.ForeColor = Color.FromArgb(11, 94, 235);
            label16.Location = new Point(-2, 460);
            label16.Name = "label16";
            label16.Size = new Size(253, 20);
            label16.TabIndex = 47;
            label16.Text = "Vessel Registry / MARINA Certificate ";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label15.ForeColor = Color.FromArgb(11, 94, 235);
            label15.Location = new Point(3, 519);
            label15.Name = "label15";
            label15.Size = new Size(122, 20);
            label15.TabIndex = 46;
            label15.Text = "Safety Certificate";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.FromArgb(11, 94, 235);
            label14.Location = new Point(-2, 575);
            label14.Name = "label14";
            label14.Size = new Size(148, 20);
            label14.TabIndex = 45;
            label14.Text = " Insurance Document";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.FromArgb(11, 94, 235);
            label13.Location = new Point(3, 398);
            label13.Name = "label13";
            label13.Size = new Size(169, 20);
            label13.TabIndex = 44;
            label13.Text = "Certificate of Ownership";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.FromArgb(11, 94, 235);
            label12.Location = new Point(3, 345);
            label12.Name = "label12";
            label12.Size = new Size(210, 28);
            label12.TabIndex = 43;
            label12.Text = "Required Documents";
            // 
            // nudFloorNumbers
            // 
            nudFloorNumbers.Location = new Point(198, 140);
            nudFloorNumbers.Name = "nudFloorNumbers";
            nudFloorNumbers.Size = new Size(150, 27);
            nudFloorNumbers.TabIndex = 40;
            nudFloorNumbers.ValueChanged += nudFloorNumbers_ValueChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(11, 94, 235);
            label8.Location = new Point(198, 115);
            label8.Name = "label8";
            label8.Size = new Size(125, 20);
            label8.TabIndex = 33;
            label8.Text = "Number of Floors";
            // 
            // tbFerryCode
            // 
            tbFerryCode.Location = new Point(3, 138);
            tbFerryCode.Name = "tbFerryCode";
            tbFerryCode.Size = new Size(125, 27);
            tbFerryCode.TabIndex = 32;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.FromArgb(11, 94, 235);
            label7.Location = new Point(3, 115);
            label7.Name = "label7";
            label7.Size = new Size(80, 20);
            label7.TabIndex = 31;
            label7.Text = "Ferry Code";
            // 
            // tbFerryName
            // 
            tbFerryName.Location = new Point(192, 76);
            tbFerryName.Name = "tbFerryName";
            tbFerryName.Size = new Size(212, 27);
            tbFerryName.TabIndex = 30;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.FromArgb(11, 94, 235);
            label6.Location = new Point(192, 41);
            label6.Name = "label6";
            label6.Size = new Size(85, 20);
            label6.TabIndex = 29;
            label6.Text = "Ferry Name";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.FromArgb(11, 94, 235);
            label5.Location = new Point(3, 41);
            label5.Name = "label5";
            label5.Size = new Size(108, 20);
            label5.TabIndex = 28;
            label5.Text = "Ferry Company";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.FromArgb(11, 94, 235);
            label2.Location = new Point(3, 2);
            label2.Name = "label2";
            label2.Size = new Size(133, 28);
            label2.TabIndex = 25;
            label2.Text = "Ferry Details";
            // 
            // tbCompanyName
            // 
            tbCompanyName.Location = new Point(3, 76);
            tbCompanyName.Name = "tbCompanyName";
            tbCompanyName.Size = new Size(125, 27);
            tbCompanyName.TabIndex = 24;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.Gray;
            label1.Location = new Point(3, -29);
            label1.Name = "label1";
            label1.Size = new Size(343, 20);
            label1.TabIndex = 23;
            label1.Text = "Enter ferry details, route, and schedule information";
            // 
            // flowFloors
            // 
            flowFloors.AutoScroll = true;
            flowFloors.FlowDirection = FlowDirection.TopDown;
            flowFloors.Location = new Point(-2, 185);
            flowFloors.Name = "flowFloors";
            flowFloors.Size = new Size(480, 116);
            flowFloors.TabIndex = 41;
            flowFloors.WrapContents = false;
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(11, 94, 235);
            btnSave.ForeColor = Color.White;
            btnSave.Location = new Point(131, 597);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(116, 39);
            btnSave.TabIndex = 24;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.Red;
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(264, 597);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(116, 39);
            btnCancel.TabIndex = 25;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // FerryRegistrationForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonFace;
            ClientSize = new Size(506, 648);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(RegistrationFormPanel);
            ForeColor = Color.Gray;
            Name = "FerryRegistrationForm";
            Text = "Register New Ferry";
            RegistrationFormPanel.ResumeLayout(false);
            RegistrationFormPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudFloorNumbers).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel RegistrationFormPanel;
        private NumericUpDown nudFloorNumbers;
        private FlowLayoutPanel flowFloors;
        private Label label8;
        private TextBox tbFerryCode;
        private Label label7;
        private TextBox tbFerryName;
        private Label label6;
        private Label label5;
        private Label label2;
        private TextBox tbCompanyName;
        private Label label1;
        private Label label12;
        private Button btnSave;
        private Button btnCancel;
        private Label labelpo;
        private Label label16;
        private Label label15;
        private Label label14;
        private Label label13;
        private Button btnFP;
        private Button btnPO;
        private Button btnID;
        private Button btnSC;
        private Button btnVR;
        private Button btnCO;
        private Label labelfp;
        private Label lblTotalCapacity;
    }
}