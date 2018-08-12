using CRM.BusinessLayer.BusinessModels;
using CRM.BusinessLayer.Interfaces;
using CRM.DataAccessLayer.Interfaces;
using CRM.DataAccessLayer.Providers.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.Common.Models;

namespace CRM.BusinessLayer.Services
{
   public class CustomerService:ICustomerDetails
    {
        private ICustomerProvider _customerProvider;
        public CustomerService(ICustomerProvider custProvider)
        {
            _customerProvider = custProvider;
        }
        public List<CustomerDetails> GetCustomerList()
        {
            List<CustomerDetails> customerDetails = new List<CustomerDetails>();
            var çustResult = _customerProvider.GetCustomerList();
            foreach (var items in çustResult)
            {
                CustomerDetails customer = new CustomerDetails();
                customer.CustomerID = items.CustomerID;
                customer.CustomerName = items.CustomerName;
                customer.ContactPersonNo = items.ContactPersonNo;
                customer.ContactPersonName = items.ContactPersonName;
                customer.IndustryCategoryId = items.IndustryCategoryId;
                customer.Website = items.Website;
                customer.ShippingAddress = items.ShippingAddress;
                customer.ShippingAddress1 = items.ShippingAddress1;
                customer.ShippingCity = items.ShippingCity;
                customer.ShippingState = items.ShippingState;
                customer.ShippingCountry = items.ShippingCountry;
                customer.ShippingPincode = items.ShippingPincode;
                customer.BillingAddress = items.BillingAddress;
                customer.BillingAddress1 = items.BillingAddress1;
                customer.BillingCity = items.BillingCity;
                customer.BillingState = items.BillingState;
                customer.BillingCountry = items.BillingCountry;
                customer.BillingPincode = items.BillingPincode;
                customer.PrimaryPhoneNo = items.PrimaryPhoneNo;
                customer.PrimaryMailID = items.PrimaryMailID;
                customer.GSTNO = items.GSTNO;
                customerDetails.Add(customer);
            }
            return customerDetails;
        }
        public bool SaveCustomer(CustomerDetails CustDetails)
        {
            bool result = false;
            DLCustomerDetails customer = new DLCustomerDetails();
            customer.CustomerID = CustDetails.CustomerID;
            customer.CustomerName = CustDetails.CustomerName;
            customer.PrimaryMailID = CustDetails.PrimaryMailID;
            customer.PrimaryPhoneNo = CustDetails.PrimaryPhoneNo;
            customer.Fax = CustDetails.Fax;
            customer.Website = CustDetails.Website;
            customer.IndustryCategoryId = CustDetails.IndustryCategoryId;
            customer.ContactPersonNo = CustDetails.ContactPersonNo;
            customer.ContactPersonName = CustDetails.ContactPersonName;
            customer.ShippingAddress = CustDetails.ShippingAddress;
            customer.ShippingAddress1 = CustDetails.ShippingAddress1;
            customer.ShippingCity = CustDetails.ShippingCity;
            customer.ShippingState = CustDetails.ShippingState;
            customer.ShippingCountry = CustDetails.ShippingCountry;
            customer.ShippingPincode = CustDetails.ShippingPincode;
            customer.BillingAddress = CustDetails.BillingAddress;
            customer.BillingAddress1 = CustDetails.BillingAddress1;
            customer.BillingCity = CustDetails.BillingCity;
            customer.BillingState = CustDetails.BillingState;
            customer.BillingCountry = CustDetails.BillingCountry;
            customer.BillingPincode = CustDetails.BillingPincode;
            customer.GSTNO = CustDetails.GSTNO;
            result = _customerProvider.SaveCustomer(customer);
            return result;
        }
        public bool UpdateCustomer(CustomerDetails CustDetails)
        {
            bool result = false;
            DLCustomerDetails customer = new DLCustomerDetails();
            customer.CustomerID = CustDetails.CustomerID;
            customer.CustomerName = CustDetails.CustomerName;
            customer.PrimaryMailID = CustDetails.PrimaryMailID;
            customer.PrimaryPhoneNo = CustDetails.PrimaryPhoneNo;
            customer.Fax = CustDetails.Fax;
            customer.Website = CustDetails.Website;
            customer.IndustryCategoryId = CustDetails.IndustryCategoryId;
            customer.ContactPersonNo = CustDetails.ContactPersonNo;
            customer.ContactPersonName = CustDetails.ContactPersonName;
            customer.ShippingAddress = CustDetails.ShippingAddress;
            customer.ShippingAddress1 = CustDetails.ShippingAddress1;
            customer.ShippingCity = CustDetails.ShippingCity;
            customer.ShippingState = CustDetails.ShippingState;
            customer.ShippingCountry = CustDetails.ShippingCountry;
            customer.ShippingPincode = CustDetails.ShippingPincode;
            customer.BillingAddress = CustDetails.BillingAddress;
            customer.BillingAddress1 = CustDetails.BillingAddress1;
            customer.BillingCity = CustDetails.BillingCity;
            customer.BillingState = CustDetails.BillingState;
            customer.BillingCountry = CustDetails.BillingCountry;
            customer.BillingPincode = CustDetails.BillingPincode;
            customer.GSTNO = CustDetails.GSTNO;
            result = _customerProvider.UpdateCustomer(customer);
            return result;
        }
        public bool DeleteCustomer(int customerID)
        {
            bool result = false;
            result = _customerProvider.DeleteCustomer(customerID);
            return result;
        }
        public CustomerDetails GetCustomerByID(int custID)
        {
                var items = _customerProvider.GetCustomerByID(custID);
                CustomerDetails customer = new CustomerDetails();
                customer.CustomerID = items.CustomerID;
                customer.CustomerName = items.CustomerName;
                customer.ContactPersonNo = items.ContactPersonNo;
                customer.ContactPersonName = items.ContactPersonName;
                customer.IndustryCategoryId = items.IndustryCategoryId;
                customer.Website = items.Website;
                customer.ShippingAddress = items.ShippingAddress;
                customer.ShippingAddress1 = items.ShippingAddress1;
                customer.ShippingCity = items.ShippingCity;
                customer.ShippingState = items.ShippingState;
                customer.ShippingCountry = items.ShippingCountry;
                customer.ShippingPincode = items.ShippingPincode;
                customer.BillingAddress = items.BillingAddress;
                customer.BillingAddress1 = items.BillingAddress1;
                customer.BillingCity = items.BillingCity;
                customer.BillingState = items.BillingState;
                customer.BillingCountry = items.BillingCountry;
                customer.BillingPincode = items.BillingPincode;
                customer.PrimaryPhoneNo = items.PrimaryPhoneNo;
                customer.PrimaryMailID = items.PrimaryMailID;
                customer.Fax = items.Fax;
                customer.GSTNO = items.GSTNO;
            return customer;
        }

        public int SaveKYC(KYCDetails kycDetails)
        {
            return _customerProvider.SaveKYC(kycDetails);
        }

        public List<KYCDetails> GetKYCByCustID(int custID)
        {
            return _customerProvider.GetKYCByCustID(custID);

        }
    }
}
