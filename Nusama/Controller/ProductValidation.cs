using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nusama.Controller
{
    public class ProductValidation
    {
        public static bool validateAddNewItem(string name, string desc, string category, int price)
        {
            if(name.Length < 5 || desc.Length < 5 || category == null || price <= 0)
            {
                return false;
            }
            return true;
        }

        public static bool validateUpdateItem(string name, string desc, int price)
        {
            if (name.Length < 5 || desc.Length < 5 || price <= 0)
            {
                return false;
            }
            return true;
        }

        public static bool validateCart(int qty, string color, string size)
        {
            if (qty <= 0 || color.Length == 0 || size.Length == 0)
            {
                return false;
            }
            return true;
        }
    }
}