using AADL_DataAccess;
using AADL_DataAccess.HelperClasses;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Linq;

namespace AADLDataAccess.Expert
{
    public class clsExpertCaseTypeData
    {
        public static bool GetInfoByCaseTypeID(int? expertCaseTypeID, ref string expertCaseTypeName)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetExpertCaseTypeInfoByCaseTypeID", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ExpertCaseTypeID", (object)expertCaseTypeID ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;

                                expertCaseTypeName = (string)reader["ExpertCaseTypeName"];
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

        public static bool GetInfoByCaseTypeName(string expertCaseTypeName, ref int? expertCaseTypeID)
        {
            bool isFound = false;

            try
            {
                using (SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("SP_GetExpertCaseTypeInfoByCaseTypeName", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@ExpertCaseTypeName", (object)expertCaseTypeName ?? DBNull.Value);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // The record was found
                                isFound = true;

                                expertCaseTypeID = (reader["ExpertCaseTypeID"] != DBNull.Value) ? (int?)reader["ExpertCaseTypeID"] : null;
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

        public static int? Add(string name)
            => clsCaseTypeData.Add(name, clsCaseTypeData.enWhichPractitioner.Expert);
        public static bool Update(int ID, string name)
            => clsCaseTypeData.Update(ID, name, clsCaseTypeData.enWhichPractitioner.Expert);

        public static bool Delete(int ID)
            => clsCaseTypeData.Delete(ID, clsCaseTypeData.enWhichPractitioner.Expert);

        public static bool Exists(string name)
            => clsCaseTypeData.Exists(name, clsCaseTypeData.enWhichPractitioner.Expert);

        public static DataTable All()
        => clsDataAccessHelper.All("SP_GetAllExpertCasesTypes");
    }
}