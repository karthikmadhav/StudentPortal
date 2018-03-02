using CRM.BusinessLayer.BusinessModels;
using CRM.BusinessLayer.Interfaces;
using CRM.BusinessLayer.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using CRMPresentation.Models;
using CRMPresentation.Repository;

namespace CRMPresentation.Controllers
{
    public class MasterSettingsController : Controller
    {
        private ILeadSource _LeadSource;
        private IIndustryCategory _IndustryCategory;
        string apiUrl = ConfigurationManager.AppSettings["baseurl"] + "/api/GloabalSettings/";
        HttpClient client;
        public MasterSettingsController(ILeadSource LeadSource, IIndustryCategory industryCategory)
        {
            //_LeadSource = new LeadSourceService();
            _LeadSource = LeadSource;
            _IndustryCategory = industryCategory;

            client = new HttpClient();
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
        // GET: MasterSettings
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewLeadSource()
        {
            List<LeadSource> leadSource = new List<LeadSource>();
            leadSource = _LeadSource.GetLeadSourceList();
            return View(leadSource);
        }
        //Web API Consume
        public async Task<ActionResult> ViewLeadSourceAPI()
        {
            List<LeadSource> leadSrc = new List<LeadSource>();
            HttpResponseMessage responseMessage = await client.GetAsync(apiUrl);
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = responseMessage.Content.ReadAsStringAsync().Result;
                leadSrc = JsonConvert.DeserializeObject<List<LeadSource>>(responseData);
            }
            return View(leadSrc);
        }

        //LeadSource Start
        [HttpGet]
        public ActionResult NewLeadSource()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult  NewLeadSource(LeadSource leadSource)
        {
            bool result = _LeadSource.SaveLeadSource(leadSource);
            if (result)
                return RedirectToAction("ViewLeadSource", "MasterSettings");

            return RedirectToAction("NewLeadSource", "MasterSettings");

        }

        public ActionResult EditLeadSource(int id)
        {
            List<LeadSource> leadSource = new List<LeadSource>();
            leadSource = _LeadSource.GetLeadSourceList();
            LeadSource leadSrc = leadSource.Where(x => x.LeadSourceId== id).FirstOrDefault();
            return View(leadSrc);
        }
        [HttpPost]
        public ActionResult EditLeadSource(LeadSource leadSource)
        {
            bool result = _LeadSource.UpdateLeadSource(leadSource);
            return View();
        }
        public ActionResult DeleteLeadSource(int id)
        {
            bool result = _LeadSource.DeleteLeadSource(id);
            return RedirectToAction("ViewLeadSource", "MasterSettings");
        }
        //LeadSource End

        //Industry Category Start
        public ActionResult ViewIndustryCategory()
        {
            List<IndustryCategory> industryCategory = new List<IndustryCategory>();
            industryCategory = _IndustryCategory.GetIndustryCategoryList();
            return View(industryCategory);
        }

        [HttpGet]
        public ActionResult NewIndustryCategory()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult NewIndustryCategory(IndustryCategory industry)
        {
            bool result = _IndustryCategory.SaveIndustryCategory(industry);
            if (result)
                return RedirectToAction("ViewIndustryCategory", "MasterSettings");

            return RedirectToAction("NewIndustryCategory", "MasterSettings");
        }
        public ActionResult EditIndustry(int id)
        {

            return RedirectToAction("ViewIndustryCategory");
        }
        [HttpPost]
        public ActionResult EditIndustry(IndustryCategory industry)
        {
            bool result = _IndustryCategory.UpdateIndustryCategory(industry);
            if (result)
                return RedirectToAction("ViewIndustryCategory");

            return RedirectToAction("NewIndustryCategory");
        }
        public ActionResult DeleteIndustry(int id)
        {
            bool result = _IndustryCategory.DeleteIndustryCategory(id);
            if (result)
                return RedirectToAction("ViewIndustryCategory");

            return RedirectToAction("NewIndustryCategory");
        }
        //Industry Category End
        [HttpGet]
        public virtual PartialViewResult Menu()
        {
            IEnumerable<Menu> Menu = null;

            if (Session["_Menu"] != null)
            {
                Menu = (IEnumerable<Menu>)Session["_Menu"];
            }
            else
            {
                int loginUserID;
                if (Session["_UserID"] != null)
                     loginUserID =Convert.ToInt32(Session["_UserID"].ToString());
                Menu = MenuData.GetMenus("10002");// pass employee id here
                Session["_Menu"] = Menu;
            }
            return PartialView("MenuList", Menu);
        }

    }
}