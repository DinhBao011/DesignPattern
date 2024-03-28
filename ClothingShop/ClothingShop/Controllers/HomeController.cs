using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothingShop.Models;

namespace ClothingShop.Controllers
{
    public class HomeController : Controller
    {
        ClothingStoreEntities db = new ClothingStoreEntities();
        public ActionResult Index()
        {
            var prod = db.Products.ToList().Take(8);
            return View(prod);
        }

       
    }
}