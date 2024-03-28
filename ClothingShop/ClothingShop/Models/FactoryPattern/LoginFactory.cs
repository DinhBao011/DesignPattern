using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;


namespace ClothingShop.Models.FactoryPattern
{
    internal abstract class LoginFactory<T>
    {
        public abstract ILogin<T> CreateLogin();
    }

}