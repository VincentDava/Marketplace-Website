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
    public partial class AddSizeColor : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int productId = Convert.ToInt32(Request.QueryString["productId"]);
            string targetColor = Request.QueryString["colorName"];

            if(targetColor != null && Request.QueryString["action"] == "delete")
            {
                //ProductRepository.deleteColorOption(productId, targetColor);
                //Response.Redirect("~/View/AddSizeColor.aspx?productId=" + productId);
            }

            Product currentProduct = ProductRepository.findProductByID(productId);

            productIdLabel.Text = currentProduct.productName;

            List<ColorOption> colorData = ProductRepository.GetColorOption(productId);
            ColorRepeater.DataSource = colorData;
            ColorRepeater.DataBind();

            List<SizeOption> sizeData = ProductRepository.GetSizeOption(productId);
            SizeRepeater.DataSource = sizeData;
            SizeRepeater.DataBind();
        }

        protected void addColorBtn_Click(object sender, EventArgs e)
        {
            string color = colorBox.Text;
            int productId = Convert.ToInt32(Request.QueryString["productId"]);
            ProductRepository.addColorOption(productId, color);
            colorStatus.Text = "Success";
            Response.Redirect(Request.Url.PathAndQuery);
        }

        protected void addSizeBtn_Click(object sender, EventArgs e)
        {
            string size = sizeBox.Text;
            int productId = Convert.ToInt32(Request.QueryString["productId"]);
            ProductRepository.addSizeOption(productId, size);
            sizeStatus.Text = "Success";
            Response.Redirect(Request.Url.PathAndQuery);
        }

        protected void deleteColorBtn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string colorName = button.CommandArgument;
            int productId = Convert.ToInt32(Request.QueryString["productId"]);
            ProductRepository.deleteColorOption(productId, colorName);

            Response.Redirect(Request.Url.PathAndQuery);
        }

        protected void deleteSizeBtn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string sizeName = button.CommandArgument;
            int productId = Convert.ToInt32(Request.QueryString["productId"]);
            ProductRepository.deleteSizeOption(productId, sizeName);

            Response.Redirect(Request.Url.PathAndQuery);
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