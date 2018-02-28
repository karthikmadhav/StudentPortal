using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.BusinessModels
{
   public class IndustryCategory
    {
        public int IndustryCategoryId { get; set; }
        public string IndustryCategoryName { get; set; }
        public char Status { get; set; }
    }
}
