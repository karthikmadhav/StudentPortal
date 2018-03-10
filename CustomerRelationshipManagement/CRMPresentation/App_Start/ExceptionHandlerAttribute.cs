using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace CRMPresentation.App_Start
{
    public class ExceptionHandlerAttribute: FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            if (!filterContext.ExceptionHandled)
            {
                try
                {
                    var message = filterContext.Exception.Message;
                    var stackTrace = filterContext.Exception.StackTrace;
                    var controllerName = filterContext.RouteData.Values["controller"].ToString();
                    var userName = HttpContext.Current.User.Identity.Name;

                    //Implement Log function
                }
                catch (SmtpFailedRecipientException smtpException)
                {


                }
                catch (Exception ex)
                {
                }
            }
            if (filterContext.RequestContext.HttpContext.Request.IsAjaxRequest())
            {
                filterContext.Result = new JsonResult
                {
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet,
                    Data = new { error = true }
                };
            }
            filterContext.ExceptionHandled = true;
        }
    }
}