using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingShop.Models.BuilderPattern
{
    public class ProductViewModel
    {
        public int CategoryID { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }
    }
}