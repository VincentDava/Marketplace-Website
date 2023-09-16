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
    public partial class SearchPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string keyWord = Request.QueryString["keyword"];

            keyBox.Text = keyWord;

            List<Product> listProduct = ProductRepository.findProduct(keyWord);
            resultRepeater.DataSource = listProduct;
            resultRepeater.DataBind();
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
                this.MasterPageFile = "~/View/MasterPage-Guest.Master";
            }
            else if (customerRole == 1)
            {
                this.MasterPageFile = "~/View/MasterPage-Customer.Master";
            }
            else if (customerRole == 2)
            {
                this.MasterPageFile = "~/View/MasterPage-Seller.Master";
            }
            else
            {
                this.MasterPageFile = "~/View/MasterPage-Guest.Master";
            }
        }

        protected void moreDetailBtn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string productId = button.CommandArgument;
            Response.Redirect("~/View/ProductDetail.aspx?productId=" + productId);
        }
    }
}