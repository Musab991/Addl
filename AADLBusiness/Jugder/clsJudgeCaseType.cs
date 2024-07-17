using System.Data;
using AADLBusiness;
using AADLDataAccess;
using AADLDataAccess.Judger;

namespace AADLBusiness.Judger
{
    public class clsJudgeCaseType
    {

        public enum enMode { AddNew = 0, Update = 1 };

        public enMode Mode = enMode.AddNew;

        public int? JudgeCaseTypeID { get; set; }
        public string JudgeCaseTypeName { get; set; }

        public clsJudgeCaseType()
        {
            this.JudgeCaseTypeID = -1;
            this.JudgeCaseTypeName = null;

            Mode = enMode.AddNew;
        }

        private clsJudgeCaseType(int JudgeCaseTypeID, string JudgeCaseTypeName)
        {
            this.JudgeCaseTypeID = JudgeCaseTypeID;
            this.JudgeCaseTypeName = JudgeCaseTypeName;

            Mode = enMode.Update;
        }

        public static clsJudgeCaseType Find(int JudgeCaseTypeID)
        {
            string JudgeCaseTypeName = "";

            if (clsJudgeCaseTypeData.GetJudgeCaseTypeInfoByCaseTypeID(JudgeCaseTypeID, ref JudgeCaseTypeName))
                return new clsJudgeCaseType(JudgeCaseTypeID, JudgeCaseTypeName);
            else
                return null;
        }

        public static clsJudgeCaseType Find(string JudgeCaseTypeName)
        {
            int JudgeCaseTypeID = -1;

            if (clsJudgeCaseTypeData.GetJudgeCaseTypeInfoByCaseTypeName(JudgeCaseTypeName, ref JudgeCaseTypeID))
                return new clsJudgeCaseType(JudgeCaseTypeID, JudgeCaseTypeName);
            else
                return null;
        }

        public static bool Delete(int JudgeCaseTypeID)
            => clsJudgeCaseTypeData.Delete(JudgeCaseTypeID);

        public static bool Exists(string name)
            => clsJudgeCaseTypeData.Exists(name);

        public static DataTable All()
        {
            return clsJudgeCaseTypeData.All();
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNew())
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

        private bool _AddNew()
        {
            this.JudgeCaseTypeID = clsJudgeCaseTypeData.Add(this.JudgeCaseTypeName);

            return (this.JudgeCaseTypeID.HasValue);
        }

        private bool _Update()
        {
            return clsJudgeCaseTypeData.Update((int)this.JudgeCaseTypeID, this.JudgeCaseTypeName);
        }

    }

}
