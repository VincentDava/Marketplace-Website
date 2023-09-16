using Nusama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nusama.Repository
{
    public class CustomerRepository
    {
        public static DatabaseEntities db = SingletonDatabase.GetInstance();
        public static Customer findCustomerByEmail(string email)
        {
            Customer customerFound = (from x in db.Customers where x.customerEmail == email select x).FirstOrDefault();
            return customerFound;
        }

        public static Customer findCustomerByLogin(string email, string pass)
        {
            Customer customerFound = (from x in db.Customers where x.customerEmail == email && x.customerPassword == pass select x).FirstOrDefault();
            if (customerFound == null)
            {
                return null;
            }
            return customerFound;
        }

        public static Customer findCustomerByID(int id)
        {
            Customer customerFound = (from x in db.Customers where x.customerId == id select x).FirstOrDefault();
            return customerFound;
        }

        public static HttpCookie logout()
        {
            HttpCookie myCookie = new HttpCookie("UserInfo");
            myCookie.Expires = DateTime.Now.AddDays(-100);
            return myCookie;
        }

        public static int getCustomerRole(Customer currentCustomer)
        {        
            if(currentCustomer == null)
            {
                return -1;
            }
            
            if(currentCustomer.customerRole == "seller")
            {
                return 2;
            }
            else if(currentCustomer.customerRole == "customer")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}