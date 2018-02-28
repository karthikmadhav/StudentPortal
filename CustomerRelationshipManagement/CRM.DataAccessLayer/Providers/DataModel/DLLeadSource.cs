using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DataAccessLayer.Providers.DataModel
{
   public class DLLeadSource
    {
        public int LeadSourceId { get; set; }
        public string LeadSourceName { get; set; }
        public char LeadStatus { get; set; }
    }
}
