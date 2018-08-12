using CRM.BusinessLayer.Interfaces;
using CRM.DataAccessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRM.BusinessLayer.BusinessModels;
using CRM.DataAccessLayer.Providers.DataModel;

namespace CRM.BusinessLayer.Services
{
   public class CompanyService: ICompanyDetails
    {
        private ICompanyProvider _companyProvider;
        public CompanyService(ICompanyProvider compProvider)
        {
            _companyProvider = compProvider;
        }

        public bool DeleteCompany(int CompanyId)
        {
            throw new NotImplementedException();
        }

        public CompanyDetails GetCompanyByID(int compID)
        {
            throw new NotImplementedException();
        }

        public List<CompanyDetails> GetCompanyList()
        {
            List<CompanyDetails> customerDetails = new List<CompanyDetails>();
            var çustResult = _companyProvider.GetCompanyList();
            foreach (var items in çustResult)
            {
                CompanyDetails customer = new CompanyDetails();
                customer.CompanyID = items.CompanyID;
                customer.CompanyName = items.CompanyName;
                //customer.ContactPersonNo = items.ContactPersonNo;
                //customer.ContactPersonName = items.ContactPersonName;
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

        public bool SaveCompany(CompanyDetails CompDetails)
        {
            bool result = false;
            DLCompanyDetails company = new DLCompanyDetails();
            company.CompanyID = CompDetails.CompanyID;
            company.CompanyName = CompDetails.CompanyName;
            company.PrimaryMailID = CompDetails.PrimaryMailID;
            company.PrimaryPhoneNo = CompDetails.PrimaryPhoneNo;
            company.Fax = CompDetails.Fax;
            company.Website = CompDetails.Website;
            company.IndustryCategoryId = CompDetails.IndustryCategoryId;
            company.ShippingAddress = CompDetails.ShippingAddress;
            company.ShippingAddress1 = CompDetails.ShippingAddress1;
            company.ShippingCity = CompDetails.ShippingCity;
            company.ShippingState = CompDetails.ShippingState;
            company.ShippingCountry = CompDetails.ShippingCountry;
            company.ShippingPincode = CompDetails.ShippingPincode;
            company.BillingAddress = CompDetails.BillingAddress;
            company.BillingAddress1 = CompDetails.BillingAddress1;
            company.BillingCity = CompDetails.BillingCity;
            company.BillingState = CompDetails.BillingState;
            company.BillingCountry = CompDetails.BillingCountry;
            company.BillingPincode = CompDetails.BillingPincode;
            company.GSTNO = CompDetails.GSTNO;
            result = _companyProvider.SaveCompany(company);
            return result;
        }

        public bool UpdateCompany(CompanyDetails CompDetails)
        {
            throw new NotImplementedException();
        }
    }
}
