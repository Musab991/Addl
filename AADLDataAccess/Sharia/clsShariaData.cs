using AADL_DataAccess;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AADL_DataAccess.HelperClasses;

namespace AADLDataAccess.Sharia
{
    public class clsShariaData
    {
        public enum enWhichID { ShariaID = 1, PractitionerID, PersonID, ShariaLicenseNumber }
        public static bool GetShariaInfoByShariaID(int ShariaID, ref int PersonID, ref string ShariaLicenseNumber,
            ref bool IsLawyer, ref int PractitionerID, ref DateTime IssueDate, ref int? LastEditByUserID,
            ref int SubscriptionTypeID, ref int SubscriptionWayID, ref int CreatedByUserID, ref bool IsActive,
           ref Dictionary<int, string> CasesShariaPracticesIDNameDictionary)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_GetShariaInfoByShariaID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ShariaID", ShariaID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                // Read first result set

                                if (reader.Read())
                                {
                                    // The record was found
                                    isFound = true;
                                    IsLawyer = (bool)reader["IsLawyer"];
                                    PractitionerID = (int)reader["PractitionerID"];
                                    SubscriptionTypeID = (int)reader["SubscriptionTypeID"];
                                    SubscriptionWayID = (int)reader["SubscriptionWayID"];
                                }

                                // Read second result set
                                reader.NextResult();
                                if (reader.Read())
                                {
                                    // The record was found
                                    isFound = true;
                                    ShariaID = (int)reader["ShariaID"];
                                    ShariaLicenseNumber = (string)reader["ShariaLicenseNumber"];
                                    IssueDate = (DateTime)reader["IssueDate"];
                                    LastEditByUserID = reader["LastEditByUserID"] != DBNull.Value ? LastEditByUserID = (int)reader["LastEditByUserID"] : null;
                                    CreatedByUserID = (int)reader["CreatedByUserID"];
                                    IsActive = (bool)reader["IsActive"];
                                    PersonID = (int)reader["PersonID"];
                                }

                                // Read second result set
                                reader.NextResult();
                                while (reader.Read())
                                {
                                    // Process the data from Sharias CasesPractice table
                                    int regulatoryCaseTypeId = reader.GetInt32(reader.GetOrdinal("ShariaCaseTypeID"));
                                    string regulatoryCaseTypeName = reader.GetString(reader.GetOrdinal("ShariaCaseTypeName"));

                                    CasesShariaPracticesIDNameDictionary.Add(regulatoryCaseTypeId, regulatoryCaseTypeName);
                                }
                            }
                            else
                            {
                                // The record was not found
                                isFound = false;
                            }
                        }

                    }
                    catch (SqlException ex)
                    {

                        clsDataAccessSettings.WriteEventToLogFile("Exception from Data Access layer clsSharia class, get info by id():\n" + ex.Message,
                            EventLogEntryType.Error);
                        //Console.WriteLine("Error: " + ex.Message);
                        isFound = false;
                    }
                    catch (Exception ex)
                    {

                        clsDataAccessSettings.WriteEventToLogFile("Exception from Data Access layer clsSharia class, get info by id():\n" + ex.Message,
                            EventLogEntryType.Error);
                        //Console.WriteLine("Error: " + ex.Message);
                        isFound = false;
                    }
                }

            }

            return isFound;
        }

        public static bool GetShariaInfoByPersonID(int PersonID, ref int ShariaID, ref string ShariaLicenseNumber,
            ref bool IsLawyer, ref int PractitionerID, ref DateTime IssueDate, ref int? LastEditByUserID,
            ref int SubscriptionTypeID, ref int SubscriptionWayID, ref int CreatedByUserID, ref bool IsActive,
            ref Dictionary<int, string> CasesShariaPracticesIDNameDictionary)

        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_GetShariaInfoByPersonID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", PersonID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                // Read first result set

                                if (reader.Read())
                                {
                                    // The record was found
                                    isFound = true;
                                    PractitionerID = (int)reader["PractitionerID"];
                                    IsLawyer = (bool)reader["IsLawyer"];
                                    SubscriptionTypeID = (int)reader["SubscriptionTypeID"];
                                    SubscriptionWayID = (int)reader["SubscriptionWayID"];
                                }

                                // Read second result set
                                reader.NextResult();
                                if (reader.Read())
                                {
                                    // The record was found
                                    isFound = true;
                                    ShariaID = (int)reader["ShariaID"];
                                    IssueDate = (DateTime)reader["IssueDate"];
                                    ShariaLicenseNumber = (string)reader["ShariaLicenseNumber"];
                                    LastEditByUserID = reader["LastEditByUserID"] != DBNull.Value ? LastEditByUserID = (int)reader["LastEditByUserID"] : null;
                                    CreatedByUserID = (int)reader["CreatedByUserID"];
                                    IsActive = (bool)reader["IsActive"];
                                }

                                // Read second result set
                                reader.NextResult();
                                while (reader.Read())
                                {
                                    // Process the data from Sharias CasesPractice table
                                    int regulatoryCaseTypeId = reader.GetInt32(reader.GetOrdinal("ShariaCaseTypeID"));
                                    string regulatoryCaseTypeName = reader.GetString(reader.GetOrdinal("ShariaCaseTypeName"));

                                    CasesShariaPracticesIDNameDictionary.Add(regulatoryCaseTypeId, regulatoryCaseTypeName);
                                }
                            }
                            else
                            {
                                // The record was not found
                                isFound = false;
                            }
                        }

                    }
                    catch (SqlException ex)
                    {

                        clsDataAccessSettings.WriteEventToLogFile("Exception from Data Access layer clsSharia class, get info by person():\n" + ex.Message,
                            EventLogEntryType.Error);
                        //Console.WriteLine("Error: " + ex.Message);
                        isFound = false;
                    }
                    catch (Exception ex)
                    {

                        clsDataAccessSettings.WriteEventToLogFile("Exception from Data Access layer clsSharia class, get info by preson():\n" + ex.Message,
                            EventLogEntryType.Error);
                        //Console.WriteLine("Error: " + ex.Message);
                        isFound = false;
                    }

                }

            }

            return isFound;
        }

        public static bool GetShariaInfoByShariaLicenseNumber(string ShariaLicenseNumber, ref int PersonID, ref int ShariaID, ref int PractitionerID,
            ref bool IsLawyer, ref DateTime IssueDate, ref int? LastEditByUserID,
            ref int SubscriptionTypeID, ref int SubscriptionWayID, ref int CreatedByUserID, ref bool IsActive,
             ref Dictionary<int, string> CasesShariaPracticesIDNameDictionary)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {



                using (SqlCommand command = new SqlCommand("SP_GetShariaInfoByShariaLicenseNumber", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ShariaLicenseNumber", ShariaLicenseNumber);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                // Read first result set

                                if (reader.Read())
                                {
                                    // The record was found
                                    isFound = true;
                                    PractitionerID = (int)reader["PractitionerID"];
                                    IsLawyer = (bool)reader["IsLawyer"];
                                    PersonID = (int)reader["PersonID"];
                                    SubscriptionTypeID = (int)reader["SubscriptionTypeID"];
                                    SubscriptionWayID = (int)reader["SubscriptionWayID"];
                                }

                                // Read second result set
                                reader.NextResult();
                                if (reader.Read())
                                {
                                    // The record was found
                                    isFound = true;
                                    ShariaID = (int)reader["ShariaID"];
                                    IssueDate = (DateTime)reader["IssueDate"];
                                    LastEditByUserID = reader["LastEditByUserID"] != DBNull.Value ? LastEditByUserID = (int)reader["LastEditByUserID"] : null;
                                    CreatedByUserID = (int)reader["CreatedByUserID"];
                                    IsActive = (bool)reader["IsActive"];
                                }

                                // Read second result set
                                reader.NextResult();
                                while (reader.Read())
                                {
                                    // Process the data from ShariasCasesPractice table
                                    int regulatoryCaseTypeId = reader.GetInt32(reader.GetOrdinal("ShariaCaseTypeID"));
                                    string regulatoryCaseTypeName = reader.GetString(reader.GetOrdinal("ShariaCaseTypeName"));

                                    CasesShariaPracticesIDNameDictionary.Add(regulatoryCaseTypeId, regulatoryCaseTypeName);
                                }
                            }
                            else
                            {
                                // The record was not found
                                isFound = false;
                            }
                        }

                    }
                    catch (SqlException ex)
                    {

                        clsDataAccessSettings.WriteEventToLogFile("Exception from Data Access layer clsSharia class, get info by mebmer():\n" + ex.Message,
                            EventLogEntryType.Error);
                        //Console.WriteLine("Error: " + ex.Message);
                        isFound = false;
                    }
                    catch (Exception ex)
                    {

                        clsDataAccessSettings.WriteEventToLogFile("Exception from Data Access layer clsSharia class, get info by mebmer():\n" + ex.Message,
                            EventLogEntryType.Error);
                        //Console.WriteLine("Error: " + ex.Message);
                        isFound = false;
                    }


                }

            }

            return isFound;
        }

        public static bool GetShariaInfoByPractitionerID(int InputPractitionerID, ref int PersonID, ref int ShariaID,
            ref string ShariaLicenseNumber, ref bool IsLawyer, ref DateTime IssueDate, ref int? LastEditByUserID,
            ref int SubscriptionTypeID, ref int SubscriptionWayID, ref int CreatedByUserID, ref bool IsActive,
           ref Dictionary<int, string> CasesShariaPracticesIDNameDictionary)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {



                using (SqlCommand command = new SqlCommand("SP_GetShariaInfoByPractitionerID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PractitionerID", InputPractitionerID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                // Read first result set

                                if (reader.Read())
                                {
                                    // The record was found
                                    isFound = true;
                                    PersonID = (int)reader["PersonID"];
                                    IsLawyer = (bool)reader["IsLawyer"];
                                    SubscriptionTypeID = (int)reader["SubscriptionTypeID"];
                                    SubscriptionWayID = (int)reader["SubscriptionWayID"];
                                }

                                // Read second result set
                                reader.NextResult();
                                if (reader.Read())
                                {
                                    // The record was found
                                    isFound = true;
                                    ShariaID = (int)reader["ShariaID"];
                                    ShariaLicenseNumber = (string)reader["ShariaLicenseNumber"];
                                    IssueDate = (DateTime)reader["IssueDate"];
                                    LastEditByUserID = reader["LastEditByUserID"] != DBNull.Value ? LastEditByUserID = (int)reader["LastEditByUserID"] : null;
                                    CreatedByUserID = (int)reader["CreatedByUserID"];
                                    IsActive = (bool)reader["IsActive"];
                                }

                                // Read second result set
                                reader.NextResult();
                                while (reader.Read())
                                {
                                    // Process the data from ShariasCasesPractice table
                                    int regulatoryCaseTypeId = reader.GetInt32(reader.GetOrdinal("ShariaCaseTypeID"));
                                    string regulatoryCaseTypeName = reader.GetString(reader.GetOrdinal("ShariaCaseTypeName"));

                                    CasesShariaPracticesIDNameDictionary.Add(regulatoryCaseTypeId, regulatoryCaseTypeName);
                                }
                            }
                            else
                            {
                                // The record was not found
                                isFound = false;
                            }
                        }

                    }
                    catch (SqlException ex)
                    {

                        clsDataAccessSettings.WriteEventToLogFile("Exception from Data Access layer clsSharia class, get info by pracititonerID():\n" + ex.Message,
                            EventLogEntryType.Error);
                        //Console.WriteLine("Error: " + ex.Message);
                        isFound = false;
                    }
                    catch (Exception ex)
                    {

                        clsDataAccessSettings.WriteEventToLogFile("Exception from Data Access layer clsSharia class, get info by PRactitinoerID():\n" + ex.Message,
                            EventLogEntryType.Error);
                        //Console.WriteLine("Error: " + ex.Message);
                        isFound = false;
                    }


                }

            }

            return isFound;
        }

   
        /// <summary>
        ///Can create a new Sharia profile in database, and verify if it has a practitioner profile  or not .
        ///by default it is lawyer=true 
        /// <returns> List of three New IDs ([0]NewShariaID, [1]NewPractitionerID)</returns>
        public static (int NewShariaID, int NewPractitionerID) AddNewSharia(int PersonID, string ShariaLicenseNumber,
            int SubscriptionTypeID, int SubscriptionWayID, int CreatedByUserID, bool IsActive,
          Dictionary<int, string> CasesShariaPracticesIDNameDictionary)
        {
            int ShariaID = -1, PractitionerID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_AddNewSharia", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@ShariaLicenseNumber", ShariaLicenseNumber);
                    command.Parameters.AddWithValue("@SubscriptionTypeID", SubscriptionTypeID);
                    command.Parameters.AddWithValue("@SubscriptionWayID", SubscriptionWayID);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@IsActive", IsActive);


                    // Create table-valued parameter for cases IDs
                    // Iterate over cases and insert into  table-valued parameter
                    var ShariaCasesTable = new DataTable();
                    ShariaCasesTable.Columns.Add("CaseID", typeof(int));
                    foreach (int ShariaCaseID in CasesShariaPracticesIDNameDictionary.Keys)
                    {
                        ShariaCasesTable.Rows.Add(ShariaCaseID);
                    }
                    // Add table-valued parameter
                    SqlParameter parameter = command.Parameters.AddWithValue("@ShariaCasesPracticesIds", ShariaCasesTable);
                    parameter.SqlDbType = SqlDbType.Structured;
                    parameter.TypeName = "dbo.HashSetOfInt";// Replace "YourHashSetType" with the actual SQL Server type name


                    SqlParameter outputIdParam = new SqlParameter("@NewShariaID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };
                    SqlParameter outputIdParam2 = new SqlParameter("@OutputPractitionerID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };


                    command.Parameters.Add(outputIdParam);
                    command.Parameters.Add(outputIdParam2);

                    try
                    {
                        connection.Open();

                        command.ExecuteNonQuery();
                        ShariaID = (int)command.Parameters["@NewShariaID"].Value;
                        PractitionerID = (int)command.Parameters["@OutputPractitionerID"].Value;

                    }
                    catch (SqlException ex)
                    {
                        clsDataAccessSettings.WriteEventToLogFile("sharia data access class , add to database method()\nSQL EXCEPTION:" + ex.Message, System.Diagnostics.EventLogEntryType.Error);

                        Console.WriteLine("SQL Error occurred: " + ex.Message);

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSettings.WriteEventToLogFile("sharia data access class , add to database method()\n" + ex.Message, System.Diagnostics.EventLogEntryType.Error);

                        Console.WriteLine();
                    }
                }

            }

            return (ShariaID, PractitionerID);

        }
        /// <summary>
        /// I passed the only available  or allowed parameter for updating 
        /// </summary>
        /// <returns>Is it updated successfully or not </returns>
        public static bool UpdateSharia(int ShariaID, int PractitionerID, string ShariaLicenseNumber,
            int SubscriptionTypeID, int SubscriptionWayID, bool IsActive,
           int? LastEditByUserID, Dictionary<int, string> CasesShariaPracticesIDNameDictionary)
        {

            int EffectedRows = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_UpdateSharia", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;


                    command.Parameters.AddWithValue("@ShariaID", ShariaID);
                    command.Parameters.AddWithValue("@PractitionerID", PractitionerID);
                    command.Parameters.AddWithValue("@ShariaLicenseNumber", ShariaLicenseNumber);
                    command.Parameters.AddWithValue("@SubscriptionTypeID", SubscriptionTypeID);
                    command.Parameters.AddWithValue("@SubscriptionWayID", SubscriptionWayID);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@LastEditByUserID", LastEditByUserID);


                    // Create table-valued parameter for cases IDs
                    // Iterate over cases and insert into  table-valued parameter
                    var CasesTable = new DataTable();
                    CasesTable.Columns.Add("CaseID", typeof(int));
                    foreach (int CaseID in CasesShariaPracticesIDNameDictionary.Keys)
                    {
                        CasesTable.Rows.Add(CaseID);
                    }
                    // Add table-valued parameter
                    SqlParameter parameter = command.Parameters.AddWithValue("@ShariaCasesPracticesIds", CasesTable);
                    parameter.SqlDbType = SqlDbType.Structured;
                    parameter.TypeName = "dbo.HashSetOfInt";// Replace "YourHashSetType" with the actual SQL Server type name


                    try
                    {
                        connection.Open();
                        EffectedRows = command.ExecuteNonQuery();

                    }
                    catch (SqlException ex)
                    {
                        clsDataAccessSettings.WriteEventToLogFile("sharia data access class , update  method()\n" + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                        return false;
                    }
                }

            }

            return EffectedRows > 0;

        }

        public static bool DeletePermanently(int? shariaID)
         => clsDataAccessHelper.Delete("SP_DeleteShariaPermanently", "ShariaID", shariaID);

        public static bool Deactivate(int ShariaID, int LastEditByUserID)
           => clsDataAccessHelper.Deactivate("SP_DeactivateSharia", "ShariaID", ShariaID, "LastEditByUserID", LastEditByUserID);
        public static bool Activate(int ShariaID, int LastEditByUserID)
            => clsDataAccessHelper.Activate("SP_ActivateSharia", "ShariaID", ShariaID, "LastEditByUserID", LastEditByUserID);

        public static int Count(bool IsDraft = false) => clsDataAccessHelper.Count("SP_GetTotalShariasCount", IsDraft);

        public static DataTable GetShariasPerPage(ushort pageNumber, uint rowsPerPage, bool IsDraft = false) => 
            clsDataAccessHelper.AllInPages(pageNumber, rowsPerPage, "SP_GetShariasPerPage", IsDraft);
        public static bool IsExistsInWhiteListByPractitionerIDAndPractitionerTypeID(int? PractitionerID, int? PractitionerTypeID)
          => clsDataAccessHelper.Exists("SP_IsPractitionerInWhiteList", "PractitionerID", PractitionerID, "PractitionerTypeID", PractitionerTypeID);

        public static bool IsExistsInClosedListByPractitionerIDAndPractitionerTypeID(int? PractitionerID, int? PractitionerTypeID)
        => clsDataAccessHelper.Exists("SP_IsPractitionerInClosedList", "PractitionerID", PractitionerID, "PractitionerTypeID", PractitionerTypeID);
        public static bool ExistsByShariaID(int? shariaID)
            => clsDataAccessHelper.Exists("SP_IsShariaExistsByShariaID", "ShariaID", shariaID);

        public static bool ExistsByPersonID(int? personID)
            => clsDataAccessHelper.Exists("SP_IsShariaExistsByPersonID", "PersonID", personID);

        public static bool ExistsByPractitionerID(int? practitionerID)
            => clsDataAccessHelper.Exists("SP_IsShariaExistsByPractitionerID", "PractitionerID", practitionerID);
        public static bool ExistsByShariaLicenseNumber(string ShariaLicenseNumber)
        => clsDataAccessHelper.Exists("SP_IsShariaExistsByShariaLicenseNumber", "ShariaLicenseNumber", ShariaLicenseNumber);

        public static DataTable All()
            => clsDataAccessHelper.All("SP_GetAllSharias");




    }

}
