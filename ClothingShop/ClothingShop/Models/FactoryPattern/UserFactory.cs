using ClothingShop.Models.SingletenPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClothingShop.Models.FactoryPattern
{
    public class UserFactory : Controller, ILogin<Customer>
    {
        [HttpGet]
        public bool Login(string account)
        {
            return account != null;
        }
        [HttpPost]
        public bool Login(Customer customer, ref object account)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrEmpty(customer.EmailCus))
                {
                    ModelState.AddModelError(string.Empty, "Username is not empty");
                }
                if (string.IsNullOrEmpty(customer.Password))
                {
                    ModelState.AddModelError(string.Empty, "Password is not empty");
                }
                if (ModelState.IsValid)
                {
                    //Find customer have username and password invalid in database
                    var customerK = SingletonData.Instance.Customers.
                        FirstOrDefault(cK => cK.EmailCus == customer.EmailCus && cK.Password == customer.Password);
                    if (customerK != null)
                    {
                        account = customerK;
                        return true;
                    }
                    else
                    {
                        ViewBag.Notify = "Username or password is incorrect";
                        return false;
                    }
                }
            }
            return false;
        }
    }
}