using Nusama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nusama.Factory
{
    public class CustomerFactory
    {
        public static Customer CreateCustomer(int id, string name, string email, string pass, string address)
        {
            return new Customer
            {
                customerId = id,
                customerName = name,
                customerEmail = email,
                customerPassword = pass,
                customerAddress = address,
                customerRole = "cust"
            };
        }
    }
}