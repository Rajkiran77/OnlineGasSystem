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
    public class CustomerSupportDB
    {
        private string ConnectionString = string.Empty;
        SqlConnection sqlConnection;
        public CustomerSupportDB()
        {
            ConnectionString = ConfigurationSettings.AppSettings["DataBaseConnection"];
            sqlConnection = new SqlConnection(ConnectionString);
        }


        public CustomerSupport GetCustomerSupport(int userId)
        {
            CustomerSupport customerSupport = new CustomerSupport();
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = Constant.SPGETCUSTOMERSUPPORT;
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Connection = sqlConnection;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    customerSupport.custsupportid = DataReaderHelper.GetIntValue(sqlDataReader, "custsupportid");
                    customerSupport.custsupportphno = DataReaderHelper.GetLongValue(sqlDataReader, "custsupportphno");
                    customerSupport.custsupportemail = DataReaderHelper.GetStringValue(sqlDataReader, "custsupportemail");
                    customerSupport.companyname = DataReaderHelper.GetStringValue(sqlDataReader, "companyname");
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

            return customerSupport;
        }
        public List<FAQ> GetFAQ(int CompanyID)
        {
            List<FAQ> fAQs = new List<FAQ>();
            
            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = Constant.SPGETNOTIFICATION;
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue("@CompanyID", CompanyID);
                sqlCommand.Connection = sqlConnection;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    FAQ fAQ = new FAQ();
                    fAQ.notimssg = DataReaderHelper.GetStringValue(sqlDataReader, "notimssg");
                    fAQs.Add(fAQ);
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

            return fAQs;
        }
        public List<Company> GetCompanyList()
        {
            List<Company> companylist = new List<Company>();

            try
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = Constant.SPGETCOMPANY;
                sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlCommand.Connection = sqlConnection;
                SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
                while (sqlDataReader.Read())
                {
                    Company company  = new Company();
                    company.companyid = DataReaderHelper.GetIntValue(sqlDataReader, "companyid");
                    company.companyname = DataReaderHelper.GetStringValue(sqlDataReader, "companyname");
                    companylist.Add(company);
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

            return companylist;
        }
    }

}
    