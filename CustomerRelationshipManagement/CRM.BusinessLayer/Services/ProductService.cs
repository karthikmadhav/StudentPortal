using CRM.BusinessLayer.BusinessModels;
using CRM.BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM.BusinessLayer.Services
{
   public class ProductService: IProduct
    {
        public List<Product> GetProductList()
        {
            List<Product> productList = new List<Product>();
            productList.Add(new Product { ProdID = 1, ProdName = "Product One", ProdDesc = "New Product", Status = 'Y' });
            productList.Add(new Product { ProdID = 1, ProdName = "Product Two", ProdDesc = "Old Product", Status = 'Y' });
            productList.Add(new Product { ProdID = 1, ProdName = "Product Three", ProdDesc = "Product-2010", Status = 'Y' });
            productList.Add(new Product { ProdID = 1, ProdName = "Product Four", ProdDesc = "Product-2011", Status = 'Y' });
            productList.Add(new Product { ProdID = 1, ProdName = "Product Five", ProdDesc = "Product-2013", Status = 'Y' });
            return productList;
        }
        public bool SaveProduct(Product product)
        {
            return true;
        }
        public bool UpdateProduct(Product product)
        {
            return true;
        }
        public bool DeleteProduct(int prodID)
        {
            return true;
        }
    }

}
