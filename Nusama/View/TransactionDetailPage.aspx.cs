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
    public partial class TransactionDetailPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int customerID = Convert.ToInt32(Request.Cookies["UserInfo"].Value);
                int transactionId = Convert.ToInt32(Request.QueryString["tranId"]);

                TransactionHeader th = TransactionRepository.GetTransactionHeader(transactionId);
                tranIdLabel.Text = th.transactionId.ToString();
                dateLabel.Text = th.transactionDate.ToString();
                addressLabel.Text = th.address;
                paymentLabel.Text = th.paymentMethod;

                List<TransactionItem> cart = TransactionRepository.GetAllTransactionItem(transactionId);
                tranRepeater.DataSource = cart;
                tranRepeater.DataBind();

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