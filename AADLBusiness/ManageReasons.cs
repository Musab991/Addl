using AADLDataAccess;
using System.Data;

namespace AADLBusiness
{
    public class clsReason
    {
        public enum enCompanyOrPractitioner : byte { Company = 1, Practitioner = 2 }
        public enum enWhichListType : byte { Black = 1, White = 2, Closed = 3 }
        public enum enMode : byte { Add, Update }
        public int? Id { get; set; }
        public string Name { get; set; }
        public enMode Mode { get; private set; }
        public enWhichListType WhichListType { get; set; }
        public enCompanyOrPractitioner CompanyOrPractitioner { get; set; }

        public clsReason(enCompanyOrPractitioner companyOrPractitioner, enWhichListType whichListType)
        {
            WhichListType = whichListType;
            CompanyOrPractitioner = companyOrPractitioner;
            Mode = enMode.Add;
        }

        protected clsReason(int id, string name, enCompanyOrPractitioner companyOrPractitioner, enWhichListType whichListType)
        {
            Id = id;
            Name = name;
            WhichListType = whichListType;
            CompanyOrPractitioner = companyOrPractitioner;
            Mode = enMode.Update;
        }

        public static clsReason Find(int id, enCompanyOrPractitioner companyOrPractitioner, enWhichListType whichListType) 
        {
            string name = null;

            var companyOrPractitionerData = companyOrPractitioner == enCompanyOrPractitioner.Company ? clsReasonData.enCompanyOrPractitioner.Company : clsReasonData.enCompanyOrPractitioner.Practitioner;

            switch (whichListType)
            {
                case enWhichListType.Black:
                    if (clsReasonData.GetByReasonID(id, ref name, companyOrPractitionerData, clsReasonData.enWhichListType.Black))
                        return new clsReason(id, name, companyOrPractitioner, whichListType);
                    else
                        return null;

                case enWhichListType.White:
                    if (clsReasonData.GetByReasonID(id, ref name, companyOrPractitionerData, clsReasonData.enWhichListType.White))
                        return new clsReason(id, name, companyOrPractitioner, whichListType);
                    else
                        return null;

                case enWhichListType.Closed:
                    if (clsReasonData.GetByReasonID(id, ref name, companyOrPractitionerData, clsReasonData.enWhichListType.Closed))
                        return new clsReason(id, name, companyOrPractitioner, whichListType);
                    else
                        return null;
                default:
                    return null;
            }
        }

        public static bool Delete(int id, enCompanyOrPractitioner companyOrPractitioner, enWhichListType whichListType)
        {
            var companyOrPractitionerData = companyOrPractitioner == enCompanyOrPractitioner.Company ? clsReasonData.enCompanyOrPractitioner.Company : clsReasonData.enCompanyOrPractitioner.Practitioner;

            switch (whichListType)
            {
                case enWhichListType.Black:
                    return clsReasonData.Delete(id, companyOrPractitionerData, clsReasonData.enWhichListType.Black);
                case enWhichListType.White:
                    return clsReasonData.Delete(id, companyOrPractitionerData, clsReasonData.enWhichListType.White);
                case enWhichListType.Closed:
                    return clsReasonData.Delete(id, companyOrPractitionerData, clsReasonData.enWhichListType.Closed);
                default:
                    return false;
            }
        }

        public static bool Exists(string name, enCompanyOrPractitioner companyOrPractitioner, enWhichListType whichListType)
        {
            var companyOrPractitionerData = companyOrPractitioner == enCompanyOrPractitioner.Company ? clsReasonData.enCompanyOrPractitioner.Company : clsReasonData.enCompanyOrPractitioner.Practitioner;

            switch (whichListType)
            {
                case enWhichListType.Black:
                    return clsReasonData.Exists(name, companyOrPractitionerData, clsReasonData.enWhichListType.Black);
                case enWhichListType.White:
                    return clsReasonData.Exists(name, companyOrPractitionerData, clsReasonData.enWhichListType.White);
                case enWhichListType.Closed:
                    return clsReasonData.Exists(name, companyOrPractitionerData, clsReasonData.enWhichListType.Closed);
                default:
                    return false;
            }
        }

        public static DataTable All(enCompanyOrPractitioner companyOrPractitioner, enWhichListType whichListType)
        {
            var companyOrPractitionerData = companyOrPractitioner == enCompanyOrPractitioner.Company ? clsReasonData.enCompanyOrPractitioner.Company : clsReasonData.enCompanyOrPractitioner.Practitioner;

            switch (whichListType)
            {
                case enWhichListType.Black:
                    return clsReasonData.All(companyOrPractitionerData, clsReasonData.enWhichListType.Black);
                case enWhichListType.White:
                    return clsReasonData.All(companyOrPractitionerData, clsReasonData.enWhichListType.White);
                case enWhichListType.Closed:
                    return clsReasonData.All(companyOrPractitionerData, clsReasonData.enWhichListType.Closed);
                default:
                    return null;
            }
        }

        public bool Save()
        {
            switch (Mode)
            {
                case enMode.Add:
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

        private bool _Add()
        {
            var companyOrPractitionerData = CompanyOrPractitioner == enCompanyOrPractitioner.Company ? clsReasonData.enCompanyOrPractitioner.Company : clsReasonData.enCompanyOrPractitioner.Practitioner;

            switch (WhichListType)
            {
                case enWhichListType.Black:
                    return _Add(companyOrPractitionerData, clsReasonData.enWhichListType.Black);
                case enWhichListType.White:
                    return _Add(companyOrPractitionerData, clsReasonData.enWhichListType.White);
                case enWhichListType.Closed:
                    return _Add(companyOrPractitionerData, clsReasonData.enWhichListType.Closed);
                default:
                    return false;
            }
        }

        private bool _Add(clsReasonData.enCompanyOrPractitioner companyOrPractitionerData, clsReasonData.enWhichListType whichListType)
        {
            this.Id = clsReasonData.Add(this.Name, companyOrPractitionerData, whichListType);
            return this.Id.HasValue;
        }

        private bool _Update()
        {
            var companyOrPractitionerData = CompanyOrPractitioner == enCompanyOrPractitioner.Company ? clsReasonData.enCompanyOrPractitioner.Company : clsReasonData.enCompanyOrPractitioner.Practitioner;

            switch (WhichListType)
            {
                case enWhichListType.Black:
                    return _Update(companyOrPractitionerData, clsReasonData.enWhichListType.Black);
                case enWhichListType.White:
                    return _Update(companyOrPractitionerData, clsReasonData.enWhichListType.White);
                case enWhichListType.Closed:
                    return _Update(companyOrPractitionerData, clsReasonData.enWhichListType.Closed);
                default:
                    return false;
            }
        }

        private bool _Update(clsReasonData.enCompanyOrPractitioner companyOrPractitionerData, clsReasonData.enWhichListType whichListType)
            => clsReasonData.Update(this.Id.Value, this.Name, companyOrPractitionerData, whichListType);
    }
}