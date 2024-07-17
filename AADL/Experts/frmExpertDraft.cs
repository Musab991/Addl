using AADLBusiness.Expert;
using AADLBusiness;
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

namespace AADL.Experts
{
    public partial class frmExpertDraft : Form
    {
        private ushort _pageNumber = 0;
        private uint? _currentPageNumber = 1;
        private uint? _totalNumberOfPages = null;
        private DataTable _dtExpertsDraft;
        public frmExpertDraft()
        {
            InitializeComponent();
        }

        private void _FillDataGridView(DataTable dtExpertDraft)
        {
            dgvExpertsDraft.DataSource = null;
            try
            {

                if (dtExpertDraft != null && dtExpertDraft.Rows.Count > 0)
                {
                    dgvExpertsDraft.DataSource = dtExpertDraft;
                    // Set the DataGridView properties to auto size columns and rows
                    dgvExpertsDraft.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dgvExpertsDraft.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    //dgvExpertsDraft AutoSizeMode for the FullName column to AutoSize
                    //dgvExpertsDraft.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvExpertsDraft.Columns["ExpertCasesPractice"].Width = 130;
                    //Change the columns name
                    dgvExpertsDraft.Columns["ExpertID"].HeaderText = "الرقم التعريفي";
                    dgvExpertsDraft.Columns["PersonID"].HeaderText = "رقم التعريفي لملف البيانات الشخصية";
                    dgvExpertsDraft.Columns["CreatedByUserName"].HeaderText = "تم الانشاء من قبل  ";
                    dgvExpertsDraft.Columns["IssueDate"].HeaderText = "تاريخ الانشاء";
                    dgvExpertsDraft.Columns["IsActive"].HeaderText = "هل نشط";
                    dgvExpertsDraft.Columns["ExpertCasesPractice"].HeaderText = "القضايا";
                    dgvExpertsDraft.Columns["SubscriptionTypeName"].HeaderText = "نوع الاشتراك";
                    dgvExpertsDraft.Columns["SubscriptionWayName"].HeaderText = "طريقة الاشتراك";
                    dgvExpertsDraft.Columns["IsInBlackList"].HeaderText = "القائمة السوداء";
                    dgvExpertsDraft.Columns["IsInWhiteList"].HeaderText = "القائمة البيضاء";
                    dgvExpertsDraft.Columns["IsInClosedList"].HeaderText = "القائمة المغلقة";
                    dgvExpertsDraft.Columns["LastEditByUserName"].HeaderText = "اخر مستخدم قام بالتحديث";
                    dgvExpertsDraft.Columns["UpdatedDateTime"].HeaderText = "تاريخ اخر تحديث";

                    lblTotalRecordsCount.Text = dtExpertDraft.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {

                clsHelperClasses.WriteEventToLogFile("Expcetion in regualtor draft list :" + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                Console.WriteLine(ex.Message);
            }
        }

        private void _LoadRefreshExpertsPerPage()
        {
            // Get the number of pages and show them in the ComoboBox "cbPage"
            _HandleNumberOfPages();

            // load Experts data per page and save them in the DataTable "_dtExperts"
            // in case the page number is equal to zero assign null to the DataTable "_dtExperts"
            _dtExpertsDraft = _pageNumber > 0 ? clsExpert.GetExpertsPerPageDraft(_pageNumber, clsUtil.RowsPerPage) : null;
            _FillDataGridView(_dtExpertsDraft);
        }

        private void _HandleNumberOfPages()
        {
            uint totalExpertsCount = (uint)clsExpert.CountDraft();

            // Calculate the number of pages depending on "totalExpertsCount"
            uint numberOfPages = totalExpertsCount > 0 ? (uint)Math.Ceiling((double)totalExpertsCount / clsUtil.RowsPerPage) : 0;

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
                    filterColumn = "ExpertID";
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
                _dtExpertsDraft.DefaultView.RowFilter = string.Empty;
            }
            else
            {

                if (filterColumn == "ExpertID")
                    //in this case we deal with integer not string.
                    _dtExpertsDraft.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterColumn, filterValue);
                else
                    _dtExpertsDraft.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterColumn, filterValue);
            }

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvExpertsDraft.Rows.Count.ToString();
        }
        private void _Settings()
        {
            cbFilterBy.SelectedItem = "لا شيء";
        }
        private void _HandleCurrentPage()
        {
            cbPage.SelectedIndex = Convert.ToInt16(_currentPageNumber - 1);
        }
        private void frmExpertDraftList_Load(object sender, EventArgs e)
        {
            //Customize the appearance of the DataGridView
            clsUtil.CustomizeDataGridView(dgvExpertsDraft);

            _LoadRefreshExpertsPerPage();
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

            if (_dtExpertsDraft != null)
            {
                _dtExpertsDraft.DefaultView.RowFilter = string.Empty;
                lblTotalRecordsCount.Text = dgvExpertsDraft.Rows.Count.ToString();
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
