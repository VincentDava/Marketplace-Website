using Nusama.Controller;
using Nusama.Model;
using Nusama.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nusama.View
{
    public partial class EditProduct : System.Web.UI.Page
    {
        public int customerRole;
        protected void Page_Load(object sender, EventArgs e)
        {
            int productId;

            if (Request.QueryString["action"] == "delete")
            {
                productId = Convert.ToInt32(Request.QueryString["productId"]);
                ProductRepository.deleteOldPicture(productId);
                ProductRepository.deleteProduct(productId);
                Response.Redirect("~/View/Homepage.aspx");
            }

            productId = Convert.ToInt32(Request.QueryString["productId"]);

            if (!IsPostBack)
            {
                Product currentProduct = ProductRepository.findProductByID(productId);
                nameBox.Text = currentProduct.productName;
                priceBox.Text = currentProduct.productPrice.ToString();
                descBox.Text = currentProduct.productDesc;
                currentImage.ImageUrl = currentProduct.productImage;
                currentImage.DataBind();
            }
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
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

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text;
            int price = Convert.ToInt32(priceBox.Text);
            string desc = descBox.Text;
            
            if (imageUpload.HasFile && ProductValidation.validateUpdateItem(name, desc, price))
            {
                int productId = Convert.ToInt32(Request.QueryString["productId"]);
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(imageUpload.FileName);
                string filePath = Server.MapPath("~/Image/Product/" + fileName);

                imageUpload.SaveAs(filePath);

                string imagePath = "/Image/Product/" + fileName;

                ProductRepository.deleteOldPicture(productId);

                ProductRepository.updateProduct(productId, name, price, desc, imagePath);

                Response.Redirect(Request.RawUrl);
            }
            else
            {
                errorLabel.Text = "Failed";
            }
        }
    }
}