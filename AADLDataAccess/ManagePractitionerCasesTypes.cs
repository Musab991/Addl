using AADL_DataAccess;
using AADL_DataAccess.HelperClasses;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System;

namespace AADLDataAccess
{
    public static class clsCaseTypeData
    {
        public enum enWhichPractitioner : byte { Regulator = 1, Sharia, Judger, Expert }

        public static int? Add(string JudgeCaseTypeName, enWhichPractitioner whichPractitioner)
        {
            int? newCaseTypeID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewCaseType", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Name", JudgeCaseTypeName);
                        command.Parameters.AddWithValue("@WhichPractitioner", whichPractitioner);

                        SqlParameter outputIdParam = new SqlParameter("@NewCaseTypeID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        newCaseTypeID = command.Parameters["@NewCaseTypeID"].Value as int?;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.WriteEventToLogFile("Exception Message From clsCaseTypeData class DataAccess add new Case type method:\t" + ex.Message,
                    EventLogEntryType.Error);

                newCaseTypeID = null;
            }

            return newCaseTypeID;
        }

        public static bool Update(int ID, string name, enWhichPractitioner whichPractitioner)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_UpdateCaseType", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@WhichPractitioner", whichPractitioner);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        clsDataAccessSettings.WriteEventToLogFile("Review your clsCaseTypeData class data access layer ,Update\n Exception:" +
                            ex.Message, EventLogEntryType.Error);
                        Console.WriteLine(ex.Message);

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSettings.WriteEventToLogFile("Review your clsCaseTypeData class data access layer ,Update\n Exception:" +
                            ex.Message, EventLogEntryType.Error);
                        Console.WriteLine(ex.Message);

                    }

                }

            }

            return rowsAffected > 0;

        }

        public static bool Exists(string name, enWhichPractitioner whichPractitioner)
            => clsDataAccessHelper.Exists("SP_DoesCaseTypeExistsByName", "Name", name, "WhichPractitioner", (int)whichPractitioner);

        public static bool Delete(int ID, enWhichPractitioner whichPractitioner)
            => clsDataAccessHelper.Delete("SP_DeleteCaseType", "ID", ID, "WhichPractitioner", (int)whichPractitioner);
    }
}
