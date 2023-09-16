using Nusama.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nusama.View
{
    public partial class MasterPage_Customer : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LogoImage.ImageUrl = "~/Image/NusamaLogo.png";
        }

        protected void logOutBtn_Click(object sender, EventArgs e)
        {
            HttpCookie deleteCookie = CustomerRepository.logout();
            Response.Cookies.Add(deleteCookie);
            Response.Redirect("~/View/LoginPage.aspx");
        }
        protected void tranListBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/TransactionList.aspx");
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string keyword = searchBar.Text;
            Response.Redirect("~/View/SearchPage.aspx?keyword=" + keyword);
        }

        protected void cartBtn_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("~/View/CartPage.aspx");
        }
    }
}