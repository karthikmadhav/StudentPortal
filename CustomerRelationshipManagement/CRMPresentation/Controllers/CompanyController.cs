using CRM.BusinessLayer.BusinessModels;
using CRM.BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMPresentation.Controllers
{
    public class CompanyController : Controller
    {
        private IIndustryCategory _IndustryCategory;
      

        public CompanyController(IIndustryCategory industryCategory)
        {
            _IndustryCategory = industryCategory;
           
        }
        // GET: Company
        public ActionResult NewCompany()
        {
            List<IndustryCategory> industryCategory = new List<IndustryCategory>();
            industryCategory = _IndustryCategory.GetIndustryCategoryList();

            CompanyDetails companyDet = new CompanyDetails();
            companyDet.IndustryCategoryList = industryCategory;

            return View(companyDet);
        }
        public ActionResult ViewCompany()
        {
            List<CompanyDetails> companyDetails = new List<CompanyDetails>();
            CompanyDetails companyDet = new CompanyDetails();
            companyDet.CompanyName = "ABC Company";
            companyDet.CompanyID = 1;
            companyDet.BillingAddress = "XXXX";
            companyDet.BillingAddress1 = "YYY";
            companyDet.BillingCity="ZZZ";
            companyDet.BillingState = "CCCC";
            companyDet.BillingCountry = "BBB";
            companyDet.BillingPincode = "12345";
            companyDet.ShippingAddress = "XXXX";
            companyDet.ShippingAddress1 = "YYY";
            companyDet.ShippingCity = "ZZZ";
            companyDet.ShippingState = "CCCC";
            companyDet.ShippingCountry = "BBB";
            companyDet.ShippingPincode = "12345";
            companyDet.PrimaryMailID = "GGG@GMAIL.COM";
            companyDet.PrimaryPhoneNo = "94839933233";
            companyDet.Fax = "3333";
            companyDet.AnnualRevenue = 123554;
            companyDetails.Add(companyDet);
            return View(companyDetails);
        }
        public ActionResult CompanyDetails(int Id)
        {
            CompanyDetails companyDet = new CompanyDetails();
            companyDet.CompanyName = "ABC Company";
            companyDet.CompanyID = 1;
            companyDet.BillingAddress = "XXXX";
            companyDet.BillingAddress1 = "YYY";
            companyDet.BillingCity = "ZZZ";
            companyDet.BillingState = "CCCC";
            companyDet.BillingCountry = "BBB";
            companyDet.BillingPincode = "12345";
            companyDet.ShippingAddress = "XXXX";
            companyDet.ShippingAddress1 = "YYY";
            companyDet.ShippingCity = "ZZZ";
            companyDet.ShippingState = "CCCC";
            companyDet.ShippingCountry = "BBB";
            companyDet.ShippingPincode = "12345";
            companyDet.PrimaryMailID = "GGG@GMAIL.COM";
            companyDet.PrimaryPhoneNo = "94839933233";
            companyDet.Fax = "3333";
            companyDet.AnnualRevenue = 123554;
            return PartialView("CompanyDetails",companyDet);
        }
        public ActionResult DeleteCompany(int Id)
        {
            return RedirectToAction("ViewCompany");
        }
        public ActionResult EditCompany(CompanyDetails compDetails)
        {
            return RedirectToAction("ViewCompany");

        }
    }
}