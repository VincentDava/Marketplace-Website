using Nusama.Handler;
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
    public partial class CheckoutPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int customerID = Convert.ToInt32(Request.Cookies["UserInfo"].Value);

                List<CartContent> cart = ProductRepository.GetCartProduct(customerID);
                cartRepeater.DataSource = cart;
                cartRepeater.DataBind();

                int? totalPrice = cart.Sum(product => product.productPrice);
                subtotalLabel.Text = totalPrice.ToString();

                totalLabel.Text = (totalPrice + 35000).ToString();
            }
        }

        protected void confirmBtn_Click(object sender, EventArgs e)
        {
            string address = addressBox.Text;
            int customerID = Convert.ToInt32(Request.Cookies["UserInfo"].Value);
            string method = PaymentMethod.SelectedValue;
            if (address.Length > 0 && method.Length > 0)
            {
                List<CartContent> cart = ProductRepository.GetCartProduct(customerID);
                int nextId = IdGenerator.GenerateTransactionID();
                DateTime now = DateTime.Now;

                TransactionRepository.CreateNewTransaction(nextId, now, customerID, method, address);

                Response.Redirect("~/View/TransactionList.aspx");
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