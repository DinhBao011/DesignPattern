using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingShop.Models.FacadePatten
{
    public class InfoProduct
    {
        public InfoProduct(int productID, string productName, string descriptionPro, decimal? pricePro, int? categoryID, string imgPro)
        {
            ProductID = productID;
            CategoryID = categoryID;
            ProductName = productName;
            DescriptionPro = descriptionPro;
            price = pricePro;
            ImagePro = imgPro;
        }
        int ProductID { get; set; }
        string ProductName { get; set; }
        string DescriptionPro { get; set; }
        decimal? price { get; set; }
        int? CategoryID { get; set; }
        string ImagePro { get; set; }
        public void SetInfo(Product product)
        {
            product.ProductID = ProductID;
            product.CategoryID = CategoryID;
            product.ProductName = ProductName;
            product.DecriptionPro = DescriptionPro;
            product.price = price;
            product.ImagePro = ImagePro;
        }
    }
}