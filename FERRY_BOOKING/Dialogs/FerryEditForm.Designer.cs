namespace FERRY_BOOKING.Dialogs
{
    partial class FerryEditForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtFerryCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtFerryName;
        private System.Windows.Forms.DataGridView dgvFloors;
        private System.Windows.Forms.Button btnAddFloor;
        private System.Windows.Forms.Button btnRemoveFloor;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private System.Windows.Forms.Panel panelLockWarning;
        private System.Windows.Forms.Label lblLockWarning;

        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtFerryCode = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtFerryName = new System.Windows.Forms.TextBox();
            this.dgvFloors = new System.Windows.Forms.DataGridView();
            this.btnAddFloor = new System.Windows.Forms.Button();
            this.btnRemoveFloor = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();

            // 🔥 New controls:
            this.panelLockWarning = new System.Windows.Forms.Panel();
            this.lblLockWarning = new System.Windows.Forms.Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvFloors)).BeginInit();
            this.SuspendLayout();

            // 
            // panelLockWarning
            // 
            this.panelLockWarning.BackColor = System.Drawing.Color.FromArgb(255, 230, 230);
            this.panelLockWarning.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelLockWarning.Controls.Add(this.lblLockWarning);
            this.panelLockWarning.Location = new System.Drawing.Point(18, 330);
            this.panelLockWarning.Name = "panelLockWarning";
            this.panelLockWarning.Size = new System.Drawing.Size(420, 45);
            this.panelLockWarning.TabIndex = 11;
            this.panelLockWarning.Visible = false; // Hidden by default

            // 
            // lblLockWarning
            // 
            this.lblLockWarning.AutoSize = true;
            this.lblLockWarning.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblLockWarning.ForeColor = System.Drawing.Color.DarkRed;
            this.lblLockWarning.Location = new System.Drawing.Point(10, 13);
            this.lblLockWarning.Name = "lblLockWarning";
            this.lblLockWarning.Size = new System.Drawing.Size(210, 15);
            this.lblLockWarning.TabIndex = 0;
            this.lblLockWarning.Text = "⚠ Editing is locked for this ferry.";

            // 
            // (YOUR EXISTING CONTROLS BELOW)
            // label1
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Company:";

            // lblCompanyName
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(90, 14);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(33, 15);
            this.lblCompanyName.TabIndex = 1;
            this.lblCompanyName.Text = "N/A";

            // lblCode
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(18, 44);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(64, 15);
            this.lblCode.TabIndex = 2;
            this.lblCode.Text = "Ferry Code";

            // txtFerryCode
            this.txtFerryCode.Location = new System.Drawing.Point(110, 41);
            this.txtFerryCode.Name = "txtFerryCode";
            this.txtFerryCode.Size = new System.Drawing.Size(220, 23);
            this.txtFerryCode.TabIndex = 3;

            // lblName
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(18, 76);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(70, 15);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Ferry Name";

            // txtFerryName
            this.txtFerryName.Location = new System.Drawing.Point(110, 73);
            this.txtFerryName.Name = "txtFerryName";
            this.txtFerryName.Size = new System.Drawing.Size(220, 23);
            this.txtFerryName.TabIndex = 5;

            // dgvFloors
            this.dgvFloors.AllowUserToAddRows = false;
            this.dgvFloors.AllowUserToDeleteRows = true;
            this.dgvFloors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFloors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFloors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFloors.Location = new System.Drawing.Point(18, 110);
            this.dgvFloors.MultiSelect = false;
            this.dgvFloors.Name = "dgvFloors";
            this.dgvFloors.RowTemplate.Height = 25;
            this.dgvFloors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFloors.Size = new System.Drawing.Size(420, 180);
            this.dgvFloors.TabIndex = 6;

            // btnAddFloor
            this.btnAddFloor.Location = new System.Drawing.Point(18, 300);
            this.btnAddFloor.Name = "btnAddFloor";
            this.btnAddFloor.Size = new System.Drawing.Size(90, 28);
            this.btnAddFloor.TabIndex = 7;
            this.btnAddFloor.Text = "Add Floor";
            this.btnAddFloor.UseVisualStyleBackColor = true;
            this.btnAddFloor.Click += new System.EventHandler(this.btnAddFloor_Click);

            // btnRemoveFloor
            this.btnRemoveFloor.Location = new System.Drawing.Point(120, 300);
            this.btnRemoveFloor.Name = "btnRemoveFloor";
            this.btnRemoveFloor.Size = new System.Drawing.Size(120, 28);
            this.btnRemoveFloor.TabIndex = 8;
            this.btnRemoveFloor.Text = "Remove Selected";
            this.btnRemoveFloor.UseVisualStyleBackColor = true;
            this.btnRemoveFloor.Click += new System.EventHandler(this.btnRemoveFloor_Click);

            // btnSave
            this.btnSave.Location = new System.Drawing.Point(258, 300);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(90, 28);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // btnCancel
            this.btnCancel.Location = new System.Drawing.Point(358, 300);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(80, 28);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // FerryEditForm
            this.ClientSize = new System.Drawing.Size(452, 380);
            this.Controls.Add(this.panelLockWarning); // 🔥 ADD WARNING PANEL
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnRemoveFloor);
            this.Controls.Add(this.btnAddFloor);
            this.Controls.Add(this.dgvFloors);
            this.Controls.Add(this.txtFerryName);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.txtFerryCode);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.lblCompanyName);
            this.Controls.Add(this.label1);
            this.Name = "FerryEditForm";
            this.Text = "Edit Ferry";
            ((System.ComponentModel.ISupportInitialize)(this.dgvFloors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

    }
}