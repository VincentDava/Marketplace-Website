using Nusama.Controller;
using Nusama.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nusama.View
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["UserInfo"] != null)
            {
                Response.Redirect("~/View/Homepage.aspx");
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            string email = emailBox.Text;
            string pass = passBox.Value;

            HttpCookie cookie = CustomerValidation.validateLogin(email, pass);

            if(cookie != null)
            {
                Response.Cookies.Add(cookie);
                Response.Redirect("~/View/Homepage.aspx");
            }
            else
            {
                statusLabel.Text = "Login Failed!";
            }
        }

        protected void guestBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Homepage.aspx");
        }
    }
}