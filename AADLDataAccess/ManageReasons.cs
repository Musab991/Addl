using AADL_DataAccess;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using AADL_DataAccess.HelperClasses;

namespace AADLDataAccess
{
    public static class clsReasonData
    {
        public enum enCompanyOrPractitioner : byte { Company = 1, Practitioner = 2 }

        public enum enWhichListType : byte {  Black = 1, White = 2, Closed = 3 }

        public static bool GetByReasonID(int  Id, ref string name, enCompanyOrPractitioner companyOrPractitioner, enWhichListType whichListType)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetReasonByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ReasonID", Id);
                        command.Parameters.AddWithValue("@WhichListType", whichListType);
                        command.Parameters.AddWithValue("@CompanyOrPractitioner", companyOrPractitioner);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;

                                name = (string)reader["ReasonName"];
                            }
                            else
                            {
                                // The record was not found
                                isFound = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                isFound = false;
                clsDataAccessHelper.HandleException(ex);
            }

            return isFound;
        }

        public static int? Add(string name, enCompanyOrPractitioner companyOrPractitioner, enWhichListType whichListType)
        {
            int? newReasonID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewReason", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Name", name);
                        command.Parameters.AddWithValue("@WhichListType", whichListType);
                        command.Parameters.AddWithValue("@CompanyOrPractitioner", companyOrPractitioner);

                        SqlParameter outputIdParam = new SqlParameter("@NewReasonID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        newReasonID = command.Parameters["@NewReasonID"].Value as int?;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.WriteEventToLogFile(ex.Message, EventLogEntryType.Error);
                newReasonID = null;
            }

            return newReasonID;
        }

        public static bool Update(int ID, string newName, enCompanyOrPractitioner companyOrPractitioner, enWhichListType whichListType)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_UpdateReason", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ReasonID", ID);
                    command.Parameters.AddWithValue("@NewName", newName);
                    command.Parameters.AddWithValue("@WhichListType", whichListType);
                    command.Parameters.AddWithValue("@CompanyOrPractitioner", companyOrPractitioner);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        clsDataAccessSettings.WriteEventToLogFile(ex.Message, EventLogEntryType.Error);
                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSettings.WriteEventToLogFile(ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return rowsAffected > 0;
        }

        public static bool Exists(string name, enCompanyOrPractitioner companyOrPractitioner, enWhichListType whichListType)
            => clsDataAccessHelper.Exists("SP_DoesReasonExistsByName", "Name", name, "CompanyOrPractitioner", companyOrPractitioner, "WhichListType", whichListType);

        public static bool Delete(int id, enCompanyOrPractitioner companyOrPractitioner, enWhichListType whichListType)
            => clsDataAccessHelper.Delete("SP_DeleteReason", "ReasonID", id, "CompanyOrPractitioner", companyOrPractitioner, "WhichListType", whichListType);

        public static DataTable All(enCompanyOrPractitioner companyOrPractitioner, enWhichListType whichListType)
            => clsDataAccessHelper.All("SP_GetAllReasonsByFilter", "CompanyOrPractitioner", companyOrPractitioner, "WhichListType", whichListType);
    }
}
