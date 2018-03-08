using CRM.Common.Interface;
using CRM.Common.Models;
using CRM.DataAccessLayer.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DataAccessLayer.Providers
{
   public class RoleDetailsProvider : IRole
    {
        CRMEntities entity = new CRMEntities();
        public List<RoleDetails> GetAllRoles()
        {
            List<RoleDetails> roleDetails = new List<RoleDetails>();
            var roleDet = entity.RoleMasters.ToList();
            roleDetails = roleDet.Select(x => new RoleDetails { Active = x.Active, Name = x.Name,RoleId=x.RoleId }).ToList();
            return roleDetails;
        }
        public bool SaveRole(RoleDetails roleDetails)
        {
            RoleMaster roleMaster = new RoleMaster();
            roleMaster.Name = roleDetails.Name;
            roleMaster.Active = roleDetails.Active;
            entity.RoleMasters.Add(roleMaster);
            entity.SaveChanges();

            return true;
        }
        public bool UpdateRole(RoleDetails roleDetails)
        {
            RoleMaster updatedRole = (from c in entity.RoleMasters
                                        where c.RoleId == roleDetails.RoleId
                                        select c).FirstOrDefault();
            updatedRole.Name = roleDetails.Name;
            updatedRole.Active = roleDetails.Active;
            entity.SaveChanges();
            return true;
        }
        public bool DeleteRole(int roleID)
        {
            RoleMaster updatedRole = (from c in entity.RoleMasters
                                      where c.RoleId == roleID
                                      select c).FirstOrDefault();
            entity.RoleMasters.Remove(updatedRole);
            entity.SaveChanges();
            return true;
        }
        public RoleDetails GetRoleByID(int roleID)
        {
            RoleDetails roleDetails = new RoleDetails();
            roleDetails = entity.RoleMasters.Where(x=>x.RoleId==roleID).Select(x=> new RoleDetails { Name=x.Name,RoleId=x.RoleId,Active=x.Active}).FirstOrDefault();
            return roleDetails;
        }
    }
}
