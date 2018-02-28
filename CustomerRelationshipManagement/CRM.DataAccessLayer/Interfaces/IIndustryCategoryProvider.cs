using CRM.DataAccessLayer.Providers.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.DataAccessLayer.Interfaces
{
    public interface IIndustryCategoryProvider
    {
        List<DLLIndustryCategory> GetIndustryCategoryList();
        bool SaveIndustryCategory(DLLIndustryCategory IndustryCategory);
        bool UpdateIndustryCategory(DLLIndustryCategory IndustryCategory);
        bool DeleteIndustryCategory(int IndustryCategoryId);
    }
}
