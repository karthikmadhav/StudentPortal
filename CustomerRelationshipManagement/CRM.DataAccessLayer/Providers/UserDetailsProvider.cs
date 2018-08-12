using CRM.Common.Interface;
using CRM.Common.Models;
using CRM.DataAccessLayer.ConnectionManager;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DataAccessLayer.Providers
{
   public class UserDetailsProvider: IUserDetails
    {
        System.Data.IDbConnection dbConnection;
        ConnectionRepository connManager = new ConnectionRepository();
        #region Srored Procedure Name
        public string newUser = "usp_AddNewUser";
        public string newUserAuthentication = "usp_NewUserAuthentication";
        public string getAllUser = "usp_GetAllUser";
        public string getUserByID = "usp_GetUserByID";


        #endregion
        public UserDetailsProvider()
        {
            dbConnection = connManager.GetConnection();
        }
        public int SaveUser(UserDetails userDetails)
        {
            int iValue = 0;
            DynamicParameters param = new DynamicParameters();
            param.Add("@Name", userDetails.Name);
            param.Add("@RoleId", userDetails.RoleId);
            param.Add("@Active", userDetails.Active?1:0);
           
            //var id = dbConnection.Query<int>(newUser, param, commandType: CommandType.StoredProcedure).SingleOrDefault();

            const string sql = @"INSERT INTO dbo.UserMaster (Name,RoleId,Active)
                               Values (@Name,@RoleId,@Active);
                               SELECT CAST(SCOPE_IDENTITY() as int)";
            var id = dbConnection.Query<int>(sql, new { Name = userDetails.Name,RoleId= userDetails.RoleId,Active= userDetails.Active ? 1 : 0 }).Single();

            iValue = Convert.ToInt32(id);
            if (iValue > 0)
            {
                DynamicParameters paramNew = new DynamicParameters();
                paramNew.Add("@UserID", iValue);
                paramNew.Add("@UserName", userDetails.UserName);
                paramNew.Add("@Password", userDetails.Password);
                var newid = dbConnection.Query<int>(newUserAuthentication, paramNew, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            return iValue;
        }
        public List<UserDetails> GetAllUser()
        {
            List<UserDetails> userDetail = new List<UserDetails>();
            try
            {
                DynamicParameters param = new DynamicParameters();
                return userDetail = dbConnection.Query<UserDetails>(getAllUser, commandType: CommandType.StoredProcedure).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }
        public UserDetails GetUserByID(int userID)
        {
            UserDetails userDetail = new UserDetails();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserID", userID);
                return userDetail = dbConnection.Query<UserDetails>(getUserByID, param, commandType: CommandType.StoredProcedure).SingleOrDefault();

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }
    }
}
