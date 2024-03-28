using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingShop.Models.DecoratorPattern.NotifierDecorator
{
    public class PasswordDecorator : AbstractDecorator
    {
        Customer _customer;
        public PasswordDecorator(CustomerDecorator customerD, string password, Customer customer) : base(customerD)
        {
            this._customer = customer;
            Password = password;
        }
        public override Customer MakeCustomer()
        {
            base.MakeCustomer();
            Customer customerD = _customer;
            customerD.Password = Password;
            return customerD;
        }
    }
}