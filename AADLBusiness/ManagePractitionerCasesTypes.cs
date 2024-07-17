using AADLBusiness.Expert;
using AADLBusiness.Judger;
using AADLBusiness.Sharia;
using System.Data;

namespace AADLBusiness
{
    public class clsCaseType
    {
        public enum enWhichPractitioner : byte { Regulator = 1, Sharia, Judger, Expert }
        public enum enMode : byte { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;

        public int? ID { get; set; }
        public string Name { get; set; }
        public static enWhichPractitioner WhichPractitioner {  get; set; }

        private static clsRegulatoryCaseType _RegulatorCaseType;
        private static clsShariaCaseType _ShariaCaseType;
        private static clsJudgeCaseType _JudgetorCaseType;
        private static clsExpertCaseType _ExpertCaseType;

        public clsCaseType(enWhichPractitioner whichPractitioner)
        {
            ID = null;
            Name = null;
            WhichPractitioner = whichPractitioner;
            Mode = enMode.AddNew;

            switch(whichPractitioner)
            {
                case enWhichPractitioner.Regulator:
                    _RegulatorCaseType = new clsRegulatoryCaseType();
                    break;
                case enWhichPractitioner.Sharia:
                    _ShariaCaseType = new clsShariaCaseType();
                    break;
                case enWhichPractitioner.Judger:
                    _JudgetorCaseType = new clsJudgeCaseType(); 
                    break;
                case enWhichPractitioner.Expert:
                    _ExpertCaseType = new clsExpertCaseType();
                    break;
            }
        }

        private clsCaseType(int? id, string name, enWhichPractitioner whichPractitioner)
        {
            ID = id;
            Name = name;
            WhichPractitioner = whichPractitioner;

            Mode = enMode.Update;
        }

        private bool _Add()
        {
            bool isAdded = false;
            switch(WhichPractitioner)
            {
                case enWhichPractitioner.Regulator:
                    _RegulatorCaseType = new clsRegulatoryCaseType();
                    _RegulatorCaseType.RegulatoryCaseTypeName = Name;
                    isAdded = _RegulatorCaseType.Save();
                    if(isAdded) this.ID = _RegulatorCaseType.RegulatoryCaseTypeID;
                    return isAdded;

                case enWhichPractitioner.Sharia:
                    _ShariaCaseType = new clsShariaCaseType();
                    _ShariaCaseType.ShariaCaseTypeName = Name;
                    isAdded = _ShariaCaseType.Save();
                    if (isAdded) this.ID = _ShariaCaseType.ShariaCaseTypeID;
                    return isAdded;

                case enWhichPractitioner.Judger:
                    _JudgetorCaseType = new clsJudgeCaseType();
                    _JudgetorCaseType.JudgeCaseTypeName = Name;
                    isAdded = _JudgetorCaseType.Save();
                    if (isAdded) this.ID = _JudgetorCaseType.JudgeCaseTypeID;
                    return isAdded;

            case enWhichPractitioner.Expert:
                    _ExpertCaseType = new clsExpertCaseType();
                    _ExpertCaseType.ExpertCaseTypeName = Name;
                    isAdded = _ExpertCaseType.Save();
                    if (isAdded) this.ID = _ExpertCaseType.ExpertCaseTypeID;
                    return isAdded;

            default:
                    return false;
            }
        }

        private bool _Update()
        {
            switch (WhichPractitioner)
            {
                case enWhichPractitioner.Regulator:
                    _RegulatorCaseType.RegulatoryCaseTypeName = Name;
                    return _RegulatorCaseType.Save();

                case enWhichPractitioner.Sharia:
                    _ShariaCaseType.ShariaCaseTypeName = Name;
                    return _ShariaCaseType.Save();

                case enWhichPractitioner.Judger:
                    _JudgetorCaseType.JudgeCaseTypeName = Name;
                    return _JudgetorCaseType.Save();

                case enWhichPractitioner.Expert:
                    _ExpertCaseType.ExpertCaseTypeName = Name;
                    return _ExpertCaseType.Save();

                default:
                    return false;
            }
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

        public static clsCaseType Find(int ID, enWhichPractitioner whichPractitioner)
        {
            switch (whichPractitioner)
            {
                case enWhichPractitioner.Regulator:
                    _RegulatorCaseType = clsRegulatoryCaseType.Find(ID);
                    return _RegulatorCaseType != null ? new clsCaseType(_RegulatorCaseType.RegulatoryCaseTypeID, _RegulatorCaseType.RegulatoryCaseTypeName, whichPractitioner) : null;

                case enWhichPractitioner.Sharia:
                    _ShariaCaseType = clsShariaCaseType.Find(ID);
                    return _ShariaCaseType != null ? new clsCaseType(_ShariaCaseType.ShariaCaseTypeID, _ShariaCaseType.ShariaCaseTypeName, whichPractitioner) : null;

                case enWhichPractitioner.Judger:
                    _JudgetorCaseType = clsJudgeCaseType.Find(ID);
                    return _JudgetorCaseType != null ? new clsCaseType(_JudgetorCaseType.JudgeCaseTypeID, _JudgetorCaseType.JudgeCaseTypeName, whichPractitioner) : null;

                case enWhichPractitioner.Expert:
                    _ExpertCaseType = clsExpertCaseType.Find(ID);
                    return _ExpertCaseType != null ? new clsCaseType(_ExpertCaseType.ExpertCaseTypeID, _ExpertCaseType.ExpertCaseTypeName, whichPractitioner) : null;

                default:
                    return null;
            }
        }

        public static clsCaseType Find(string name, enWhichPractitioner whichPractitioner)
        {
            switch (whichPractitioner)
            {
                case enWhichPractitioner.Regulator:
                    _RegulatorCaseType = clsRegulatoryCaseType.Find(name);
                    return _RegulatorCaseType != null ? new clsCaseType(_RegulatorCaseType.RegulatoryCaseTypeID, _RegulatorCaseType.RegulatoryCaseTypeName, whichPractitioner) : null;

                case enWhichPractitioner.Sharia:
                    _ShariaCaseType = clsShariaCaseType.Find(name);
                    return _ShariaCaseType != null ? new clsCaseType(_ShariaCaseType.ShariaCaseTypeID, _ShariaCaseType.ShariaCaseTypeName, whichPractitioner) : null;

                case enWhichPractitioner.Judger:
                    _JudgetorCaseType = clsJudgeCaseType.Find(name);
                    return _JudgetorCaseType != null ? new clsCaseType(_JudgetorCaseType.JudgeCaseTypeID, _JudgetorCaseType.JudgeCaseTypeName, whichPractitioner) : null;

                case enWhichPractitioner.Expert:
                    _ExpertCaseType = clsExpertCaseType.Find(name);
                    return _ExpertCaseType != null ? new clsCaseType(_ExpertCaseType.ExpertCaseTypeID, _ExpertCaseType.ExpertCaseTypeName, whichPractitioner) : null;

                default:
                    return null;
            }
        }

        public static bool Delete(int ID, enWhichPractitioner whichPractitioner)
        {
            switch (whichPractitioner)
            {
                case enWhichPractitioner.Regulator:
                    return clsRegulatoryCaseType.Delete(ID);

                case enWhichPractitioner.Sharia:
                    return clsShariaCaseType.Delete(ID);

                case enWhichPractitioner.Judger:
                    return clsJudgeCaseType.Delete(ID);

                case enWhichPractitioner.Expert:
                    return clsExpertCaseType.Delete(ID);

                default:
                    return false;
            }
        }

        public static bool Exists(string name, enWhichPractitioner whichPractitioner)
        {
            switch (whichPractitioner)
            {
                case enWhichPractitioner.Regulator:
                    return clsRegulatoryCaseType.Exists(name);

                case enWhichPractitioner.Sharia:
                    return clsShariaCaseType.Exists(name);

                case enWhichPractitioner.Judger:
                    return clsJudgeCaseType.Exists(name);

                case enWhichPractitioner.Expert:
                    return clsExpertCaseType.Exists(name);

                default:
                    return false;
            }
        }

        public static DataTable All(enWhichPractitioner whichPractitioner)
        {
            DataTable dt = new DataTable();
            switch (whichPractitioner)
            {
                case enWhichPractitioner.Regulator:
                    dt = clsRegulatoryCaseType.All();
                    break;
                case enWhichPractitioner.Sharia:
                    dt = clsShariaCaseType.All();
                    break;
                case enWhichPractitioner.Judger:
                    dt =  clsJudgeCaseType.All();
                    break;
                case enWhichPractitioner.Expert:
                    dt =  clsExpertCaseType.All();
                    break;
                default:
                    return null;
            }

            if(dt != null &&  dt.Rows.Count > 0)
            {
                dt.Columns[0].ColumnName = "ID";
                dt.Columns[1].ColumnName = "Name";
            }

            return dt;
        }
    }
}
