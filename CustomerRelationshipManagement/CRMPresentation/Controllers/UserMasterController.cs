using CRM.Common.Interface;
using CRM.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMPresentation.Controllers
{
    public class UserMasterController : Controller
    {
        private IRole _IRole;
        private IUserAuthentication _IUserAuthentication;
        private IUserDetails _IUserDetails;
        public UserMasterController(IRole role, IUserAuthentication userAuthentication, IUserDetails userAuth)
        {
            _IRole = role;
            _IUserAuthentication = userAuthentication;
            _IUserDetails = userAuth;
        }
        // GET: UserMaster
        public ActionResult NewUser()
        {
            UserDetails uDetails = new UserDetails();
            uDetails.roleDetails = _IRole.GetAllRoles();
            return View(uDetails);
        }
        [HttpPost]
        public ActionResult NewUser(UserDetails uDetails)
        {
            UserDetails uDetail = new UserDetails();
            uDetail.roleDetails = _IRole.GetAllRoles();
            if (ModelState.IsValid)
            {
                int value = _IUserDetails.SaveUser(uDetails);
                return RedirectToAction("ViewUser");
            }
            return View(uDetail);
        }
        public ActionResult ViewUser()
        {
            UserDetails user = new UserDetails();
            List<UserDetails> usetDetails = new List<UserDetails>();
            usetDetails = _IUserDetails.GetAllUser();
            return View(usetDetails);
        }
        public string CheckUserAvailability(string userName)
        {
            string result = "False";
            UserAuthentication userAuth = new UserAuthentication();
            userAuth = _IUserAuthentication.GetAuthenticationByName(userName);
            if (userAuth != null)
                result = "True";
            return result;
        }
    }
}