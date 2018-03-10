using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMPresentation.App_Start
{
    public class SessionExpireAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var currentURL = filterContext.HttpContext.Request.RawUrl;
            if (HttpContext.Current.Session["_UserID"] == null)
            {
                string redirectUrl = null;
                var isAjaxRequest = filterContext.HttpContext.Request.IsAjaxRequest();
                if (isAjaxRequest)
                {
                    filterContext.HttpContext.Response.StatusCode = 200;
                    filterContext.HttpContext.Response.StatusDescription = redirectUrl;
                    filterContext.HttpContext.Response.RedirectLocation = redirectUrl;
                    filterContext.Result = new JsonResult
                    {
                        Data = new { Redirect = redirectUrl },
                        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    };
                }
                else
                {
                    //filterContext.Result = new RedirectResult(redirectUrl, true);
                }
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}