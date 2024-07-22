using AADLBusiness;
using System;
using System.Windows.Forms;

namespace AADL.Reasons
{
    public partial class frmAddEditReason : Form
    {
        public event Action ReasonEdited;
        public event Action ReasonAdded;

        protected virtual void OnReasonAdded()
        {
            ReasonAdded?.Invoke();
        }

        protected virtual void OnReasonEdited()
        {
            ReasonEdited?.Invoke();
        }

        public enum enMode { Add, Update }
        private int _reasonID;
        private string _title = string.Empty;
        private enMode _mode;
        private clsReason _reason;
        private clsReason.enCompanyOrPractitioner _companyOrPractitioner;
        private clsReason.enWhichListType _whichListType;

        public frmAddEditReason(clsReason.enCompanyOrPractitioner companyOrPractitioner, clsReason.enWhichListType whichListType)
        {
            InitializeComponent();
            _companyOrPractitioner = companyOrPractitioner;
            _whichListType = whichListType;
            _mode = enMode.Add;
        }

        public frmAddEditReason(int reasonId, clsReason.enCompanyOrPractitioner companyOrPractitioner, clsReason.enWhichListType whichListType)
        {
            InitializeComponent();
            _companyOrPractitioner = companyOrPractitioner;
            _whichListType = whichListType;
            _reasonID = reasonId;
            _mode = enMode.Update;
        }

        private void _LoadData()
        {
            _HandleTitle();

            if (_mode == enMode.Update)
            {
                // load reason type data
                _reason = clsReason.Find(_reasonID, _companyOrPractitioner, _whichListType);

                if (_reason == null)
                {
                    MessageBox.Show("حدث عطل فني في النظام اثناء تحميل البيانات. الرجاء ابلاغ فريق الصيانة", "عطل فني في النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                lblReasonID.Text = _reasonID.ToString();
                txtReasonName.Text = _reason.Name;
            }

            txtReasonName.Focus();
        }

        private void _FillReasonTypeObject()
        {
            if (_mode == enMode.Add)
            {
                _reason = new clsReason(_companyOrPractitioner, _whichListType);
            }

            _reason.Name = txtReasonName.Text.Trim();
        }

        private void _Settings()
        {
            _mode = enMode.Update;
            lblReasonID.Text = _reason.Id.ToString();
            _HandleTitle();
            txtReasonName.Focus();
        }

        private void _HandleTitle()
        {

            string whichList = _whichListType == clsReason.enWhichListType.Black
                ? "السوداء" : (_whichListType == clsReason.enWhichListType.White ? "البيضاء" : "المغلقة");

            if (_mode == enMode.Add)
                _title = $"اضافة سبب للقائمة {whichList}";

            if (_mode == enMode.Update)
                _title = $"تعديل سبب للقائمة {whichList}";

            this.Text = _title;
            lblTitle.Text = _title;
        }

        private void frmAddEditReason_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // validate provided data
            if (string.IsNullOrWhiteSpace(txtReasonName.Text))
            {
                MessageBox.Show("يجب ادخال السبب", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // check if case type already exists
            if (_mode == enMode.Add && clsReason.Exists(txtReasonName.Text.Trim(), _companyOrPractitioner, _whichListType))
            {
                MessageBox.Show("يوجد سبب بنفس الاسم. الرجاء ادخال اسم مختلف", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"هل انت متاكد انك تريد {_title}؟", "تاكيد العملية", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _FillReasonTypeObject();

                if (_mode == enMode.Add)
                {
                    if (_reason.Save())
                    {
                        MessageBox.Show($"تمت اضافة السبب بنجاح.", "تمت العملية بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OnReasonAdded();
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
                    if (_reason.Save())
                    {
                        MessageBox.Show($"تم تعديل السبب بنجاح", "تمت العملية بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OnReasonEdited();
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
