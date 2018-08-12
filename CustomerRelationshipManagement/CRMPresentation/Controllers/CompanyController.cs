using CRM.BusinessLayer.BusinessModels;
using CRM.BusinessLayer.Interfaces;
using CRMPresentation.App_Start;
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
        private ICompanyDetails _ICompanyDetails;

        public CompanyController(IIndustryCategory industryCategory, ICompanyDetails companyDetails)
        {
            _IndustryCategory = industryCategory;
            _ICompanyDetails = companyDetails;


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
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeActivity()]
        public ActionResult NewCompany(CompanyDetails companyDetails)
        {
            bool result = false;
            List<IndustryCategory> industryCategory = new List<IndustryCategory>();
            industryCategory = _IndustryCategory.GetIndustryCategoryList();
            CompanyDetails companyDet = new CompanyDetails();
            companyDet.IndustryCategoryList = industryCategory;
            if (ModelState.IsValid)
            {
                result = _ICompanyDetails.SaveCompany(companyDetails);
            }
            if (result)
                return RedirectToAction("ViewCompany");
            else
                return View(companyDet);
        }
        public ActionResult ViewCompany()
        {
            var companyCollection = _ICompanyDetails.GetCompanyList();
            List<CompanyDetails> comptDetails = new List<CompanyDetails>();
            foreach (var items in companyCollection)
            {
                CompanyDetails customerDet = new CompanyDetails();
                customerDet.CompanyName = items.CompanyName;
                customerDet.CompanyID = items.CompanyID;
                customerDet.BillingAddress = items.BillingAddress;
                customerDet.BillingAddress1 = items.BillingAddress1;
                customerDet.BillingCity = items.BillingCity;
                customerDet.BillingState = items.BillingState;
                customerDet.BillingCountry = items.BillingCountry;
                customerDet.BillingPincode = items.BillingPincode;
                customerDet.ShippingAddress = items.ShippingAddress;
                customerDet.ShippingAddress1 = items.ShippingAddress1;
                customerDet.ShippingCity = items.ShippingCity;
                customerDet.ShippingState = items.ShippingState;
                customerDet.ShippingCountry = items.ShippingCountry;
                customerDet.ShippingPincode = items.ShippingPincode;
                customerDet.PrimaryMailID = items.PrimaryMailID;
                customerDet.PrimaryPhoneNo = items.PrimaryPhoneNo;
                customerDet.Fax = items.Fax;
                customerDet.IndustryCategoryId = items.IndustryCategoryId;
                comptDetails.Add(customerDet);
            }
            return View(comptDetails);
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