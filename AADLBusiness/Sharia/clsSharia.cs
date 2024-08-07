using AADLBusiness.Lists.Closed;
using AADLBusiness.Lists.WhiteList;
using AADLDataAccess;
using AADLDataAccess.Sharia;
using System;
using System.Collections.Generic;
using System.Data;

namespace AADLBusiness.Sharia

{
    public class clsSharia:clsPractitioner
    {
      

        public enum enSearchBy { ShariaLicenseNumber, PersonID, ShariaID,  LawyerID ,PractitionerID };
        public int ShariaID { set; get; }

        public string ShariaLicenseNumber { set; get; }

        private Dictionary<int,string> _ShariaCasesPracticeIDNameDictionary;

        public Dictionary<int,string>ShariaCasesPracticeIDNameDictionary
        {
            get
            {
                return _ShariaCasesPracticeIDNameDictionary;
            }
            set
            {
 
                _ShariaCasesPracticeIDNameDictionary = value;
            }
        }

        public override clsSubscriptionType SubscriptionTypeInfo { get; }
        public override clsSubscriptionWay SubscriptionWayInfo { get; }

        public override clsUser UserInfo { get; }
        public override clsUser LastEditByUserInfo { get; }
        public override clsPerson SelectedPersonInfo { get; }

        //cls white list - cls closed list.
        public clsSharia()
        {
            this.ShariaID = -1;
            this.PersonID = -1;
            this.ShariaLicenseNumber = "";
            this.IssueDate = DateTime.MinValue;
            this.LastEditDate = null;
            this.LastEditByUserID= null;
            this.SubscriptionTypeID = -1;
            this.CreatedByUserID = -1;
            this.IsActive = false;
            UserInfo = null;
            Mode = enMode.AddNew;
            _ShariaCasesPracticeIDNameDictionary = new Dictionary<int, string>();

        }

        private clsSharia(int PractitionerID, int PersonID,bool IsLawyer, int SubscriptionTypeID,int SubscriptionWayID, int ShariaID, 
            string ShariaLicenseNumber, DateTime IssueDate,
            DateTime? LastEditDate, int? LastEditByUserID, int CreatedByUserID, bool IsActive,
            Dictionary<int, string> ShariaCasesPracticeIDNameDictionary)
        {
            try
            {
            this.PractitionerID = PractitionerID;
            this.PersonID = PersonID;
            this.IsLawyer = IsLawyer;
            this.SubscriptionTypeID = SubscriptionTypeID;
            this.SubscriptionWayID = SubscriptionWayID;
            this.SubscriptionTypeInfo = clsSubscriptionType.Find(SubscriptionTypeID);
            this.SubscriptionWayInfo = clsSubscriptionWay.Find(SubscriptionWayID);
            this.ShariaID = ShariaID;
            this.ShariaLicenseNumber = ShariaLicenseNumber;
            this.PractitionerID= PractitionerID;
            this.IssueDate = IssueDate;
            this.LastEditDate = LastEditDate;
            this.LastEditByUserID= LastEditByUserID;
            if (this.LastEditByUserID != null) this.LastEditByUserInfo = clsUser.Find(this.LastEditByUserID.Value);
            this.CreatedByUserID = CreatedByUserID;
            this.IsActive = IsActive;
            this.SelectedPersonInfo = clsPerson.Find(PersonID, clsPerson.enSearchBy.PersonID);

            UserInfo = clsUser.Find(CreatedByUserID);
            //cases regulator practice.
            _ShariaCasesPracticeIDNameDictionary = ShariaCasesPracticeIDNameDictionary;

            Mode = enMode.Update;
            }
                catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                clsHelperClasses.WriteEventToLogFile("Problem happens in construction sharia object,", System.Diagnostics.EventLogEntryType.Error);
            }

        }
        protected  override bool _AddNew()
        {
            //call DataAccess Layer 

            var pair= clsShariaData.AddNewSharia(this.PersonID,
                this.ShariaLicenseNumber, this.SubscriptionTypeID, 
                this.SubscriptionWayID, this.CreatedByUserID, this.IsActive, ShariaCasesPracticeIDNameDictionary);

            this.ShariaID = pair.NewShariaID;
            this.PractitionerID = pair.NewPractitionerID;

            return (ShariaID != -1);

        }
        protected override bool _Update()
        {
            //call DataAccess Layer 
            return clsShariaData.UpdateSharia(this.ShariaID,this.PractitionerID, this.ShariaLicenseNumber,
                this.SubscriptionTypeID,this.SubscriptionWayID,this.IsActive, this.LastEditByUserID,
                 ShariaCasesPracticeIDNameDictionary);

        }
        public static clsSharia Find<T>(T Value, enSearchBy FindBasedOn)
        {
            int ShariaID = -1, PersonID = -1,
              PractitionerID = -1, CreatedByUserID = -1, SubscriptionTypeID = -1, SubscriptionWayID = -1;
            int? LastEditByUserID = null;
            bool IsFound = false, IsLawyer = true;
            string ShariaLicenseNumber = "";
            bool IsActive = false;
            DateTime IssueDate = DateTime.Now;
            DateTime? LastEditDate = null;

            Dictionary<int, string> ShariaCasesPracticeIDNameDictionary = new Dictionary<int, string>();

            switch (FindBasedOn)
            {
                case enSearchBy.ShariaID:
                    {
                        ShariaID = Convert.ToInt32(Value);


                        IsFound = clsShariaData.GetShariaInfoByShariaID
                               (ShariaID, ref PersonID, ref ShariaLicenseNumber, ref IsLawyer, ref PractitionerID,
                               ref IssueDate, ref LastEditByUserID, ref SubscriptionTypeID, ref SubscriptionWayID,
                               ref CreatedByUserID, ref IsActive, ref ShariaCasesPracticeIDNameDictionary);

                        break;

                    }

                case enSearchBy.PersonID:
                    {
                        PersonID = Convert.ToInt32(Value);


                        IsFound = clsShariaData.GetShariaInfoByPersonID
                               (PersonID, ref ShariaID, ref ShariaLicenseNumber, ref IsLawyer, ref PractitionerID,
                               ref IssueDate, ref LastEditByUserID, ref SubscriptionTypeID, ref SubscriptionTypeID, ref CreatedByUserID, ref IsActive
                               , ref ShariaCasesPracticeIDNameDictionary);

                        break;

                    }

                case enSearchBy.ShariaLicenseNumber:
                    {
                        ShariaLicenseNumber = Value.ToString();


                        IsFound = clsShariaData.GetShariaInfoByShariaLicenseNumber
                               (ShariaLicenseNumber, ref PersonID, ref ShariaID, ref PractitionerID, ref IsLawyer,
                               ref IssueDate, ref LastEditByUserID, ref SubscriptionTypeID, ref SubscriptionTypeID,
                               ref CreatedByUserID, ref IsActive, ref ShariaCasesPracticeIDNameDictionary);

                        break;

                    }

                case enSearchBy.PractitionerID:
                    {

                        PractitionerID = Convert.ToInt32(Value);

                        IsFound = clsShariaData.GetShariaInfoByPractitionerID
                               (PractitionerID, ref PersonID, ref ShariaID, ref ShariaLicenseNumber, ref IsLawyer,
                               ref IssueDate, ref LastEditByUserID, ref SubscriptionTypeID, ref SubscriptionWayID, ref CreatedByUserID, ref IsActive
                               , ref ShariaCasesPracticeIDNameDictionary);
                        break;

                    }


            }

            if (IsFound)
                //we return new object of that User with the right data
                return new clsSharia(PractitionerID, PersonID, IsLawyer, SubscriptionTypeID, SubscriptionWayID,
                                          ShariaID, ShariaLicenseNumber, IssueDate,
                                          LastEditDate, LastEditByUserID, CreatedByUserID, IsActive,
                                          ShariaCasesPracticeIDNameDictionary);

            throw new ArgumentNullException("No entity for \'Sharia\' was found in database that carry or fit with your input.");

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
                clsHelperClasses.WriteEventToLogFile("Problem while adding a new sharia to the system , review cls sharia class, " +
                    "\n" + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                throw new Exception(ex.Message, ex);
            }

            return false;
        }
        public static bool DeletePermanently(int ShariaID)
            => clsShariaData.DeletePermanently(ShariaID);

        public static bool Deactivate(int ShariaID, int LastEditByUserID)
            => clsShariaData.Deactivate(ShariaID, LastEditByUserID);
        public static bool Activate(int ShariaID, int LastEditByUserID)
            => clsShariaData.Activate(ShariaID, LastEditByUserID);
        public static int Count()
            => clsShariaData.Count();
        public static int CountDraft()
           => clsShariaData.Count(true);

        public static DataTable GetShariasPerPage(ushort pageNumber, uint rowsPerPage)
            => clsShariaData.GetShariasPerPage(pageNumber, rowsPerPage);

        public static DataTable GetShariasPerPageDraft(ushort pageNumber, uint rowsPerPage)
         => clsShariaData.GetShariasPerPage(pageNumber, rowsPerPage, true);

        private static bool _ExistsByShariaID(int? ShariaID)
            => clsShariaData.ExistsByShariaID(ShariaID);

        private static bool _ExistsByPersonID(int? personID)
            => clsShariaData.ExistsByPersonID(personID);

        private static bool _ExistsByPractitionerID(int? practitionerID)
            => clsShariaData.ExistsByPractitionerID(practitionerID);
        private static bool _ExistsByShariaLicenseNumber(string ShariaLicenseNumber)
          => clsShariaData.ExistsByShariaLicenseNumber(ShariaLicenseNumber);

        public static bool Exists<T>(T value, enSearchBy findBy)
        {
            switch (findBy)
            {
                case enSearchBy.ShariaID:
                    {
                        if (int.TryParse(value.ToString(), out int shariaID))
                        {

                            return _ExistsByShariaID(shariaID);
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
                case enSearchBy.ShariaLicenseNumber:
                    {
                            return _ExistsByShariaLicenseNumber(value.ToString());
                    }

                default:
                    return false;
            }

            return false;
        }

        public static DataTable All()
            => clsShariaData.All();

        public bool IsShariaInWhiteList()
        {
            //Data access , set the right type of practitioner 
            return clsWhiteList.IsPractitionerInWhiteList(this.PractitionerID, clsPractitioner.enPractitionerType.Sharia);
        }
        public bool IsShariaInClosedList()
        {
            //Data access , set the right type of practitioner 
            return clsClosedList.IsPractitionerInClosedList(this.PractitionerID, clsPractitioner.enPractitionerType.Sharia);
        }

    }

}
