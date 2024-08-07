using AADLBusiness;
using System;
using System.Windows.Forms;

namespace AADL.Users
{
    public partial class frmAddNewUser : Form
    {
        public event Action UserAdded;

        protected virtual void OnUserAdded()
        {
            UserAdded?.Invoke();
        }

        private clsUser _user;
        private int _permissions = 0;

        public frmAddNewUser()
        {
            InitializeComponent();
        }

        private void _fillUserObject()
        {
            _permissions = ctrPermissions1.Permissions;

            _user = new clsUser();
            _user.UserName = txtUserName.Text.Trim();
            _user.Password = txtPassword.Text.Trim();
            _user.IssueDate = DateTime.Now;
            _user.Permissions = _permissions;
            _user.IsActive = chkIsActive.Checked;
            _user.CreatedByUserId = clsGlobal.CurrentUser?.Id ?? null;
        }

        private bool _validateEmptyFields(TextBox textBox)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                errorProvider1.SetError(textBox, "هذا الحقل مطلوب");
                return false;
            }
            else
            {
                errorProvider1.SetError(textBox, null);
                return true;
            }
        }

        private bool _isPasswordMath()
        {
            if (txtPassword.Text.Trim() != txtConfirmPassword.Text.Trim())
            {
                errorProvider1.SetError(txtConfirmPassword, "تأكيد كلمة المرور لا يتطابق مع كلمة المرور الجديدة");

                return false;
            }
            else
            {
                errorProvider1.SetError(txtConfirmPassword, null);

                return true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                _validateEmptyFields(txtUserName);
                _validateEmptyFields(txtPassword);
                _validateEmptyFields(txtConfirmPassword);
                return;
            }

            if(clsUser.Exists(txtUserName.Text.Trim()))
            {
                MessageBox.Show("يوجد مستخدم بنفس الاسم. الرجاء ادخال اسم مختلف", "اسم متطابق", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtUserName.Focus();
                return;
            }

            if(!_isPasswordMath())
                return;

            _fillUserObject();

            // incase of no permssions has been added yet
            if (_permissions == 0)
            {
                if (MessageBox.Show("هل تريد اضافة هذا المستخدم من غير صلاحيات؟", "تبنيه بعدم اعطاء صلاحيات", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    tpUser.SelectTab("tpPermissions");
                    return;
                }
            }

            if(MessageBox.Show("هل انت متاكد انك تريد اضافة مستخدم جديد؟", "تاكيد العملية", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if(_user.Save())
                {
                    MessageBox.Show($"({_user.Id}) تمت اضافة المستخدم بناح بالرقم التعريفي", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblUserId.Text = _user.Id.ToString();
                    btnSave.Enabled = false;
                    //btnPermissions.Enabled = false;

                    OnUserAdded(); // tirgger the event
                }
                else
                {
                    MessageBox.Show("حدث عطل فني في النظام اثناء حفظ البيانات. الرجاء ابلاغ فريق الصيانة", "عطل فني في النظام", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //this.Close();
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmAddNewUser_Load(object sender, EventArgs e)
        {
            txtUserName.Focus();
        }
    }
}
