using AADLBusiness;
using System;
using System.Windows.Forms;

namespace AADL.Cases
{
    public partial class frmAddEditCaseType : Form
    {
        public event Action CaseTypeEdited;
        public event Action CaseTypeAdded;

        protected virtual void OnCaseAdded()
        {
            CaseTypeAdded?.Invoke();
        }

        protected virtual void OnCaseEdited()
        {
            CaseTypeEdited?.Invoke();
        }

        public enum enMode { Add, Update}
        private int _caseID;
        private string _title = string.Empty;
        private enMode _mode;
        private clsCaseType _caseType;
        private clsCaseType.enWhichPractitioner _whichPractitioner;

        public frmAddEditCaseType(clsCaseType.enWhichPractitioner whichPractitioner)
        {
            InitializeComponent();
            _whichPractitioner = whichPractitioner;
            _mode = enMode.Add;
        }

        public frmAddEditCaseType(int caseID, clsCaseType.enWhichPractitioner whichPractitioner)
        {
            InitializeComponent();
            _caseID = caseID;
            _whichPractitioner = whichPractitioner;
            _mode = enMode.Update;
        }

        private void _LoadData()
        {
            if (_mode == enMode.Add)
            {
                _title = "اضافة نوع قضية";
            }

            if(_mode == enMode.Update)
            {
                _title = "تعديل نوع قضية";

                // load case type data
                _caseType = clsCaseType.Find(_caseID, _whichPractitioner);

                if(_caseType == null) 
                {
                    MessageBox.Show("حدث عطل فني في النظام اثناء تحميل بيانات نوع القضية. الرجاء ابلاغ فريق الصيانة", "عطل فني في النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                lblCaseID.Text = _caseID.ToString();
                txtCaseName.Text = _caseType.Name;
            }

            this.Text = _title;
            lblTitle.Text = _title;
            txtCaseName.Focus();
        }

        private void _FillCaseTypeOblect()
        {
            if (_mode == enMode.Add)
            {
                _caseType = new clsCaseType(_whichPractitioner);
                _caseType.CreatedByAdminID = clsGlobal.CurrentAdmin.AdminID ?? 2;
            }

            _caseType.Name = txtCaseName.Text.Trim();
        }

        private void _Settings()
        {
            _mode = enMode.Update;
            lblCaseID.Text = _caseType.ID.ToString();
            _title = "تعديل نوع قضية";
            this.Text = _title;
            lblTitle.Text = _title;
            txtCaseName.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddEditCaseType_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // validate provided data
            if(string.IsNullOrWhiteSpace(txtCaseName.Text))
            {
                MessageBox.Show("يجب ادخال نوع القضية", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // check if case type already exists
            if (_mode == enMode.Add && clsCaseType.Exists(txtCaseName.Text.Trim(), _whichPractitioner))
            {
                MessageBox.Show("يوجد نوع قضية بنفس الاسم. الرجاء ادخال اسم مختلف", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"هل انت متاكد انك تريد {_title}؟", "تاكيد العملية", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _FillCaseTypeOblect();

                if(_mode == enMode.Add)
                {
                    if(_caseType.Save())
                    {
                        MessageBox.Show($"تمت اضافة نوع القضية بنجاح.", "تمت العملية بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OnCaseAdded();
                        _Settings();
                    }
                    else
                    {
                        MessageBox.Show("حدث عطل فني في النظام اثناء حفظ البيانات. الرجاء ابلاغ فريق الصيانة", "عطل فني في النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        return;
                    }
                }
                else
                {
                    if (_caseType.Save())
                    {
                        MessageBox.Show($"تم تعديل نوع القضية بنجاح", "تمت العملية بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OnCaseEdited();
                    }
                    else
                    {
                        MessageBox.Show("حدث عطل فني في النظام اثناء تعديل البيانات. الرجاء ابلاغ فريق الصيانة", "عطل فني في النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.Close();
                        return;
                    }
                }
            }
        }
    }
}
