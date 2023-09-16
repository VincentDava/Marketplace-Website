using Nusama.Controller;
using Nusama.Handler;
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
    public partial class InsertProduct : System.Web.UI.Page
    {
        public int customerRole;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void addBtn_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text;
            string desc = descBox.Text;
            int price = Convert.ToInt32(priceBox.Text);
            string category = categoryDropdown.SelectedValue;
            int customerID = Convert.ToInt32(Request.Cookies["UserInfo"].Value);

            if (imageUpload.HasFile && ProductValidation.validateAddNewItem(name, desc, category, price))
            {
                string fileName = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(imageUpload.FileName);
                string filePath = Server.MapPath("~/Image/Product/" + fileName);

                imageUpload.SaveAs(filePath);

                string imagePath = "/Image/Product/" + fileName;

                int nextId = IdGenerator.GenerateProductID();

                ProductRepository.registerNewProduct(customerID, nextId, name, price, desc, category, imagePath);

                Response.Redirect("~/View/Homepage.aspx");
            }
            else
            {
                errorLabel.Text = "Add Product Failed!";
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
    }
}