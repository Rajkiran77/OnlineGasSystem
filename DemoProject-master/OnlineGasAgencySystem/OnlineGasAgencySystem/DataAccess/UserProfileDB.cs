using System;
using System.Configuration;
using System.Data.SqlClient;
using OnlineGasAgencySystem.Helper;
using OnlineGasAgencySystem.Models;

namespace OnlineGasAgencySystem.DataAccess
{
    public class UserProfileDB
    {
        private string ConnectionString = string.Empty;
        SqlConnection sqlConnection;
        public UserProfileDB()
        {
            ConnectionString = ConfigurationSettings.AppSettings["DataBaseConnection"];
            sqlConnection = new SqlConnection(ConnectionString);
        }
        public UserProfile GetUserProfile(string username)
        {
            UserProfile userprofile = new UserProfile();
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = Constant.SPGETPROFILE;
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserName", username);
                sqlCommand.Connection = sqlConnection;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    userprofile.username = DataReaderHelper.GetStringValue(sqlDataReader, "username");
                    userprofile.useremail = DataReaderHelper.GetStringValue(sqlDataReader, "useremail");
                    userprofile.userphone = DataReaderHelper.GetLongValue(sqlDataReader, "userphone");
                    userprofile.useraddress = DataReaderHelper.GetStringValue(sqlDataReader, "useraddress");
                    userprofile.userpassword = DataReaderHelper.GetStringValue(sqlDataReader, "userpassword");
                    userprofile.userid = DataReaderHelper.GetIntValue(sqlDataReader, "userid");
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
            return userprofile;
        }

        public UserProfile InsertUserProfile(UserProfile user)
        {
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = Constant.SPINSERTPROFILE;
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserName", user.username);
                sqlCommand.Parameters.AddWithValue("@UserEmail", user.useremail);
                sqlCommand.Parameters.AddWithValue("@PhoneNo", user.userphone);
                sqlCommand.Parameters.AddWithValue("@Address", user.useraddress);
                sqlCommand.Parameters.AddWithValue("@Password", user.userpassword);
                sqlCommand.Connection = sqlConnection;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    user.userid = DataReaderHelper.GetIntValue(sqlDataReader, "UserId");
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
            return user;
        }
    }
}