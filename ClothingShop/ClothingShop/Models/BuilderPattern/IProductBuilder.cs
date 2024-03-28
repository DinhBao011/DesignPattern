using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClothingShop.Models.BuilderPattern
{
    public interface IProductBuilder
    {
        void SetCategory(int categoryId);
        void SetProductName(string productName);
        void SetDescription(string description);
        void SetPrice(decimal price);
        void SetImage(string imageUrl);
        Product GetProduct();
    }
}
