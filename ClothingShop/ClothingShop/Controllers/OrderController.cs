using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothingShop.Models;

namespace ClothingShop.Controllers
{
    public class OrderController : Controller
    {
        ClothingStoreEntities db = new ClothingStoreEntities();
        // GET: Order
        public ActionResult Index(int id)
        {
            var orderList = (from order in db.Orders orderby order.IDOrder descending where order.IDCus == id select order).ToList();
            return View(orderList);
        }
        
    }
}