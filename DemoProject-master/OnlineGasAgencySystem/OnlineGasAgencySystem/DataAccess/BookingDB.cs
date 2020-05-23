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
    public class BookingDB
    {
        private string ConnectionString = string.Empty;
        SqlConnection sqlConnection;
        public BookingDB()
        {
            ConnectionString = ConfigurationSettings.AppSettings["DataBaseConnection"];
            sqlConnection = new SqlConnection(ConnectionString);
        }
        public Booking GetBooking(int userId)
        {
            Booking booking = new Booking();
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = Constant.SPGETBOOKING;
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@UserID", userId);
                sqlCommand.Connection = sqlConnection;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    booking.bookingid = DataReaderHelper.GetIntValue(sqlDataReader,"bookingid");
                    booking.userid = DataReaderHelper.GetIntValue(sqlDataReader, "userid");
                    booking.connectionid = DataReaderHelper.GetIntValue(sqlDataReader, "connectionid");
                    booking.price = DataReaderHelper.GetIntValue(sqlDataReader, "price");
                    booking.statustype = DataReaderHelper.GetStringValue(sqlDataReader, "statustype");
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
            return booking;
        }
    }
}