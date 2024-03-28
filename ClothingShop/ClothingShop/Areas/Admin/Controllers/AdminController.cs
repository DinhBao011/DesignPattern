using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothingShop.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        public ActionResult AdminLogout()
        {
            Session["Account"] = null;
            Session["GioHang"] = null;
            return Redirect("~/Home/Index");

        }
    }
}