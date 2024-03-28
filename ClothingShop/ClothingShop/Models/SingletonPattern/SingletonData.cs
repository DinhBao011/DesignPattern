using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClothingShop.Models.SingletenPattern
{
    public class SingletonData
    {
        private static ClothingStoreEntities instance;

        private SingletonData() { }

        public static ClothingStoreEntities Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new ClothingStoreEntities();
                }
                return instance;
            }
        }

    }
}