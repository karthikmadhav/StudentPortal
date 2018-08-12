using CRM.BusinessLayer.BusinessModels;
using CRM.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.Interfaces
{
   public interface ICustomerDetails
    {
        List<CustomerDetails> GetCustomerList();
        bool SaveCustomer(CustomerDetails CustDetails);
        bool UpdateCustomer(CustomerDetails CustDetails);
        bool DeleteCustomer(int CustomerId);
        CustomerDetails GetCustomerByID(int custID);
        int SaveKYC(KYCDetails kycDetails);
        List<KYCDetails> GetKYCByCustID(int custID);

    }
}
