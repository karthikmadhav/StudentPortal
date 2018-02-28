using CRM.BusinessLayer.BusinessModels;
using CRM.BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity.Attributes;

namespace CRMPresentation.Controllers
{
    public class ProductController : Controller
    {
        //Multiple Concrete Implementation
        private IProduct _IProduct;
        private IProduct _IProductTest;

        public ProductController([Dependency("ProductService")]IProduct iproduct, [Dependency("ProductService1")]IProduct iproductTest)
        {
            this._IProduct = iproduct;
            this._IProductTest = iproductTest;
        }
        // GET: Product
        public ActionResult NewProduct()
        {
            return View();
        }
        [HttpPost]
        public string NewProduct(Product prod)
        {
            return "Product Added Successfully";
        }
        [HttpPost]
        public string UpdateProduct(Product prod)
        {
            return "Product Updated Successfully";
        }
        public ActionResult ViewProduct()
        {
            return View();

        }
        public JsonResult GetProductList()
        {
            var productList = _IProduct.GetProductList();
            return Json(productList, JsonRequestBehavior.AllowGet);
        }
        public string DeleteProduct(Product prod)
        {
            if (prod != null)
            {
                return "Product Deleted Successfully";
            }
            else
                return "Product Not Deleted! Try Again";
        }
        [HttpPost]

        public JsonResult SearchProduct(Product prod)
        {
            var productList = _IProduct.GetProductList();
            return Json(productList, JsonRequestBehavior.AllowGet);
        }
    }
}