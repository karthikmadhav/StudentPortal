using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.BusinessModels
{
    public class LeadSource
    {
        public int LeadSourceId { get; set; }
        public string LeadSourceName { get; set; }
        public char LeadStatus { get; set; }
    }
}
