using MallMembership.Entities;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MallMemebership.DataLayer
{
    public class EmploymentDL :IEmploymentDL
    {
        
        string connectionString = ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString();
        public bool AddEmploymentDA(EmploymentInfo employmentInfo)
        {
            try
            {
                SqlCommand cmd;
                  SqlConnection connection = new SqlConnection(connectionString);
                if (employmentInfo.EmploymentType=="UnEmployed")
                {
                    String query = string.Format("insert into tblEmploymentInfo (EmploymentType,ApplicantId) values('{0}',{1})",employmentInfo.EmploymentType,employmentInfo.ApplicantId);
                    cmd = new SqlCommand(query, connection);
                   }
                else {
                    cmd = new SqlCommand("spInsertEmployment", connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@EmploymentType", employmentInfo.EmploymentType);
                    cmd.Parameters.AddWithValue("@Company", employmentInfo.Company);
                    cmd.Parameters.AddWithValue("@Position", employmentInfo.Position);
                    cmd.Parameters.AddWithValue("@Salary", employmentInfo.Salary);
                    cmd.Parameters.AddWithValue("@ApplicantId", employmentInfo.ApplicantId);
                }
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



        public EmploymentInfo GetEmploymentByIdDA(int id)
        {
            try
            {
                EmploymentInfo employmentInfo = new EmploymentInfo();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "select * from tblEmploymentInfo where ApplicantId=" + id;
                    SqlCommand cmd = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        employmentInfo.EmploymentType = dataReader["EmploymentType"].ToString();
                        if (employmentInfo.EmploymentType=="UnEmployed")
                        {
                            return employmentInfo;

                        }
                        else
                        {

                        }
                        employmentInfo.Company = dataReader["Company"].ToString();
                        employmentInfo.Position = dataReader["Position"].ToString();
                       // employmentInfo.EmploymentType = dataReader["EmploymentType"].ToString();
                        employmentInfo.Salary = Convert.ToInt32(dataReader["Salary"]);
                    }

                }
                return employmentInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateEmploymentDA(EmploymentInfo employmentInfo)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("spUpdateEmployment", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@EmploymentType", employmentInfo.EmploymentType);
                cmd.Parameters.AddWithValue("@Company", employmentInfo.Company);
                cmd.Parameters.AddWithValue("@Position", employmentInfo.Position);
                cmd.Parameters.AddWithValue("@Salary", employmentInfo.Salary);
                cmd.Parameters.AddWithValue("@ApplicantId", employmentInfo.ApplicantId);

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


    }
}

