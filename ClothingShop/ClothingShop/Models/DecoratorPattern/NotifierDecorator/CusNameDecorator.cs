using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace ClothingShop.Models.DecoratorPattern.NotifierDecorator
{
    public class CusNameDecorator : AbstractDecorator
    {
        Customer _customer;
        public CusNameDecorator(CustomerDecorator customerD, string userName, Customer customer) : base(customerD)
        {
            this._customer = customer;
            CusName = userName;
        }
        public override Customer MakeCustomer()
        {
            base.MakeCustomer();
            Customer customerD = _customer;
            customerD.CustomerName = CusName;
            return customerD;
        }
    }
}