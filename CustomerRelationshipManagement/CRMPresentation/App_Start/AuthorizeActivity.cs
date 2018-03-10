using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CRMPresentation.App_Start
{
    public class AuthorizeActivity : AuthorizeAttribute
    {
        public int AccessLevel { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionMethodName = filterContext.ActionDescriptor.ActionName;
            string verb = filterContext.HttpContext.Request.HttpMethod;

            filterContext.HttpContext.Response.Cache.SetNoServerCaching();
            filterContext.HttpContext.Response.Cache.SetNoStore();

            string uname = filterContext.HttpContext.User.Identity.Name.ToString();
            bool isAuthenticated = filterContext.HttpContext.User.Identity.IsAuthenticated;
            bool isAuthorized = true;
            isAuthenticated = true;
            if (isAuthenticated)
            {
                //Implement role based access Get Role based action method and check here
            }
            //If authenticated means take the value assign to the session
            if (!isAuthenticated || !isAuthorized)
            {
                filterContext.Result = new HttpUnauthorizedResult(); // or a RedirectResult, etc.
                HandleUnauthorizedRequest(filterContext);
            }

        }
        protected override void HandleUnauthorizedRequest(AuthorizationContext actionContext)
        {
            if (actionContext.HttpContext.Request.IsAjaxRequest())
            {
                var redirectUrl = "";
                var data = actionContext.HttpContext.Request.RequestContext.RouteData;
                var currentAction = data.GetRequiredString("action");
                var currentController = data.GetRequiredString("controller");
                actionContext.Result = new RedirectToRouteResult(new RouteValueDictionary
                                        {{ "controller", "Home" },
                                        { "action", "UnAuthenticated" },
                                        { "redirectUrl", redirectUrl}   });

            }
            else
            {
                // this is a standard request
                actionContext.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                    {
                            { "action", "UnauthorizedAccess" },
                            { "controller", "Home" }
                    });
                actionContext.HttpContext.Response.StatusCode = 403;
            }
        }
    }
}