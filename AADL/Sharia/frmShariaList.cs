using AADL.Regulators;
using System;
using System.Data;
using System.Windows.Forms;
using AADLBusiness.Sharia;
using DVLD.Classes;
using AADL.Sharia.Controls;

namespace AADL.Sharia
{
    public partial class frmShariaList : Form
    {
        private void _OnShariaInfoUpdated() => _LoadRefreshShariasPerPage();
        private void _OnShariaInfoAdded(object sender, EventArgs e) => _LoadRefreshShariasPerPage();
        private void _Subscribe(frmAddUpdatePractitioner frm) => frm.evNewPractitionerAdded += _OnShariaInfoAdded;
        private void _Subscribe(frmShariaCard frm) => frm.ShariaInfoUpdated += _OnShariaInfoUpdated;

        private enum enMode { add, update, delete }
        private enMode _mode = enMode.add;
        private ushort _pageNumber = 0;
        private uint? _currentPageNumber = 1;
        private uint? _totalNumberOfPages = null;
        private DataTable _dtSharias;
        public frmShariaList()
        {
            InitializeComponent();
        }
        private void _FillDataGridView(DataTable dtSharias)
        {
            dgvSharias.DataSource = null;

            if (dtSharias != null && dtSharias.Rows.Count > 0)
            {
                dgvSharias.DataSource = dtSharias;

                //Set AutoSizeMode for the FullName column to AutoSize
                dgvSharias.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                //Change the columns name

                dgvSharias.Columns["ShariaID"].HeaderText = "الرقم التعريفي";
                dgvSharias.Columns["FullName"].HeaderText = "الاسم رباعي";
                dgvSharias.Columns["Phone"].HeaderText = "رقم الهاتف";
                dgvSharias.Columns["Email"].HeaderText = "البريد الالكتروني";
                dgvSharias.Columns["ShariaLicenseNumber"].HeaderText = "رقم الاجازة الشرعية";
                dgvSharias.Columns["Gender"].HeaderText = "النوع";
                dgvSharias.Columns["CountryName"].HeaderText = "الدولة";
                dgvSharias.Columns["CityName"].HeaderText = "المدينة";
                dgvSharias.Columns["SubscriptionTypeName"].HeaderText = "نوع الاشتراك";
                dgvSharias.Columns["SubscriptionWayName"].HeaderText = "طريقة الاشتراك";
                dgvSharias.Columns["IsActive"].HeaderText = "هل فعال ؟";

                lblTotalRecordsCount.Text = dtSharias.Rows.Count.ToString();
            }
        }

        private void _LoadRefreshShariasPerPage()
        {
            // Get the number of pages and show them in the ComoboBox "cbPage"
            if (_mode == enMode.add || _mode == enMode.delete)
                _HandleNumberOfPages();

            // load Sharias data per page and save them in the DataTable "_dtSharias"
            // in case the page number is equal to zero assign null to the DataTable "_dtSharias"
            _dtSharias = _pageNumber > 0 ? clsSharia.GetShariasPerPage(_pageNumber, clsUtil.RowsPerPage) : null;
            _FillDataGridView(_dtSharias);

        }
        private void _HandleNumberOfPages()
        {
            uint totalShariasCount = (uint)clsSharia.Count();

            // Calculate the number of pages depending on "totalShariasCount"
            uint numberOfPages = totalShariasCount > 0 ? (uint)Math.Ceiling((double)totalShariasCount / clsUtil.RowsPerPage) : 0;

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
                    filterColumn = "ShariaID";
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
                case "رقم الاجازة الشرعية":
                    filterColumn = "ShariaLicenseNumber";
                    break;
                default:
                    filterColumn = "None";
                    break;
            }

            //Reset the filters in case nothing selected or filter value contains nothing.
            if (filterValue == string.Empty || filterColumn == "None")
            {
                _dtSharias.DefaultView.RowFilter = string.Empty;
            }
            else
            {

                if (filterColumn == "ShariaID" || filterColumn == "PractitionerID")
                    //in this case we deal with integer not string.
                    _dtSharias.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterColumn, filterValue);
                else
                    _dtSharias.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterColumn, filterValue);
            }

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvSharias.Rows.Count.ToString();
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
        private void _ShowShariaCardForm()
        {
            int ShariaID = (int)dgvSharias.CurrentRow.Cells["ShariaID"].Value;

            frmShariaCard frm = new frmShariaCard(ShariaID, ctrlShariaCard.enWhichID.ShariaID);
            _mode = enMode.update;
            _Subscribe(frm);
            frm.ShowDialog();
        }
        private void _HandleCurrentPage()
        {
            cbPage.SelectedIndex = Convert.ToInt16(_currentPageNumber - 1);
        }
        private void frmShariasList_Load(object sender, EventArgs e)
        {
            //Customize the appearance of the DataGridView
            clsUtil.CustomizeDataGridView(dgvSharias);

            _LoadRefreshShariasPerPage();
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

            if (_dtSharias != null)
            {
                _dtSharias.DefaultView.RowFilter = string.Empty;
                lblTotalRecordsCount.Text = dgvSharias.Rows.Count.ToString();
            }
        }

        private void cbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected page number
            _pageNumber = ushort.TryParse(cbPage.Text, out ushort result) == true ? result : (ushort)0;

            // Load Sharias data from the database and view it in the DataGridView
            _dtSharias = clsSharia.GetShariasPerPage(_pageNumber, clsUtil.RowsPerPage);
            _FillDataGridView(_dtSharias);

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
        private void dgvSharias_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Check if there are any rows and columns in the DataGridView
                if (dgvSharias.Rows.Count == 0 || dgvSharias.Columns.Count == 0)
                {
                    // Suppress the ContextMenuStrip
                    return;
                }

                // Check if the clicked cell is valid
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Show the ContextMenuStrip
                    dgvSharias.CurrentCell = dgvSharias[e.ColumnIndex, e.RowIndex];
                    cmsSharias.Show(Cursor.Position);
                }
            }
        }

        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowShariaCardForm();
        }

        private void activateShariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int shariaID = (int)dgvSharias.CurrentRow.Cells["ShariaID"].Value;

            if (MessageBox.Show($"هل انت متاكد انك تريد تريد تفعيل الحساب رقم {shariaID} ؟", "تاكيد التفعيل", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (clsSharia.Activate(shariaID,(int)clsGlobal.CurrentUser.UserID))
                {
                    MessageBox.Show($"تم تفعيل الحساب بنجاح", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _mode = enMode.delete;
                    _LoadRefreshShariasPerPage();
                }
                else
                    MessageBox.Show($"لم يتم تفعيل الحساب بنجاح بسبب عطل فني في النظام. الرجاء إبلاغ فريق الصيانة", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deactivateShariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ShariaID = (int)dgvSharias.CurrentRow.Cells["ShariaID"].Value;

            if (MessageBox.Show($"هل انت متاكد انك تريد تريد الغاء تفعيل الحساب رقم {ShariaID} ؟", "تاكيد الإلغاء", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (clsSharia.Deactivate(ShariaID, (int)clsGlobal.CurrentUser.UserID))
                {
                    MessageBox.Show($"تم الإلغاء تفعيل الحساب بنجاح", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _mode = enMode.delete;
                    _LoadRefreshShariasPerPage();
                }
                else
                    MessageBox.Show($"لم يتم الإلغاء تفعيل الحساب بنجاح بسبب عطل فني في النظام. الرجاء إبلاغ فريق الصيانة", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        [Obsolete( "it ain't work properly.")]
        private void deleteShariaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int ShariaID = (int)dgvSharias.CurrentRow.Cells["ShariaID"].Value;

            if (MessageBox.Show($"تحذير: سوف يتم حذف الحساب رقم ({ShariaID}) و كل ما يتعلق به. هل ما زلت تريد حذف هذا الحساب؟", "تاكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsSharia.DeletePermanently(ShariaID))
                {
                    MessageBox.Show($"تم حذف الحساب بنجاح", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _mode = enMode.delete;
                    _LoadRefreshShariasPerPage();
                }
                else
                    MessageBox.Show($"لم يتم حذف الحساب بنجاح بسبب عطل فني في النظام. الرجاء إبلاغ فريق الصيانة", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmsSharias_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool isActive = (bool)dgvSharias.CurrentRow.Cells["IsActive"].Value;

            if (isActive)
            {
                activateShariaToolStripMenuItem.Enabled = false;
                deactivateShariaToolStripMenuItem.Enabled = true;
            }
            else
            {
                activateShariaToolStripMenuItem.Enabled = true;
                deactivateShariaToolStripMenuItem.Enabled = false;
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
                _dtSharias.DefaultView.RowFilter = filterValue;
            else
                _dtSharias.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterColumn, filterValue);

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvSharias.Rows.Count.ToString();
        }

        private void dgvSharias_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _ShowShariaCardForm();
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
                _dtSharias.DefaultView.RowFilter = filterValue;
            else
                _dtSharias.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", filterColumn, filterValue);

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvSharias.Rows.Count.ToString();
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
                _dtSharias.DefaultView.RowFilter = filterValue;
            else
                _dtSharias.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", filterColumn, filterValue);

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvSharias.Rows.Count.ToString();
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
