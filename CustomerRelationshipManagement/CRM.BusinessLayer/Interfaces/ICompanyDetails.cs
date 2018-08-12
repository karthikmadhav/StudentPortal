using CRM.BusinessLayer.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.Interfaces
{
   public interface ICompanyDetails
    {
       
            List<CompanyDetails> GetCompanyList();
            bool SaveCompany(CompanyDetails CompDetails);
            bool UpdateCompany(CompanyDetails CompDetails);
            bool DeleteCompany(int CompanyId);
            CompanyDetails GetCompanyByID(int compID);
    }
}
