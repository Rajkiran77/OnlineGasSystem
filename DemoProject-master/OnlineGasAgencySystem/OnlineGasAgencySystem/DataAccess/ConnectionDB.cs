using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using OnlineGasAgencySystem.Helper;
using OnlineGasAgencySystem.Models;

namespace OnlineGasAgencySystem.DataAccess
{
    public class ConnectionDB
    {
        private string ConnectionString = string.Empty;
        SqlConnection sqlConnection;
        public ConnectionDB()
        {
            ConnectionString = ConfigurationSettings.AppSettings["DataBaseConnection"];
            sqlConnection = new SqlConnection(ConnectionString);
        }
        public Connection GetConnection(int userId)
        {
            Connection connection = new Connection();
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText =Constant.SPGETCONNECTION;
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserID",userId);
                sqlCommand.Connection = sqlConnection;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    connection.connectionid = DataReaderHelper.GetIntValue(sqlDataReader, "connectionid");
                    connection.userid = DataReaderHelper.GetIntValue(sqlDataReader, "userid");
                    connection.connectiontype = DataReaderHelper.GetStringValue(sqlDataReader, "connectiontype");
                    connection.isActive = DataReaderHelper.GetBoolValue(sqlDataReader, "isActive");
                    //connection.usertypeid = DataReaderHelper.GetIntValue(sqlDataReader, "usertypeid");
                }

            }
            catch (System.Exception ex)
            {

                throw;
            }
            finally
            {
                sqlConnection.Close();
            }
            return connection;
        }
    }
}