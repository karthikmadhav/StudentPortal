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
    public class UserAuthenticationProvider : IUserAuthentication
    {
        ConnectionRepository connManager = new ConnectionRepository();
        public System.Data.SqlClient.SqlConnection con;
        System.Data.IDbConnection dbConnection;
        #region Srored Procedure Name
        public string valUser = "usp_ValidateUser";
        public string userAuthByName = "usp_GetUserAuthByName";

        #endregion

        public UserAuthenticationProvider()
        {
            dbConnection = connManager.GetConnection();
        }
        public UserAuthentication GetUserAuthentication(UserAuthentication userCred)
        {
            UserAuthentication userAuth = new UserAuthentication();

            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserName", userCred.UserName);
                param.Add("@Password", userCred.Password);
                return userAuth = dbConnection.Query<UserAuthentication>(valUser, param, commandType: CommandType.StoredProcedure).SingleOrDefault();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }
        public UserAuthentication GetAuthenticationByName(string userName)
        {
            UserAuthentication userAuth = new UserAuthentication();
            try
            {
                DynamicParameters param = new DynamicParameters();
                param.Add("@UserName", userName);
                return userAuth = dbConnection.Query<UserAuthentication>(userAuthByName, param, commandType: CommandType.StoredProcedure).SingleOrDefault();
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
