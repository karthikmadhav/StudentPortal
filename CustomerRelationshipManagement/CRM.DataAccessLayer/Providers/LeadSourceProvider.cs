using CRM.DataAccessLayer.Interfaces;
using CRM.DataAccessLayer.Providers.DataModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace CRM.DataAccessLayer.Providers
{
   public class LeadSourceProvider:ILeadProvider
    {

        public List<DLLeadSource> GetLeadSourceList()
        {

            List<DLLeadSource> leadSource = new List<DLLeadSource>();

            //Dapper Implementation
            //using (IDbConnection db = new SqlConnection(ConfigurationManager.ConnectionStrings["friendConnection"].ConnectionString))
            //{
            //    leadSource = db.Query<DLLeadSource>("Select * From tblFriends").ToList();

            //}
            leadSource.Add(new DLLeadSource { LeadSourceId = 1, LeadSourceName = "News Paper Add", LeadStatus = 'Y' });
            leadSource.Add(new DLLeadSource { LeadSourceId = 2, LeadSourceName = "Cold Call", LeadStatus = 'Y' });
            leadSource.Add(new DLLeadSource { LeadSourceId = 3, LeadSourceName = "TV Add", LeadStatus = 'Y' });
            leadSource.Add(new DLLeadSource { LeadSourceId = 4, LeadSourceName = "Friend Reference", LeadStatus = 'Y' });
            return leadSource;
        }
        public bool SaveLeadSource(DLLeadSource leadSource)
        {
            return true;
        }
        public bool UpdateLeadSource(DLLeadSource leadsource)
        {
            return true;

        }
        public bool DeleteLeadSource(int leadID)
        {
            return true;

        }
    }
}
