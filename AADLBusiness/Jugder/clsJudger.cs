using AADLBusiness;
using AADLBusiness.Lists.Closed;
using AADLBusiness.Lists.WhiteList;
using AADLDataAccess.Judger;
using AADLDataAccess.Judger;
using System;
using System.Collections.Generic;
using System.Data;

namespace AADLBusiness.Judger
{
    public class clsJudger : clsPractitioner
    {
        public clsJudger()
        {
            JudgerID = -1;
            PersonID = -1;
            IssueDate = DateTime.MinValue;
            LastEditDate = null;
            LastEditByUserID = null;
            SubscriptionTypeID = -1;
            CreatedByUserID = -1;
            IsActive = false;
            UserInfo = null;
            _JudgeCasesPracticeIDNameDictionary = new Dictionary<int, string>();
            Mode = enMode.AddNew;
        }

        private clsJudger(int JudgerID, int PractitionerID, int PersonID, bool IsLawyer, int SubscriptionTypeID, int SubscriptionWayID, DateTime IssueDate,
            DateTime? LastEditDate, int? LastEditByUserID, int CreatedByUserID, bool IsActive, Dictionary<int, string> JudgerCasesPracticeIDNameDictionary)
        {
            try
            {
                this.JudgerID = JudgerID;
                this.PersonID = PersonID;
                this.SelectedPersonInfo = clsPerson.Find(PersonID, clsPerson.enSearchBy.PersonID);
                this.PractitionerID = PractitionerID;
                this.IsLawyer = IsLawyer;
                this.SubscriptionTypeID = SubscriptionTypeID;
                this.SubscriptionTypeInfo = clsSubscriptionType.Find(SubscriptionTypeID);
                this.SubscriptionWayID = SubscriptionWayID;
                this.SubscriptionWayInfo = clsSubscriptionWay.Find(SubscriptionWayID);
                this.IssueDate = IssueDate;
                this.LastEditDate = LastEditDate;
                this.LastEditByUserID = LastEditByUserID;
                if (this.LastEditByUserID != null) this.LastEditByUserInfo = clsUser.FindByUserID(this.LastEditByUserID);
                this.CreatedByUserID = CreatedByUserID;
                this.UserInfo = clsUser.FindByUserID(this.CreatedByUserID);
                this.IsActive = IsActive;
                this._JudgeCasesPracticeIDNameDictionary = JudgerCasesPracticeIDNameDictionary;

                this.Mode = enMode.Update;
            }
            catch (Exception ex)
            {
                clsHelperClasses.WriteEventToLogFile($"Problem happens in construction Judger object: {ex.Message}", System.Diagnostics.EventLogEntryType.Error);
            }
        }

        public int JudgerID { get; set; }

        private Dictionary<int, string> _JudgeCasesPracticeIDNameDictionary;

        public Dictionary<int, string> JudgeCasesPracticeIDNameDictionary
        {
            get
            {
                return _JudgeCasesPracticeIDNameDictionary;
            }
            set
            {

                _JudgeCasesPracticeIDNameDictionary = value;
            }
        }

        public override clsSubscriptionType SubscriptionTypeInfo { get; }

        public override clsSubscriptionWay SubscriptionWayInfo { get; }

        public override clsUser UserInfo { get; }

        public override clsUser LastEditByUserInfo { get; }

        public override clsPerson SelectedPersonInfo { get; }

        public static clsJudger FindByJudgerID(int JudgerID)
        {
            int PractitionerID = -1, PersonID = -1, SubscriptionTypeID = -1, SubscriptionWayID = -1, CreatedByUserID = -1;
            int? LastEditByUserID = null;
            DateTime IssueDate = DateTime.MinValue;
            DateTime? LastEditDate = null;
            bool IsActive = false, IsLawyer = false;
            Dictionary<int, string> CasesJudgerPracticesIDNameDictionary = new Dictionary<int, string>();

            if (clsJudgerData.GetJudgerInfoByJudgerID(JudgerID, ref PractitionerID, ref PersonID, ref IsLawyer, ref IssueDate, ref SubscriptionTypeID,
                ref SubscriptionWayID, ref CreatedByUserID, ref IsActive, ref LastEditByUserID, ref CasesJudgerPracticesIDNameDictionary))
            {
                return new clsJudger(JudgerID, PractitionerID, PersonID, IsLawyer, SubscriptionTypeID, SubscriptionWayID, IssueDate,
                    LastEditDate, LastEditByUserID, CreatedByUserID, IsActive, CasesJudgerPracticesIDNameDictionary);
            }

            return null;
        }

        public static clsJudger FindByPersonID(int PersonID)
        {
            int PractitionerID = -1, JudgerID = -1, SubscriptionTypeID = -1, SubscriptionWayID = -1, CreatedByUserID = -1;
            int? LastEditByUserID = null;
            DateTime IssueDate = DateTime.MinValue;
            DateTime? LastEditDate = null;
            bool IsActive = false, IsLawyer = false;
            Dictionary<int, string> CasesJudgerPracticesIDNameDictionary = new Dictionary<int, string>();

            if (clsJudgerData.GetJudgerInfoByPersonID(PersonID, ref JudgerID, ref PractitionerID, ref IsLawyer, ref IssueDate, ref SubscriptionTypeID,
                ref SubscriptionWayID, ref CreatedByUserID, ref IsActive, ref LastEditByUserID, ref CasesJudgerPracticesIDNameDictionary))
            {
                return new clsJudger(JudgerID, PractitionerID, PersonID, IsLawyer, SubscriptionTypeID, SubscriptionWayID, IssueDate,
                    LastEditDate, LastEditByUserID, CreatedByUserID, IsActive, CasesJudgerPracticesIDNameDictionary);
            }

            return null;
        }

        public static clsJudger FindByPractitionerID(int PractitionerID)
        {
            int PersonID = -1, JudgerID = -1, SubscriptionTypeID = -1, SubscriptionWayID = -1, CreatedByUserID = -1;
            int? LastEditByUserID = null;
            DateTime IssueDate = DateTime.MinValue;
            DateTime? LastEditDate = null;
            bool IsActive = false, IsLawyer = false;
            Dictionary<int, string> CasesJudgerPracticesIDNameDictionary = new Dictionary<int, string>();

            if (clsJudgerData.GetJudgerInfoByPractitionerID(PractitionerID, ref JudgerID, ref PersonID, ref IsLawyer, ref IssueDate, ref SubscriptionTypeID,
                ref SubscriptionWayID, ref CreatedByUserID, ref IsActive, ref LastEditByUserID, ref CasesJudgerPracticesIDNameDictionary))
            {
                return new clsJudger(JudgerID, PractitionerID, PersonID, IsLawyer, SubscriptionTypeID, SubscriptionWayID, IssueDate,
                    LastEditDate, LastEditByUserID, CreatedByUserID, IsActive, CasesJudgerPracticesIDNameDictionary);
            }

            return null;
        }

        public static bool IsJudgerExistByJudgerID(int JudgerID)
        {
            return clsJudgerData.IsJudgerExist(JudgerID, clsJudgerData.enWhichID.JudgerID);
        }

        public static bool IsJudgerExistByPersonID(int PersonID)
        {
            return clsJudgerData.IsJudgerExist(PersonID, clsJudgerData.enWhichID.PersonID);
        }

        public static bool IsJudgerExistByPractitionerID(int PractitionerID)=>
            clsJudgerData.IsJudgerExist(PractitionerID, clsJudgerData.enWhichID.PractitionerID);

        public bool IsJudgerInWhiteList()
        {
            //Data access , set the right type of practitioner 
            return clsWhiteList.IsPractitionerInWhiteList(this.PractitionerID, clsPractitioner.enPractitionerType.Judger);
        }
        public bool IsJudgerInClosedList()
        {
            //Data access , set the right type of practitioner 
            return clsClosedList.IsPractitionerInClosedList(this.PractitionerID, clsPractitioner.enPractitionerType.Judger);
        }

        public static bool DeletePermanently(int JudgerID)
            => clsJudgerData.DeletePermanently(JudgerID);
        public static bool Deactivate(int JudgerID, int LastEditByUserID)
             => clsJudgerData.Deactivate(JudgerID, LastEditByUserID);
        public static bool Activate(int JudgerID, int LastEditByUserID)
            => clsJudgerData.Activate(JudgerID, LastEditByUserID);
        public static int Count()
            => clsJudgerData.Count();
        public static int CountDraft()
           => clsJudgerData.Count(true);

        public static DataTable GetJudgersPerPage(ushort pageNumber, uint rowsPerPage)
            => clsJudgerData.GetJudgersPerPage(pageNumber, rowsPerPage);

        public static DataTable GetJudgersPerPageDraft(ushort pageNumber, uint rowsPerPage)
         => clsJudgerData.GetJudgersPerPage(pageNumber, rowsPerPage, true);

        public override bool Save()
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
                default:
                    return false;
            }
        }

        protected override bool _AddNew()
        {
            (this.JudgerID, this.PractitionerID) = clsJudgerData.AddNewJudger(PersonID, SubscriptionTypeID, SubscriptionWayID, CreatedByUserID,
                                                                                    IsActive, JudgeCasesPracticeIDNameDictionary);

            return this.JudgerID != -1;
        }

        protected override bool _Update()
        {
            return clsJudgerData.UpdateJudger(JudgerID, PractitionerID, SubscriptionTypeID, SubscriptionWayID, IsActive, LastEditByUserID, JudgeCasesPracticeIDNameDictionary);
        }
   
    }
}

