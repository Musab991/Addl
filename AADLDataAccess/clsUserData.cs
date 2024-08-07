using AADL_DataAccess;
using AADL_DataAccess.HelperClasses;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AADLBusiness
{
    public class clsUserData
    {
        public static bool GetUserInfoByID(int userId, ref string userName, ref string password, ref bool isActive, ref DateTime issueDate,ref int permissions, ref int? createdByUserId)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetUserById", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserId", userId);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                userName = (string)reader["UserName"];
                                password = (string)reader["Password"];
                                isActive = (bool)reader["IsActive"];
                                issueDate = (DateTime)reader["IssueDate"];
                                permissions = (int)reader["Permissions"];
                                createdByUserId = reader["CreatedByUserId"] as int?;

                                isFound = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.WriteEventToLogFile(ex.Message, EventLogEntryType.Error);
                isFound = false;
            }

            return isFound; 
        }

        public static bool GetUserInfoByCredentials(string userName,  string password, ref int userId, ref bool isActive, ref DateTime issueDate, ref int permissions, ref int? createdByUserId)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_GetUserByCredentials", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserName", userName);
                        command.Parameters.AddWithValue("@Password", password);

                        connection.Open();

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                isActive = (bool)reader["IsActive"];
                                issueDate = (DateTime)reader["IssueDate"];
                                permissions = (int)reader["Permissions"];
                                userId = (int)reader["UserId"];
                                createdByUserId = reader["CreatedByUserId"] as int?;

                                isFound = true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.WriteEventToLogFile(ex.Message, EventLogEntryType.Error);
                isFound = false;
            }

            return isFound;
        }

        public static int? AddNew(string userName, string password, bool isActive, DateTime issueDate, int permissions, int? createdByUserId)
        {
            int? newUserId = null;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_AddNewUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserName", userName);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@IsActive", isActive);
                        command.Parameters.AddWithValue("@IssueDate", issueDate);
                        command.Parameters.AddWithValue("@Permissions", permissions);
                        command.Parameters.AddWithValue("@CreatedByUserId", createdByUserId.HasValue ? (object)createdByUserId : DBNull.Value);

                        // Add output parameter for the NewUserId
                        SqlParameter newUserIdParameter = new SqlParameter("@NewUserId", SqlDbType.Int);
                        newUserIdParameter.Direction = ParameterDirection.Output;
                        command.Parameters.Add(newUserIdParameter);


                        connection.Open();

                        command.ExecuteNonQuery();

                        newUserId = (int)command.Parameters["@NewUserId"].Value;
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.WriteEventToLogFile(ex.Message, EventLogEntryType.Error);
                newUserId = null;
            }

            return newUserId;
        }

        public static bool Update(int userId, string userName, string password, bool isActive, int permissions)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_UpdateUser", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@UserName", userName);
                        command.Parameters.AddWithValue("@Password", password);
                        command.Parameters.AddWithValue("@IsActive", isActive);
                        command.Parameters.AddWithValue("@Permissions", permissions);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.WriteEventToLogFile(ex.Message, EventLogEntryType.Error);
                rowsAffected = 0;
            }

            return (rowsAffected > 0);
        }

        public static bool ChangeUserName(int userId, string newUserName)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_ChangeUserName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@NewUserName", newUserName);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.WriteEventToLogFile(ex.Message, EventLogEntryType.Error);
                rowsAffected = 0;
            }

            return (rowsAffected > 0);
        }

        public static bool ChangePassword(int userId, string newPassword)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_ChangeUserPassword", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@NewPassword", newPassword);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.WriteEventToLogFile(ex.Message, EventLogEntryType.Error);
                rowsAffected = 0;
            }

            return (rowsAffected > 0);
        }

        public static bool ChangePermissions(int userId, int newPermissions)
        {
            int rowsAffected = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_ChangeUserPermissions", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@UserId", userId);
                        command.Parameters.AddWithValue("@NewPermissions", newPermissions);

                        connection.Open();
                        rowsAffected = command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.WriteEventToLogFile(ex.Message, EventLogEntryType.Error);
                rowsAffected = 0;
            }

            return (rowsAffected > 0);
        }

        public static bool IsActive(int userId)
        {
            bool isActive = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_IsUserActive", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add input parameter
                        command.Parameters.AddWithValue("@UserId", userId);

                        // Add output parameter
                        SqlParameter isActiveParam = new SqlParameter("@IsActive", SqlDbType.Bit)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(isActiveParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        // Check if the output parameter has been set and get its value
                        if (isActiveParam.Value != DBNull.Value)
                        {
                            isActive = Convert.ToBoolean(isActiveParam.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.WriteEventToLogFile(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                isActive = false;
            }

            return isActive;
        }

        public static bool IsActive(string userName, string password)
        {
            bool isActive = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand("SP_IsUserActiveByCredentials", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Add input parameters
                        command.Parameters.AddWithValue("@UserName", userName);
                        command.Parameters.AddWithValue("@Password", password);

                        // Add output parameter
                        SqlParameter isActiveParam = new SqlParameter("@IsActive", SqlDbType.Bit)
                        {
                            Direction = ParameterDirection.Output
                        };
                        command.Parameters.Add(isActiveParam);

                        connection.Open();
                        command.ExecuteNonQuery();

                        // Check if the output parameter has been set and get its value
                        if (isActiveParam.Value != DBNull.Value)
                        {
                            isActive = Convert.ToBoolean(isActiveParam.Value);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                clsDataAccessSettings.WriteEventToLogFile(ex.Message, System.Diagnostics.EventLogEntryType.Error);
                isActive = false;
            }

            return isActive;
        }

        public async static Task<DataTable> GetAllUsers()
        {

            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {


                string query = @"select * from fullUserInfo_view;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {


                    try
                    {
                        connection.Open();

                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {


                            if (reader.HasRows)

                            {
                                dt.Load(reader);
                            }

                        }


                    }

                    catch (Exception ex)
                    {
                        clsDataAccessSettings.WriteEventToLogFile("Review your user class data access layer ,GetAllUsers Method() \n Exception:" +
                                                                           ex.Message, EventLogEntryType.Error);
                    }
                }
            }

            return dt;

        }

        public static DataTable All()
            => clsDataAccessHelper.All("SP_GetAllUsers");

        public static bool Delete(int userId)
            => clsDataAccessHelper.Delete("SP_DeleteUser", "UserId", userId);

        public static bool Exsits(int userId)
            => clsDataAccessHelper.Exists("SP_IsUserExistsById", "UserId", userId);

        public static bool Exists(string userName)
            => clsDataAccessHelper.Exists("SP_IsUserExistsByUsername", "UserName", userName);

        public static bool Exists(string userName, string password)
            => clsDataAccessHelper.Exists("SP_IsUserExistsByCredentials", "UserName", userName, "Password", password);

        public static bool Activate(int userId)
            => clsDataAccessHelper.Activate("SP_ActivateUser", "userId", userId);

        public static bool Deactivate(int userId)
            => clsDataAccessHelper.Activate("SP_DeactivateUser", "userId", userId);
    }
}
