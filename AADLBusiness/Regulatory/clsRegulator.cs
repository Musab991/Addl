using AADLBusiness;
using AADLDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using static AADLBusiness.clsPerson;
using AADLBusiness.Lists.WhiteList;
using AADLBusiness.Lists.Closed;

namespace AADLBusiness
{
    public class clsRegulator:clsPractitioner
    {
        public enum enSearchBy { PersonID, RegulatorID, MembershipNumber, PractitionerID};
        public int RegulatorID { set; get; }
        public string MembershipNumber { set; get; }
 
        private Dictionary<int,string>_RegulatorCasesPracticeIDNameDictionary;

        public Dictionary<int, string> RegulatorCasesPracticeIDNameDictionary
        {
            get
            {
                return _RegulatorCasesPracticeIDNameDictionary;
            }
            set
            {
                
                _RegulatorCasesPracticeIDNameDictionary = value;
            }
        }
        public override clsUser UserInfo { get; }
        public override clsUser LastEditByUserInfo { get; }
        public override clsPerson SelectedPersonInfo { get;  }
        public override clsSubscriptionType SubscriptionTypeInfo { get; }
        public override clsSubscriptionWay SubscriptionWayInfo { get; }

        // Snapshot of the initial state
        private clsRegulator initialState;

        public clsRegulator()
        {
            this.RegulatorID = -1;
            this.PersonID = -1;
            this.MembershipNumber = "";
            this.IsLawyer = true;
            this.IssueDate = DateTime.MinValue;
            this.LastEditDate = null;
            this.CreatedByUserID = -1;
            this.IsActive = false;
            UserInfo = null;
            Mode = enMode.AddNew;
            _RegulatorCasesPracticeIDNameDictionary = new Dictionary<int, string>();

        }

        private clsRegulator(int PractitionerID,int PersonID,bool IsLawyer,int SubscriptionTypeID,int SubscriptionWayID,
            int RegulatorID,   string MembershipNumber, DateTime IssueDate,
            DateTime? LastEditDate, int ?LastEditByUserID, int CreatedByUserID, bool IsActive,
            Dictionary<int, string> RegulatorCasesPracticeIDNameDictionary)
        {
            this.PractitionerID = PractitionerID;
            this.PersonID = PersonID;
            this.SelectedPersonInfo = clsPerson.Find(PersonID, clsPerson.enSearchBy.PersonID);
            this.IsLawyer = IsLawyer;
            this.SubscriptionTypeID = SubscriptionTypeID;
            this.SubscriptionWayID = SubscriptionWayID;
            this.SubscriptionTypeInfo = clsSubscriptionType.Find(SubscriptionTypeID);
            this.SubscriptionWayInfo = clsSubscriptionWay.Find(SubscriptionWayID);
            this.RegulatorID = RegulatorID;
            this.MembershipNumber = MembershipNumber;
            this.IssueDate = IssueDate;
            this.LastEditDate = LastEditDate;
            this.LastEditByUserID = LastEditByUserID;
            this.CreatedByUserID = CreatedByUserID;
            this.IsActive = IsActive;
            _RegulatorCasesPracticeIDNameDictionary = RegulatorCasesPracticeIDNameDictionary;
            UserInfo = clsUser.FindByUserID(CreatedByUserID);
            SelectedPersonInfo = clsPerson.Find(PersonID, clsPerson.enSearchBy.PersonID);
            LastEditByUserInfo=clsUser.FindByUserID(LastEditByUserID);
            Mode = enMode.Update;

            //or make object carrying properties only
            // Create a snapshot of the initial state
            initialState = (clsRegulator)this.MemberwiseClone();

        }
        protected override bool _AddNew()
        {
            //call DataAccess Layer 

            var pair = clsRegulatorData.AddNewRegulator(this.PersonID,
                this.MembershipNumber,   this.SubscriptionTypeID, this.SubscriptionWayID,
                this.CreatedByUserID, this.IsActive, RegulatorCasesPracticeIDNameDictionary);

            
                this.RegulatorID = pair.NewRegulatorID;
                this.PractitionerID = pair.NewPractitionerID;

            return (RegulatorID != -1);

        }
        protected override bool _Update()
        {
            //call DataAccess Layer 


            return clsRegulatorData.UpdateRegulator(this.RegulatorID,this.PractitionerID,
                 this.MembershipNumber, (int)this.LastEditByUserID, this.SubscriptionTypeID, this.SubscriptionWayID,
                 this.IsActive, RegulatorCasesPracticeIDNameDictionary);
            
        }

        public static clsRegulator Find<T>(T Value,enSearchBy FindBasedOn)
        {
            int RegulatorID = -1, PersonID = -1,
              PractitionerID=-1,CreatedByUserID = -1,SubscriptionTypeID=-1,SubscriptionWayID=-1;
            int? LastEditByUserID = null;
            bool IsFound = false, IsLawyer = true;
            string MembershipNumber = "";
            bool IsActive = false;
            DateTime IssueDate = DateTime.Now;
            DateTime ?LastEditDate= null;

            Dictionary<int, string> RegulatorCasesPracticeIDNameDictionary = new Dictionary<int, string>();
     
            switch (FindBasedOn)
            {
                case enSearchBy.RegulatorID:
                    {
                        RegulatorID = Convert.ToInt32(Value);


                            IsFound = clsRegulatorData.GetRegulatorInfoByRegulatorID
                                   (RegulatorID, ref PersonID, ref MembershipNumber, ref IsLawyer, ref PractitionerID,
                                   ref IssueDate, ref LastEditByUserID, ref SubscriptionTypeID, ref SubscriptionWayID,
                                   ref CreatedByUserID, ref IsActive,ref RegulatorCasesPracticeIDNameDictionary);

                        break;

                    }
          
                case enSearchBy.PersonID:
                    {
                        PersonID = Convert.ToInt32(Value);


                            IsFound = clsRegulatorData.GetRegulatorInfoByPersonID
                                   (PersonID,ref RegulatorID, ref MembershipNumber, ref IsLawyer, ref PractitionerID,
                                   ref IssueDate, ref LastEditByUserID, ref SubscriptionTypeID, ref SubscriptionTypeID, ref CreatedByUserID,ref  IsActive
                                   , ref RegulatorCasesPracticeIDNameDictionary);

                        break;

                    }

                case enSearchBy.MembershipNumber:
                    {
                         MembershipNumber=Value.ToString();
                      
                       
                        IsFound = clsRegulatorData.GetRegulatorInfoByMembershipNumber
                               (MembershipNumber, ref PersonID, ref RegulatorID, ref PractitionerID, ref IsLawyer,
                               ref IssueDate, ref LastEditByUserID, ref SubscriptionTypeID, ref SubscriptionTypeID,
                               ref CreatedByUserID, ref IsActive,ref RegulatorCasesPracticeIDNameDictionary);

                        break;

                    }

                case enSearchBy.PractitionerID:
                    {

                         PractitionerID = Convert.ToInt32(Value);

                            IsFound = clsRegulatorData.GetRegulatorInfoByPractitionerID
                                   (PractitionerID, ref PersonID, ref RegulatorID, ref MembershipNumber, ref IsLawyer,
                                   ref IssueDate, ref LastEditByUserID, ref SubscriptionTypeID, ref SubscriptionWayID, ref CreatedByUserID, ref IsActive
                                   , ref RegulatorCasesPracticeIDNameDictionary);
                        break;

                    }


            }

            if (IsFound)
                //we return new object of that User with the right data
                return new clsRegulator( PractitionerID,  PersonID,IsLawyer,  SubscriptionTypeID,  SubscriptionWayID,
                                          RegulatorID,  MembershipNumber,  IssueDate,
                                          LastEditDate, LastEditByUserID,  CreatedByUserID,  IsActive,
                                          RegulatorCasesPracticeIDNameDictionary);

            throw new ArgumentNullException("No entity for \'Regulator\' was found in database that carry or fit with your input.");
            
        }
        public override bool Save()
        {

            try
            {

            switch (Mode)
            {
       
                    case enMode.AddNew:
                {

                     if (_AddNew())
                     {
                  
                         Mode = enMode.Update;
                         return true;
                     }
                     else
                     {

                         return false;
                     }

                }
                    
                    case enMode.Update:
                    {
                        return _Update();
                    
                    }
         
            }


            }
            catch (Exception ex)
            {
                clsHelperClasses.WriteEventToLogFile("Problem while adding a new regulator to the system , review cls regulator class, " +
                    "\n"+ex.Message,System.Diagnostics.EventLogEntryType.Error);
                Console.WriteLine(ex.ToString());
                throw ex;

            }

            return false;

        }
       
  
        public static bool Deactivate(int RegulatorID,int LastEditByUserID)
                      => clsRegulatorData.Deactivate(RegulatorID,LastEditByUserID);
        public static bool Activate(int RegulatorID)
            => clsRegulatorData.Activate(RegulatorID) ;

        public static bool DeletePermanently(int RegulatorID)
            => clsRegulatorData.DeletePermanently(RegulatorID);

        public static int Count()
            => clsRegulatorData.Count();

        public static DataTable GetRegulatorsPerPage(ushort pageNumber, uint rowsPerPage)
            => clsRegulatorData.GetRegulatorsPerPage(pageNumber, rowsPerPage);

        private static bool _ExistsByRegulatorID(int? RegulatorID)
            => clsRegulatorData.ExistsByRegulatorID(RegulatorID);

        private static bool _ExistsByPersonID(int? personID)
            => clsRegulatorData.ExistsByPersonID(personID);

        private static bool _ExistsByPractitionerID(int? practitionerID)
            => clsRegulatorData.ExistsByPractitionerID(practitionerID);
        private static bool _ExistsByMembershipNumber(string MembershipNumber)
          => clsRegulatorData.ExistsByMembershipNumber(MembershipNumber);

        public static bool Exists<T>(T value, enSearchBy findBy)
        {
            switch (findBy)
            {
                case enSearchBy.RegulatorID:
                    {
                        if (int.TryParse(value.ToString(), out int RegulatorID))
                        {

                            return _ExistsByRegulatorID(RegulatorID);
                        }
                        break;
                    }

                case enSearchBy.PersonID:
                    {
                        if (int.TryParse(value.ToString(), out int PersonID))
                        {

                            return _ExistsByPersonID(PersonID);
                        }
                        break;
                    }


                case enSearchBy.PractitionerID:
                    {
                        if (int.TryParse(value.ToString(), out int PractitionerID))
                        {

                            return _ExistsByPractitionerID(PractitionerID);
                        }
                        break;
                    }
                case enSearchBy.MembershipNumber:
                    {
                        return _ExistsByMembershipNumber(value.ToString());
                    }

                default:
                    return false;
            }

            return false;
        }

        public static DataTable All()
            => clsRegulatorData.All();

        public bool IsRegulatorInWhiteList()
        {
            //Data access , set the right type of practitioner 
            return clsWhiteList.IsPractitionerInWhiteList(this.PractitionerID, clsPractitioner.enPractitionerType.Regulatory);
        }
        public bool IsRegulatorInClosedList()
        {
            //Data access , set the right type of practitioner 
            return clsClosedList.IsPractitionerInClosedList(this.PractitionerID, clsPractitioner.enPractitionerType.Regulatory);
        }



    }

}

