using Nusama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nusama.Factory
{
    public class ColorFactory
    {
        public static ColorOption CreateColor(int productid, string name, int id)
        {
            return new ColorOption
            {
                productId = productid,
                colorName = name,
                optionId = id
            };
        }
    }
}