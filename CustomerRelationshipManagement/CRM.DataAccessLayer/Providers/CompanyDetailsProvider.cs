using CRM.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.DataAccessLayer.Providers.DataModel;
using CRM.DataAccessLayer.ConnectionManager;
using Dapper;
using System.Data;

namespace CRM.DataAccessLayer.Providers
{
    public class CompanyDetailsProvider : ICompanyProvider
    {
        ConnectionRepository connManager = new ConnectionRepository();
        public System.Data.SqlClient.SqlConnection con;
        #region Srored Procedure Name
        public string addNewCompany = "usp_AddNewCompany";
        public string getAllCompany = "usp_GetAllCompany";
        public string deleteCompany = "usp_DeleteCompany";
        public string updateCompany = "usp_UpdateCompany";
        public string getCompanyByID = "usp_GetCompanyByID";
        #endregion
        System.Data.IDbConnection dbConnection;
        int rowsAffected = 0;
        public bool DeleteCompany(int CompanyId)
        {
            throw new NotImplementedException();
        }
        public CompanyDetailsProvider()
        {
            dbConnection = connManager.GetConnection();
        }
        public DLCompanyDetails GetCompanyByID(int compID)
        {
            throw new NotImplementedException();
        }

        public List<DLCompanyDetails> GetCompanyList()
        {
            List<DLCompanyDetails> custDetails = new List<DLCompanyDetails>();
            try
            {
                con = connManager.GetConnection();
                con.Open();
                custDetails = SqlMapper.Query<DLCompanyDetails>(con, getAllCompany).ToList();
                return custDetails;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
        }

        public bool SaveCompany(DLCompanyDetails CompDetails)
        {
            try
            {
                con = connManager.GetConnection();
                con.Open();
                con.Execute(addNewCompany, CompDetails, commandType: CommandType.StoredProcedure);
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }

        }

        public bool UpdateCompany(DLCompanyDetails CompDetails)
        {
            throw new NotImplementedException();
        }
    }
}
