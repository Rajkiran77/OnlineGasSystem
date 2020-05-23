using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace OnlineGasAgencySystem.Helper
{
    public static class DataReaderHelper
    {
        public static int? GetIntValue(SqlDataReader sqlDataReader, string columnName)
        {
            int? value = null;
            value=sqlDataReader.GetValue(sqlDataReader.GetOrdinal(columnName)) != null ? (int?)sqlDataReader.GetValue(sqlDataReader.GetOrdinal(columnName)) : null;
            return value;
        }

        public static string GetStringValue(SqlDataReader sqlDataReader, string columnName)
        {
            string value = null;
            value = sqlDataReader.GetValue(sqlDataReader.GetOrdinal(columnName)) != null ? (string)sqlDataReader.GetValue(sqlDataReader.GetOrdinal(columnName)) : null;
            return value;
        }

        public static bool? GetBoolValue(SqlDataReader sqlDataReader, string columnName)
        {
            bool? value = null;
            value = sqlDataReader.GetValue(sqlDataReader.GetOrdinal(columnName)) != null ? (bool?)sqlDataReader.GetValue(sqlDataReader.GetOrdinal(columnName)) : null;
            return value;
        }
        public static decimal? GetDecimalValue(SqlDataReader sqlDataReader, string columnName)
        {
            decimal? value = null;
            value = sqlDataReader.GetValue(sqlDataReader.GetOrdinal(columnName)) != null ? (decimal?)sqlDataReader.GetValue(sqlDataReader.GetOrdinal(columnName)) : null;
            return value;
        }
        public static DateTime? GetDateTimeValue(SqlDataReader sqlDataReader, string columnName)
        {
            DateTime? value = null;
            value = sqlDataReader.GetValue(sqlDataReader.GetOrdinal(columnName)) != null ? (DateTime?)sqlDataReader.GetValue(sqlDataReader.GetOrdinal(columnName)) : null;
            return value;
        }
        public static long? GetLongValue(SqlDataReader sqlDataReader, string columnName)
        {
            long? value = null;
            value = sqlDataReader.GetValue(sqlDataReader.GetOrdinal(columnName)) != null ? (long?)sqlDataReader.GetValue(sqlDataReader.GetOrdinal(columnName)) : null;
            return value;
        }
    }
}