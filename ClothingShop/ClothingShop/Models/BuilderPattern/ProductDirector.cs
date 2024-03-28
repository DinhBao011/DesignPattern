using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingShop.Models.BuilderPattern
{
    public class ProductDirector
    {
        private readonly IProductBuilder _builder;

        public ProductDirector(IProductBuilder builder)
        {
            _builder = builder;
        }

        public Product Construct(int categoryId, string productName, string description, decimal price, string imageUrl)
        {
            _builder.SetCategory(categoryId);
            _builder.SetProductName(productName);
            _builder.SetDescription(description);
            _builder.SetPrice(price);
            _builder.SetImage(imageUrl);
            return _builder.GetProduct();
        }
    }
}