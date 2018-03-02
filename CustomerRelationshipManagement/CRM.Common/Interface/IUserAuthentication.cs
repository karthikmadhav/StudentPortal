using CRM.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Common.Interface
{
   public interface IUserAuthentication
    {
        UserAuthentication GetUserAuthentication(UserAuthentication userCred);
    }
}
