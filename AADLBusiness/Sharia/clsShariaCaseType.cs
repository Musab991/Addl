using AADLBusiness;
using AADLDataAccess;
using AADLDataAccess.Sharia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AADLBusiness.Sharia
{
    public class clsShariaCaseType
    {
    
        public enum enMode { AddNew = 0, Update = 1 };
    
        public enMode Mode = enMode.AddNew;
    
        public int? ShariaCaseTypeID { get; set; }

        public string ShariaCaseTypeName { get; set; }

        public clsShariaCaseType()
        {
            this.ShariaCaseTypeID = -1;
            this.ShariaCaseTypeName = "";
        }

        private clsShariaCaseType(int ShariaCaseTypeID, string ShariaCaseTypeName)
        {
            this.ShariaCaseTypeID = ShariaCaseTypeID;
            this.ShariaCaseTypeName = ShariaCaseTypeName;
        }

        public static clsShariaCaseType Find(int ShariaCaseTypeID)
        {
            string ShariaCaseTypeName = "";

            if (clsShariaCaseTypeData.GetShariaCaseTypeInfoByCaseTypeID(ShariaCaseTypeID, ref ShariaCaseTypeName))

                return new clsShariaCaseType(ShariaCaseTypeID, ShariaCaseTypeName);
            else
                return null;

        }
    
        public static clsShariaCaseType Find(string ShariaCaseTypeName)
        {

            int ShariaCaseTypeID = -1;

            if (clsShariaCaseTypeData.GetShariaCaseTypeInfoByCaseTypeName(ShariaCaseTypeName, ref ShariaCaseTypeID))

                return new clsShariaCaseType(ShariaCaseTypeID, ShariaCaseTypeName);
            else
                return null;

        }
    
        public static DataTable All()
        {
            return clsShariaCaseTypeData.GetAllShariaCaseTypes();
        }

        private bool _AddNewShariaCaseType()
        {
            //call DataAccess Layer 

            this.ShariaCaseTypeID = clsShariaCaseTypeData.Add(this.ShariaCaseTypeName);

            return (this.ShariaCaseTypeID.HasValue);

        }
    
        private bool _UpdateShariaCaseType()
        {
            //call DataAccess Layer 

            return clsShariaCaseTypeData.Update((int)this.ShariaCaseTypeID, this.ShariaCaseTypeName);
        }
    
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewShariaCaseType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateShariaCaseType();

            }

            return false;
        }

        public static bool Delete(int caseID)
            => clsShariaCaseTypeData.Delete(caseID);

        public static bool Exists(string name)
            => clsShariaCaseTypeData.Exists(name);
    }
}
