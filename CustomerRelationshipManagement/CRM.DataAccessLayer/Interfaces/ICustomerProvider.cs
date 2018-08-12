using CRM.Common.Models;
using CRM.DataAccessLayer.Providers.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DataAccessLayer.Interfaces
{
   public interface ICustomerProvider
    {
        List<DLCustomerDetails> GetCustomerList();
        bool SaveCustomer(DLCustomerDetails CustDetails);
        bool UpdateCustomer(DLCustomerDetails CustDetails);
        bool DeleteCustomer(int CustomerId);
        DLCustomerDetails GetCustomerByID(int custID);
        int SaveKYC(KYCDetails kycDetails);
        List<KYCDetails> GetKYCByCustID(int custID);
    }
}
