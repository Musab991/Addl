using AADL.Experts;
using AADL.Regulators;
using AADLBusiness.Expert;
using DVLD.Classes;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace AADL.Experts
{
    public partial class frmExpertsList : Form
    {
        private void _OnExpertInfoUpdated() => _LoadRefreshExpertsPerPage();

        private void _Subscribe(frmExpertCard frm) => frm.ExpertInfoUpdated += _OnExpertInfoUpdated;

        private void _OnExpertInfoAdded(object sender, EventArgs e) => _LoadRefreshExpertsPerPage();

        private void _Subscribe(frmAddUpdatePractitioner frm) => frm.evNewPractitionerAdded += _OnExpertInfoAdded;

        private enum enMode { add, update, delete }
        private enMode _mode = enMode.add;
        private ushort _pageNumber = 0;
        private uint? _currentPageNumber = 1;
        private uint? _totalNumberOfPages = null;
        private DataTable _dtExperts;

        public frmExpertsList()
        {
            InitializeComponent();
        }

        private void _FillDataGridView(DataTable dtExperts)
        {
            dgvExperts.DataSource = null;
            if (dtExperts != null && dtExperts.Rows.Count > 0)
            {
                dgvExperts.DataSource = dtExperts;

                //Set AutoSizeMode for the FullName column to AutoSize
                dgvExperts.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                //Change the columns name

                dgvExperts.Columns["ExpertID"].HeaderText = "الرقم التعريفي";
                dgvExperts.Columns["FullName"].HeaderText = "الاسم رباعي";
                dgvExperts.Columns["Phone"].HeaderText = "رقم الهاتف";
                dgvExperts.Columns["Email"].HeaderText = "البريد الالكتروني";
                dgvExperts.Columns["Gender"].HeaderText = "النوع";
                dgvExperts.Columns["CountryName"].HeaderText = "الدولة";
                dgvExperts.Columns["CityName"].HeaderText = "المدينة";
                dgvExperts.Columns["SubscriptionTypeName"].HeaderText = "نوع الاشتراك";
                dgvExperts.Columns["SubscriptionWayName"].HeaderText = "طريقة الاشتراك";
                dgvExperts.Columns["IsActive"].HeaderText = "هل فعال ؟";

                lblTotalRecordsCount.Text = dtExperts.Rows.Count.ToString();
            }
        }

        private void _LoadRefreshExpertsPerPage()
        {
            // Get the number of pages and show them in the ComoboBox "cbPage"
            if (_mode == enMode.add || _mode == enMode.delete)
                _HandleNumberOfPages();

            // load Experts data per page and save them in the DataTable "_dtExperts"
            // in case the page number is equal to zero assign null to the DataTable "_dtExperts"
            _dtExperts = _pageNumber > 0 ? clsExpert.GetExpertsPerPage(_pageNumber, clsUtil.RowsPerPage) : null;
            _FillDataGridView(_dtExperts);
        }

        private void _HandleNumberOfPages()
        {
            uint totalExpertsCount = (uint)clsExpert.Count();

            // Calculate the number of pages depending on "totalExpertsCount"
            uint numberOfPages = totalExpertsCount > 0 ? (uint)Math.Ceiling((double)totalExpertsCount / clsUtil.RowsPerPage) : 0;

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
                    filterColumn = "ExpertID";
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
                _dtExperts.DefaultView.RowFilter = string.Empty;
            }
            else
            {

                if (filterColumn == "ExpertID" || filterColumn == "PractitionerID")
                    //in this case we deal with integer not string.
                    _dtExperts.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterColumn, filterValue);
                else
                    _dtExperts.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterColumn, filterValue);
            }

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvExperts.Rows.Count.ToString();
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

        private void _HandleCurrentPage()
        {
            cbPage.SelectedIndex = Convert.ToInt16(_currentPageNumber - 1);
        }

        private void _ShowExpertCardForm()
        {
            int expertID = (int)dgvExperts.CurrentRow.Cells["ExpertID"].Value;

            frmExpertCard frm = new frmExpertCard(expertID, clsExpert.enFindBy.ExpertID);
            _mode = enMode.update;
            _Subscribe(frm);
            frm.ShowDialog();
        }

        private void frmExpertsList_Load(object sender, EventArgs e)
        {
            // Cusomize the appearance of the DataGridView
            clsUtil.CustomizeDataGridView(dgvExperts);

            _LoadRefreshExpertsPerPage();
            _FillComboBoxBySubscriptionWays();
            _FillComboBoxBySubscriptionTypes();
            _Settings();
        }

        private void cbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected page number
            _pageNumber = ushort.TryParse(cbPage.Text, out ushort result) == true ? result : (ushort)0;

            // Load Experts data from the database and view it in the DataGridView
            _dtExperts = clsExpert.GetExpertsPerPage(_pageNumber, clsUtil.RowsPerPage);
            _FillDataGridView(_dtExperts);

            // Reset the filter
            cbFilterBy.SelectedItem = "لا شيء";
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

            if (_dtExperts != null)
            {
                _dtExperts.DefaultView.RowFilter = string.Empty;
                lblTotalRecordsCount.Text = dgvExperts.Rows.Count.ToString();
            }
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
        private void dgvExperts_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Check if there are any rows and columns in the DataGridView
                if (dgvExperts.Rows.Count == 0 || dgvExperts.Columns.Count == 0)
                {
                    // Suppress the ContextMenuStrip
                    return;
                }

                // Check if the clicked cell is valid
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Show the ContextMenuStrip
                    dgvExperts.CurrentCell = dgvExperts[e.ColumnIndex, e.RowIndex];
                    cmsExperts.Show(Cursor.Position);
                }
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
                _dtExperts.DefaultView.RowFilter = filterValue;
            else
                _dtExperts.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterColumn, filterValue);

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvExperts.Rows.Count.ToString();
        }

        private void cmsExperts_Opening(object sender, CancelEventArgs e)
        {
            bool isActive = (bool)dgvExperts.CurrentRow.Cells["IsActive"].Value;

            if (isActive)
            {
                activateExpertToolStripMenuItem.Enabled = false;
                deactivateExpertToolStripMenuItem.Enabled = true;
            }
            else
            {
                activateExpertToolStripMenuItem.Enabled = true;
                deactivateExpertToolStripMenuItem.Enabled = false;
            }
        }

        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowExpertCardForm();
        }

        private void activateExpertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int expertID = (int)dgvExperts.CurrentRow.Cells["ExpertID"].Value;

            if (MessageBox.Show($"هل انت متاكد انك تريد تريد تفعيل الحساب رقم {expertID} ؟", "تاكيد التفعيل", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (clsExpert.Activate(expertID, (int)clsGlobal.CurrentUser.Id))
                {
                    MessageBox.Show($"تم تفعيل الحساب بنجاح", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _mode = enMode.delete;
                    _LoadRefreshExpertsPerPage();
                }
                else
                    MessageBox.Show($"لم يتم تفعيل الحساب بنجاح بسبب عطل فني في النظام. الرجاء إبلاغ فريق الصيانة", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deactivateExpertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int expertID = (int)dgvExperts.CurrentRow.Cells["ExpertID"].Value;

            if (MessageBox.Show($"هل انت متاكد انك تريد تريد الغاء تفعيل الحساب رقم {expertID} ؟", "تاكيد الإلغاء", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (clsExpert.Deactivate(expertID,(int)clsGlobal.CurrentUser.Id))
                {
                    MessageBox.Show($"تم الإلغاء تفعيل الحساب بنجاح", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _mode = enMode.delete;
                    _LoadRefreshExpertsPerPage();
                }
                else
                    MessageBox.Show($"لم يتم الإلغاء تفعيل الحساب بنجاح بسبب عطل فني في النظام. الرجاء إبلاغ فريق الصيانة", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteExpertToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int expertID = (int)dgvExperts.CurrentRow.Cells["ExpertID"].Value;

            if (MessageBox.Show($"تحذير: سوف يتم حذف الحساب رقم ({expertID}) و كل ما يتعلق به. هل ما زلت تريد حذف هذا الحساب؟", "تاكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsExpert.DeletePermanently(expertID))
                {
                    MessageBox.Show($"تم حذف الحساب بنجاح", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _mode = enMode.delete;
                    _LoadRefreshExpertsPerPage();
                }
                else
                    MessageBox.Show($"لم يتم حذف الحساب بنجاح بسبب عطل فني في النظام. الرجاء إبلاغ فريق الصيانة", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvExperts_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _ShowExpertCardForm();
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
                _dtExperts.DefaultView.RowFilter = filterValue;
            else
                _dtExperts.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", filterColumn, filterValue);

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvExperts.Rows.Count.ToString();
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
                _dtExperts.DefaultView.RowFilter = filterValue;
            else
                _dtExperts.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", filterColumn, filterValue);

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvExperts.Rows.Count.ToString();
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
