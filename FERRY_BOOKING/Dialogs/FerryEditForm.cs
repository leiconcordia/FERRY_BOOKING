using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FERRY_BOOKING.DATABASE;

namespace FERRY_BOOKING.Dialogs
{
    public partial class FerryEditForm : Form
    {
        private readonly int _ferryId;
        private readonly string _companyName;
        private readonly FerryOwnerHelper _helper = new FerryOwnerHelper();

        private bool _editingAllowed = true;

        public FerryEditForm(int ferryId, string companyName)
        {
            InitializeComponent();
            _ferryId = ferryId;
            _companyName = companyName;
            lblCompanyName.Text = companyName;
            LoadFerryDetails();
        }

        private void LoadFerryDetails()
        {
            // 1. Check whether editing is allowed BEFORE loading anything
            if (!_helper.CanEditFerry(_ferryId, out string reason))
            {
                _editingAllowed = false;

                // Disable editing controls
                btnSave.Enabled = false;
                btnAddFloor.Enabled = false;
                btnRemoveFloor.Enabled = false;
                txtFerryCode.Enabled = false;
                txtFerryName.Enabled = false;
                dgvFloors.ReadOnly = true;

                MessageBox.Show(
                    "This ferry cannot be edited.\nReason: " + reason,
                    "Editing Disabled",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
            }

            // Load ferry details 
            var row = _helper.GetFerryById(_ferryId);
            if (row != null)
            {
                txtFerryCode.Text = row["FerryCode"].ToString();
                txtFerryName.Text = row["FerryName"].ToString();
            }

            // Load floors
            DataTable floors = _helper.GetFerryFloors(_ferryId);
            if (floors != null)
            {
                dgvFloors.DataSource = floors;

                if (dgvFloors.Columns.Contains("FloorID"))
                    dgvFloors.Columns["FloorID"].Visible = false;
                if (dgvFloors.Columns.Contains("Capacity"))
                    dgvFloors.Columns["Capacity"].Visible = false;

                if (dgvFloors.Columns.Contains("FloorNumber"))
                    dgvFloors.Columns["FloorNumber"].ReadOnly = true;
            }
        }

        private void btnAddFloor_Click(object sender, EventArgs e)
        {
            if (!_editingAllowed)
            {
                MessageBox.Show("Editing is disabled for this ferry.",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataTable dt = dgvFloors.DataSource as DataTable;
            if (dt == null)
            {
                dt = new DataTable();
                dt.Columns.Add("FloorNumber", typeof(int));
                dt.Columns.Add("Rows", typeof(int));
                dt.Columns.Add("Columns", typeof(int));
                dt.Columns.Add("Capacity", typeof(int));
            }

            int maxFloor = dt.Rows.Count > 0 ? dt.AsEnumerable().Max(r => Convert.ToInt32(r["FloorNumber"])) : 0;

            DataRow newRow = dt.NewRow();
            newRow["FloorNumber"] = maxFloor + 1;
            newRow["Rows"] = 1;
            newRow["Columns"] = 1;
            if (dt.Columns.Contains("Capacity"))
                newRow["Capacity"] = 1;

            dt.Rows.Add(newRow);
            dgvFloors.DataSource = dt;
        }

        private void btnRemoveFloor_Click(object sender, EventArgs e)
        {
            if (!_editingAllowed)
            {
                MessageBox.Show("Editing is disabled for this ferry.",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dgvFloors.CurrentRow == null || dgvFloors.CurrentRow.IsNewRow) return;

            DataTable dt = dgvFloors.DataSource as DataTable;
            if (dt != null)
            {
                dt.Rows.RemoveAt(dgvFloors.CurrentRow.Index);

                // Reindex floor numbers
                int index = 1;
                foreach (DataRow r in dt.Select("", "FloorNumber ASC"))
                    r["FloorNumber"] = index++;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_editingAllowed)
            {
                MessageBox.Show("Editing is disabled for this ferry.",
                    "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate fields
            if (string.IsNullOrWhiteSpace(txtFerryName.Text) || string.IsNullOrWhiteSpace(txtFerryCode.Text))
            {
                MessageBox.Show("Ferry name and code are required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Build floors dt
            DataTable floors = new DataTable();
            floors.Columns.Add("FloorNumber", typeof(int));
            floors.Columns.Add("Rows", typeof(int));
            floors.Columns.Add("Columns", typeof(int));

            foreach (DataGridViewRow row in dgvFloors.Rows)
            {
                if (row.IsNewRow) continue;

                floors.Rows.Add(
                    Convert.ToInt32(row.Cells["FloorNumber"].Value),
                    Convert.ToInt32(row.Cells["Rows"].Value),
                    Convert.ToInt32(row.Cells["Columns"].Value)
                );
            }

            string errorMessage;

            bool success = _helper.UpdateFerry(
                _ferryId,
                txtFerryCode.Text.Trim(),
                txtFerryName.Text.Trim(),
                floors,
                out errorMessage
            );


            if (success)
            {
                MessageBox.Show("Ferry updated.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            else
            {
                MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
    }
}
