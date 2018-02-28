using CRM.BusinessLayer.BusinessModels;
using CRM.BusinessLayer.Interfaces;
using CRM.DataAccessLayer.Interfaces;
using CRM.DataAccessLayer.Providers.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.Services
{
   public class IndustryCategoryService: IIndustryCategory
    {
        private IIndustryCategoryProvider _IndustryCategory;
        public IndustryCategoryService(IIndustryCategoryProvider IndustryProvider)
        {
            //_LeadProvider = new LeadSourceProvider();
            _IndustryCategory = IndustryProvider;
        }

        public List<IndustryCategory> GetIndustryCategoryList()
        {
            List<IndustryCategory> industryCategory = new List<IndustryCategory>();
            var industryResult = _IndustryCategory.GetIndustryCategoryList();
            foreach (var items in industryResult)
            {
                IndustryCategory industry = new IndustryCategory();
                industry.IndustryCategoryId = items.IndustryCategoryId;
                industry.IndustryCategoryName = items.IndustryCategoryName;
                industry.Status = items.Status;
                industryCategory.Add(industry);
            }
            return industryCategory;
        }

        public bool SaveIndustryCategory(IndustryCategory IndustryCategory)
        {
            DLLIndustryCategory industryCategory = new DLLIndustryCategory();
            industryCategory.IndustryCategoryName = IndustryCategory.IndustryCategoryName;
            industryCategory.Status = IndustryCategory.Status;

            bool result = false;
            result= _IndustryCategory.SaveIndustryCategory(industryCategory);
            return result;
        }
        public bool UpdateIndustryCategory(IndustryCategory IndustryCategory)
        {
            return true;
        }
        public bool DeleteIndustryCategory(int IndustryCategoryId)
        {
            return true;
        }
    }
}
