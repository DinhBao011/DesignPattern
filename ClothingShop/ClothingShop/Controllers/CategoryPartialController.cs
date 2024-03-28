using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothingShop.Models;
using ClothingShop.Models.SingletenPattern;

namespace ClothingShop.Controllers
{
    public class CategoryPartialController : Controller
    {
        // GET: CategoryPartial
        public ActionResult PartialCate()
        {
            ViewBag.CategoryList = SingletonData.Instance.Categories.ToList();
            return PartialView();
        }
    }
}