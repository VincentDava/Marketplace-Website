using Nusama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nusama.Factory
{
    public class CartFactory
    {
        public static Cart CreateCart(int id, int product_id, int qty, string color, string size, int cartId)
        {
            return new Cart
            {
                customerId = id,
                productId = product_id,
                quantity = qty,
                productColor = color,
                productSize = size,
                cartId = cartId
            };
        }
    }
}