using CRM.BusinessLayer.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.Interfaces
{
    public interface IIndustryCategory
    {
        List<IndustryCategory> GetIndustryCategoryList();
        bool SaveIndustryCategory(IndustryCategory IndustryCategory);
        bool UpdateIndustryCategory(IndustryCategory IndustryCategory);
        bool DeleteIndustryCategory(int IndustryCategoryId);
    }
}
