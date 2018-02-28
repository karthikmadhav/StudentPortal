using CRM.BusinessLayer.BusinessModels;
using CRM.BusinessLayer.Interfaces;
using CRM.DataAccessLayer.Interfaces;
using CRM.DataAccessLayer.Providers;
using CRM.DataAccessLayer.Providers.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CRM.WebAPI.Controllers
{
    public class CustomerController : ApiController
    {
        private ICustomerProvider _ICustomerDetails;
        public CustomerController()
        {
            _ICustomerDetails = new CustomerDetailsProvider();
        }
        public IHttpActionResult GetCustomer()
        {
            return Ok<List<DLCustomerDetails>>(_ICustomerDetails.GetCustomerList());
        }
        public IHttpActionResult CustomerDetails(int Id)
        {
            return Ok<DLCustomerDetails>(_ICustomerDetails.GetCustomerByID(Id));
        }
        public bool NewCustomer(CustomerDetails items)
        {
            bool result = false;

            DLCustomerDetails customerDet = new DLCustomerDetails();
            customerDet.CustomerName = items.CustomerName;
            customerDet.CustomerID = items.CustomerID;
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
            //if (ModelState.IsValid)
            //{
                result = _ICustomerDetails.SaveCustomer(customerDet);
            //}
            return result;
        }
    }
}
