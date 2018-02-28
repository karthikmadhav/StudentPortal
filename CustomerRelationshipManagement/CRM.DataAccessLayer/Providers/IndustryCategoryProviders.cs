using CRM.DataAccessLayer.ConnectionManager;
using CRM.DataAccessLayer.Interfaces;
using CRM.DataAccessLayer.Providers.DataModel;
using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DataAccessLayer.Providers
{
   public class IndustryCategoryProviders: IIndustryCategoryProvider
    {
        ConnectionRepository connManager = new ConnectionRepository();
        public System.Data.SqlClient.SqlConnection con;

        #region Srored Procedure Name
        public string addNewIndustry = "usp_AddNewIndustryCategory";
        public string getAllIndustryCategory = "usp_GetAllIndustryCategory";
        public string deleteIndustryCategory = "usp_DeleteIndustryCategory";
        public string updateIndustryCategory = "usp_UpdateIndustryCategory";
        #endregion


        IDbConnection dbConnection ;
        int rowsAffected=0;

        public IndustryCategoryProviders()
        {
            dbConnection = connManager.GetConnection();
        }
        public List<DLLIndustryCategory> GetIndustryCategoryList()
        {
            try
            {
                List<DLLIndustryCategory> industryCategory = new List<DLLIndustryCategory>();
                con = connManager.GetConnection();
                con.Open();
                industryCategory = SqlMapper.Query<DLLIndustryCategory>(con, getAllIndustryCategory).ToList();
                return industryCategory;

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                con.Close();
            }
            //using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["SqlServerConnString"].ConnectionString))
            //{

            //    industryCategory = db.Query<DLLIndustryCategory>("Select * From [dbo].[IndustryCategory]").ToList();
            //}
        }
        public bool SaveIndustryCategory(DLLIndustryCategory IndustryCategory)
        {
            //Dapper Implementation
            try
            {
                con = connManager.GetConnection();
                con.Open();
                con.Execute(addNewIndustry, IndustryCategory, commandType: CommandType.StoredProcedure);
                con.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
           
        }
        public bool UpdateIndustryCategory(DLLIndustryCategory IndustryCategory)
        {
            using (dbConnection)
            {
                string sqlQuery = "update [dbo].[IndustryCategory] SET IndustryCategoryName='" + IndustryCategory.IndustryCategoryName + "',Status='" + IndustryCategory.Status + "' WHERE IndustryCategoryId=" + IndustryCategory.IndustryCategoryId;
                 rowsAffected = dbConnection.Execute(sqlQuery);
            }
            if (rowsAffected > 0)
                return true;
            else
                return false;

        }
        public bool DeleteIndustryCategory(int IndustryCategoryId)
        {
            con = connManager.GetConnection();
            con.Open();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@IndustryCategoryId", IndustryCategoryId);

                rowsAffected= con.Execute(deleteIndustryCategory, param, commandType: CommandType.StoredProcedure);
                con.Close();
                return true;
            }
            catch(Exception ex)
            {
                throw;
            }
            //using (dbConnection)
            //{
            //    string sqlQuery = "Delete From [dbo].[IndustryCategory] WHERE IndustryCategoryId = " + IndustryCategoryId;
            //     rowsAffected = dbConnection.Execute(sqlQuery);
            //}
            //if (rowsAffected > 0)
            //    return true;
            //else
            //    return false;
        }
    }
}
