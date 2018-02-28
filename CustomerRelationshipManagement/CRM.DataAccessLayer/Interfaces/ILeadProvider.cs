using CRM.DataAccessLayer.Providers.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DataAccessLayer.Interfaces
{
    public interface ILeadProvider
    {
        List<DLLeadSource> GetLeadSourceList();
        bool SaveLeadSource(DLLeadSource leadsource);
        bool UpdateLeadSource(DLLeadSource leadsource);
        bool DeleteLeadSource(int leadID);
    }
}
