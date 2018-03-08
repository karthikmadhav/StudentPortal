using CRM.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Common.Interface
{
    public interface IRole
    {
        List<RoleDetails> GetAllRoles();
        bool SaveRole(RoleDetails roleDetails);
        bool UpdateRole(RoleDetails roleDetails);
        bool DeleteRole(int roleID);
        RoleDetails GetRoleByID(int roleID);
    }
}
