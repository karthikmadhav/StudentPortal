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
   public class UserDetailsService: IUserDetails
    {
        private IUserDetails _IUserDetails;
        public UserDetailsService()
        {
            _IUserDetails = new UserDetailsProvider();
        }
        public int SaveUser(UserDetails userDetails)
        {
            int value = _IUserDetails.SaveUser(userDetails);
            return value;
        }
        public List<UserDetails> GetAllUser()
        {
            List<UserDetails> userDetails = new List<UserDetails>();
            userDetails = _IUserDetails.GetAllUser();
            return userDetails;
        }

    }
}
