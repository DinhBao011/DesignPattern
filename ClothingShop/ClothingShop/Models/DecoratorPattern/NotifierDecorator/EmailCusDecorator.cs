using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingShop.Models.DecoratorPattern.NotifierDecorator
{
    public class EmailCusDecorator : AbstractDecorator
    {
        Customer _customer;
        public EmailCusDecorator(CustomerDecorator customerD, string email, Customer customer) : base(customerD)
        {
            this._customer = customer;
            Email = email;
        }
        public override Customer MakeCustomer()
        {
            base.MakeCustomer();
            Customer customerD = _customer;
            customerD.EmailCus = Email;
            return customerD;
        }
    }
}