using AADLBusiness;
using DVLD.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace AADL.Reasons
{
    public partial class frmReasonsList : Form
    {
        private enum enMode { add, update }
        private enMode _mode = enMode.add;
        private void _OnReasonAddedUpdated() => _LoadRefreshReasons();

        private void _Subscribe(frmAddEditReason frm)
        {
            if (_mode == enMode.add)
                frm.ReasonAdded += _OnReasonAddedUpdated;

            if (_mode == enMode.update)
                frm.ReasonEdited += _OnReasonAddedUpdated;
        }

        private DataTable _dtReasons;
        private clsReason.enCompanyOrPractitioner _companyOrPractitioner;
        private clsReason.enWhichListType _whichListType;

        public frmReasonsList(clsReason.enCompanyOrPractitioner companyOrPractitioner, clsReason.enWhichListType whichListType)
        {
            InitializeComponent();
            _companyOrPractitioner = companyOrPractitioner;
            _whichListType = whichListType;
        }

        private void _FillDataGridView(DataTable dtReasons)
        {
            dgvReasons.DataSource = null;
            if (dtReasons != null && dtReasons.Rows.Count > 0)
            {
                dgvReasons.DataSource = dtReasons;

                //Change the columns name
                dgvReasons.Columns["ReasonID"].HeaderText = "الرقم";
                dgvReasons.Columns["ReasonName"].HeaderText = "الاسم";

                lblTotalRecordsCount.Text = dtReasons.Rows.Count.ToString();
            }
        }

        private void _Settings()
        {
            cbFilterBy.SelectedItem = "لا شيء";
        }

        private void _LoadRefreshReasons()
        {
            _dtReasons = clsReason.All(_companyOrPractitioner, _whichListType);
            _FillDataGridView(_dtReasons);
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
                    filterColumn = "ReasonID";
                    break;
                case "الاسم":
                    filterColumn = "ReasonName";
                    break;
                default:
                    filterColumn = "None";
                    break;
            }

            //Reset the filters in case nothing selected or filter value contains nothing.
            if (filterValue == string.Empty || filterColumn == "None")
            {
                _dtReasons.DefaultView.RowFilter = string.Empty;
            }
            else
            {

                if (filterColumn == "ID")
                    //in this case we deal with integer not string.
                    _dtReasons.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterColumn, filterValue);
                else
                    _dtReasons.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterColumn, filterValue);
            }

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvReasons.Rows.Count.ToString();
        }

        private void frmReasonsList_Load(object sender, EventArgs e)
        {
            // Cusomize the appearance of the DataGridView
            clsUtil.CustomizeDataGridView(dgvReasons);
            _LoadRefreshReasons();
            _Settings();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = cbFilterBy.Text != "لا شيء";

            if (txtFilterValue.Visible)
            {
                txtFilterValue.Clear();
                txtFilterValue.Focus();
            }

            if (_dtReasons != null)
            {
                _dtReasons.DefaultView.RowFilter = string.Empty;
                lblTotalRecordsCount.Text = dgvReasons.Rows.Count.ToString();
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

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _mode = enMode.add;
            frmAddEditReason frm = new frmAddEditReason(_companyOrPractitioner, _whichListType);
            _Subscribe(frm);
            frm.ShowDialog();
        }

        private void dgvReasons_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Check if there are any rows and columns in the DataGridView
                if (dgvReasons.Rows.Count == 0 || dgvReasons.Columns.Count == 0)
                {
                    // Suppress the ContextMenuStrip
                    return;
                }

                // Check if the clicked cell is valid
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Show the ContextMenuStrip
                    dgvReasons.CurrentCell = dgvReasons[e.ColumnIndex, e.RowIndex];
                    cmsReasons.Show(Cursor.Position);
                }
            }
        }

        private void editReasonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _mode = enMode.update;
            int ReasonID = (int)dgvReasons.CurrentRow.Cells["ReasonID"].Value;
            frmAddEditReason frm = new frmAddEditReason(ReasonID, _companyOrPractitioner, _whichListType);
            _Subscribe(frm);
            frm.ShowDialog();
        }

        private void deleteReasonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ReasonID = (int)dgvReasons.CurrentRow.Cells["ReasonID"].Value;

            if (MessageBox.Show($"هل انت متاكد انك تريد حذف السبب؟", "تاكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsReason.Delete(ReasonID, _companyOrPractitioner, _whichListType))
                {
                    MessageBox.Show($"تم حذف السبب بنجاح", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _LoadRefreshReasons();
                }
                else
                    MessageBox.Show($"لم يتم حذف السبب بنجاح بسبب عطل فني في النظام. الرجاء إبلاغ فريق الصيانة", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
