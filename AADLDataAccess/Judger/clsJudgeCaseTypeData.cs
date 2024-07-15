using AADL_DataAccess;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using AADL_DataAccess.HelperClasses;
using System.Xml.Linq;

namespace AADLDataAccess.Judger
{
    public static class clsJudgeCaseTypeData
    {
        public static bool GetJudgeCaseTypeInfoByCaseTypeID(int JudgeCaseTypeID, ref string JudgeCaseTypeName, ref int CreatedByAdminID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetJudgeCaseTypeInfoByCaseTypeID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@JudgeCaseTypeID", JudgeCaseTypeID);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                JudgeCaseTypeName = (string)reader["JudgeCaseTypeName"];
                                CreatedByAdminID = (int)reader["CreatedByAdminID"];

                                isFound = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.WriteEventToLogFile("Review your clsJudgeCaseTypeData class data access layer ,get case type info by ID\n Exception:" +
                    ex.Message, EventLogEntryType.Error);

                isFound = false;
            }


            return isFound;
        }

        public static bool GetJudgeCaseTypeInfoByCaseTypeName(string JudgeCaseTypeName, ref int JudgeCaseTypeID, ref int CreatedByAdminID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetJudgeCaseTypeInfoByCaseTypeName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@JudgeCaseTypeName", JudgeCaseTypeName);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {

                            if (reader.Read())
                            {
                                JudgeCaseTypeID = (int)reader["JudgeCaseTypeID"];
                                CreatedByAdminID = (int)reader["CreatedByAdminID"];

                                isFound = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.WriteEventToLogFile("Review your clsJudgeCaseTypeData class data access layer ,get case type info by ID\n Exception:" +
                    ex.Message, EventLogEntryType.Error);

                isFound = false;
            }

            return isFound;
        }

        public static int? Add(string name, int createdByAdminID)
            => clsCaseTypeData.Add(name, createdByAdminID, clsCaseTypeData.enWhichPractitioner.Judger);

        public static bool Update(int ID, string name)
            => clsCaseTypeData.Update(ID, name, clsCaseTypeData.enWhichPractitioner.Judger);

        public static DataTable All()
            => clsDataAccessHelper.All("SP_GetAllJudgeCaseTypes");

        public static bool Delete(int ID)
            => clsCaseTypeData.Delete(ID, clsCaseTypeData.enWhichPractitioner.Judger);

        public static bool Exists(string name)
            => clsCaseTypeData.Exists(name, clsCaseTypeData.enWhichPractitioner.Judger);
    }
}
