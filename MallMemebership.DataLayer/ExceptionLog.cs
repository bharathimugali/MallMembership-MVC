using MallMembership.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace MallMemebership.DataLayer
{
   public class ExceptionLog
    {
        public bool AddException(ExceptionLogging exceptionLogging)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnStringDb"].ToString();

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

       
        
    }
}
