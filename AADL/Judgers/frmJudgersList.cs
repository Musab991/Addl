using AADL.Regulators;
using AADLBusiness.Judger;
using DVLD.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace AADL.Judgers
{
    public partial class frmJudgersList : Form
    {
        private void _OnJudgerInfoUpdated() => _LoadRefreshJudgersPerPage();

        private void _Subscribe(frmJudgerCard frm) => frm.JudgerInfoUpdated += _OnJudgerInfoUpdated;

        private void _OnJudgerInfoAdded(object sender, EventArgs e) => _LoadRefreshJudgersPerPage();

        private void _Subscribe(frmAddUpdatePractitioner frm) => frm.evNewPractitionerAdded += _OnJudgerInfoAdded;

        private enum enMode { add, update, delete }
        private enMode _mode = enMode.add;
        private ushort _pageNumber = 0;
        private uint? _currentPageNumber = 1;
        private uint? _totalNumberOfPages = null;
        private DataTable _dtJudgers;

        public frmJudgersList()
        {
            InitializeComponent();
        }

        private void _FillDataGridView(DataTable dtJudgers)
        {
            dgvJudgers.DataSource = null;

            if (dtJudgers != null && dtJudgers.Rows.Count > 0)
            {
                dgvJudgers.DataSource = dtJudgers;

                //Set AutoSizeMode for the FullName column to AutoSize
                dgvJudgers.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                //Change the columns name

                dgvJudgers.Columns["JudgerID"].HeaderText = "الرقم التعريفي";
                dgvJudgers.Columns["FullName"].HeaderText = "الاسم رباعي";
                dgvJudgers.Columns["Phone"].HeaderText = "رقم الهاتف";
                dgvJudgers.Columns["Email"].HeaderText = "البريد الالكتروني";
                dgvJudgers.Columns["Gender"].HeaderText = "النوع";
                dgvJudgers.Columns["CountryName"].HeaderText = "الدولة";
                dgvJudgers.Columns["CityName"].HeaderText = "المدينة";
                dgvJudgers.Columns["SubscriptionTypeName"].HeaderText = "نوع الاشتراك";
                dgvJudgers.Columns["SubscriptionWayName"].HeaderText = "طريقة الاشتراك";
                dgvJudgers.Columns["IsActive"].HeaderText = "هل فعال ؟";

                lblTotalRecordsCount.Text = dtJudgers.Rows.Count.ToString();
            }
        }

        private void _LoadRefreshJudgersPerPage()
        {
            // Get the number of pages and show them in the ComoboBox "cbPage"
            if (_mode == enMode.add || _mode == enMode.delete)
                _HandleNumberOfPages();

            // load Judgers data per page and save them in the DataTable "_dtJudgers"
            // in case the page number is equal to zero assign null to the DataTable "_dtJudgers"
            _dtJudgers = _pageNumber > 0 ? clsJudger.GetJudgersPerPage(_pageNumber, clsUtil.RowsPerPage) : null;
            _FillDataGridView(_dtJudgers);
        }

        private void _HandleNumberOfPages()
        {
            uint totalJudgersCount = (uint)clsJudger.Count();

            // Calculate the number of pages depending on "totalJudgersCount"
            uint numberOfPages = totalJudgersCount > 0 ? (uint)Math.Ceiling((double)totalJudgersCount / clsUtil.RowsPerPage) : 0;

            _totalNumberOfPages = numberOfPages;

            cbPage.Items.Clear();

            if (numberOfPages == 0)
            {
                cbPage.Items.Add(0);

                cbPage.Enabled = false;
                cbFilterBy.Enabled = false;
                btnNextPage.Enabled = false;
                btnPreviousPage.Enabled = false;
            }
            else
            {
                for (int i = 1; i <= numberOfPages; i++)
                    cbPage.Items.Add(i);

                cbPage.Enabled = true;
                cbFilterBy.Enabled = true;
                btnNextPage.Enabled = true;
                btnPreviousPage.Enabled = true;
            }

            // Select the first page to to load its data if any
            cbPage.SelectedIndex = 0;
            _pageNumber = ushort.TryParse(cbPage.Text, out ushort result) == true ? result : (ushort)0;
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
                case "الرقم التعريفي":
                    filterColumn = "JudgerID";
                    break;
                case "الاسم":
                    filterColumn = "FullName";
                    break;
                case "رقم الهاتف":
                    filterColumn = "Phone";
                    break;
                case "البريد الالكتروني":
                    filterColumn = "Email";
                    break;
                default:
                    filterColumn = "None";
                    break;
            }

            //Reset the filters in case nothing selected or filter value contains nothing.
            if (filterValue == string.Empty || filterColumn == "None")
            {
                _dtJudgers.DefaultView.RowFilter = string.Empty;
            }
            else
            {

                if (filterColumn == "JudgerID" || filterColumn == "PractitionerID")
                    //in this case we deal with integer not string.
                    _dtJudgers.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterColumn, filterValue);
                else
                    _dtJudgers.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterColumn, filterValue);
            }

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvJudgers.Rows.Count.ToString();
        }

        private void _FillComboBoxBySubscriptionWays()
        {
            clsUtil.FillComboBoxBySubscriptionWays(cbSubscriptionWay);
        }

        private void _FillComboBoxBySubscriptionTypes()
        {
            clsUtil.FillComboBoxBySubscriptionTypes(cbSubscriptionType);
        }

        private void _Settings()
        {
            cbFilterBy.SelectedItem = "لا شيء";
        }

        private void _ShowJudgerCardForm()
        {
            int judgerID = (int)dgvJudgers.CurrentRow.Cells["JudgerID"].Value;

            frmJudgerCard frm = new frmJudgerCard(judgerID, Judgers.Controls.ctrJudgerCard.enWhichID.JudgerID);
            _mode = enMode.update;
            _Subscribe(frm);
            frm.ShowDialog();
        }

        private void _HandleCurrentPage()
        {
            cbPage.SelectedIndex = Convert.ToInt16(_currentPageNumber - 1);
        }

        private void frmJudgersList_Load(object sender, EventArgs e)
        {
            //Customize the appearance of the DataGridView
            clsUtil.CustomizeDataGridView(dgvJudgers);

            _LoadRefreshJudgersPerPage();
            _FillComboBoxBySubscriptionWays();
            _FillComboBoxBySubscriptionTypes();
            _Settings();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "لا شيء" && cbFilterBy.Text != "هل فعال ؟"
               && cbFilterBy.Text != "نوع الاشتراك" && cbFilterBy.Text != "طريقة الاشتراك");

            cbIsActive.Visible = cbFilterBy.Text == "هل فعال ؟";
            cbSubscriptionType.Visible = cbFilterBy.Text == "نوع الاشتراك";
            cbSubscriptionWay.Visible = cbFilterBy.Text == "طريقة الاشتراك";

            if (cbIsActive.Visible)
                cbIsActive.SelectedItem = "الكل";
            else if (cbSubscriptionType.Visible)
            {
                cbSubscriptionType.SelectedItem = "الكل";
            }

            else if (cbSubscriptionWay.Visible)
            {
                cbSubscriptionWay.SelectedItem = "الكل";
            }

            else if (txtFilterValue.Visible)
            {
                txtFilterValue.Clear();
                txtFilterValue.Focus();
            }

            if (_dtJudgers != null)
            {
                _dtJudgers.DefaultView.RowFilter = string.Empty;
                lblTotalRecordsCount.Text = dgvJudgers.Rows.Count.ToString();
            }
        }

        private void cbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected page number
            _pageNumber = ushort.TryParse(cbPage.Text, out ushort result) == true ? result : (ushort)0;

            // Load Judgers data from the database and view it in the DataGridView
            _dtJudgers = clsJudger.GetJudgersPerPage(_pageNumber, clsUtil.RowsPerPage);
            _FillDataGridView(_dtJudgers);

            // Reset the filter
            cbFilterBy.SelectedItem = "لا شيء";
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _Filter();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "الرقم التعريفي")
                clsUtil.IsNumber(e);
        }

        // This function will supress the ContextMenuStrip from being shown incase the DataGridView is empty
        private void dgvJudgers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Check if there are any rows and columns in the DataGridView
                if (dgvJudgers.Rows.Count == 0 || dgvJudgers.Columns.Count == 0)
                {
                    // Suppress the ContextMenuStrip
                    return;
                }

                // Check if the clicked cell is valid
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Show the ContextMenuStrip
                    dgvJudgers.CurrentCell = dgvJudgers[e.ColumnIndex, e.RowIndex];
                    cmsJudgers.Show(Cursor.Position);
                }
            }
        }

        private void deactivateJudgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int judgerID = (int)dgvJudgers.CurrentRow.Cells["JudgerID"].Value;

            if (MessageBox.Show($"هل انت متاكد انك تريد تريد الغاء تفعيل الحساب رقم {judgerID} ؟", "تاكيد الإلغاء", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (clsJudger.Deactivate(judgerID))
                {
                    MessageBox.Show($"تم الإلغاء تفعيل الحساب بنجاح", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _mode = enMode.delete;
                    _LoadRefreshJudgersPerPage();
                }
                else
                    MessageBox.Show($"لم يتم الإلغاء تفعيل الحساب بنجاح بسبب عطل فني في النظام. الرجاء إبلاغ فريق الصيانة", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteJudgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int judgerID = (int)dgvJudgers.CurrentRow.Cells["JudgerID"].Value;

            if (MessageBox.Show($"تحذير: سوف يتم حذف الحساب رقم ({judgerID}) و كل ما يتعلق به. هل ما زلت تريد حذف هذا الحساب؟", "تاكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsJudger.DeletePermanently(judgerID))
                {
                    MessageBox.Show($"تم حذف الحساب بنجاح", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _mode = enMode.delete;
                    _LoadRefreshJudgersPerPage();
                }
                else
                    MessageBox.Show($"لم يتم حذف الحساب بنجاح بسبب عطل فني في النظام. الرجاء إبلاغ فريق الصيانة", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowJudgerCardForm();
        }

        private void cmsJudgers_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool isActive = (bool)dgvJudgers.CurrentRow.Cells["IsActive"].Value;

            if (isActive)
            {
                activateJudgerToolStripMenuItem.Enabled = false;
                deactivateJudgerToolStripMenuItem.Enabled = true;
            }
            else
            {
                activateJudgerToolStripMenuItem.Enabled = true;
                deactivateJudgerToolStripMenuItem.Enabled = false;
            }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filterColumn = "IsActive";
            string filterValue = string.Empty;

            // Map Selected Filter to real Column name 
            switch (cbIsActive.Text)
            {
                case "الكل":
                    filterValue = string.Empty;
                    break;
                case "نعم":
                    filterValue = "1";
                    break;
                case "لا":
                    filterValue = "0";
                    break;
                default:
                    filterValue = string.Empty;
                    break;
            }

            if (filterValue == string.Empty)
                _dtJudgers.DefaultView.RowFilter = filterValue;
            else
                _dtJudgers.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterColumn, filterValue);

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvJudgers.Rows.Count.ToString();
        }

        private void activateJudgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int judgerID = (int)dgvJudgers.CurrentRow.Cells["JudgerID"].Value;

            if (MessageBox.Show($"هل انت متاكد انك تريد تريد تفعيل الحساب رقم {judgerID} ؟", "تاكيد التفعيل", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (clsJudger.Activate(judgerID))
                {
                    MessageBox.Show($"تم تفعيل الحساب بنجاح", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _mode = enMode.delete;
                    _LoadRefreshJudgersPerPage();
                }
                else
                    MessageBox.Show($"لم يتم تفعيل الحساب بنجاح بسبب عطل فني في النظام. الرجاء إبلاغ فريق الصيانة", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvJudgers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _ShowJudgerCardForm();
        }

        private void cbSubscriptionWay_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filterColumn = "SubscriptionWayName";
            string filterValue = string.Empty;

            if (cbSubscriptionWay.Text != "الكل")
            {
                filterValue = cbSubscriptionWay.Text.ToString();
            }

            if (filterValue == string.Empty)
                _dtJudgers.DefaultView.RowFilter = filterValue;
            else
                _dtJudgers.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", filterColumn, filterValue);

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvJudgers.Rows.Count.ToString();
        }

        private void cbSubscriptionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filterColumn = "SubscriptionTypeName";
            string filterValue = string.Empty;
            if (cbSubscriptionType.Text != "الكل")
            {
                filterValue = cbSubscriptionType.Text.ToString();
            }

            if (filterValue == string.Empty)
                _dtJudgers.DefaultView.RowFilter = filterValue;
            else
                _dtJudgers.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", filterColumn, filterValue);

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvJudgers.Rows.Count.ToString();
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (_currentPageNumber > 1)
            {
                _currentPageNumber--;
                _HandleCurrentPage();
            }
        }

        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (_currentPageNumber < _totalNumberOfPages)
            {
                _currentPageNumber++;
                _HandleCurrentPage();
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            _mode = enMode.add;

            frmAddUpdatePractitioner frm = new frmAddUpdatePractitioner();
            _Subscribe(frm);
            frm.ShowDialog();
        }
   
    }

}
