using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineGasAgencySystem.Models;

namespace OnlineGasAgencySystem.DataAccess
{
    public class PaymentDB
    {
        private string ConnectionString = string.Empty;
        SqlConnection sqlConnection;
    }
    /*public PaymentDB()
    {
        ConnectionString = ConfigurationSettings.AppSettings["DataBaseConnection"];
        sqlConnection = new SqlConnection(ConnectionString);
    }
    public Payment GetPayment(string username)
    {
        Payment payment = new Payment();
        try
        {
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "SP_GET_USERProfile";
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@UserName", username);
            sqlCommand.Connection = sqlConnection;
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            while (sqlDataReader.Read())
            {

            }

        }
        catch (SystemException ex)
        {
            throw;
        }
        finally
        {
            sqlConnection.Close();
        }
        return payment;
    }*/
}