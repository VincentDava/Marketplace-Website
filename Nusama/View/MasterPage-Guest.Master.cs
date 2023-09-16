using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nusama.View
{
    public partial class MasterPage_Guest : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LogoImage.ImageUrl = "~/Image/NusamaLogo.png";
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/LoginPage.aspx");
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/RegisterPage.aspx");
        }

        protected void searchButton_Click(object sender, EventArgs e)
        {
            string keyword = searchBar.Text;
            Response.Redirect("~/View/SearchPage.aspx?keyword=" + keyword);
        }
    }
}