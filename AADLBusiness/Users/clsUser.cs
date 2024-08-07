using AADLBusiness.Permissions;
using System;
using System.Data;
using System.Threading.Tasks;

namespace AADLBusiness
{
    public class clsUser
    {
        public enum enMode { add, update }
        public enMode Mode { get; set; }

        public int? Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }
        public DateTime IssueDate { get; set; }
        public int Permissions { get; set; }
        public int? CreatedByUserId { get; set; }

        public clsUser()
        {
            Mode = enMode.add;
        }

        private clsUser(int id, string userName, string password, bool isActive, DateTime issueDate, int permissions, int? createdByUserId)
        {
            Id = id;
            UserName = userName;
            Password = password;
            IsActive = isActive;
            IssueDate = issueDate;
            Permissions = permissions;
            CreatedByUserId = createdByUserId;
            Mode = enMode.update;
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.add:
                    if (_Add())
                    {
                        this.Mode = enMode.update;
                        return true;
                    }
                    return false;

                case enMode.update:
                    return this._Update();

                default:
                    return false;
            }
        }

        public static clsUser Find(int id)
        {
            string userName = string.Empty;
            string password = string.Empty;
            bool isActive = false;
            DateTime issueDate = DateTime.MinValue;
            int permissions = 0;
            int? createdByUserId = null;

            if (clsUserData.GetUserInfoByID(id, ref userName, ref password, ref isActive, ref issueDate, ref permissions, ref createdByUserId))
            {
                return new clsUser(id, userName, password, isActive, issueDate, permissions, createdByUserId);
            }

            return null;
        }

        public static clsUser Find(string userName, string password)
        {
            int userId = 0;
            bool isActive = false;
            DateTime issueDate = DateTime.MinValue;
            int permissions = 0;
            int? createdByUserId = null;

            if (clsUserData.GetUserInfoByCredentials(userName, password, ref userId, ref isActive, ref issueDate, ref permissions, ref createdByUserId))
            {
                return new clsUser(userId, userName, password, isActive, issueDate, permissions, createdByUserId);
            }

            return null;
        }

        public static bool Delete(int id)
            => clsUserData.Delete(id);

        public static bool Exists(int userId)
            => clsUserData.Exsits(userId);

        public static bool Exists(string userName)
            => clsUserData.Exists(userName);

        public static bool Exists(string userName, string password)
            => clsUserData.Exists(userName, password);

        public static bool Activate(int userId)
            => clsUserData.Activate(userId);

        public static bool Deactivate(int userId)
            => clsUserData.Deactivate(userId);

        public static async Task<DataTable> GetAllUsers()
            => await clsUserData.GetAllUsers();

        public static DataTable All()
            => clsUserData.All();

        public bool ChangeUserName(string newUserName)
        {
            if (Mode == enMode.update && Id.HasValue)
            {
                return clsUserData.ChangeUserName(Id.Value, newUserName);
            }
            return false;
        }

        public bool ChangePassword(string newPassword)
        {
            if (Mode == enMode.update && Id.HasValue)
            {
                return clsUserData.ChangePassword(Id.Value, newPassword);
            }
            return false;
        }

        public bool ChangePermissions(int newPermissions)
        {
            if (Mode == enMode.update && Id.HasValue)
            {
                return clsUserData.ChangePermissions(Id.Value, newPermissions);
            }
            return false;
        }

        public bool HasPermission(enPermission permission)
            => HasPermission(permission, this.Permissions);

        public static bool HasPermission(enPermission permission, int userPermissions)
        {
            if (userPermissions == (int)enPermission.Admen)
                return true;

            return ((int)permission & userPermissions) == (int)permission;
        }

        private bool _Add()
        {
            this.Id = clsUserData.AddNew(UserName, Password, IsActive, IssueDate, Permissions, CreatedByUserId);
            return this.Id.HasValue;
        }

        private bool _Update()
            => clsUserData.Update(Id.Value, UserName, Password, IsActive, Permissions);
    }
}