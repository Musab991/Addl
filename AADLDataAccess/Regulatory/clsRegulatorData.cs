﻿using AADL_DataAccess;
using AADL_DataAccess.HelperClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;
using static AADLDataAccess.Judger.clsJudgerData;

namespace AADLDataAccess
{
    /// <summary>
    /// To Stored_Procedure not ,yet.
    /// </summary>
    public class clsRegulatorData
    {
        public enum enWhichID { RegulatorID = 1, PractitionerID, PersonID }

        public static bool GetRegulatorInfoByRegulatorID(int RegulatorID,ref int PersonID,ref string MembershipNumber,
            ref bool IsLawyer,ref int PractitionerID, ref DateTime IssueDate,ref int? LastEditByUserID,
            ref int SubscriptionTypeID,ref int SubscriptionWayID,ref int CreatedByUserID,ref bool IsActive,
           ref Dictionary<int, string> CasesRegulatorPracticesIDNameDictionary)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_GetRegulatorInfoByRegulatorID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                  
                    command.Parameters.AddWithValue("@RegulatorID", RegulatorID);

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
                                    RegulatorID = (int)reader["RegulatorID"];
                                    PractitionerID = (int)reader["PractitionerID"];
                                    MembershipNumber = (string)reader["MembershipNumber"];
                                    IssueDate = (DateTime)reader["IssueDate"];
                                    LastEditByUserID = reader["LastEditByUserID"] != DBNull.Value ? LastEditByUserID=(int)reader["LastEditByUserID"] : null;
                                    CreatedByUserID = (int)reader["CreatedByUserID"];
                                    IsActive = (bool)reader["IsActive"];
                                }

                                // Read second result set
                                reader.NextResult();
                                while (reader.Read())
                                {
                                    // Process the data from RegulatorsCasesPractice table
                                    int regulatoryCaseTypeId = reader.GetInt32(reader.GetOrdinal("RegulatoryCaseTypeID"));
                                    string regulatoryCaseTypeName = reader.GetString(reader.GetOrdinal("RegulatoryCaseTypeName"));

                                    CasesRegulatorPracticesIDNameDictionary.Add(regulatoryCaseTypeId, regulatoryCaseTypeName);
                                    isFound = true;

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

                        clsDataAccessSettings.WriteEventToLogFile("Exception from Data Access layer clsRegulator class, get info by id():\n" + ex.Message,
                            EventLogEntryType.Error);
                        //Console.WriteLine("Error: " + ex.Message);
                        isFound = false;
                    }
                    catch (Exception ex)
                    {

                        clsDataAccessSettings.WriteEventToLogFile("Exception from Data Access layer clsRegulator class, get info by id():\n" + ex.Message,
                            EventLogEntryType.Error);
                        //Console.WriteLine("Error: " + ex.Message);
                        isFound = false;
                    }
                }

            }

            return isFound;
        }

        public static bool GetRegulatorInfoByPersonID(int PersonID, ref int RegulatorID, ref string MembershipNumber,
            ref bool IsLawyer, ref int PractitionerID, ref DateTime IssueDate,ref  int? LastEditByUserID, 
            ref int SubscriptionTypeID, ref int SubscriptionWayID, ref int CreatedByUserID, ref bool IsActive,
            ref Dictionary<int, string> CasesRegulatorPracticesIDNameDictionary)

        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_GetRegulatorInfoByPersonID", connection))
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
                                    RegulatorID = (int)reader["RegulatorID"];
                                    IssueDate = (DateTime)reader["IssueDate"];
                                    MembershipNumber = (string)reader["MembershipNumber"];
                                    LastEditByUserID = reader["LastEditByUserID"] != DBNull.Value ? LastEditByUserID = (int)reader["LastEditByUserID"] : null;
                                    CreatedByUserID = (int)reader["CreatedByUserID"];
                                    IsActive = (bool)reader["IsActive"];
                                }

                                // Read second result set
                                reader.NextResult();
                                while (reader.Read())
                                {
                                    // Process the data from RegulatorsCasesPractice table
                                    int regulatoryCaseTypeId = reader.GetInt32(reader.GetOrdinal("RegulatoryCaseTypeID"));
                                    string regulatoryCaseTypeName = reader.GetString(reader.GetOrdinal("RegulatoryCaseTypeName"));

                                    CasesRegulatorPracticesIDNameDictionary.Add(regulatoryCaseTypeId, regulatoryCaseTypeName);
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

                        clsDataAccessSettings.WriteEventToLogFile("Exception from Data Access layer clsRegulator class, get info by person():\n" + ex.Message,
                            EventLogEntryType.Error);
                        //Console.WriteLine("Error: " + ex.Message);
                        isFound = false;
                    }
                    catch (Exception ex)
                    {

                        clsDataAccessSettings.WriteEventToLogFile("Exception from Data Access layer clsRegulator class, get info by preson():\n" + ex.Message,
                            EventLogEntryType.Error);
                        //Console.WriteLine("Error: " + ex.Message);
                        isFound = false;
                    }

                }

            }

            return isFound;
        }

        public static bool GetRegulatorInfoByMembershipNumber(string MembershipNumber, ref int PersonID, ref int RegulatorID, ref int PractitionerID, 
            ref bool IsLawyer,ref DateTime IssueDate, ref int? LastEditByUserID,  
            ref int SubscriptionTypeID, ref int SubscriptionWayID,ref int CreatedByUserID, ref bool IsActive,
             ref Dictionary<int,string> CasesRegulatorPracticesIDNameDictionary)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {



                using (SqlCommand command = new SqlCommand("SP_GetRegulatorInfoByMebmershipNumber", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@MembershipNumber", MembershipNumber);

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
                                    RegulatorID = (int)reader["RegulatorID"];
                                    IssueDate = (DateTime)reader["IssueDate"];
                                    LastEditByUserID = reader["LastEditByUserID"] != DBNull.Value ? LastEditByUserID = (int)reader["LastEditByUserID"] : null;
                                    CreatedByUserID = (int)reader["CreatedByUserID"];
                                    IsActive = (bool)reader["IsActive"];
                                }

                                // Read second result set
                                reader.NextResult();
                                while (reader.Read())
                                {
                                    // Process the data from RegulatorsCasesPractice table
                                    int regulatoryCaseTypeId = reader.GetInt32(reader.GetOrdinal("RegulatoryCaseTypeID"));
                                    string regulatoryCaseTypeName = reader.GetString(reader.GetOrdinal("RegulatoryCaseTypeName"));

                                    CasesRegulatorPracticesIDNameDictionary.Add(regulatoryCaseTypeId, regulatoryCaseTypeName);
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

                        clsDataAccessSettings.WriteEventToLogFile("Exception from Data Access layer clsRegulator class, get info by mebmer():\n" + ex.Message,
                            EventLogEntryType.Error);
                        //Console.WriteLine("Error: " + ex.Message);
                        isFound = false;
                    }
                    catch (Exception ex)
                    {

                        clsDataAccessSettings.WriteEventToLogFile("Exception from Data Access layer clsRegulator class, get info by mebmer():\n" + ex.Message,
                            EventLogEntryType.Error);
                        //Console.WriteLine("Error: " + ex.Message);
                        isFound = false;
                    }


                }

            }

            return isFound;
        }

        public static bool GetRegulatorInfoByPractitionerID(int InputPractitionerID, ref int PersonID, ref int RegulatorID,
            ref string MembershipNumber, ref bool IsLawyer, ref DateTime IssueDate, ref int? LastEditByUserID, 
            ref int SubscriptionTypeID, ref int SubscriptionWayID, ref int CreatedByUserID, ref bool IsActive,
           ref Dictionary<int, string> CasesRegulatorPracticesIDNameDictionary)
        {
            bool isFound = false;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {



                using (SqlCommand command = new SqlCommand("SP_GetRegulatorInfoByPractitionerID", connection))
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
                                    RegulatorID = (int)reader["RegulatorID"];
                                    MembershipNumber = (string)reader["MembershipNumber"];
                                    IssueDate = (DateTime)reader["IssueDate"];
                                    LastEditByUserID = reader["LastEditByUserID"] != DBNull.Value ? LastEditByUserID = (int)reader["LastEditByUserID"] : null;
                                    CreatedByUserID = (int)reader["CreatedByUserID"];
                                    IsActive = (bool)reader["IsActive"];
                                }

                                // Read second result set
                                reader.NextResult();
                                while (reader.Read())
                                {
                                    // Process the data from RegulatorsCasesPractice table
                                    int regulatoryCaseTypeId = reader.GetInt32(reader.GetOrdinal("RegulatoryCaseTypeID"));
                                    string regulatoryCaseTypeName = reader.GetString(reader.GetOrdinal("RegulatoryCaseTypeName"));

                                    CasesRegulatorPracticesIDNameDictionary.Add(regulatoryCaseTypeId, regulatoryCaseTypeName);
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

                        clsDataAccessSettings.WriteEventToLogFile("Exception from Data Access layer clsRegulator class, get info by pracititonerID():\n" + ex.Message,
                            EventLogEntryType.Error);
                        //Console.WriteLine("Error: " + ex.Message);
                        isFound = false;
                    }
                    catch (Exception ex)
                    {

                        clsDataAccessSettings.WriteEventToLogFile("Exception from Data Access layer clsRegulator class, get info by PRactitinoerID():\n" + ex.Message,
                            EventLogEntryType.Error);
                        //Console.WriteLine("Error: " + ex.Message);
                        isFound = false;
                    }


                }

            }

            return isFound;
        }

        /// <summary>
        ///Can create a new regulator profile in database, and verify if it has a practitioner profile or not .
        ///Note: I don't supply the method with  IsLawyer boolean , or practitioner ID , because it will be either created or selected in T-SQL.
        ///and Regulator is standard for IsLawyer =true
        /// <returns> List of three New IDs ([0]RegulatorID,[1]PractitionerID)</returns>
        public static (int NewRegulatorID, int NewPractitionerID) AddNewRegulator(int? PersonID,  string MembershipNumber,
            int SubscriptionTypeID,int SubscriptionWayID,  int CreatedByUserID,bool IsActive,
            Dictionary<int, string> CasesRegulatorPracticesIDNameDictionary)
        {
            int RegulatorID = -1, PractitionerID = -1;

            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_AddNewRegulator", connection))
                {

                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@PersonID", PersonID);
                    command.Parameters.AddWithValue("@MembershipNumber", MembershipNumber);
                    command.Parameters.AddWithValue("@SubscriptionTypeID", SubscriptionTypeID);
                    command.Parameters.AddWithValue("@SubscriptionWayID", SubscriptionWayID);
                    command.Parameters.AddWithValue("@CreatedByUserID", CreatedByUserID);
                    command.Parameters.AddWithValue("@IsActive", IsActive);

                    // Create table-valued parameter for cases IDs
                    // Iterate over cases and insert into  table-valued parameter
                    var CasesTable = new DataTable();
                    CasesTable.Columns.Add("CaseID", typeof(int));
                    foreach (int CaseID in CasesRegulatorPracticesIDNameDictionary.Keys)
                    {
                        CasesTable.Rows.Add(CaseID);
                    }
                    // Add table-valued parameter
                    SqlParameter parameter = command.Parameters.AddWithValue("@RegulatoryCasesPracticesIds", CasesTable);
                    parameter.SqlDbType = SqlDbType.Structured;
                    parameter.TypeName = "dbo.HashSetOfInt";// Replace "YourHashSetType" with the actual SQL Server type name


                    SqlParameter outputIdParam = new SqlParameter("@NewRegulatorID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(outputIdParam);
                    SqlParameter outputIdParam2 = new SqlParameter("@OUTPUTPractitionerID", SqlDbType.Int)
                    {
                        Direction = ParameterDirection.Output
                    };

                    command.Parameters.Add(outputIdParam2);

                    try
                    {
                        connection.Open();

                        command.ExecuteNonQuery();
                        RegulatorID = (int)command.Parameters["@NewRegulatorID"].Value;
                        PractitionerID = (int)command.Parameters["@OUTPUTPractitionerID"].Value;

                    }
                    catch (SqlException ex)
                    {
                        clsDataAccessSettings.WriteEventToLogFile("regulator data access class , add to database method()\nSQL EXCEPTION:" + ex.Message, System.Diagnostics.EventLogEntryType.Error);

                        Console.WriteLine("SQL Error occurred: " + ex.Message);

                    }
                    catch (Exception ex)
                    {
                        clsDataAccessSettings.WriteEventToLogFile("regulator data access class , add to database method()\n"+ex.Message, System.Diagnostics.EventLogEntryType.Error);
                        Console.WriteLine(ex.Message);
                    }
                }

            }

            return (RegulatorID, PractitionerID);

        }

        /// <summary>
        /// It accepts only the parameter that can be real changes, other properties ain't available to re-change after was created.
        /// </summary>
        /// <returns>Is it updated successfully or not</returns>
        public static bool UpdateRegulator(int? RegulatorID,int PractitionerID, string MembershipNumber,
          int LastEditByUserID, int SubscriptionTypeID, int SubscriptionWayID, bool IsActive,
           Dictionary<int, string> CasesRegulatorPracticesIDNameDictionary)
        {

            int TotalEffectedRows = 0;
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_UpdateRegulator", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@RegulatorID", RegulatorID);
                    command.Parameters.AddWithValue("@PractitionerID", PractitionerID);
                    command.Parameters.AddWithValue("@MembershipNumber", MembershipNumber);
                    command.Parameters.AddWithValue("@SubscriptionTypeID", SubscriptionTypeID);
                    command.Parameters.AddWithValue("@SubscriptionWayID", SubscriptionWayID);
                    command.Parameters.AddWithValue("@IsActive", IsActive);
                    command.Parameters.AddWithValue("@LastEditByUserID", LastEditByUserID);
                        
                    // Create table-valued parameter for cases IDs
                    // Iterate over cases and insert into  table-valued parameter
                    var CasesTable = new DataTable();
                    CasesTable.Columns.Add("CaseID", typeof(int));
                    foreach (int CaseID in CasesRegulatorPracticesIDNameDictionary.Keys)
                    {
                        CasesTable.Rows.Add(CaseID);
                    }
                    // Add table-valued parameter
                    SqlParameter parameter = command.Parameters.AddWithValue("@RegulatoryCasesPracticesIds", CasesTable);
                    parameter.SqlDbType = SqlDbType.Structured;
                    parameter.TypeName = "dbo.HashSetOfInt";// Replace "YourHashSetType" with the actual SQL Server type name


                    try
                    {
                        connection.Open();
                        TotalEffectedRows = command.ExecuteNonQuery();
                    }
                    catch (SqlException ex)
                    {
                        clsDataAccessSettings.WriteEventToLogFile("regulator data access class , update  method()\n" + ex.Message, System.Diagnostics.EventLogEntryType.Error);
                        return false;
                    }
                }

            }

            return TotalEffectedRows>0;

        }
       
        public async static Task<DataTable> GetAllRegulatorsAsync()
        {

            DataTable dt = new DataTable();
            using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
            {

                using (SqlCommand command = new SqlCommand("SP_GetAllRegulatorsInfo_View", connection))
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
                        clsDataAccessSettings.WriteEventToLogFile("Exception comes from data access layer of Regulators class , where data grid view load all people method dropped:\n"
                            + ex.Message, EventLogEntryType.Error);
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }

            }

            return dt;

        }

        public static DataTable All(string StoredProcedure )
                   => clsDataAccessHelper.All(StoredProcedure);
   
        /// <summary>
        /// Able to handle deleting process for both regulator info , and its cases practices.
        /// Also,it handles it relationship with Lawyer Profile , and Practitioner profile
        /// </summary>
        /// <param name="RegulatorID"></param>
        /// <returns>Weather it was deleted successfully or not.</returns>

        public static bool DeletePermanently(int? RegulatorID)
            => clsDataAccessHelper.Delete("SP_DeleteRegulatorPermanently", "RegulatorID", RegulatorID);

      
        public static bool Deactivate(int RegulatorID,int LastEditByUserID)
          => clsDataAccessHelper.Deactivate("SP_DeactivateRegulator", "RegulatorID", RegulatorID,"LastEditByUserID", LastEditByUserID);
        public static bool Activate(int RegulatorID, int LastEditByUserID)
            => clsDataAccessHelper.Activate("SP_ActivateRegulator", "RegulatorID", RegulatorID, "LastEditByUserID", LastEditByUserID);
        public static bool ExistsByRegulatorID(int? shariaID)
         => clsDataAccessHelper.Exists("SP_IsRegulatorExistsByRegulatorID", "RegulatorID", shariaID);

        public static bool ExistsByPersonID(int? personID)
            => clsDataAccessHelper.Exists("SP_IsRegulatorExistsByPersonID", "PersonID", personID);

        public static bool ExistsByPractitionerID(int? practitionerID)
            => clsDataAccessHelper.Exists("SP_IsRegulatorExistsByPractitionerID", "PractitionerID", practitionerID);
        public static bool ExistsByMembershipNumber(string MembershipNumber)
        => clsDataAccessHelper.Exists("SP_IsRegulatorExistsByMembershipNumber", "MembershipNumber", MembershipNumber);
  
        public static int Count(bool IsDraft = false) => clsDataAccessHelper.Count("SP_GetTotalRegulatorsCount",IsDraft);

        public static DataTable GetRegulatorsPerPage(ushort pageNumber, uint rowsPerPage,bool IsDraft=false) => clsDataAccessHelper.AllInPages(pageNumber, rowsPerPage, "SP_GetRegulatorsPerPage",IsDraft);

        public static bool IsExistsInWhiteListByPractitionerIDAndPractitionerTypeID(int? PractitionerID, int? PractitionerTypeID)
        => clsDataAccessHelper.Exists("SP_IsPractitionerInWhiteList", "PractitionerID", PractitionerID, "PractitionerTypeID", PractitionerTypeID);

        public static bool IsExistsInClosedListByPractitionerIDAndPractitionerTypeID(int? PractitionerID, int? PractitionerTypeID)
        => clsDataAccessHelper.Exists("SP_IsPractitionerInClosedList", "PractitionerID", PractitionerID, "PractitionerTypeID", PractitionerTypeID);
    }

}
