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
            nudTrips = new NumericUpDown();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            tbDestinationPort = new TextBox();
            tbOriginPort = new TextBox();
            label8 = new Label();
            tbFerryCode = new TextBox();
            label7 = new Label();
            tbFerryName = new TextBox();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            flowFloors = new FlowLayoutPanel();
            flowTrips = new FlowLayoutPanel();
            btnSave = new Button();
            btnCancel = new Button();
            RegistrationFormPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudFloorNumbers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTrips).BeginInit();
            SuspendLayout();
            // 
            // RegistrationFormPanel
            // 
            RegistrationFormPanel.AutoScroll = true;
            RegistrationFormPanel.AutoScrollMinSize = new Size(0, 1080);
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
            RegistrationFormPanel.Controls.Add(nudTrips);
            RegistrationFormPanel.Controls.Add(label11);
            RegistrationFormPanel.Controls.Add(label10);
            RegistrationFormPanel.Controls.Add(label9);
            RegistrationFormPanel.Controls.Add(tbDestinationPort);
            RegistrationFormPanel.Controls.Add(tbOriginPort);
            RegistrationFormPanel.Controls.Add(label8);
            RegistrationFormPanel.Controls.Add(tbFerryCode);
            RegistrationFormPanel.Controls.Add(label7);
            RegistrationFormPanel.Controls.Add(tbFerryName);
            RegistrationFormPanel.Controls.Add(label6);
            RegistrationFormPanel.Controls.Add(label5);
            RegistrationFormPanel.Controls.Add(label4);
            RegistrationFormPanel.Controls.Add(label3);
            RegistrationFormPanel.Controls.Add(label2);
            RegistrationFormPanel.Controls.Add(textBox1);
            RegistrationFormPanel.Controls.Add(label1);
            RegistrationFormPanel.Controls.Add(flowFloors);
            RegistrationFormPanel.Controls.Add(flowTrips);
            RegistrationFormPanel.Location = new Point(7, 3);
            RegistrationFormPanel.Name = "RegistrationFormPanel";
            RegistrationFormPanel.Size = new Size(500, 577);
            RegistrationFormPanel.TabIndex = 23;
            // 
            // lblTotalCapacity
            // 
            lblTotalCapacity.AutoSize = true;
            lblTotalCapacity.Location = new Point(5, 288);
            lblTotalCapacity.Name = "lblTotalCapacity";
            lblTotalCapacity.Size = new Size(85, 20);
            lblTotalCapacity.TabIndex = 56;
            lblTotalCapacity.Text = "Capacity : 0";
            // 
            // btnFP
            // 
            btnFP.BackColor = Color.FromArgb(11, 94, 235);
            btnFP.ForeColor = Color.White;
            btnFP.Location = new Point(308, 971);
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
            btnPO.Location = new Point(308, 905);
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
            btnID.Location = new Point(308, 848);
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
            btnSC.Location = new Point(308, 792);
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
            btnVR.Location = new Point(308, 733);
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
            btnCO.Location = new Point(308, 674);
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
            labelfp.Location = new Point(5, 971);
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
            labelpo.Location = new Point(5, 915);
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
            label16.Location = new Point(0, 743);
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
            label15.Location = new Point(5, 802);
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
            label14.Location = new Point(0, 858);
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
            label13.Location = new Point(5, 681);
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
            label12.Location = new Point(5, 628);
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
            // nudTrips
            // 
            nudTrips.Location = new Point(0, 474);
            nudTrips.Name = "nudTrips";
            nudTrips.Size = new Size(150, 27);
            nudTrips.TabIndex = 39;
            nudTrips.ValueChanged += nudTrips_ValueChanged;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.FromArgb(11, 94, 235);
            label11.Location = new Point(-4, 442);
            label11.Name = "label11";
            label11.Size = new Size(168, 20);
            label11.TabIndex = 38;
            label11.Text = "Number of trips per day";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.FromArgb(11, 94, 235);
            label10.Location = new Point(173, 339);
            label10.Name = "label10";
            label10.Size = new Size(115, 20);
            label10.TabIndex = 37;
            label10.Text = "Destination Port";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.FromArgb(11, 94, 235);
            label9.Location = new Point(3, 339);
            label9.Name = "label9";
            label9.Size = new Size(80, 20);
            label9.TabIndex = 36;
            label9.Text = "Origin Port";
            // 
            // tbDestinationPort
            // 
            tbDestinationPort.Location = new Point(173, 362);
            tbDestinationPort.Name = "tbDestinationPort";
            tbDestinationPort.Size = new Size(125, 27);
            tbDestinationPort.TabIndex = 35;
            // 
            // tbOriginPort
            // 
            tbOriginPort.Location = new Point(3, 362);
            tbOriginPort.Name = "tbOriginPort";
            tbOriginPort.Size = new Size(125, 27);
            tbOriginPort.TabIndex = 34;
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.FromArgb(11, 94, 235);
            label4.Location = new Point(-5, 414);
            label4.Name = "label4";
            label4.Size = new Size(169, 28);
            label4.TabIndex = 27;
            label4.Text = "Schedule Details";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.FromArgb(11, 94, 235);
            label3.Location = new Point(0, 311);
            label3.Name = "label3";
            label3.Size = new Size(140, 28);
            label3.TabIndex = 26;
            label3.Text = "Route Details";
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
            // textBox1
            // 
            textBox1.Location = new Point(3, 76);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 24;
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
            flowFloors.Size = new Size(480, 100);
            flowFloors.TabIndex = 41;
            flowFloors.WrapContents = false;

            // 
            // flowTrips
            // 
            flowTrips.AutoScroll = true;
            flowTrips.FlowDirection = FlowDirection.TopDown;
            flowTrips.Location = new Point(3, 507);
            flowTrips.Name = "flowTrips";
            flowTrips.Size = new Size(480, 118);
            flowTrips.TabIndex = 42;
            flowTrips.WrapContents = false;
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
            ((System.ComponentModel.ISupportInitialize)nudTrips).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Panel RegistrationFormPanel;
        private FlowLayoutPanel flowTrips;
        private NumericUpDown nudFloorNumbers;
        private FlowLayoutPanel flowFloors;
        private NumericUpDown nudTrips;
        private Label label11;
        private Label label10;
        private Label label9;
        private TextBox tbDestinationPort;
        private TextBox tbOriginPort;
        private Label label8;
        private TextBox tbFerryCode;
        private Label label7;
        private TextBox tbFerryName;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private TextBox textBox1;
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