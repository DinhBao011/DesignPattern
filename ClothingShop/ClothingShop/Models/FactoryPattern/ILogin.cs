using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingShop.Models.FactoryPattern
{
    internal interface ILogin<T>
    {
        //GET
        bool Login(string account);

        //POST
        bool Login(T x, ref object account);
    }
}
