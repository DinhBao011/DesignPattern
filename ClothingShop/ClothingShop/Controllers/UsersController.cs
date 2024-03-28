using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ClothingShop.Models;
using ClothingShop.Models.DecoratorPattern;
using ClothingShop.Models.DecoratorPattern.NotifierDecorator;
using ClothingShop.Models.FactoryPattern;
using ClothingShop.Models.SingletenPattern;

namespace ClothingShop.Controllers
{
    public class UsersController : Controller
    {
        LoginFactory<Customer> loginFactory;
        ILogin<Customer> user;
        object account;

        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        void CreateLogin()
        {
            loginFactory = new LoginUserFac();
            user = loginFactory.CreateLogin();
        }

        [HttpGet]
        public ActionResult Login()
        {
            String account = Session["Account"] as String;
            CreateLogin();
            if (user.Login(account))
            {
                return Redirect("/Home/Index");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult Login(Customer cus)
        {

            CreateLogin();
            if (user.Login(cus, ref account))
            {
                Session["Account"] = account;
                return Redirect("/");
            }
            else if (cus.EmailCus == "dakt@gmail.com" && cus.Password == "12345")
            {
                return RedirectToAction("Index", "Admin/Orders");
            }
            else
                return View();
        }

        public ActionResult Logout()
        {
            Session["Account"] = null;
            Session["GioHang"] = null ;
            return RedirectToAction("Login", "Users");
        }
        [HttpGet]

        public ActionResult SignUp()
        {
            String account = Session["Account"] as String;
            if (account != null)
            {
                return Redirect("/Home/Index");
            }
            return View();
        }
        [HttpPost]

        public ActionResult SignUp(Customer cus)
        {
            #region Factory Method
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(cus.CustomerName))
                {
                    ModelState.AddModelError(string.Empty, "Username is not empty");
                }
                if (string.IsNullOrEmpty(cus.EmailCus))
                {
                    ModelState.AddModelError(string.Empty, "Email is not empty");
                }
                if (string.IsNullOrEmpty(cus.Password))
                {
                    ModelState.AddModelError(string.Empty, "Password is not empty");
                }

                var customer = SingletonData.Instance.Customers.FirstOrDefault(c => c.EmailCus == cus.EmailCus);
                if (customer != null)
                {
                    ModelState.AddModelError(string.Empty, "This email is already registered");
                }

                if (ModelState.IsValid)
                {
                    Customer customer1 = new Customer();
                    CustomerDecorator cusD = new ConcreteCustomer();
                    cusD.MakeCustomer();

                    cusD = new CusNameDecorator(cusD, cus.CustomerName, customer1);
                    customer1 = cusD.MakeCustomer();

                    cusD = new EmailCusDecorator(cusD, cus.EmailCus, customer1);
                    customer1 = cusD.MakeCustomer();

                    cusD = new PasswordDecorator(cusD, cus.Password, customer1);
                    customer1 = cusD.MakeCustomer();

                    SingletonData.Instance.Customers.Add(customer1);
                    SingletonData.Instance.SaveChanges();
                }
                else
                {
                    return View();
                }
            }
            return RedirectToAction("login");
            #endregion
        }
    }
}