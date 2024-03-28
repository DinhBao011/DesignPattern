using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingShop.Models.FacadePattern
{
    public class InfoProduct
    {
        int ProductID { get; set; }
        string ProductName { get; set; }
        decimal? price { get; set; }
        int? CategoryID { get; set; }
        string DecriptionPro { get; set; }
        string ImagePro { get; set; }

        public InfoProduct(int productId, string productName, decimal? pricePro, int? categoryId, string desProduct, string imagePro) 
        {
            ProductID = productId;
            ProductName = productName;
            price = pricePro;
            CategoryID = categoryId;
            DecriptionPro = desProduct;
            ImagePro = imagePro;
        }
        public void SetInfoProduct(Product product)
        {
            product.ProductID = ProductID;
            product.ProductName = ProductName;
            product.price = price;
            product.CategoryID = CategoryID;
            product.DecriptionPro = DecriptionPro;
            product.ImagePro = ImagePro;
        }
    }
}