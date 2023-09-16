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
    public partial class CartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int customerID = Convert.ToInt32(Request.Cookies["UserInfo"].Value);

                List<CartContent> cart = ProductRepository.GetCartProduct(customerID);
                cartRepeater.DataSource = cart;
                cartRepeater.DataBind();
            }
        }

        protected void removeBtn_Click(object sender, EventArgs e)
        {
            Button removeBtn = (Button)sender;
            int cartId = Convert.ToInt32(removeBtn.CommandArgument);

            ProductRepository.deleteCart(cartId);

            Response.Redirect("~/View/CartPage.aspx");
        }

        protected void checkOut_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/CheckoutPage.aspx");
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            int customerRole;
            if (Request.Cookies["UserInfo"] != null)
            {
                int customerID = Convert.ToInt32(Request.Cookies["UserInfo"].Value);

                Customer findCustomer = CustomerRepository.findCustomerByID(customerID);

                customerRole = CustomerRepository.getCustomerRole(findCustomer);
            }
            else
            {
                customerRole = 0;
            }

            if (customerRole == 0)
            {
                Response.Redirect("~/View/Homepage.aspx");
            }
            else if (customerRole == 1)
            {
                this.MasterPageFile = "~/View/MasterPage-Customer.Master";
            }
            else
            {
                Response.Redirect("~/View/Homepage.aspx");
            }
        }
    }
}