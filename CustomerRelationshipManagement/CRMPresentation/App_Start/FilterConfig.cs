using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMPresentation.App_Start
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new SessionExpireAttribute());
            filters.Add(new NoCacheAttribute());
            filters.Add(new AuthorizeActivity());
            filters.Add(new ExceptionHandlerAttribute());
        }
    }
}