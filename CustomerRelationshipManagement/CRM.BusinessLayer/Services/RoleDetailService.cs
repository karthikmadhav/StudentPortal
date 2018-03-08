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
   public class RoleDetailService:IRole
    {
        private IRole _IRole;

        public RoleDetailService()
        {
            _IRole = new RoleDetailsProvider();
        }
        public List<RoleDetails> GetAllRoles()
        {
            List<RoleDetails> roleDetails = new List<RoleDetails>();
            roleDetails = _IRole.GetAllRoles();
            return roleDetails;
        }
        public bool SaveRole(RoleDetails roleDetails)
        {
            bool result = false;
            result = _IRole.SaveRole(roleDetails);
            return true;
        }
        public bool UpdateRole(RoleDetails roleDetails)
        {
            bool result = false;
            result = _IRole.UpdateRole(roleDetails);
            return result;
        }
        public bool DeleteRole(int roleID)
        {
            bool result = false;
            result = _IRole.DeleteRole(roleID);
            return result;
        }
        public RoleDetails GetRoleByID(int roleID)
        {
            RoleDetails roleDetails = new RoleDetails();
            roleDetails = _IRole.GetRoleByID(roleID);
            return roleDetails;
        }
    }
}
