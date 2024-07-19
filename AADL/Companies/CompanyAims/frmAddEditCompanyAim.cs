using AADLBusiness;
using System;
using System.Windows.Forms;

namespace AADL.Companies.CompanyAims
{
    public partial class frmAddEditCompanyAim : Form
    {
        public event Action CompanyAimEdited;
        public event Action CompanyAimAdded;

        protected virtual void OnAimAdded()
            => CompanyAimAdded?.Invoke();

        protected virtual void OnAimEdited()
            => CompanyAimEdited?.Invoke();

        public enum enMode { Add, Update }
        public enMode _mode;
        private int _Id;
        private clsCompanyAim _companyAim;
        private string _title = string.Empty;

        public frmAddEditCompanyAim()
        {
            InitializeComponent();
            _mode = enMode.Add;
        }

        public frmAddEditCompanyAim(int id)
        {
            InitializeComponent();
            _Id = id;
            _mode = enMode.Update;
        }

        private void _LoadData()
        {
            if (_mode == enMode.Add)
                _title = "اضافة هدف لشركة";

            if (_mode == enMode.Update)
            {
                _title = "تعديل هدف لشركة";

                // load case type data
                _companyAim = clsCompanyAim.Find(_Id);

                if (_companyAim == null)
                {
                    MessageBox.Show("حدث عطل فني في النظام اثناء تحميل بيانات هدف الشركة. الرجاء ابلاغ فريق الصيانة", "عطل فني في النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();
                    return;
                }

                lblAimID.Text = _Id.ToString();
                txtName.Text = _companyAim.Name;
            }

            this.Text = _title;
            lblTitle.Text = _title;
            txtName.Focus();
        }

        private void _FillCompanyAimObject()
        {
            if (_mode == enMode.Add)
            {
                _companyAim = new clsCompanyAim();
            }

            _companyAim.Name = txtName.Text.Trim();
        }

        private void _Settings()
        {
            _mode = enMode.Update;
            lblAimID.Text = _companyAim.Id.ToString();
            _title = "تعديل هدف لشركة";
            this.Text = _title;
            lblTitle.Text = _title;
            txtName.Focus();
        }

        private void frmAddEditCompanyAim_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // validate provided data
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("يجب ادخال اسم الهدف", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // check if case type already exists
            if (_mode == enMode.Add && clsCompanyAim.Exists(txtName.Text.Trim()))
            {
                MessageBox.Show("يوجد نوع قضية بنفس الاسم. الرجاء ادخال اسم مختلف", "خطاء", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"هل انت متاكد انك تريد {_title}؟", "تاكيد العملية", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _FillCompanyAimObject();

                if (_mode == enMode.Add)
                {
                    if (_companyAim.Save())
                    {
                        MessageBox.Show($"تمت اضافة اسم الهدف بنجاح.", "تمت العملية بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OnAimAdded();
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
                    if (_companyAim.Save())
                    {
                        MessageBox.Show($"تم تعديل اسم الهدف بنجاح", "تمت العملية بنجاح", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        OnAimEdited();
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
