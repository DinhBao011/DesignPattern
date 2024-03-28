using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingShop.Models.FacadePatten
{
    public class ImageProduct
    {
        string FileImage;
        public ImageProduct(string fileImage)
        {
            this.FileImage = fileImage;
        }
        public void SetImage(Product product)
        {
            product.ImagePro = FileImage;
        }
    }
}