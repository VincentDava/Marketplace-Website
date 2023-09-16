using Nusama.Model;
using Nusama.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nusama.View
{
    public partial class MasterPage_Seller : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LogoImage.ImageUrl = "~/Image/NusamaLogo.png";
            if (Request.Cookies["UserInfo"] != null)
            {
                int userInfo = Convert.ToInt32(Request.Cookies["UserInfo"].Value);
                Customer currentCustomer = CustomerRepository.findCustomerByID(userInfo);
                nameBox.Text = currentCustomer.customerName;
            }
            else
            {
                Response.Redirect("~/View/LoginPage.aspx");
            }

        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string keyword = searchBar.Text;
            Response.Redirect("~/View/SearchPage.aspx?keyword=" + keyword);
        }

        protected void logOutBtn_Click(object sender, EventArgs e)
        {
            HttpCookie deleteCookie = CustomerRepository.logout();
            Response.Cookies.Add(deleteCookie);
            Response.Redirect("~/View/LoginPage.aspx");
        }

        protected void addProductBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/InsertProduct.aspx");
        }

        protected void productListBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/ProductPage.aspx");
        }
    }
}