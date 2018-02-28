using CRM.DataAccessLayer.Interfaces;
using CRM.DataAccessLayer.Providers;
using CRM.DataAccessLayer.Providers.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRM.WebAPI.Controllers
{
    public class MasterSettingsController : ApiController
    {
        private ILeadProvider _LeadProvider;
        public MasterSettingsController()
        {
            ILeadProvider leadProvider= new LeadSourceProvider();
            _LeadProvider = leadProvider;

        }
        public MasterSettingsController(ILeadProvider leadProvider)
        {
            leadProvider = new LeadSourceProvider();
            _LeadProvider = leadProvider;
        }
        public IHttpActionResult GetLeadSource()
        {
            //Implement Validation Part
            return Ok<List<DLLeadSource>>(_LeadProvider.GetLeadSourceList());
        }
    }
}
