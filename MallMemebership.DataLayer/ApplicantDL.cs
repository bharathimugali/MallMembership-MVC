using MallMembership.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace MallMemebership.DataLayer
{
    public class ApplicantDL : IApplicantDL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString();
        public bool AddApplicantDA(ApplicantInfo applicantInfo)
        {
            try
            {
                int i;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("spInsertApplicant", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@FirstName", applicantInfo.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", applicantInfo.LastName);
                        cmd.Parameters.AddWithValue("@PhoneNumber", applicantInfo.PhoneNumber);
                        cmd.Parameters.AddWithValue("@Email", applicantInfo.Email);
                        cmd.Parameters.AddWithValue("@HighestCompletedStage", applicantInfo.HighestCompletedStage);
                        cmd.Parameters.AddWithValue("@UserAgent", applicantInfo.UserAgent);
                        cmd.Parameters.AddWithValue("@IPAddress", applicantInfo.IPAddress);
                        cmd.Parameters.AddWithValue("@ContentType", applicantInfo.ContentType);
                        connection.Open();
                        i = cmd.ExecuteNonQuery();
                        connection.Close();
                    }
                }
                if (i >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ApplicantInfo GetRecentApplicantDA()
        {
            try
            {
                ApplicantInfo applicantInfo = new ApplicantInfo();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "select top 1 * from tblApplicantInfo order by ApplicantId desc";
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {

                        connection.Open();
                        SqlDataReader dataReader = cmd.ExecuteReader();
                        while (dataReader.Read())
                        {

                            applicantInfo.ApplicantId = Convert.ToInt32(dataReader["ApplicantId"]);
                            applicantInfo.FirstName = dataReader["FirstName"].ToString();
                            applicantInfo.LastName = dataReader["LastName"].ToString();
                            applicantInfo.PhoneNumber = dataReader["PhoneNumber"].ToString();
                            applicantInfo.Email = dataReader["Email"].ToString();
                            applicantInfo.HighestCompletedStage = Convert.ToInt32(dataReader["HighestCompletedStage"]);

                        }
                    }
                }
                return applicantInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ApplicantInfo GetApplicantByIdDA(int id)
        {
            try
            {
                ApplicantInfo applicantInfo = new ApplicantInfo();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "select * from tblApplicantInfo where ApplicantId=" + id;
                    SqlCommand cmd = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {

                        applicantInfo.ApplicantId = Convert.ToInt32(dataReader["ApplicantId"]);
                        applicantInfo.FirstName = dataReader["FirstName"].ToString();
                        applicantInfo.LastName = dataReader["LastName"].ToString();
                        applicantInfo.PhoneNumber = dataReader["PhoneNumber"].ToString();
                        applicantInfo.Email = dataReader["Email"].ToString();
                        applicantInfo.HighestCompletedStage = Convert.ToInt32(dataReader["HighestCompletedStage"]);
                    }

                }
                return applicantInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateApplicantDA(ApplicantInfo applicantInfo)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("spUpdateApplicant", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ApplicantId", applicantInfo.ApplicantId);
                cmd.Parameters.AddWithValue("@FirstName", applicantInfo.FirstName);
                cmd.Parameters.AddWithValue("@LastName", applicantInfo.LastName);
                cmd.Parameters.AddWithValue("@PhoneNumber", applicantInfo.PhoneNumber);
                cmd.Parameters.AddWithValue("@Email", applicantInfo.Email);
                cmd.Parameters.AddWithValue("@HighestCompletedStage", applicantInfo.HighestCompletedStage);
                cmd.Parameters.AddWithValue("@UserAgent", applicantInfo.UserAgent);
                cmd.Parameters.AddWithValue("@IPAddress", applicantInfo.IPAddress);
                cmd.Parameters.AddWithValue("@ContentType", applicantInfo.ContentType);
                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public bool AddExceptionDA(ExceptionLogging exceptionLogging)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("spInsertException", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ActionName", exceptionLogging.ActionName);
                cmd.Parameters.AddWithValue("@ControllerName", exceptionLogging.ControllerName);
                cmd.Parameters.AddWithValue("@ExceptionLogTime", exceptionLogging.ExceptionLogTime);
                cmd.Parameters.AddWithValue("@ExceptionStackTrack", exceptionLogging.ExceptionStackTrack);
                cmd.Parameters.AddWithValue("@ExceptionMessage", exceptionLogging.ExceptionMessage);

                connection.Open();
                int i = cmd.ExecuteNonQuery();
                connection.Close();
                if (i >= 1)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CustomApplicant> GetApplicants()
        {
            try
            {
               List<CustomApplicant> applicants = new List<CustomApplicant>();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand cmd = new SqlCommand("spGetApplicant", connection);

                    connection.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        CustomApplicant applicantInfo = new CustomApplicant();
                        applicantInfo.ApplicantId = Convert.ToInt32(dataReader["ApplicantId"]);
                        applicantInfo.FirstName = dataReader["FirstName"].ToString();
                        applicantInfo.LastName = dataReader["LastName"].ToString();
                        applicantInfo.PhoneNumber = dataReader["PhoneNumber"].ToString();
                        applicantInfo.Email = dataReader["Email"].ToString();
                      applicants.Add(applicantInfo);
                    }
                   
                }
                return applicants;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
