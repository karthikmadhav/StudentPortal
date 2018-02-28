using CRM.BusinessLayer.BusinessModels;
using CRM.BusinessLayer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.Interfaces
{
   public interface IProduct
    {
        List<Product> GetProductList();
        bool SaveProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int prodID);
    }
}
