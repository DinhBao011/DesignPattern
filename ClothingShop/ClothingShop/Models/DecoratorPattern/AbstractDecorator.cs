using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingShop.Models.DecoratorPattern
{
    public class AbstractDecorator : CustomerDecorator
    {
        private CustomerDecorator _customer;
        public AbstractDecorator(CustomerDecorator customer)
        {
            this._customer = customer;
        }
        public override Customer MakeCustomer()
        {
            return _customer.MakeCustomer();
        }
    }
}