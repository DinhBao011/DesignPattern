using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingShop.Models.BuilderPattern
{
    public class ProductBuilder : IProductBuilder
    {
        private Product _product = new Product();

        public void SetCategory(int categoryId)
        {
            _product.CategoryID = categoryId;
        }

        public void SetProductName(string productName)
        {
            _product.ProductName = productName;
        }

        public void SetDescription(string description)
        {
            _product.DecriptionPro = description;
        }

        public void SetPrice(decimal price)
        {
            _product.price = price;
        }

        public void SetImage(string imageUrl)
        {
            _product.ImagePro = imageUrl;
        }

        public Product GetProduct()
        {
            return _product;
        }
    }
}