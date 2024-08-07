using AADLBusiness;
using System;
using System.Windows.Forms;

namespace AADL.Users
{
    public partial class frmPermissions : Form
    {
        private int _newPermissions;
        private int _userId;
        private clsUser _user;
        public frmPermissions(int userId)
        {
            InitializeComponent();
            _userId = userId;
        }

        private void frmPermissions_Load(object sender, EventArgs e)
        {
            _user = clsUser.Find(_userId);
            if(_user is null)
            {
                MessageBox.Show($"لا يوجد مستخدم بالرقم ({_userId}) ؟", "غير موجود", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            ctrPermissions1.CheckUserPermisions(_user.Permissions);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show($"هل انت متاكد انك تريد تعديل صلاحيات المستخدم بالرقم ({_userId}) ؟", "تاكيد العملية", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                _newPermissions = ctrPermissions1.Permissions;

                if (_user.ChangePermissions(_newPermissions))
                {
                    MessageBox.Show($"تم تعديل صلاحيات المستخدم بنجاح", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    if (_user.Id == clsGlobal.CurrentUser.Id)
                        clsGlobal.CurrentUser.Permissions = _newPermissions;
                }
                else
                    MessageBox.Show($"لم يتم تعديل صلاحيات المستخدم بنجاح بسبب عطل فني في النظام. الرجاء إبلاغ فريق الصيانة", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
