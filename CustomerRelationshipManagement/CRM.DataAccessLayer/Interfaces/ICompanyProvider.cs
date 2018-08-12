using CRM.DataAccessLayer.Providers.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DataAccessLayer.Interfaces
{
    public interface ICompanyProvider
    {
        List<DLCompanyDetails> GetCompanyList();
        bool SaveCompany(DLCompanyDetails CompDetails);
        bool UpdateCompany(DLCompanyDetails CompDetails);
        bool DeleteCompany(int CompanyId);
        DLCompanyDetails GetCompanyByID(int compID);
    }
}
