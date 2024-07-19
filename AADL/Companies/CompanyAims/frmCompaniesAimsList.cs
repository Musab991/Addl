using AADLBusiness;
using DVLD.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace AADL.Companies.CompanyAims
{
    public partial class frmCompaniesAimsList : Form
    {
        private enum enMode { add, update }
        private enMode _mode = enMode.add;
        private void _OnAimAddedUpdated() => _LoadRefreshAims();

        private void _Subscribe(frmAddEditCompanyAim frm)
        {
            if (_mode == enMode.add)
                frm.CompanyAimAdded += _OnAimAddedUpdated;

            if (_mode == enMode.update)
                frm.CompanyAimEdited += _OnAimAddedUpdated;
        }

        private DataTable _dtAims;

        public frmCompaniesAimsList()
        {
            InitializeComponent();
        }

        private void _FillDataGridView(DataTable dtAims)
        {
            dgvAims.DataSource = null;
            if (dtAims != null && dtAims.Rows.Count > 0)
            {
                dgvAims.DataSource = dtAims;

                //Change the columns name
                dgvAims.Columns["AimID"].HeaderText = "الرقم";
                dgvAims.Columns["Name"].HeaderText = "الاسم";

                lblTotalRecordsCount.Text = dtAims.Rows.Count.ToString();
            }
        }

        private void _Settings()
        {
            cbFilterBy.SelectedItem = "لا شيء";
        }

        private void _LoadRefreshAims()
        {
            _dtAims = clsCompanyAim.All();
            _FillDataGridView(_dtAims);
        }

        private void _Filter()
        {
            string filterColumn = string.Empty;
            string filterValue = txtFilterValue.Text.Trim();

            // Map Selected Filter to real Column name 
            switch (cbFilterBy.Text)
            {
                case "لا شيء":
                    filterColumn = "None";
                    break;
                case "الرقم":
                    filterColumn = "AimID";
                    break;
                case "الاسم":
                    filterColumn = "Name";
                    break;
                default:
                    filterColumn = "None";
                    break;
            }

            //Reset the filters in case nothing selected or filter value contains nothing.
            if (filterValue == string.Empty || filterColumn == "None")
            {
                _dtAims.DefaultView.RowFilter = string.Empty;
            }
            else
            {

                if (filterColumn == "AimID")
                    //in this case we deal with integer not string.
                    _dtAims.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterColumn, filterValue);
                else
                    _dtAims.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterColumn, filterValue);
            }

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvAims.Rows.Count.ToString();
        }

        private void frmCompaniesAimsList_Load(object sender, EventArgs e)
        {
            // Cusomize the appearance of the DataGridView
            clsUtil.CustomizeDataGridView(dgvAims);
            _LoadRefreshAims();
            _Settings();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _mode = enMode.add;
            frmAddEditCompanyAim frm = new frmAddEditCompanyAim();
            _Subscribe(frm);
            frm.ShowDialog();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = cbFilterBy.Text != "لا شيء";

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Clear();
                txtFilterValue.Focus();
            }

            if (_dtAims != null)
            {
                _dtAims.DefaultView.RowFilter = string.Empty;
                lblTotalRecordsCount.Text = dgvAims.Rows.Count.ToString();
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _Filter();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "الرقم")
                clsUtil.IsNumber(e);
        }

        private void dgvAims_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Check if there are any rows and columns in the DataGridView
                if (dgvAims.Rows.Count == 0 || dgvAims.Columns.Count == 0)
                {
                    // Suppress the ContextMenuStrip
                    return;
                }

                // Check if the clicked cell is valid
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Show the ContextMenuStrip
                    dgvAims.CurrentCell = dgvAims[e.ColumnIndex, e.RowIndex];
                    cmsAims.Show(Cursor.Position);
                }
            }
        }

        private void editAimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _mode = enMode.update;
            int ID = (int)dgvAims.CurrentRow.Cells["AimID"].Value;
            frmAddEditCompanyAim frm = new frmAddEditCompanyAim(ID);
            _Subscribe(frm);
            frm.ShowDialog();
        }

        private void deleteAimToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvAims.CurrentRow.Cells["AimID"].Value;

            if (MessageBox.Show($"هل انت متاكد انك تريد حذف هذة الهدف؟", "تاكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsCompanyAim.Delete(ID))
                {
                    MessageBox.Show($"تم حذف الهدف بنجاح", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _LoadRefreshAims();
                }
                else
                    MessageBox.Show($"لم يتم حذف الهدف بنجاح بسبب عطل فني في النظام. الرجاء إبلاغ فريق الصيانة", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
