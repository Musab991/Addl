using AADL.Cases;
using AADLBusiness;
using AADLBusiness.Expert;
using DVLD.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace AADL.Cases_Types
{
    public partial class frmCasesTypesList : Form
    {
        private enum enMode { add, update }
        private enMode _mode = enMode.add;
        private void _OnCaseAddedUpdated() => _LoadRefreshCases();

        private void _Subscribe(frmAddEditCaseType frm)
        {
            if (_mode == enMode.add)
                frm.CaseTypeAdded += _OnCaseAddedUpdated;

            if (_mode == enMode.update)
                frm.CaseTypeEdited += _OnCaseAddedUpdated;
        }

        private clsCaseType.enWhichPractitioner _whichPractitioner;
        private DataTable _dtCases;
        public frmCasesTypesList(clsCaseType.enWhichPractitioner whichPractitioner)
        {
            InitializeComponent();
            _whichPractitioner = whichPractitioner;
        }

        private void _FillDataGridView(DataTable dtCases)
        {
            dgvCases.DataSource = null;
            if (dtCases != null && dtCases.Rows.Count > 0)
            {
                dgvCases.DataSource = dtCases;

                //Change the columns name
                dgvCases.Columns["ID"].HeaderText = "الرقم";
                dgvCases.Columns["Name"].HeaderText = "الاسم";

                lblTotalRecordsCount.Text = dtCases.Rows.Count.ToString();
            }
        }

        private void _Settings()
        {
            cbFilterBy.SelectedItem = "لا شيء";
        }

        private void _LoadRefreshCases()
        {
            _dtCases = clsCaseType.All(_whichPractitioner);
            _FillDataGridView(_dtCases);
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
                    filterColumn = "ID";
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
                _dtCases.DefaultView.RowFilter = string.Empty;
            }
            else
            {

                if (filterColumn == "ID")
                    //in this case we deal with integer not string.
                    _dtCases.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterColumn, filterValue);
                else
                    _dtCases.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterColumn, filterValue);
            }

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvCases.Rows.Count.ToString();
        }

        private void frmCasesTypesList_Load(object sender, EventArgs e)
        {
            // Cusomize the appearance of the DataGridView
            clsUtil.CustomizeDataGridView(dgvCases);
            _LoadRefreshCases();
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

            if (_dtCases != null)
            {
                _dtCases.DefaultView.RowFilter = string.Empty;
                lblTotalRecordsCount.Text = dgvCases.Rows.Count.ToString();
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
            frmAddEditCaseType frm = new frmAddEditCaseType(_whichPractitioner);
            _Subscribe(frm);
            frm.ShowDialog();
        }

        private void editCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _mode = enMode.update;
            int ID = (int)dgvCases.CurrentRow.Cells["ID"].Value;
            frmAddEditCaseType frm = new frmAddEditCaseType(ID, _whichPractitioner);
            _Subscribe(frm);
            frm.ShowDialog();
        }

        private void dgvCases_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Check if there are any rows and columns in the DataGridView
                if (dgvCases.Rows.Count == 0 || dgvCases.Columns.Count == 0)
                {
                    // Suppress the ContextMenuStrip
                    return;
                }

                // Check if the clicked cell is valid
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Show the ContextMenuStrip
                    dgvCases.CurrentCell = dgvCases[e.ColumnIndex, e.RowIndex];
                    cmsCases.Show(Cursor.Position);
                }
            }
        }

        private void deleteCaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ID = (int)dgvCases.CurrentRow.Cells["ID"].Value;

            if (MessageBox.Show($"هل انت متاكد انك تريد حذف هذة القضية؟", "تاكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsCaseType.Delete(ID, _whichPractitioner))
                {
                    MessageBox.Show($"تم حذف نوع القضية بنجاح", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _LoadRefreshCases();
                }
                else
                    MessageBox.Show($"لم يتم حذف نوع القضية بنجاح بسبب عطل فني في النظام. الرجاء إبلاغ فريق الصيانة", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
