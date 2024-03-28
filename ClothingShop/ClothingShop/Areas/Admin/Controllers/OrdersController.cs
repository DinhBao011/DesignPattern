using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ClothingShop.Models;
using ClothingShop.Models.SingletenPattern;
using ClothingShop.Models.StatePattern;

namespace ClothingShop.Areas.Admin.Controllers
{
    public class OrdersController : Controller
    {
        private ClothingStoreEntities db = new ClothingStoreEntities();

        // GET: Admin/Orders
        public ActionResult Index(string Search = "")
        {
            if (Search != "")
            {
                var order = db.Orders.Include(o => o.Customer).Where(x => x.Customer.CustomerName.ToUpper().Contains(Search.ToUpper()));
                return View(order.ToList());
            }
            else
            {
                var orders = db.Orders.Include(o => o.Customer);
                return View(orders.ToList());
            }
        }

        // GET: Admin/Orders/Details/5
        public ActionResult Details(int id)
        {
            var detailList = db.OrderDetails.Where(item => item.IDOrder == id).ToList();
            ViewBag.Detail = detailList;

            decimal total = 0;
            foreach (var item in detailList)
            {
                total += item.UnitPrice.GetValueOrDefault();
            }
            ViewBag.Total = total;
            var order = db.Orders.FirstOrDefault(item => item.IDOrder == id);
            return View(order);
        }

        public ActionResult ConfirmOrder(int id)
        {
            var order = db.Orders.FirstOrDefault(item => item.IDOrder == id);
            if(order != null)
            {
                #region StatePattern
                OrderState orderS = new OrderState(new PendingState());
                orderS.ApproveOrder(order);
                #endregion
                db.SaveChanges();


            }
            //order.Status = 1;
            //db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
