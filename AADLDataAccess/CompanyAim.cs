using AADL_DataAccess.HelperClasses;
using AADL_DataAccess;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;

namespace AADLDataAccess
{
    public static class clsCompanyAimData
    {
        public static bool GetInfoByAimID(int Id, ref string name)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetCompanyAimByID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AimID", Id);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                name = (string)reader["Name"];
                                isFound = true;
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

        public static int? Add(string name)
        {
            int? newAimID = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewCompanyAim", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Name", name);

                        SqlParameter outputIdParam = new SqlParameter("@NewAimID", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(outputIdParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        newAimID = command.Parameters["@NewAimID"].Value as int?;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.WriteEventToLogFile("Exception Message From clsAimCompanyData class DataAccess add new aim type method:\t" + ex.Message,
                    EventLogEntryType.Error);

                newAimID = null;
            }

            return newAimID;
        }

        public static bool Update(int ID, string name)
        {
            int rowsAffected = 0;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_UpdateCompanyAim", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@AimID", ID);
                    command.Parameters.AddWithValue("@Name", name);

                    try
                    {
                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        clsDataAccessSettings.WriteEventToLogFile("Review your clsCompanyAimData class data access layer ,Update\n Exception:" +
                            ex.Message, EventLogEntryType.Error);
                        Console.WriteLine(ex.Message);

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSettings.WriteEventToLogFile("Review your clsCompanyAimData class data access layer ,Update\n Exception:" +
                            ex.Message, EventLogEntryType.Error);
                        Console.WriteLine(ex.Message);

                    }

                }

            }

            return rowsAffected > 0;
        }

        public static bool Delete(int ID)
            => clsDataAccessHelper.Delete("SP_DeleteCompanyAim", "AimID", ID);

        public static bool Exists(string name)
            => clsDataAccessHelper.Exists("SP_DoesCompanyAimExistsByName", "Name", name);

        public static DataTable All()
            => clsDataAccessHelper.All("SP_GetAllCompanyAims");
    }
}
