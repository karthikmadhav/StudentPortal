using CRM.BusinessLayer.Interfaces;
using CRM.Common.Interface;
using CRM.Common.Models;
using CRMPresentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMPresentation.Controllers
{
    public class HomeController : Controller
    {
        private IUserAuthentication _IUserAuthentication;
        public HomeController(IUserAuthentication userAuthentication)
        {
            _IUserAuthentication = userAuthentication;
        }
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserAuthentication loginDetails)
        {
            if (ModelState.IsValid)
            {
                UserAuthentication logDetails = _IUserAuthentication.GetUserAuthentication(loginDetails);
                if (logDetails!=null)
                {
                    Session["_UserID"] = Convert.ToString(logDetails.UserID);
                    return RedirectToAction("Dashboard");
                }
                return View();
            }
            return View();

        }
    }
}