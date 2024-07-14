using AADLDataAccess;
using AADLDataAccess.Expert;
using System.Data;

namespace AADLBusiness.Expert
{
    public class clsExpertCaseType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? ExpertCaseTypeID { get; set; }
        public string ExpertCaseTypeName { get; set; }
        public int? CreatedByAdminID { get; set; }

        public clsExpertCaseType()
        {
            ExpertCaseTypeID = null;
            ExpertCaseTypeName = string.Empty;
            CreatedByAdminID = null;

            Mode = enMode.AddNew;
        }

        private clsExpertCaseType(int? expertCaseTypeID,
            string expertCaseTypeName, int? createdByAdminID)
        {
            ExpertCaseTypeID = expertCaseTypeID;
            ExpertCaseTypeName = expertCaseTypeName;
            CreatedByAdminID = createdByAdminID;

            Mode = enMode.Update;
        }

        private bool _Add()
        {
            ExpertCaseTypeID = clsExpertCaseTypeData.Add(ExpertCaseTypeName, CreatedByAdminID.Value);

            return (ExpertCaseTypeID.HasValue);
        }

        private bool _Update()
        {
            return clsExpertCaseTypeData.Update((int)ExpertCaseTypeID, ExpertCaseTypeName);
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_Add())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _Update();
            }

            return false;
        }

        public static clsExpertCaseType Find(int? expertCaseTypeID)
        {
            string expertCaseTypeName = string.Empty;
            int? createdByAdminID = null;

            bool isFound = clsExpertCaseTypeData.GetInfoByCaseTypeID(expertCaseTypeID,
                ref expertCaseTypeName, ref createdByAdminID);

            return (isFound) ? (new clsExpertCaseType(expertCaseTypeID, expertCaseTypeName, createdByAdminID)) : null;
        }

        public static clsExpertCaseType Find(string expertCaseTypeName)
        {
            int? expertCaseTypeID = null;
            int? createdByAdminID = null;

            bool isFound = clsExpertCaseTypeData.GetInfoByCaseTypeName(expertCaseTypeName,
                ref expertCaseTypeID, ref createdByAdminID);

            return (isFound) ? (new clsExpertCaseType(expertCaseTypeID,
                expertCaseTypeName, createdByAdminID)) : null;
        }

        public static bool Delete(int expertCaseTypeID)
            => clsExpertCaseTypeData.Delete(expertCaseTypeID);

        public static bool Exists(string name)
            => clsExpertCaseTypeData.Exists(name);

        public static DataTable All()
            => clsExpertCaseTypeData.All();
    }
}