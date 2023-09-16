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
    public partial class ProductPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int customerID = Convert.ToInt32(Request.Cookies["UserInfo"].Value);

                List<Product> productList = ProductRepository.getAllProductByCustomerID(customerID);
                productRepeater.DataSource = productList;
                productRepeater.DataBind();
            }
        }

        protected void removeBtn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string productId = button.CommandArgument;
            Response.Redirect("~/View/EditProduct.aspx?productId=" + productId + "&action=delete");
        }

        protected void editBtn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string productId = button.CommandArgument;
            Response.Redirect("~/View/EditProduct.aspx?productId=" + productId);
        }

        protected void addColorSize_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string productId = button.CommandArgument;
            Response.Redirect("~/View/AddSizeColor.aspx?productId=" + productId);
        }

        protected void parentRepeater_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Repeater ColorRepeater = (Repeater)e.Item.FindControl("ColorRepeater");
                Repeater SizeRepeater = (Repeater)e.Item.FindControl("SizeRepeater");

                Product product = e.Item.DataItem as Product;

                List<string> colorData = ProductRepository.GetColorOptionsForProduct(product.productId);
                ColorRepeater.DataSource = colorData;
                ColorRepeater.DataBind();

                List<string> sizeData = ProductRepository.GetSizeOptionsForProduct(product.productId);
                SizeRepeater.DataSource = sizeData;
                SizeRepeater.DataBind();
            }
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

            if (customerRole == 2)
            {
                this.MasterPageFile = "~/View/MasterPage-Seller.Master";
            }
            else
            {
                Response.Redirect("~/View/Homepage.aspx");
            }
        }
    }
}