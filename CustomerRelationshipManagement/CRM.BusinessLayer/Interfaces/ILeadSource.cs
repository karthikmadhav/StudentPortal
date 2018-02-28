using CRM.BusinessLayer.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.Interfaces
{
    public interface ILeadSource
    {
        List<LeadSource> GetLeadSourceList();
         bool SaveLeadSource(LeadSource leadsource);
        bool UpdateLeadSource(LeadSource leadsource);
        bool DeleteLeadSource(int leadID);
    }
}
