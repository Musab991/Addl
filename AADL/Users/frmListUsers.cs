using AADLBusiness;
using AADLBusiness.Permissions;
using DVLD.Classes;
using System;
using System.Data;
using System.Windows.Forms;

namespace AADL.Users
{
    public partial class frmListUsers : Form
    {
        private void _OnUserAdded() => _LoadRefreshUsers();

        private void _Subscribe(frmAddNewUser frm) => frm.UserAdded += _OnUserAdded;


        private static DataTable _dtUsers;

        public frmListUsers()
        {
            InitializeComponent();
        }

        private void _FillDataGridView(DataTable dtUsers)
        {
            dgvUsers.DataSource = null;
            if (dtUsers != null && dtUsers.Rows.Count > 0)
            {
                dgvUsers.DataSource = dtUsers;

                //Change the columns name
                dgvUsers.Columns["UserId"].HeaderText = "الرقم التعريفي";
                dgvUsers.Columns["UserName"].HeaderText = "الاسم";
                dgvUsers.Columns["IssueDate"].HeaderText = "تاريخ الانشاء";
                dgvUsers.Columns["CreatedByUser"].HeaderText = "تم الانشاء من قبل";
                dgvUsers.Columns["IsActive"].HeaderText = "هل فعال ؟";

                lblTotalRecordsCount.Text = dtUsers.Rows.Count.ToString();
            }
        }

        private void _LoadRefreshUsers()
        {
            _dtUsers = clsUser.All();
            _FillDataGridView(_dtUsers);
        }

        private void _Settings()
        {
            cbFilterBy.SelectedItem = "لا شيء";
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
                    filterColumn = "UserId";
                    break;
                case "الاسم":
                    filterColumn = "UserName";
                    break;
                case "من قام بالانشاء":
                    filterColumn = "CreatedByUser";
                    break;
                case "هل فعال ؟":
                    filterColumn = "IsActive";
                    break;
                default:
                    filterColumn = "None";
                    break;
            }

            //Reset the filters in case nothing selected or filter value contains nothing.
            if (filterValue == string.Empty || filterColumn == "None")
            {
                _dtUsers.DefaultView.RowFilter = string.Empty;
            }
            else
            {

                if (filterColumn == "UserId")
                    //in this case we deal with integer not string.
                    _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterColumn, filterValue);
                else
                    _dtUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterColumn, filterValue);
            }

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvUsers.Rows.Count.ToString();
        }

        private void _ShowUserInfoForm()
        {
            int judgerID = (int)dgvUsers.CurrentRow.Cells["UserId"].Value;

            frmUserInfo frm = new frmUserInfo(judgerID);
            frm.ShowDialog();
        }

        private void frmListUsers_Load(object sender, EventArgs e)
        {
            // Cusomize the appearance of the DataGridView
            clsUtil.CustomizeDataGridView(dgvUsers);
            _LoadRefreshUsers();
            _Settings();
        }

        private void txtFilterValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "الرقم التعريفي")
                clsUtil.IsNumber(e);
        }

        private void dgvUsers_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                // Check if there are any rows and columns in the DataGridView
                if (dgvUsers.Rows.Count == 0 || dgvUsers.Columns.Count == 0)
                {
                    // Suppress the ContextMenuStrip
                    return;
                }

                // Check if the clicked cell is valid
                if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
                {
                    // Show the ContextMenuStrip
                    dgvUsers.CurrentCell = dgvUsers[e.ColumnIndex, e.RowIndex];
                    cmsUsers.Show(Cursor.Position);
                }
            }
        }

        private void cbIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filterColumn = "IsActive";
            string filterValue = string.Empty;

            // Map Selected Filter to real Column name 
            switch (cbIsActive.Text)
            {
                case "الكل":
                    filterValue = string.Empty;
                    break;
                case "نعم":
                    filterValue = "1";
                    break;
                case "لا":
                    filterValue = "0";
                    break;
                default:
                    filterValue = string.Empty;
                    break;
            }

            if (filterValue == string.Empty)
                _dtUsers.DefaultView.RowFilter = filterValue;
            else
                _dtUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", filterColumn, filterValue);

            // Updates the total records count label
            lblTotalRecordsCount.Text = dgvUsers.Rows.Count.ToString();
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {
            _Filter();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtFilterValue.Visible = (cbFilterBy.Text != "لا شيء" && cbFilterBy.Text != "هل فعال ؟");

            cbIsActive.Visible = cbFilterBy.Text == "هل فعال ؟";

            if (cbIsActive.Visible)
                cbIsActive.SelectedItem = "الكل";

            else if (txtFilterValue.Visible)
            {
                txtFilterValue.Clear();
                txtFilterValue.Focus();
            }

            if (_dtUsers != null)
            {
                _dtUsers.DefaultView.RowFilter = string.Empty;
                lblTotalRecordsCount.Text = dgvUsers.Rows.Count.ToString();
            }
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            if (!clsUtil.HasAccess(enPermission.AddUser))
                return;

            frmAddNewUser frm = new frmAddNewUser();
            _Subscribe(frm);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsUtil.HasAccess(enPermission.UpdateUser))
                return;

            int userId = (int)dgvUsers.CurrentRow.Cells["UserId"].Value;
            frmChangeUserPassword frm = new frmChangeUserPassword(userId);
            frm.ShowDialog();
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsUtil.HasAccess(enPermission.DeleteUser))
                return;

            int userId = (int)dgvUsers.CurrentRow.Cells["UserId"].Value;
            if (MessageBox.Show($"هل انت متاكد انك تريد حذف حساب المستخدم بالرقم ({userId}) ؟", "تاكيد الحذف", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (clsUser.Delete(userId))
                {
                    MessageBox.Show($"تم حذف الحساب بنجاح", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _LoadRefreshUsers();
                }
                else
                    MessageBox.Show($"لم يتم حذف الحساب بنجاح بسبب عطل فني في النظام. الرجاء إبلاغ فريق الصيانة", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void activateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsUtil.HasAccess(enPermission.UpdateUser))
                return;

            int userID = (int)dgvUsers.CurrentRow.Cells["UserId"].Value;

            if (MessageBox.Show($"هل انت متاكد انك تريد تريد تفعيل الحساب رقم {userID} ؟", "تاكيد التفعيل", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (clsUser.Activate(userID))
                {
                    MessageBox.Show($"تم تفعيل الحساب بنجاح", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    _LoadRefreshUsers();
                }
                else
                    MessageBox.Show($"لم يتم تفعيل الحساب بسبب عطل فني في النظام. الرجاء إبلاغ فريق الصيانة", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deactivateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsUtil.HasAccess(enPermission.UpdateUser))
                return;

            int userID = (int)dgvUsers.CurrentRow.Cells["UserId"].Value;

            if (MessageBox.Show($"هل انت متاكد انك تريد تريد إلغاء تفعيل الحساب رقم {userID} ؟", "تاكيد إلغاء التفعيل", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                if (clsUser.Deactivate(userID))
                {
                    MessageBox.Show($"تم إلغاء تفعيل الحساب بنجاح", "نجحت العملية", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _LoadRefreshUsers();
                }
                else
                    MessageBox.Show($"لم يتم إلغاء تفعيل الحساب بسبب عطل فني في النظام. الرجاء إبلاغ فريق الصيانة", "فشلت العملية", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmsUsers_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool isActive = (bool)dgvUsers.CurrentRow.Cells["IsActive"].Value;

            if (isActive)
            {
                activateUserToolStripMenuItem.Enabled = false;
                deactivateUserToolStripMenuItem.Enabled = true;
            }
            else
            {
                activateUserToolStripMenuItem.Enabled = true;
                deactivateUserToolStripMenuItem.Enabled = false;
            }
        }

        private void showInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ShowUserInfoForm();
        }

        private void dgvUsers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            _ShowUserInfoForm();
        }

        private void changePermissionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!clsUtil.HasAccess(enPermission.UpdateUser))
                return;

            int userID = (int)dgvUsers.CurrentRow.Cells["UserId"].Value;
            frmPermissions frm = new frmPermissions(userID);
            frm.ShowDialog();
        }
    }
}
