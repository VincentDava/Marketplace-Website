using Nusama.Model;
using Nusama.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Nusama.Controller
{
    public class CustomerValidation
    {
        //DatabaseEntities db = SingletonDatabase.GetInstance();
        public static bool validateRegister(string name, string email, string pass, string cpass)
        {
            string correctEmail = email.Trim();

            if (name.Length < 5 || !IsValidEmail(correctEmail) || string.Equals(pass, cpass, StringComparison.Ordinal) || pass.Length < 5)
            {
                return false;
            }

            Customer sameEmail = CustomerRepository.findCustomerByEmail(email);
            if(sameEmail == null)
            {
                return true;
            }
            return false;

        }

        private static bool IsValidEmail(string email)
        {
            string pattern = @"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$";
            return Regex.IsMatch(email, pattern);
        }

        public static HttpCookie validateLogin(string email, string pass)
        {
            Customer customerFound = CustomerRepository.findCustomerByLogin(email, pass);

            if (customerFound != null)
            {
                HttpCookie cookie = new HttpCookie("UserInfo");
                cookie.Value = customerFound.customerId.ToString();
                cookie.Expires = DateTime.Now.AddDays(7);
                
                return cookie;
            }
            else
            {
                return null;
            }

        }
    }
}