using AADLBusiness;
using AADLBusiness.Sharia;
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

namespace AADL.Sharia
{
    public partial class frmShariaDraft : Form
    {
        private enum enMode { add, update, delete }
        private enMode _mode = enMode.add;

        private DataTable _dtShariasDraft;
        private ushort _pageNumber = 0;
        private uint? _currentPageNumber = 1;
        private uint? _totalNumberOfPages = null;
        public frmShariaDraft()
        {
            InitializeComponent();
        }
        private void _FillDataGridView(DataTable dtShariaDraft)
        {
            dgvShariasDraft.DataSource = null;
            try
            {

                if (dtShariaDraft != null && dtShariaDraft.Rows.Count > 0)
                {
                    dgvShariasDraft.DataSource = dtShariaDraft;
                    // Set the DataGridView properties to auto size columns and rows
                    dgvShariasDraft.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    dgvShariasDraft.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                    //dgvShariasDraft AutoSizeMode for the FullName column to AutoSize
                    //dgvShariasDraft.Columns["FullName"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dgvShariasDraft.Columns["ShariaCasesPractice"].Width = 130;
                    //Change the columns name
                    dgvShariasDraft.Columns["ShariaID"].HeaderText = "الرقم التعريفي";
                    dgvShariasDraft.Columns["ShariaLicenseNumber"].HeaderText = "رقم الاجازة الشرعية";
                    dgvShariasDraft.Columns["PersonID"].HeaderText = "رقم التعريفي لملف البيانات الشخصية";
                    dgvShariasDraft.Columns["CreatedByUserName"].HeaderText = "تم الانشاء من قبل  ";
                    dgvShariasDraft.Columns["IssueDate"].HeaderText = "تاريخ الانشاء";
                    dgvShariasDraft.Columns["IsActive"].HeaderText = "هل نشط";
                    dgvShariasDraft.Columns["ShariaCasesPractice"].HeaderText = "القضايا";
                    dgvShariasDraft.Columns["SubscriptionTypeName"].HeaderText = "نوع الاشتراك";
                    dgvShariasDraft.Columns["SubscriptionWayName"].HeaderText = "طريقة الاشتراك";
                    dgvShariasDraft.Columns["IsInBlackList"].HeaderText = "القائمة السوداء";
                    dgvShariasDraft.Columns["IsInWhiteList"].HeaderText = "القائمة البيضاء";
                    dgvShariasDraft.Columns["IsInClosedList"].HeaderText = "القائمة المغلقة";
                    dgvShariasDraft.Columns["LastEditByUserName"].HeaderText = "اخر مستخدم قام بالتحديث";
                    dgvShariasDraft.Columns["UpdatedDateTime"].HeaderText = "تاريخ اخر تحديث";

                    lblTotalRecordsCount.Text = dtShariaDraft.Rows.Count.ToString();
                }
            }
            catch (Exception ex)
            {

                clsHelperClasses.WriteEventToLogFile("Expcetion in regualtor draft list :" + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                Console.WriteLine(ex.Message);
            }
        }

        private void _LoadRefreshShariasPerPage()
        {
            // Get the number of pages and show them in the ComoboBox "cbPage"
            _HandleNumberOfPages();

            // load Sharias data per page and save them in the DataTable "_dtSharias"
            // in case the page number is equal to zero assign null to the DataTable "_dtSharias"
            _dtShariasDraft = _pageNumber > 0 ? clsSharia.GetShariasPerPageDraft(_pageNumber, clsUtil.RowsPerPage) : null;
            _FillDataGridView(_dtShariasDraft);
        }

        private void _HandleNumberOfPages()
        {
            uint totalShariasCount = (uint)clsSharia.CountDraft();

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
                _dtShariasDraft.DefaultView.RowFilter = string.Empty;
                }
                 else
                 {
                if (filterColumn == "ShariaID")
                    //in this case we deal with integer not string.
                    _dtShariasDraft.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterColumn, filterValue);
                else
                    _dtShariasDraft.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterColumn, filterValue);
                 }

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvShariasDraft.Rows.Count.ToString();
        }
        private void _Settings()
        {
            cbFilterBy.SelectedItem = "لا شيء";
        }
        private void _HandleCurrentPage()
        {
            cbPage.SelectedIndex = Convert.ToInt16(_currentPageNumber - 1);
        }
        private void frmShariaDraftList_Load(object sender, EventArgs e)
        {
            //Customize the appearance of the DataGridView
            clsUtil.CustomizeDataGridView(dgvShariasDraft);

            _LoadRefreshShariasPerPage();
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

            if (_dtShariasDraft != null)
            {
                _dtShariasDraft.DefaultView.RowFilter = string.Empty;
                lblTotalRecordsCount.Text = dgvShariasDraft.Rows.Count.ToString();
            }
        }
        private void cbPage_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected page number
            _pageNumber = ushort.TryParse(cbPage.Text, out ushort result) == true ? result : (ushort)0;

            // Load Sharias data from the database and view it in the DataGridView
            _dtShariasDraft = clsSharia.GetShariasPerPageDraft(_pageNumber, clsUtil.RowsPerPage);
            _FillDataGridView(_dtShariasDraft);

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
        private void dgvShariasDraft_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Check if there are any rows and columns in the DataGridView
                if (dgvShariasDraft.Rows.Count == 0 || dgvShariasDraft.Columns.Count == 0)
                {
                    // Suppress the ContextMenuStrip
                    return;
                }

                // Check if the clicked cell is valid
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Show the ContextMenuStrip
                    dgvShariasDraft.CurrentCell = dgvShariasDraft[e.ColumnIndex, e.RowIndex];
                    cmsShariasDraft.Show(Cursor.Position);
                }
            }
        }
        private void dgvShariasDraft_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //_ShowJudgerCardForm();

        }

    }
}
