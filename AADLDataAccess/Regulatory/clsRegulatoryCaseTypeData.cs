using AADL_DataAccess;
using AADL_DataAccess.HelperClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AADLDataAccess
{
    public class clsRegulatoryCaseTypeData
    {
        public static bool GetRegulatoryCaseTypeInfoByCaseTypeID(int RegulatoryCaseTypeID ,ref string RegulatoryCaseTypeName
            ,ref int CreatedByAdminID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_GetRegulatoryCaseTypeInfoByCaseTypeID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@RegulatoryCaseTypeID", RegulatoryCaseTypeID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {


                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;

                                RegulatoryCaseTypeName = (string)reader["RegulatoryCaseTypeName"];
                                CreatedByAdminID = (int)reader["CreatedByAdminID"];

                            }
                            else
                            {
                                // The record was not found
                                isFound = false;
                            }


                        }


                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSettings.WriteEventToLogFile("Review your clsRegulatoryCaseTypeData class data access layer ,get case type info by ID\n Exception:" +
                            ex.Message, EventLogEntryType.Error);
                        throw new Exception(ex.Message);

                    }


                }

            }


            return isFound;
        }
        public static bool GetRegulatoryCaseTypeInfoByCaseTypeName(string RegulatoryCaseTypeName,ref int RegulatoryCaseTypeID
          , ref int CreatedByAdminID)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_GetRegulatoryCaseTypeInfoByCaseTypeName", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@RegulatoryCaseTypeName", RegulatoryCaseTypeName);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {


                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;

                                RegulatoryCaseTypeID = (int)reader["RegulatoryCaseTypeID"];
                                CreatedByAdminID = (int)reader["CreatedByAdminID"];

                            }
                            else
                            {
                                // The record was not found
                                isFound = false;
                            }


                        }


                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSettings.WriteEventToLogFile("Review your clsRegulatoryCaseTypeData class data access layer ,get case type info by ID\n Exception:" +
                            ex.Message, EventLogEntryType.Error);
                        throw new Exception(ex.Message);

                    }


                }

            }


            return isFound;
        }
        public static int?  Add(string name, int createdByAdminID)
            => clsCaseTypeData.Add(name, createdByAdminID, clsCaseTypeData.enWhichPractitioner.Regulator);
        public static bool Update(int ID, string name)
            => clsCaseTypeData.Update(ID, name, clsCaseTypeData.enWhichPractitioner.Regulator);
        public static bool Delete(int ID)
            => clsCaseTypeData.Delete(ID, clsCaseTypeData.enWhichPractitioner.Regulator);
        public static DataTable All()
            => clsDataAccessHelper.All("SP_GetAllRegulatoryCasesTypes");

        public static bool Exists(string name)
            => clsCaseTypeData.Exists(name, clsCaseTypeData.enWhichPractitioner.Regulator);

    }
}
