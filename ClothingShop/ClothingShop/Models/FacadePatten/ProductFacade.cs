using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingShop.Models.FacadePatten
{
    public class ProductFacade
    {
        ImageProduct imageProduct;
        InfoProduct infoProduct;
        public ProductFacade(string fileImage, int productID, string productName, string decriptionPro, decimal? pricePro, int? categoryID, string imgPro)
        {
            imageProduct = new ImageProduct(fileImage);
            infoProduct = new InfoProduct(productID, productName, decriptionPro, pricePro, categoryID, imgPro);
        }
        public void ConstructProduct(Product product)
        {
            imageProduct.SetImage(product);
            infoProduct.SetInfo(product);
        }
        
    }
}