using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMPresentation.Security
{
    public class AuthorizeActivity : AuthorizeAttribute
    {
        public int AccessLevel { get; set; }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            string controllerName = filterContext.ActionDescriptor.ControllerDescriptor.ControllerName;
            string actionMethodName = filterContext.ActionDescriptor.ActionName;
        }
    }
}