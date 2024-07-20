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

        public clsExpertCaseType()
        {
            ExpertCaseTypeID = null;
            ExpertCaseTypeName = string.Empty;

            Mode = enMode.AddNew;
        }

        private clsExpertCaseType(int? expertCaseTypeID, string expertCaseTypeName)
        {
            ExpertCaseTypeID = expertCaseTypeID;
            ExpertCaseTypeName = expertCaseTypeName;

            Mode = enMode.Update;
        }

        private bool _Add()
        {
            ExpertCaseTypeID = clsExpertCaseTypeData.Add(ExpertCaseTypeName);

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

            bool isFound = clsExpertCaseTypeData.GetInfoByCaseTypeID(expertCaseTypeID, ref expertCaseTypeName);

            return (isFound) ? (new clsExpertCaseType(expertCaseTypeID, expertCaseTypeName)) : null;
        }

        public static clsExpertCaseType Find(string expertCaseTypeName)
        {
            int? expertCaseTypeID = null;

            bool isFound = clsExpertCaseTypeData.GetInfoByCaseTypeName(expertCaseTypeName,  ref expertCaseTypeID);

            return (isFound) ? (new clsExpertCaseType(expertCaseTypeID, expertCaseTypeName)) : null;
        }

        public static bool Delete(int expertCaseTypeID)
            => clsExpertCaseTypeData.Delete(expertCaseTypeID);

        public static bool Exists(string name)
            => clsExpertCaseTypeData.Exists(name);

        public static DataTable All()
            => clsExpertCaseTypeData.All();
    }
}