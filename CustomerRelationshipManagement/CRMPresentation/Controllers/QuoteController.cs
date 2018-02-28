using CRM.BusinessLayer.BusinessModels;
using CRM.BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMPresentation.Controllers
{
    public class QuoteController : Controller
    {
        private ICustomerDetails _ICustomerDetails;

        public QuoteController(ICustomerDetails CustomerDetails)
        {
            _ICustomerDetails = CustomerDetails;
        }
        // GET: Quote
        public ActionResult GenerateQuote()
        {
            QuoteDetails qt = new QuoteDetails();
            qt.custList = _ICustomerDetails.GetCustomerList();
            return View(qt);
        }
        public string SaveQuote(QuoteDetails quoteDetails)
        {
            return "Product Added Successfully";
        }
    }
  
}