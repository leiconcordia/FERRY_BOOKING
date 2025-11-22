namespace FERRY_BOOKING.Dialogs
{
    partial class FerryEditForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblWarning = new System.Windows.Forms.Label();
            this.txtFerryName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtFerryCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnRemoveFloor = new System.Windows.Forms.Button();
            this.btnAddFloor = new System.Windows.Forms.Button();
            this.dgvFloors = new System.Windows.Forms.DataGridView();
            this.lblFloors = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFloors)).BeginInit();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.panel1.Controls.Add(this.lblSubtitle);
            this.panel1.Controls.Add(this.lblTitle);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(600, 80);
            this.panel1.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(195, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Edit Ferry";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.White;
            this.lblSubtitle.Location = new System.Drawing.Point(20, 52);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(272, 23);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Update ferry details and layout";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblWarning);
            this.panel2.Controls.Add(this.txtFerryName);
            this.panel2.Controls.Add(this.lblName);
            this.panel2.Controls.Add(this.txtFerryCode);
            this.panel2.Controls.Add(this.lblCode);
            this.panel2.Controls.Add(this.lblCompanyName);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(20, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(560, 200);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Ferry Information";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.Color.Gray;
            this.label1.Location = new System.Drawing.Point(15, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Company:";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCompanyName.ForeColor = System.Drawing.Color.Black;
            this.lblCompanyName.Location = new System.Drawing.Point(110, 55);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(44, 23);
            this.lblCompanyName.TabIndex = 2;
            this.lblCompanyName.Text = "N/A";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.lblCode.Location = new System.Drawing.Point(15, 95);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(98, 23);
            this.lblCode.TabIndex = 3;
            this.lblCode.Text = "Ferry Code";
            // 
            // txtFerryCode
            // 
            this.txtFerryCode.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFerryCode.Location = new System.Drawing.Point(15, 120);
            this.txtFerryCode.Name = "txtFerryCode";
            this.txtFerryCode.Size = new System.Drawing.Size(250, 30);
            this.txtFerryCode.TabIndex = 4;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.lblName.Location = new System.Drawing.Point(290, 95);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(103, 23);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "Ferry Name";
            // 
            // txtFerryName
            // 
            this.txtFerryName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtFerryName.Location = new System.Drawing.Point(290, 120);
            this.txtFerryName.Name = "txtFerryName";
            this.txtFerryName.Size = new System.Drawing.Size(250, 30);
            this.txtFerryName.TabIndex = 6;
            // 
            // lblWarning
            // 
            this.lblWarning.AutoSize = true;
            this.lblWarning.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblWarning.ForeColor = System.Drawing.Color.Red;
            this.lblWarning.Location = new System.Drawing.Point(15, 165);
            this.lblWarning.Name = "lblWarning";
            this.lblWarning.Size = new System.Drawing.Size(231, 20);
            this.lblWarning.TabIndex = 7;
            this.lblWarning.Text = "⚠ Editing is locked for this ferry";
            this.lblWarning.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btnRemoveFloor);
            this.panel3.Controls.Add(this.btnAddFloor);
            this.panel3.Controls.Add(this.dgvFloors);
            this.panel3.Controls.Add(this.lblFloors);
            this.panel3.Location = new System.Drawing.Point(20, 320);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(560, 320);
            this.panel3.TabIndex = 2;
            // 
            // lblFloors
            // 
            this.lblFloors.AutoSize = true;
            this.lblFloors.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFloors.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.lblFloors.Location = new System.Drawing.Point(15, 15);
            this.lblFloors.Name = "lblFloors";
            this.lblFloors.Size = new System.Drawing.Size(202, 25);
            this.lblFloors.TabIndex = 0;
            this.lblFloors.Text = "Floor Layout Configuration";
            // 
            // dgvFloors
            // 
            this.dgvFloors.AllowUserToAddRows = false;
            this.dgvFloors.AllowUserToDeleteRows = false;
            this.dgvFloors.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFloors.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFloors.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFloors.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightGray;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvFloors.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvFloors.EnableHeadersVisualStyles = false;
            this.dgvFloors.Location = new System.Drawing.Point(15, 50);
            this.dgvFloors.Name = "dgvFloors";
            this.dgvFloors.RowHeadersVisible = false;
            this.dgvFloors.RowHeadersWidth = 51;
            this.dgvFloors.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFloors.Size = new System.Drawing.Size(530, 210);
            this.dgvFloors.TabIndex = 1;
            // 
            // btnAddFloor
            // 
            this.btnAddFloor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.btnAddFloor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddFloor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAddFloor.ForeColor = System.Drawing.Color.White;
            this.btnAddFloor.Location = new System.Drawing.Point(15, 270);
            this.btnAddFloor.Name = "btnAddFloor";
            this.btnAddFloor.Size = new System.Drawing.Size(120, 35);
            this.btnAddFloor.TabIndex = 2;
            this.btnAddFloor.Text = "+ Add Floor";
            this.btnAddFloor.UseVisualStyleBackColor = false;
            this.btnAddFloor.Click += new System.EventHandler(this.btnAddFloor_Click);
            // 
            // btnRemoveFloor
            // 
            this.btnRemoveFloor.BackColor = System.Drawing.Color.White;
            this.btnRemoveFloor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveFloor.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnRemoveFloor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.btnRemoveFloor.Location = new System.Drawing.Point(145, 270);
            this.btnRemoveFloor.Name = "btnRemoveFloor";
            this.btnRemoveFloor.Size = new System.Drawing.Size(160, 35);
            this.btnRemoveFloor.TabIndex = 3;
            this.btnRemoveFloor.Text = "- Remove Selected";
            this.btnRemoveFloor.UseVisualStyleBackColor = false;
            this.btnRemoveFloor.Click += new System.EventHandler(this.btnRemoveFloor_Click);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel4.Controls.Add(this.btnSave);
            this.panel4.Controls.Add(this.btnCancel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 660);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(600, 70);
            this.panel4.TabIndex = 3;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.btnCancel.Location = new System.Drawing.Point(340, 15);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 40);
            this.btnCancel.TabIndex = 0;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(94)))), ((int)(((byte)(235)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(470, 15);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 40);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save Changes";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // FerryEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(600, 730);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FerryEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Ferry Details";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFloors)).EndInit();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblWarning;
        private System.Windows.Forms.TextBox txtFerryName;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtFerryCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnRemoveFloor;
        private System.Windows.Forms.Button btnAddFloor;
        private System.Windows.Forms.DataGridView dgvFloors;
        private System.Windows.Forms.Label lblFloors;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}