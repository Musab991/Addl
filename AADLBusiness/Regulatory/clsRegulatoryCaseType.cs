﻿using AADLBusiness;
using AADL_DataAccess;
using AADLDataAccess;
using Iced.Intel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AADLDataAccess.Sharia;
using AADLDataAccess.Expert;

namespace AADLBusiness
{
    public class clsRegulatoryCaseType
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;
        public int? RegulatoryCaseTypeID { get; set; }

        public string RegulatoryCaseTypeName { get; set; }

        public clsRegulatoryCaseType()
        {
            this.RegulatoryCaseTypeID = -1;
            this.RegulatoryCaseTypeName = "";
        }

        private clsRegulatoryCaseType(int RegulatoryCaseTypeID, string RegulatoryCaseTypeName)
        {
            this.RegulatoryCaseTypeID = RegulatoryCaseTypeID;
            this.RegulatoryCaseTypeName = RegulatoryCaseTypeName;
        }

        public static clsRegulatoryCaseType Find(int RegulatoryCaseTypeID)
        {
            string RegulatoryCaseTypeName = "";

            if (clsRegulatoryCaseTypeData.GetRegulatoryCaseTypeInfoByCaseTypeID(RegulatoryCaseTypeID, ref RegulatoryCaseTypeName))

                return new clsRegulatoryCaseType(RegulatoryCaseTypeID, RegulatoryCaseTypeName);
            else
                return null;

        }

        public static clsRegulatoryCaseType Find(string RegulatoryCaseTypeName)
        {

            int RegulatoryCaseTypeID = -1;

            if (clsRegulatoryCaseTypeData.GetRegulatoryCaseTypeInfoByCaseTypeName(RegulatoryCaseTypeName, ref RegulatoryCaseTypeID))

                return new clsRegulatoryCaseType(RegulatoryCaseTypeID, RegulatoryCaseTypeName);
            else
                return null;

        }
        public  static DataTable All()
        {
            return  clsRegulatoryCaseTypeData.All();
        }
     
        private bool _AddNewRegulatoryCaseType()
        {
            //call DataAccess Layer 

            this.RegulatoryCaseTypeID = clsRegulatoryCaseTypeData.Add(this.RegulatoryCaseTypeName);

            return (this.RegulatoryCaseTypeID.HasValue);

        }
        private bool _UpdateRegulatoryCaseType()
        {
            //call DataAccess Layer 

            return clsRegulatoryCaseTypeData.Update((int)this.RegulatoryCaseTypeID, this.RegulatoryCaseTypeName);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewRegulatoryCaseType())
                    {

                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:

                    return _UpdateRegulatoryCaseType();

            }

            return false;
        }

        public static bool Delete(int caseID)
            => clsRegulatoryCaseTypeData.Delete(caseID);

        public static bool Exists(string name)
            => clsRegulatoryCaseTypeData.Exists(name);

    }
}
