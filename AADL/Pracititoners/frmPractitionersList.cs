using AADL.Judgers;
using AADL.Pracititoners;
using AADLBusiness;
using AADLBusiness.Judger;
using DVLD.Classes;
using myControlLibrary;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace AADL.Regulators
{
    public partial class frmPractitionersList : Form
    {

        private void _Subscribe(frmAddUpdatePractitioner form) 
        {

            form.evPractitionerUpdated += _Reset;

        }


        public frmPractitionersList()
        {
            InitializeComponent();
        }
        private void _Reset(object sender, EventArgs e)
        {
            frmPractitionersList_Load(null, null);

        }

        private void _UpdateColumnsWidth()
        {
            clsUtil.CustomizeDataGridView(dgvPractitioners);

            //if (dgvPractitioners.Rows.Count > 0)
            //{
            //    dgvPractitioners.Columns["الرقم التعريفي"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["الاسم الكامل"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["الهاتف"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["البريد الالكتروني"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["محامي"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["نوع الاشتراك"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["طريقة الاشتراك"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["رقم العضوية"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["الاجازة الشرعية"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["نظامي فعال"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["شرعي فعال"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["محكم فعال"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["خبير فعال"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["قام بأنشاء الملف النظامي"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["قام بأنشاء الملف الشرعي"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["قام بأنشاء ملف المحكم"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["قام بأنشاء ملف الخبير"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["تاريخ انشاء الملف للنظامي"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["تاريخ انشاء الملف للشرعي"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["تاريخ انشاء الملف للمحكم"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["تاريخ انشاء الملف للخبير"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["القائمة السوداء"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["القائمة البيضاء للنظامين"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["القائمة المغلقة للنظامين"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["القائمة البيضاء للشرعين"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["القائمة المغلقة للشرعين"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["القائمة البيضاء للمحكمين"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["القائمة المغلقة للمحكمين"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["القائمة البيضاء للخبراء"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //    dgvPractitioners.Columns["القائمة المغلقة للخبراء"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;


            //}
        }

        private void _LoadDataTableToGridViewControl(DataTable PractitionerDataTable)
        {
            if (PractitionerDataTable != null && PractitionerDataTable.Rows.Count > 0)
            {

                dgvPractitioners.DataSource = PractitionerDataTable;
                dgvPractitioners.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                cbFilterBy.SelectedIndex = 0;
                _UpdateColumnsWidth();
            }
            else
            {
                dgvPractitioners.DataSource = null;// Clear all rows

                dgvPractitioners.Refresh();    // Refresh the DataGridView display
            }
            lblRecordsCount.Text = dgvPractitioners.Rows.Count.ToString();


        }
        private void frmPractitionersList_Load(object sender, EventArgs e)
        {
            _LoadDataTableToGridViewControl(clsPractitionerServices.GetAllPractitionersInfo());

        }

        private DataTable GetAllSubscriptionsTypes()
        {
            return clsSubscriptionType.GetAllSubscriptionTypes();
        }

        private void AddIsActiveTypesToComboBox()
        {

            cbIsActiveSubscription.Items.Add("الكل");

            cbIsActiveSubscription.Items.Add("نعم");
            cbIsActiveSubscription.Items.Add("لا");

        }
        private bool AddSubscriptionsTypesToComboBox()
        {

            try
            {

                DataTable dtSubscriptionTypes = GetAllSubscriptionsTypes();

                cbIsActiveSubscription.DataSource = dtSubscriptionTypes;
                cbIsActiveSubscription.DisplayMember = "SubscriptionTypeName";
            }
            catch (Exception ex)
            {

                clsHelperClasses.WriteEventToLogFile("You need to review your clsRegulatorsList ,AddSubscriptionsTypesToComboBox() ",
                    System.Diagnostics.EventLogEntryType.Error);
                Console.WriteLine(ex.Message);
                MessageBox.Show("هناك خطاء فني ما حدث انثاء تحميل انواع الاشتراكات ", "Failed",
              MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;

            }

            return true;

        }
        private void HandleComboBoxFilterBy()
        {
            ctbFilterValue.Visible = false;
            cbIsActiveSubscription.DataSource = null;

            if (cbFilterBy.Text == "هل فعال")
            {
                AddIsActiveTypesToComboBox();

            }

            else if (cbFilterBy.Text == "نوع الاشتراك")
            {
                AddSubscriptionsTypesToComboBox();
            }

            cbIsActiveSubscription.Visible = true;
            cbIsActiveSubscription.Focus();
            cbIsActiveSubscription.SelectedIndex = 0;

        }
        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number in-case user id is selected.
            if (cbFilterBy.SelectedIndex == 1 || cbFilterBy.SelectedIndex == 3)
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFilterBy.Text == "هل فعال" || cbFilterBy.Text == "نوع الاشتراك")
            {
                HandleComboBoxFilterBy();

            }

            else
            {

                ctbFilterValue.Visible = (cbFilterBy.Text != "لا شئ");
                cbIsActiveSubscription.Visible = false;

                if (cbFilterBy.Text == "None")
                {
                    ctbFilterValue.Enabled = false;
                }
                else
                    ctbFilterValue.Enabled = true;

                ctbFilterValue.Text = "";
                ctbFilterValue.Focus();
            }

        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cbFilterBy.SelectedIndex)
            {

                case 0:
                    {
                        FilterColumn = "لا شئ";
                        break;
                    }

                case 1:
                    {

                        FilterColumn = "الرقم التعريفي";
                        break;
                    }

                case 2:
                    {

                        FilterColumn = "الاسم الكامل";
                        break;
                    }


                case 3:
                    {

                        FilterColumn = "رقم الهاتف";
                        break;

                    }
                case 4:
                    {
                        FilterColumn = "البريد الالكتروني";
                        break;
                    }

                case 5:
                    {

                        FilterColumn = "رقم العضوية";
                        break;

                    }

                case 6:
                    {

                        FilterColumn = "نوع الاشتراك";
                        break;
                    }

                case 7:
                    {

                        FilterColumn = "تم الانشاء من قبل";
                        break;
                    }

                case 8:
                    {
                        FilterColumn = "هل فعال";
                        break;
                    }

                default:
                    FilterColumn = "None";
                    break;

            }
            DataTable dataTableAllPractitioners = new DataTable();
            //Reset the filters in case nothing selected or filter value conains nothing.
            if (ctbFilterValue.Text.Trim() == "" || FilterColumn == "None")
            {
                dataTableAllPractitioners.DefaultView.RowFilter = "";
                lblRecordsCount.Text = dgvPractitioners.Rows.Count.ToString();
                return;
            }


            if (FilterColumn != "الاسم الكامل" && FilterColumn != "البريد الالكتروني" && FilterColumn != "تم الانشاء من قبل"
                && FilterColumn != "رقم العضوية")
                //in this case we deal with numbers not string.
                dataTableAllPractitioners.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, ctbFilterValue.Text.Trim());
            else
                dataTableAllPractitioners.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, ctbFilterValue.Text.Trim());

            lblRecordsCount.Text = dataTableAllPractitioners.Rows.Count.ToString();

        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {

            string FilterColumn = "";
            string FilterValue = "";

            if (cbFilterBy.SelectedIndex == 6)
            {
                FilterColumn = "نوع الاشتراك";
                FilterValue = cbIsActiveSubscription.Text;
            }
            else if (cbFilterBy.SelectedIndex == 8)
            {
                FilterColumn = "هل فعال";
                FilterValue = cbIsActiveSubscription.Text;
            }

            //switch (FilterValue)
            //{
            //    case "الكل":
            //        break;
            //    case "نعم":
            //        FilterValue = 1;
            //        break;
            //    case "لا":
            //        FilterValue = "0";
            //        break;
            //}
            DataTable dataTableAllPractitioners = new DataTable();


            if (FilterValue == "الكل")
                dataTableAllPractitioners.DefaultView.RowFilter = "";
            else
            {
                //in this case we deal with numbers not string.
                //_dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, FilterValue);

                dataTableAllPractitioners.DefaultView.RowFilter = string.Format("[{0}] = '{1}'", FilterColumn, FilterValue);
            }

            lblRecordsCount.Text = dataTableAllPractitioners.Rows.Count.ToString();


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmAddUpdatePractitioner frmAddUpdatePractitioner = new frmAddUpdatePractitioner();
            frmAddUpdatePractitioner.evNewPractitionerAdded += _evNewPractitionerWasAddedUpdateYourSelf;
            frmAddUpdatePractitioner.ShowDialog();
        }
        private void _evNewPractitionerWasAddedUpdateYourSelf(object sender, EventArgs e)
        {
            frmPractitionersList_Load(sender, e);
        }
        private void lblTitle_Click(object sender, EventArgs e)
        {

        }

        private void AdvancePractitionerPropertiesQuery(AdvancedSearchPractitionerProperties PractitionerProperties)
        {
            try
            {

                DataTable AdvancedPractitionerQueryDataTable = clsPractitionerServices.Find(PractitionerProperties);
                _LoadDataTableToGridViewControl(AdvancedPractitionerQueryDataTable);
            }
            catch (Exception ex)
            {

                clsHelperClasses.WriteEventToLogFile("A problem in loading filter data of practitioner by advanced query:\n" +
                    ex.Message, System.Diagnostics.EventLogEntryType.Warning);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            frmAdvancedSearch frmAdvancedSearch = new frmAdvancedSearch();
            frmAdvancedSearch.SelectedPractitionerProperties += AdvancePractitionerPropertiesQuery;
            frmAdvancedSearch.ShowDialog();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _Reset(null,null);
        }

       
        private void تعديلToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int practitionerID = (int)dgvPractitioners.CurrentRow.Cells["PractitionerID"].Value;

            frmAddUpdatePractitioner form = new frmAddUpdatePractitioner(practitionerID);
            _Subscribe(form);
            form.ShowDialog();
        }

        private void حذفToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int practitionerID = (int)dgvPractitioners.CurrentRow.Cells["PractitionerID"].Value;

            if (MessageBox.Show($"تحذير: سوف يتم حذف الحساب رقم ({practitionerID}) و كل ما يتعلق به. هل ما زلت تريد حذف هذا الحساب؟", "تاكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsJudger.DeletePermanently(practitionerID))
                {
                    MessageBox.Show($"تم حذف الحساب بنجاح", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _Reset(null, null);
                }
                else
                    MessageBox.Show($"لم يتم حذف الحساب بنجاح بسبب عطل فني في النظام. الرجاء إبلاغ فريق الصيانة", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
