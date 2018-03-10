using CRM.BusinessLayer.BusinessModels;
using CRM.BusinessLayer.Interfaces;
using CRM.Common.Models;
using CRMPresentation.App_Start;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRMPresentation.Controllers
{
    public class CustomerController : Controller
    {
        private IIndustryCategory _IndustryCategory;
        private ICustomerDetails _ICustomerDetails;
        public CustomerController(IIndustryCategory industryCategory, ICustomerDetails CustomerDetails)
        {
            _IndustryCategory = industryCategory;
            _ICustomerDetails = CustomerDetails;
        }
        // GET: Customer
        public ActionResult NewCustomer()
        {
            //Get Industry Category
            List<IndustryCategory> industryCategory = new List<IndustryCategory>();
            industryCategory = _IndustryCategory.GetIndustryCategoryList();

            CustomerDetails customerDet = new CustomerDetails();
            customerDet.IndustryCategoryList = industryCategory;
            return View(customerDet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthorizeActivity()]
        public ActionResult NewCustomer(CustomerDetails customerDetails)
        {
            bool result = false;
            List<IndustryCategory> industryCategory = new List<IndustryCategory>();
            industryCategory = _IndustryCategory.GetIndustryCategoryList();
            CustomerDetails customerDet = new CustomerDetails();
            customerDet.IndustryCategoryList = industryCategory;
            if (ModelState.IsValid)
            {
                result = _ICustomerDetails.SaveCustomer(customerDetails);
            }
            if(result)
                return RedirectToAction("ViewCustomer");
            else
            return View(customerDet);
        }
        public ActionResult ViewCustomer()
        {
            var customerCollection= _ICustomerDetails.GetCustomerList();
            List<CustomerDetails> custDetails = new List<CustomerDetails>();
            foreach (var items in customerCollection)
            {
                CustomerDetails customerDet = new CustomerDetails();
                customerDet.CustomerName = items.CustomerName;
                customerDet.CustomerID = items.CustomerID;
                customerDet.BillingAddress = items.BillingAddress;
                customerDet.BillingAddress1 =items.BillingAddress1;
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
                custDetails.Add(customerDet);
            }
            return View(custDetails);
        }
        public ActionResult CompanyDetails(int Id)
        {
            CustomerDetails customerDet = new CustomerDetails();
            customerDet.CustomerName = "ABC Company";
            customerDet.CustomerID = 1;
            customerDet.BillingAddress = "XXXX";
            customerDet.BillingAddress1 = "YYY";
            customerDet.BillingCity = "ZZZ";
            customerDet.BillingState = "CCCC";
            customerDet.BillingCountry = "BBB";
            customerDet.BillingPincode = "12345";
            customerDet.ShippingAddress = "XXXX";
            customerDet.ShippingAddress1 = "YYY";
            customerDet.ShippingCity = "ZZZ";
            customerDet.ShippingState = "CCCC";
            customerDet.ShippingCountry = "BBB";
            customerDet.ShippingPincode = "12345";
            customerDet.PrimaryMailID = "GGG@GMAIL.COM";
            customerDet.PrimaryPhoneNo = "94839933233";
            customerDet.Fax = "3333";
            customerDet.IndustryCategoryId = 1;
            return PartialView("CustomerDetails", customerDet);
        }
        public ActionResult DeleteCustomer(int Id)
        {
            bool result = false;
            result = _ICustomerDetails.DeleteCustomer(Id);
            return RedirectToAction("ViewCustomer");
        }
        public ActionResult EditCustomer(int Id)
        {
            CustomerDetails customerDet = new CustomerDetails();
            customerDet = _ICustomerDetails.GetCustomerByID(Id);
            List<IndustryCategory> industryCategory = new List<IndustryCategory>();
            industryCategory = _IndustryCategory.GetIndustryCategoryList();
            customerDet.IndustryCategoryList = industryCategory;
            return View(customerDet);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditCustomer(CustomerDetails custDetails,int id)
        {
            if(id>0)
            custDetails.CustomerID = id;

            bool result = _ICustomerDetails.UpdateCustomer(custDetails);
            return RedirectToAction("ViewCustomer");
        }
        public ActionResult CustomerDetails( int id)
        {
            ViewBag.custID = id;
            Session["CustomerID"] = id;
            CustomerDetails customerDet = new CustomerDetails();
            customerDet = _ICustomerDetails.GetCustomerByID(id);
            return View(customerDet);
        }
        [HttpPost]
        public ActionResult CustomerFileUpload(HttpPostedFileBase file)
        {
            string path1 = Server.MapPath("/compDoc/sample_PDF.PDF");
            string custID = Session["CustomerID"].ToString();
            int id = Convert.ToInt32(custID);

            if (file != null && file.ContentLength > 0)
            {
                string path = Path.Combine(Server.MapPath("~/compDoc"),
                                       Path.GetFileName(file.FileName));
                file.SaveAs(path);
                ViewBag.Message = "File uploaded successfully";

            }
            CustomerDetails customerDet = new CustomerDetails();
            customerDet = _ICustomerDetails.GetCustomerByID(id);
            return RedirectToAction("ViewCustomer");
        }
        public JsonResult GetCustomerList()
        {
            var customerCollection = _ICustomerDetails.GetCustomerList();
            return Json(customerCollection, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCustDetails(int CustomerID)
        {
            CustomerDetails customerDet = new CustomerDetails();
            customerDet = _ICustomerDetails.GetCustomerByID(CustomerID);
            return Json(customerDet, JsonRequestBehavior.AllowGet);
        }
    }
}