using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.Common.Models
{
   public class UserDetails
    {
        public int UserId { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Role is Required")]
        public int RoleId { get; set; }
        public bool Active { get; set; }
        [Required(ErrorMessage = "User Name is Required")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is Required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public List<RoleDetails> roleDetails { get; set; }
        public string RoleName { get; set; }
    }
}
