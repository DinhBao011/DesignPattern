using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace ClothingShop.Models.DecoratorPattern
{
    public class ConcreteCustomer : CustomerDecorator
    {
        public ConcreteCustomer() 
        {
            CusName = "";
            Email = "";
            Password = "";
        }
        public override Customer MakeCustomer()
        {
            Customer customer = new Customer();
            customer.CustomerName = CusName;
            customer.EmailCus = Email;
            customer.Password = Password;
            return customer;
        }
    }
}