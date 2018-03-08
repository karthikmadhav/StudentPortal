using CRM.Common.Interface;
using CRM.Common.Models;
using CRM.DataAccessLayer.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.Services
{
   public class UserAuthenticationService: IUserAuthentication
    {
        private IUserAuthentication _IUserAuthentication;
        public UserAuthenticationService()
        {
            _IUserAuthentication = new UserAuthenticationProvider();
        }
        public UserAuthentication GetUserAuthentication(UserAuthentication userCred)
        {
            UserAuthentication userAuth = new UserAuthentication();
            userAuth = _IUserAuthentication.GetUserAuthentication(userCred);
            return userAuth;
        }
        public UserAuthentication GetAuthenticationByName(string userName)
        {
            UserAuthentication userAuth = new UserAuthentication();
            userAuth = _IUserAuthentication.GetAuthenticationByName(userName);
            return userAuth;
        }
    }
}
