using AADLBusiness;
using AADLBusiness.Judger;
using DVLD.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AADL.Regulators
{
    public partial class frmRegulatorDraft : Form
    {
        private ushort _pageNumber = 0;
        private uint? _currentPageNumber = 1;
        private uint? _totalNumberOfPages = null;
        private DataTable _dtRegulatorsDraft;

        public frmRegulatorDraft()
        {
            InitializeComponent();
        }
        private void _FillDataGridView(DataTable dtRegulatorDraft)
        {
            dgvRegulatorsDraft.DataSource = null;
            try
            {

                if (dtRegulatorDraft != null && dtRegulatorDraft.Rows.Count > 0)
                {
                    dgvRegulatorsDraft.DataSource = dtRegulatorDraft;
                    // Set the DataGridView properties to auto size columns and rows
                    dgvRegulatorsDraft.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dgvRegulatorsDraft.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    //dgvRegulatorsDraft AutoSizeMode for the FullName column to AutoSize
                    //dgvRegulatorsDraft.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvRegulatorsDraft.Columns["RegulatorCasesPractice"].Width = 130;
                    //Change the columns name
                    dgvRegulatorsDraft.Columns["RegulatorID"].HeaderText = "الرقم التعريفي";
                    dgvRegulatorsDraft.Columns["PersonID"].HeaderText = "رقم التعريفي لملف البيانات الشخصية";
                    dgvRegulatorsDraft.Columns["CreatedByUserName"].HeaderText = "تم الانشاء من قبل  ";
                    dgvRegulatorsDraft.Columns["IssueDate"].HeaderText = "تاريخ الانشاء";
                    dgvRegulatorsDraft.Columns["IsActive"].HeaderText = "هل نشط";
                    dgvRegulatorsDraft.Columns["RegulatorCasesPractice"].HeaderText = "القضايا";
                    dgvRegulatorsDraft.Columns["SubscriptionTypeName"].HeaderText = "نوع الاشتراك";
                    dgvRegulatorsDraft.Columns["SubscriptionWayName"].HeaderText = "طريقة الاشتراك";
                    dgvRegulatorsDraft.Columns["IsInBlackList"].HeaderText = "القائمة السوداء";
                    dgvRegulatorsDraft.Columns["IsInWhiteList"].HeaderText = "القائمة البيضاء";
                    dgvRegulatorsDraft.Columns["IsInClosedList"].HeaderText = "القائمة المغلقة";
                    dgvRegulatorsDraft.Columns["LastEditByUserName"].HeaderText = "اخر مستخدم قام بالتحديث";
                    dgvRegulatorsDraft.Columns["UpdatedDateTime"].HeaderText = "تاريخ اخر تحديث";

                    lblTotalRecordsCount.Text = dtRegulatorDraft.Rows.Count.ToString();
                }
            }
            catch (Exception ex) {

                clsHelperClasses.WriteEventToLogFile("Expcetion in regualtor draft list :" + ex.Message,System.Diagnostics.EventLogEntryType.Error);
                Console.WriteLine(ex.Message);
            }
        }

        private void _LoadRefreshRegulatorsPerPage()
        {
            // Get the number of pages and show them in the ComoboBox "cbPage"
                _HandleNumberOfPages();

            // load Regulators data per page and save them in the DataTable "_dtRegulators"
            // in case the page number is equal to zero assign null to the DataTable "_dtRegulators"
            _dtRegulatorsDraft = _pageNumber > 0 ? clsRegulator.GetRegulatorsPerPageDraft(_pageNumber, clsUtil.RowsPerPage) : null;
            _FillDataGridView(_dtRegulatorsDraft);
        }

        private void _HandleNumberOfPages()
        {
            uint totalRegulatorsCount = (uint)clsRegulator.CountDraft();

            // Calculate the number of pages depending on "totalRegulatorsCount"
            uint numberOfPages = totalRegulatorsCount > 0 ? (uint)Math.Ceiling((double)totalRegulatorsCount / clsUtil.RowsPerPage) : 0;

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
                case "اسم المستخدم الذي قام بالتعديل":
                    filterColumn = "LastEditByUserName";
                    break;
                default:
                    filterColumn = "None";
                    break;
            }

            //Reset the filters in case nothing selected or filter value contains nothing.
            if (filterValue == string.Empty || filterColumn == "None")
            {
                _dtRegulatorsDraft.DefaultView.RowFilter = string.Empty;
            }
            else
            {

                if (filterColumn == "RegulatorID" )
                    //in this case we deal with integer not string.
                    _dtRegulatorsDraft.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterColumn, filterValue);
                else
                    _dtRegulatorsDraft.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterColumn, filterValue);
            }

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvRegulatorsDraft.Rows.Count.ToString();
        }
        private void _Settings()
        {
            cbFilterBy.SelectedItem = "لا شيء";
        }
        private void _HandleCurrentPage()
        {
            cbPage.SelectedIndex = Convert.ToInt16(_currentPageNumber - 1);
        }
        private void frmRegulatorDraftList_Load(object sender, EventArgs e)
        {
            //Customize the appearance of the DataGridView
            clsUtil.CustomizeDataGridView(dgvRegulatorsDraft);
            
            _LoadRefreshRegulatorsPerPage();
            _Settings();
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "لا شيء");

             if (txtFilterValue.Visible)
            {
                txtFilterValue.Clear();
                txtFilterValue.Focus();
            }

            if (_dtRegulatorsDraft != null)
            {
                _dtRegulatorsDraft.DefaultView.RowFilter = string.Empty;
                lblTotalRecordsCount.Text = dgvRegulatorsDraft.Rows.Count.ToString();
            }
        }
        private void cbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected page number
            _pageNumber = ushort.TryParse(cbPage.Text, out ushort result) == true ? result : (ushort)0;

            // Load Regulators data from the database and view it in the DataGridView
            _dtRegulatorsDraft = clsRegulator.GetRegulatorsPerPageDraft(_pageNumber, clsUtil.RowsPerPage);
            _FillDataGridView(_dtRegulatorsDraft);

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

        private void btnPreviousPage_Click(object sender,EventArgs e)
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
        private void dgvRegulatorsDraft_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Check if there are any rows and columns in the DataGridView
                if (dgvRegulatorsDraft.Rows.Count == 0 || dgvRegulatorsDraft.Columns.Count == 0)
                {
                    // Suppress the ContextMenuStrip
                    return;
                }

                // Check if the clicked cell is valid
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Show the ContextMenuStrip
                    dgvRegulatorsDraft.CurrentCell = dgvRegulatorsDraft[e.ColumnIndex, e.RowIndex];
                    cmsRegulatorsDraft.Show(Cursor.Position);
                }
            }
        }
        private void dgvRegulatorsDraft_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //_ShowJudgerCardForm();

        }


    }

}
