using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothingShop.Models;
using ClothingShop.Models.SingletenPattern;

namespace ClothingShop.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        public ActionResult Index(int id)
        {
            ViewBag.Product = SingletonData.Instance.Products.FirstOrDefault(p => p.ProductID == id);

            
            ViewBag.ProdList = SingletonData.Instance.Products.ToList().Take(4);
            return View();
        }
    }
}