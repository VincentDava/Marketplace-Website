using Nusama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nusama.Factory
{
    public class ProductFactory
    {
        public static Product CreateProduct(int id, int productid, string name, int price, string desc, string category, string path)
        {
            return new Product
            {
                customerId = id,
                productId = productid,
                productName = name,
                productPrice = price,
                productDesc = desc,
                productCategory = category,
                productImage = path,
                productRating = 0
            };
        }
    }
}