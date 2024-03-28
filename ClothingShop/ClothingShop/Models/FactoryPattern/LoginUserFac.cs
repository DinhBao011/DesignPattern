using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingShop.Models.FactoryPattern
{
    internal class LoginUserFac : LoginFactory<Customer>
    {
        public override ILogin<Customer> CreateLogin()
        {
            return new UserFactory();
        }
    }
}