namespace FERRY_BOOKING.Dialogs
{
    partial class FerryViewDialog
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panel1 = new Panel();
            lblStatus = new Label();
            lblFerryCode = new Label();
            lblFerryName = new Label();
            panel2 = new Panel();
            lblTotalFloors = new Label();
            lblCapacity = new Label();
            pbFerryImage = new PictureBox();
            groupBox1 = new GroupBox();
            dgvFloors = new DataGridView();
            groupBox2 = new GroupBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnViewCO = new Button();
            btnViewVR = new Button();
            btnViewSC = new Button();
            btnViewID = new Button();
            btnViewPO = new Button();
            groupBox3 = new GroupBox();
            panel3 = new Panel();
            lblSeatPlanInfo = new Label();
            flpFloorButtons = new FlowLayoutPanel();
            tlpSeatPlan = new TableLayoutPanel();
            btnClose = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbFerryImage).BeginInit();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvFloors).BeginInit();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(11, 94, 215);
            panel1.Controls.Add(lblStatus);
            panel1.Controls.Add(lblFerryCode);
            panel1.Controls.Add(lblFerryName);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1257, 107);
            panel1.TabIndex = 0;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.ForeColor = Color.LightGreen;
            lblStatus.Location = new Point(1086, 40);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(120, 23);
            lblStatus.TabIndex = 2;
            lblStatus.Text = "Status: Active";
            // 
            // lblFerryCode
            // 
            lblFerryCode.AutoSize = true;
            lblFerryCode.Font = new Font("Segoe UI", 10F);
            lblFerryCode.ForeColor = Color.White;
            lblFerryCode.Location = new Point(25, 67);
            lblFerryCode.Name = "lblFerryCode";
            lblFerryCode.Size = new Size(111, 23);
            lblFerryCode.TabIndex = 1;
            lblFerryCode.Text = "Code: MVOQ";
            // 
            // lblFerryName
            // 
            lblFerryName.AutoSize = true;
            lblFerryName.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblFerryName.ForeColor = Color.White;
            lblFerryName.Location = new Point(23, 20);
            lblFerryName.Name = "lblFerryName";
            lblFerryName.Size = new Size(182, 41);
            lblFerryName.TabIndex = 0;
            lblFerryName.Text = "Ferry Name";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(lblTotalFloors);
            panel2.Controls.Add(lblCapacity);
            panel2.Controls.Add(pbFerryImage);
            panel2.Location = new Point(23, 133);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(400, 399);
            panel2.TabIndex = 1;
            // 
            // lblTotalFloors
            // 
            lblTotalFloors.AutoSize = true;
            lblTotalFloors.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblTotalFloors.ForeColor = Color.FromArgb(11, 94, 215);
            lblTotalFloors.Location = new Point(229, 333);
            lblTotalFloors.Name = "lblTotalFloors";
            lblTotalFloors.Size = new Size(136, 25);
            lblTotalFloors.TabIndex = 2;
            lblTotalFloors.Text = "Total Floors: 0";
            // 
            // lblCapacity
            // 
            lblCapacity.AutoSize = true;
            lblCapacity.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblCapacity.ForeColor = Color.FromArgb(11, 94, 215);
            lblCapacity.Location = new Point(17, 333);
            lblCapacity.Name = "lblCapacity";
            lblCapacity.Size = new Size(204, 25);
            lblCapacity.TabIndex = 1;
            lblCapacity.Text = "Total Capacity: 0 seats";
            // 
            // pbFerryImage
            // 
            pbFerryImage.BorderStyle = BorderStyle.FixedSingle;
            pbFerryImage.Location = new Point(17, 20);
            pbFerryImage.Margin = new Padding(3, 4, 3, 4);
            pbFerryImage.Name = "pbFerryImage";
            pbFerryImage.Size = new Size(365, 293);
            pbFerryImage.SizeMode = PictureBoxSizeMode.Zoom;
            pbFerryImage.TabIndex = 0;
            pbFerryImage.TabStop = false;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dgvFloors);
            groupBox1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox1.ForeColor = Color.FromArgb(11, 94, 215);
            groupBox1.Location = new Point(446, 133);
            groupBox1.Margin = new Padding(3, 4, 3, 4);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 4, 3, 4);
            groupBox1.Size = new Size(389, 400);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Floor Layout";
            // 
            // dgvFloors
            // 
            dgvFloors.AllowUserToAddRows = false;
            dgvFloors.AllowUserToDeleteRows = false;
            dgvFloors.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFloors.BackgroundColor = Color.White;
            dgvFloors.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFloors.Dock = DockStyle.Fill;
            dgvFloors.Location = new Point(3, 27);
            dgvFloors.Margin = new Padding(3, 4, 3, 4);
            dgvFloors.Name = "dgvFloors";
            dgvFloors.ReadOnly = true;
            dgvFloors.RowHeadersWidth = 51;
            dgvFloors.RowTemplate.Height = 25;
            dgvFloors.Size = new Size(383, 369);
            dgvFloors.TabIndex = 0;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(label2);
            groupBox2.Controls.Add(label3);
            groupBox2.Controls.Add(label4);
            groupBox2.Controls.Add(label5);
            groupBox2.Controls.Add(label6);
            groupBox2.Controls.Add(btnViewCO);
            groupBox2.Controls.Add(btnViewVR);
            groupBox2.Controls.Add(btnViewSC);
            groupBox2.Controls.Add(btnViewID);
            groupBox2.Controls.Add(btnViewPO);
            groupBox2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox2.ForeColor = Color.FromArgb(11, 94, 215);
            groupBox2.Location = new Point(23, 541);
            groupBox2.Margin = new Padding(3, 4, 3, 4);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(3, 4, 3, 4);
            groupBox2.Size = new Size(811, 312);
            groupBox2.TabIndex = 3;
            groupBox2.TabStop = false;
            groupBox2.Text = "Ferry Documents";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(23, 38);
            label2.Name = "label2";
            label2.Size = new Size(169, 20);
            label2.TabIndex = 9;
            label2.Text = "Certificate of Ownership";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(23, 93);
            label3.Name = "label3";
            label3.Size = new Size(249, 20);
            label3.TabIndex = 8;
            label3.Text = "Vessel Registry / MARINA Certificate";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(23, 148);
            label4.Name = "label4";
            label4.Size = new Size(122, 20);
            label4.TabIndex = 7;
            label4.Text = "Safety Certificate";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(23, 203);
            label5.Name = "label5";
            label5.Size = new Size(144, 20);
            label5.TabIndex = 6;
            label5.Text = "Insurance Document";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(23, 258);
            label6.Name = "label6";
            label6.Size = new Size(127, 20);
            label6.TabIndex = 5;
            label6.Text = "Permit to Operate";
            // 
            // btnViewCO
            // 
            btnViewCO.BackColor = Color.FromArgb(11, 94, 215);
            btnViewCO.Enabled = false;
            btnViewCO.FlatStyle = FlatStyle.Flat;
            btnViewCO.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnViewCO.ForeColor = Color.White;
            btnViewCO.Location = new Point(627, 25);
            btnViewCO.Margin = new Padding(3, 4, 3, 4);
            btnViewCO.Name = "btnViewCO";
            btnViewCO.Size = new Size(160, 47);
            btnViewCO.TabIndex = 4;
            btnViewCO.Text = "View Document";
            btnViewCO.UseVisualStyleBackColor = false;
            btnViewCO.Click += btnViewCO_Click;
            // 
            // btnViewVR
            // 
            btnViewVR.BackColor = Color.FromArgb(11, 94, 215);
            btnViewVR.Enabled = false;
            btnViewVR.FlatStyle = FlatStyle.Flat;
            btnViewVR.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnViewVR.ForeColor = Color.White;
            btnViewVR.Location = new Point(627, 80);
            btnViewVR.Margin = new Padding(3, 4, 3, 4);
            btnViewVR.Name = "btnViewVR";
            btnViewVR.Size = new Size(160, 47);
            btnViewVR.TabIndex = 3;
            btnViewVR.Text = "View Document";
            btnViewVR.UseVisualStyleBackColor = false;
            btnViewVR.Click += btnViewVR_Click;
            // 
            // btnViewSC
            // 
            btnViewSC.BackColor = Color.FromArgb(11, 94, 215);
            btnViewSC.Enabled = false;
            btnViewSC.FlatStyle = FlatStyle.Flat;
            btnViewSC.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnViewSC.ForeColor = Color.White;
            btnViewSC.Location = new Point(627, 135);
            btnViewSC.Margin = new Padding(3, 4, 3, 4);
            btnViewSC.Name = "btnViewSC";
            btnViewSC.Size = new Size(160, 47);
            btnViewSC.TabIndex = 2;
            btnViewSC.Text = "View Document";
            btnViewSC.UseVisualStyleBackColor = false;
            btnViewSC.Click += btnViewSC_Click;
            // 
            // btnViewID
            // 
            btnViewID.BackColor = Color.FromArgb(11, 94, 215);
            btnViewID.Enabled = false;
            btnViewID.FlatStyle = FlatStyle.Flat;
            btnViewID.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnViewID.ForeColor = Color.White;
            btnViewID.Location = new Point(627, 190);
            btnViewID.Margin = new Padding(3, 4, 3, 4);
            btnViewID.Name = "btnViewID";
            btnViewID.Size = new Size(160, 47);
            btnViewID.TabIndex = 1;
            btnViewID.Text = "View Document";
            btnViewID.UseVisualStyleBackColor = false;
            btnViewID.Click += btnViewID_Click;
            // 
            // btnViewPO
            // 
            btnViewPO.BackColor = Color.FromArgb(11, 94, 215);
            btnViewPO.Enabled = false;
            btnViewPO.FlatStyle = FlatStyle.Flat;
            btnViewPO.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnViewPO.ForeColor = Color.White;
            btnViewPO.Location = new Point(627, 245);
            btnViewPO.Margin = new Padding(3, 4, 3, 4);
            btnViewPO.Name = "btnViewPO";
            btnViewPO.Size = new Size(160, 47);
            btnViewPO.TabIndex = 0;
            btnViewPO.Text = "View Document";
            btnViewPO.UseVisualStyleBackColor = false;
            btnViewPO.Click += btnViewPO_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(panel3);
            groupBox3.Controls.Add(tlpSeatPlan);
            groupBox3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            groupBox3.ForeColor = Color.FromArgb(11, 94, 215);
            groupBox3.Location = new Point(857, 133);
            groupBox3.Margin = new Padding(3, 4, 3, 4);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(3, 4, 3, 4);
            groupBox3.Size = new Size(377, 720);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Seat Plan Preview";
            // 
            // panel3
            // 
            panel3.BackColor = Color.WhiteSmoke;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(lblSeatPlanInfo);
            panel3.Controls.Add(flpFloorButtons);
            panel3.Location = new Point(17, 33);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(343, 113);
            panel3.TabIndex = 1;
            // 
            // lblSeatPlanInfo
            // 
            lblSeatPlanInfo.AutoSize = true;
            lblSeatPlanInfo.Font = new Font("Segoe UI", 9F);
            lblSeatPlanInfo.ForeColor = Color.Black;
            lblSeatPlanInfo.Location = new Point(6, 80);
            lblSeatPlanInfo.Name = "lblSeatPlanInfo";
            lblSeatPlanInfo.Size = new Size(182, 20);
            lblSeatPlanInfo.TabIndex = 1;
            lblSeatPlanInfo.Text = "Select a floor to view plan";
            // 
            // flpFloorButtons
            // 
            flpFloorButtons.AutoScroll = true;
            flpFloorButtons.Location = new Point(6, 7);
            flpFloorButtons.Margin = new Padding(3, 4, 3, 4);
            flpFloorButtons.Name = "flpFloorButtons";
            flpFloorButtons.Size = new Size(326, 67);
            flpFloorButtons.TabIndex = 0;
            // 
            // tlpSeatPlan
            // 
            tlpSeatPlan.AutoScroll = true;
            tlpSeatPlan.BackColor = Color.White;
            tlpSeatPlan.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlpSeatPlan.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tlpSeatPlan.Location = new Point(17, 160);
            tlpSeatPlan.Margin = new Padding(3, 4, 3, 4);
            tlpSeatPlan.Name = "tlpSeatPlan";
            tlpSeatPlan.Size = new Size(343, 533);
            tlpSeatPlan.TabIndex = 0;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.FromArgb(11, 94, 215);
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(1097, 880);
            btnClose.Margin = new Padding(3, 4, 3, 4);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(137, 53);
            btnClose.TabIndex = 5;
            btnClose.Text = "Close";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // FerryViewDialog
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1257, 960);
            Controls.Add(btnClose);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(3, 4, 3, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FerryViewDialog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Ferry Details";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbFerryImage).EndInit();
            groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvFloors).EndInit();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblFerryCode;
        private System.Windows.Forms.Label lblFerryName;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTotalFloors;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.PictureBox pbFerryImage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvFloors;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnViewCO;
        private System.Windows.Forms.Button btnViewVR;
        private System.Windows.Forms.Button btnViewSC;
        private System.Windows.Forms.Button btnViewID;
        private System.Windows.Forms.Button btnViewPO;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblSeatPlanInfo;
        private System.Windows.Forms.FlowLayoutPanel flpFloorButtons;
        private System.Windows.Forms.TableLayoutPanel tlpSeatPlan;
        private System.Windows.Forms.Button btnClose;
    }
}