using CRM.BusinessLayer.BusinessModels;
using CRM.BusinessLayer.Interfaces;
using CRM.DataAccessLayer.Interfaces;
using CRM.DataAccessLayer.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.Services
{
   public class LeadSourceService:ILeadSource
    {
        private ILeadProvider _LeadProvider;
        public LeadSourceService(ILeadProvider leadProvider)
        {
            //_LeadProvider = new LeadSourceProvider();
            _LeadProvider = leadProvider;
        }
        public List<LeadSource> GetLeadSourceList()
        {
            List<LeadSource> leadSource = new List<LeadSource>();
            LeadSource lead = new LeadSource();
            var leadResult = _LeadProvider.GetLeadSourceList();
            foreach(var items in leadResult)
            {
                lead.LeadSourceId = items.LeadSourceId;
                lead.LeadSourceName = items.LeadSourceName;
                lead.LeadStatus = items.LeadStatus;
                leadSource.Add(lead);
            }
            return leadSource;
        }
        public bool SaveLeadSource(LeadSource leadSource)
        {
            return true;
        }
        public bool UpdateLeadSource(LeadSource leadsource)
        {
            return true;

        }
        public bool DeleteLeadSource(int leadID)
        {
            return true;

        }
    }
}
