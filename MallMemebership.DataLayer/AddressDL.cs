using MallMembership.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Xml;

namespace MallMemebership.DataLayer
{
  public  class AddressDL :  IAddressDL
    {
        string connectionString = ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString();
        public bool AddAddressDA(AddressInfo addressInfo)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("spInsertAddress", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Country",addressInfo.Country);
                cmd.Parameters.AddWithValue("@State", addressInfo.State);
                cmd.Parameters.AddWithValue("@City",addressInfo.City);
                cmd.Parameters.AddWithValue("@Street",addressInfo.Street );
                cmd.Parameters.AddWithValue("@ApplicantId", addressInfo.ApplicantId);
                
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

       

        public AddressInfo GetAddressByIdDA(int id)
        {
            try
            {
                AddressInfo addressInfo = new AddressInfo();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "select * from tblAddressInfo where ApplicantId=" + id;
                    SqlCommand cmd = new SqlCommand(query, connection);

                    connection.Open();
                    SqlDataReader dataReader = cmd.ExecuteReader();
                    while (dataReader.Read())
                    {
                        //dataReader.GetString(dataReader.GetOrdinal("AddressId"));
                        addressInfo.AddressId = Convert.ToInt32(dataReader["AddressId"]);
                        addressInfo.Country = dataReader["Country"].ToString();
                        addressInfo.State = dataReader["State"].ToString();
                        addressInfo.City = dataReader["City"].ToString();
                        addressInfo.Street = dataReader["Street"].ToString();
                        addressInfo.ApplicantId = Convert.ToInt32(dataReader["ApplicantId"]);
                    }
                
                }
                
                return addressInfo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool UpdateAddressDA(AddressInfo addressInfo)
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand("spUpdateAddress", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Country", addressInfo.Country);
                cmd.Parameters.AddWithValue("@State", addressInfo.State);
                cmd.Parameters.AddWithValue("@City", addressInfo.City);
                cmd.Parameters.AddWithValue("@Street", addressInfo.Street);
                cmd.Parameters.AddWithValue("@ApplicantId", addressInfo.ApplicantId);

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
