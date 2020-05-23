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
    public class TransactionDB
    {
        private string ConnectionString = string.Empty;
        SqlConnection sqlConnection;
        public TransactionDB()
        {
            ConnectionString = ConfigurationSettings.AppSettings["DataBaseConnection"];
            sqlConnection = new SqlConnection(ConnectionString);
        }
        public List<Transaction> GetTransaction(string username)
        {
            List<Transaction> transactionList = new List<Transaction>();
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = Constant.SPGETTRANSACTION;
    
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserName",username);
                sqlCommand.Connection = sqlConnection;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Transaction transaction = new Transaction();
                    transaction.transactionid = DataReaderHelper.GetIntValue(sqlDataReader, "transactionid");
                    transaction.tdob = DataReaderHelper.GetDateTimeValue(sqlDataReader, "tdob");
                    transaction.tdod = DataReaderHelper.GetDateTimeValue(sqlDataReader, "tdod");
                    transaction.connectionid = DataReaderHelper.GetIntValue(sqlDataReader, "connectionid");
                    transaction.connectiontype = DataReaderHelper.GetStringValue(sqlDataReader, "connectiontype");
                    transaction.bookingid = DataReaderHelper.GetIntValue(sqlDataReader, "bookingid");
                    transaction.price = DataReaderHelper.GetIntValue(sqlDataReader, "price");
                    transaction.companyid = DataReaderHelper.GetIntValue(sqlDataReader, "companyid");
                    transaction.companyname = DataReaderHelper.GetStringValue(sqlDataReader, "companyname");
                    transaction.statustype = DataReaderHelper.GetStringValue(sqlDataReader, "statustype");
                    transaction.userid = DataReaderHelper.GetIntValue(sqlDataReader, "userid");
                    transaction.username = DataReaderHelper.GetStringValue(sqlDataReader, "username");
                    transaction.userphone = DataReaderHelper.GetLongValue(sqlDataReader, "userphone");
                    // transaction.useraltphone = DataReaderHelper.GetLongValue(sqlDataReader, "useraltphone");
                    transaction.useraddress = DataReaderHelper.GetStringValue(sqlDataReader, "useraddress");
                    transactionList.Add(transaction);
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
           
            return transactionList;
        }

    }

}