using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingShop.Models.DecoratorPattern
{
    public abstract class CustomerDecorator
    {
        public int AccID { get; set; }
        public string CusName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public abstract Customer MakeCustomer();
    }
}