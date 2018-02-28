using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DataAccessLayer.Providers.DataModel
{
  public  class DLLIndustryCategory
    {
        public int IndustryCategoryId { get; set; }
        public string IndustryCategoryName { get; set; }
        public char Status { get; set; }
    }
}
