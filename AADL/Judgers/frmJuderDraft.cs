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

namespace AADL.Judgers
{
    public partial class frmJuderDraft : Form
    {
        public frmJuderDraft()
        {
            InitializeComponent();
        }
        private ushort _pageNumber = 0;
        private uint? _currentPageNumber = 1;
        private uint? _totalNumberOfPages = null;
        private DataTable _dtJudgersDraft;

        private void _FillDataGridView(DataTable dtJudgerDraft)
        {
            dgvJudgersDraft.DataSource = null;
            try
            {

                if (dtJudgerDraft != null && dtJudgerDraft.Rows.Count > 0)
                {
                    dgvJudgersDraft.DataSource = dtJudgerDraft;
                    // Set the DataGridView properties to auto size columns and rows
                    dgvJudgersDraft.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dgvJudgersDraft.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    //dgvJudgersDraft AutoSizeMode for the FullName column to AutoSize
                    //dgvJudgersDraft.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvJudgersDraft.Columns["JudgerCasesPractice"].Width = 130;
                    //Change the columns name
                    dgvJudgersDraft.Columns["JudgerID"].HeaderText = "الرقم التعريفي";
                    dgvJudgersDraft.Columns["PersonID"].HeaderText = "رقم التعريفي لملف البيانات الشخصية";
                    dgvJudgersDraft.Columns["CreatedByUserName"].HeaderText = "تم الانشاء من قبل  ";
                    dgvJudgersDraft.Columns["IssueDate"].HeaderText = "تاريخ الانشاء";
                    dgvJudgersDraft.Columns["IsActive"].HeaderText = "هل نشط";
                    dgvJudgersDraft.Columns["JudgerCasesPractice"].HeaderText = "القضايا";
                    dgvJudgersDraft.Columns["SubscriptionTypeName"].HeaderText = "نوع الاشتراك";
                    dgvJudgersDraft.Columns["SubscriptionWayName"].HeaderText = "طريقة الاشتراك";
                    dgvJudgersDraft.Columns["IsInBlackList"].HeaderText = "القائمة السوداء";
                    dgvJudgersDraft.Columns["IsInWhiteList"].HeaderText = "القائمة البيضاء";
                    dgvJudgersDraft.Columns["IsInClosedList"].HeaderText = "القائمة المغلقة";
                    dgvJudgersDraft.Columns["LastEditByUserName"].HeaderText = "اخر مستخدم قام بالتحديث";
                    dgvJudgersDraft.Columns["UpdatedDateTime"].HeaderText = "تاريخ اخر تحديث";

                    lblTotalRecordsCount.Text = dtJudgerDraft.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {

                clsHelperClasses.WriteEventToLogFile("Expcetion in regualtor draft list :" + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                Console.WriteLine(ex.Message);
            }
        }

        private void _LoadRefreshJudgersPerPage()
        {
            // Get the number of pages and show them in the ComoboBox "cbPage"
            _HandleNumberOfPages();

            // load Judgers data per page and save them in the DataTable "_dtJudgers"
            // in case the page number is equal to zero assign null to the DataTable "_dtJudgers"
            _dtJudgersDraft = _pageNumber > 0 ? clsJudger.GetJudgersPerPageDraft(_pageNumber, clsUtil.RowsPerPage) : null;
            _FillDataGridView(_dtJudgersDraft);
        }

        private void _HandleNumberOfPages()
        {
            uint totalJudgersCount = (uint)clsJudger.CountDraft();

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
                _dtJudgersDraft.DefaultView.RowFilter = string.Empty;
            }
            else
            {

                if (filterColumn == "JudgerID")
                    //in this case we deal with integer not string.
                    _dtJudgersDraft.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterColumn, filterValue);
                else
                    _dtJudgersDraft.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterColumn, filterValue);
            }

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvJudgersDraft.Rows.Count.ToString();
        }
        private void _Settings()
        {
            cbFilterBy.SelectedItem = "لا شيء";
        }
        private void _HandleCurrentPage()
        {
            cbPage.SelectedIndex = Convert.ToInt16(_currentPageNumber - 1);
        }
        private void frmJudgerDraftList_Load(object sender, EventArgs e)
        {
            //Customize the appearance of the DataGridView
            clsUtil.CustomizeDataGridView(dgvJudgersDraft);

            _LoadRefreshJudgersPerPage();
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

            if (_dtJudgersDraft != null)
            {
                _dtJudgersDraft.DefaultView.RowFilter = string.Empty;
                lblTotalRecordsCount.Text = dgvJudgersDraft.Rows.Count.ToString();
            }
        }
        private void cbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected page number
            _pageNumber = ushort.TryParse(cbPage.Text, out ushort result) == true ? result : (ushort)0;

            // Load Judgers data from the database and view it in the DataGridView
            _dtJudgersDraft = clsJudger.GetJudgersPerPageDraft(_pageNumber, clsUtil.RowsPerPage);
            _FillDataGridView(_dtJudgersDraft);

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
    }
}
