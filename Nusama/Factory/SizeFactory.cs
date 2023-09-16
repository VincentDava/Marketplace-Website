using Nusama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nusama.Factory
{
    public class SizeFactory
    {
        public static SizeOption CreateColor(int productid, string name, int id)
        {
            return new SizeOption
            {
                productId = productid,
                productSize = name,
                optionId = id
            };
        }
    }
}