using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace MallMemebership.DataLayer
{
    public class StageDL : IStageDL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString();
        public int GetCompleteStage(int id)
        {
            try
            {
                int highestCompletedStage;
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "select HighestCompletedStage from tblApplicantInfo where ApplicantId=" + id;
                    SqlCommand cmd = new SqlCommand(query, connection);

                    connection.Open();
                    highestCompletedStage = (int)cmd.ExecuteScalar();

                }
                return highestCompletedStage;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateCompleteStage(int id, int stage)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "update tblApplicantInfo set HighestCompletedStage=" + stage + "  where ApplicantId=" + id;
                    SqlCommand cmd = new SqlCommand(query, connection);

                    connection.Open();
                    cmd.ExecuteNonQuery();

                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
