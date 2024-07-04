using AADLBusiness;
using DVLD.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace AADL.Regulators
{
    public partial class frmRegulatorList : Form
    {
        private void _OnRegulatorInfoUpdated() => _LoadRefreshRegulatorsPerPage();

        private void _Subscribe(frmRegulatorInfo frm) => frm.RegulatorInfoUpdated += _OnRegulatorInfoUpdated;

        private void _OnRegulatorInfoAdded(object sender, EventArgs e) => _LoadRefreshRegulatorsPerPage();

        private void _Subscribe(frmAddUpdatePractitioner frm) => frm.evNewPractitionerAdded += _OnRegulatorInfoAdded;

        private enum enMode { add, update, delete }
        private enMode _mode = enMode.add;

        private DataTable _dtRegulators;
        private ushort _pageNumber = 0;
        private uint? _currentPageNumber = 1;
        private uint? _totalNumberOfPages= null;

        public frmRegulatorList()
        {
            InitializeComponent();
        }

        private void _FillDataGridView(DataTable dtRegulators)
        {
            dgvRegulators.DataSource = null;

            if (dtRegulators != null && dtRegulators.Rows.Count > 0)
            {
                dgvRegulators.DataSource = dtRegulators;

                //Set AutoSizeMode for the FullName column to AutoSize
                dgvRegulators.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                //Change the columns name

                dgvRegulators.Columns["RegulatorID"].HeaderText = "الرقم التعريفي";
                dgvRegulators.Columns["MembershipNumber"].HeaderText = "رقم العضوية";
                dgvRegulators.Columns["FullName"].HeaderText = "الاسم رباعي";
                dgvRegulators.Columns["Phone"].HeaderText = "رقم الهاتف";
                dgvRegulators.Columns["Email"].HeaderText = "البريد الالكتروني";
                dgvRegulators.Columns["Gender"].HeaderText = "النوع";
                dgvRegulators.Columns["CountryName"].HeaderText = "الدولة";
                dgvRegulators.Columns["CityName"].HeaderText = "المدينة";
                dgvRegulators.Columns["SubscriptionTypeName"].HeaderText = "نوع الاشتراك";
                dgvRegulators.Columns["SubscriptionWayName"].HeaderText = "طريقة الاشتراك";
                dgvRegulators.Columns["IsActive"].HeaderText = "هل فعال ؟";


                lblTotalRecordsCount.Text = dtRegulators.Rows.Count.ToString();
            }
        }

        private void _FillComboBoxBySubscriptionWays()
        {
            clsUtil.FillComboBoxBySubscriptionWays(cbSubscriptionWay);
        }

        private void _FillComboBoxBySubscriptionTypes()
        {
            clsUtil.FillComboBoxBySubscriptionTypes(cbSubscriptionType);
        }

        private void _LoadRefreshRegulatorsPerPage()
        {
            // Get the number of pages and show them in the ComoboBox "cbPage"
            if (_mode == enMode.add || _mode == enMode.delete)
                _HandleNumberOfPages();

            // load Judgers data per page and save them in the DataTable "_dtJudgers"
            // in case the page number is equal to zero assign null to the DataTable "_dtJudgers"
            _dtRegulators = _pageNumber > 0 ? clsRegulator.GetRegulatorsPerPage(_pageNumber, clsUtil.RowsPerPage) : null;
            _FillDataGridView(_dtRegulators);
        }

        private void _HandleNumberOfPages()
        {
            uint totalJudgersCount = (uint)clsRegulator.Count();

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
                    filterColumn = "RegulatorID";
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
                _dtRegulators.DefaultView.RowFilter = string.Empty;
            }
            else
            {

                if (filterColumn == "RegulatorID")
                    //in this case we deal with integer not string.
                    _dtRegulators.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterColumn, filterValue);
                else
                    _dtRegulators.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterColumn, filterValue);
            }

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvRegulators.Rows.Count.ToString();
        }

        private void _Settings()
        {
            cbFilterBy.SelectedItem = "لا شيء";

        }

        private void _HandleCurrentPage()
        {
            cbPage.SelectedIndex = Convert.ToInt16( _currentPageNumber - 1);

        }

        private void _ShowRequlatorCardForm()
        {
                int RegulatorID = (int)dgvRegulators.CurrentRow.Cells["RegulatorID"].Value;

                frmRegulatorInfo frm = new frmRegulatorInfo(RegulatorID);
                _mode = enMode.update;
                _Subscribe(frm);
                frm.ShowDialog();
            
        }

        private void frmRegulatorList_Load(object sender, EventArgs e)
        {

            //Customize the appearance of the DataGridView
            clsUtil.CustomizeDataGridView(dgvRegulators);

            _LoadRefreshRegulatorsPerPage();
            _FillComboBoxBySubscriptionWays();
            _FillComboBoxBySubscriptionTypes();
            _Settings();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "لا شيء" && cbFilterBy.Text != "هل فعال ؟"
                &&cbFilterBy.Text!="نوع الاشتراك" && cbFilterBy.Text != "طريقة الاشتراك");

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

            if (_dtRegulators != null)
            {
                _dtRegulators.DefaultView.RowFilter = string.Empty;
                lblTotalRecordsCount.Text = dgvRegulators.Rows.Count.ToString();
            }

        }

        private void cbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected page number
            _pageNumber = ushort.TryParse(cbPage.Text, out ushort result) == true ? result : (ushort)0;

            // Load Regulators data from the database and view it in the DataGridView
            _dtRegulators = clsRegulator.GetRegulatorsPerPage(_pageNumber, clsUtil.RowsPerPage);
            _FillDataGridView(_dtRegulators);

            // Reset the filter
            cbFilterBy.SelectedItem = "لا شيء";
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

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _Filter();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "الرقم التعريفي")
                clsUtil.IsNumber(e);
        }  
  
        // This function will supress the ContextMenuStrip from being shown in-case the DataGridView is empty
        private void dgvRegulators_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Check if there are any rows and columns in the DataGridView
                if (dgvRegulators.Rows.Count == 0 || dgvRegulators.Columns.Count == 0)
                {
                    // Suppress the ContextMenuStrip
                    return;
                }

                // Check if the clicked cell is valid
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Show the ContextMenuStrip
                    dgvRegulators.CurrentCell = dgvRegulators[e.ColumnIndex, e.RowIndex];
                    cmsRegulators.Show(Cursor.Position);
                }
            }
        }

        private void dgvRegulators_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _ShowRequlatorCardForm();
        }

        private void cmsRegulator_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool isActive = (bool)dgvRegulators.CurrentRow.Cells["IsActive"].Value;

            if (isActive)
            {
                activateRegulatorToolStripMenuItem.Enabled = false;
                deactivateRegulatorToolStripMenuItem.Enabled = true;
            }
            else
            {
                activateRegulatorToolStripMenuItem.Enabled = true;
                deactivateRegulatorToolStripMenuItem.Enabled = false;
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
                _dtRegulators.DefaultView.RowFilter = filterValue;
            else
                _dtRegulators.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterColumn, filterValue);

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvRegulators.Rows.Count.ToString();
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
                _dtRegulators.DefaultView.RowFilter = filterValue;
            else
            _dtRegulators.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", filterColumn, filterValue);


            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvRegulators.Rows.Count.ToString();
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
                _dtRegulators.DefaultView.RowFilter = filterValue;
            else
                _dtRegulators.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", filterColumn, filterValue);

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvRegulators.Rows.Count.ToString();
        }

        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            _ShowRequlatorCardForm();
            
        }

        private void activateRegulatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
                int RegulatorID = (int)dgvRegulators.CurrentRow.Cells["RegulatorID"].Value;

                if (MessageBox.Show($"هل انت متاكد انك تريد تريد تفعيل الحساب رقم {RegulatorID} ؟", "تاكيد التفعيل", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (clsRegulator.Activate(RegulatorID))
                    {
                        MessageBox.Show($"تم تفعيل الحساب بنجاح", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        _mode = enMode.delete;
                        _LoadRefreshRegulatorsPerPage();
                    }
       
                    else
                        MessageBox.Show($"لم يتم تفعيل الحساب بنجاح بسبب عطل فني في النظام. الرجاء إبلاغ فريق الصيانة", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                

                }

        }

        private void deactivateRegulatorToolStripMenuItem_Click(object sender, EventArgs e)
        {
                int RegulatorID = (int)dgvRegulators.CurrentRow.Cells["RegulatorID"].Value;
            
                if (MessageBox.Show($"هل انت متاكد انك تريد تريد الغاء تفعيل الحساب رقم {RegulatorID} ؟", "تاكيد الإلغاء", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    if (clsRegulator.Deactivate(RegulatorID,(int)clsGlobal.CurrentUser.UserID))
                    {
                        MessageBox.Show($"تم الإلغاء تفعيل الحساب بنجاح", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        _mode = enMode.delete;
                        _LoadRefreshRegulatorsPerPage();
                    }
                    else
                        MessageBox.Show($"لم يتم الإلغاء تفعيل الحساب بنجاح بسبب عطل فني في النظام. الرجاء إبلاغ فريق الصيانة", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void deleteJudgerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int RegulatorID = (int)dgvRegulators.CurrentRow.Cells["RegulatorID"].Value;

            if (MessageBox.Show($"تحذير: سوف يتم حذف الحساب رقم ({RegulatorID}) و كل ما يتعلق به. هل ما زلت تريد حذف هذا الحساب؟", "تاكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsRegulator.DeletePermanently(RegulatorID))
                {
                    MessageBox.Show($"تم حذف الحساب بنجاح", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _mode = enMode.delete;
                    _LoadRefreshRegulatorsPerPage();
                }
                else
                    MessageBox.Show($"لم يتم حذف الحساب بنجاح بسبب عطل فني في النظام.الرجاء إبلاغ فريق الصيانة", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
