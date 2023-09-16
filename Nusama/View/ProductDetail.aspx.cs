using Nusama.Controller;
using Nusama.Factory;
using Nusama.Model;
using Nusama.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Nusama.View
{
    public partial class ProductDetail : System.Web.UI.Page
    {
        public int customerRole;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int productId = Convert.ToInt32(Request.QueryString["productId"]);

                Product currentProduct = ProductRepository.findProductByID(productId);

                if (currentProduct == null)
                {
                    Response.Redirect("~/View/Homepage.aspx");
                }

                productImage.ImageUrl = currentProduct.productImage;
                nameLabel.Text = currentProduct.productName;
                ratingLabel.Text = currentProduct.productRating.ToString();
                priceLabel.Text = currentProduct.productPrice.ToString();

                List<string> colorList = ProductRepository.GetColorOptionsForProduct(productId);

                ColorChoice.DataSource = colorList;
                ColorChoice.DataBind();

                List<string> sizeList = ProductRepository.GetSizeOptionsForProduct(productId);

                SizeChoice.DataSource = sizeList;
                SizeChoice.DataBind();


                List<CommentContent> comments = ProductRepository.GetCommentsOfProduct(productId);
                commentsRepeater.DataSource = comments;
                commentsRepeater.DataBind();
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

        protected void addToCartBtn_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(Request.Cookies["UserInfo"].Value);
            int productId = Convert.ToInt32(Request.QueryString["productId"]);
            string color = ColorChoice.SelectedValue;
            string size = SizeChoice.SelectedValue;
            int qty = Convert.ToInt32(qtyBox.Text);

            ProductRepository.addNewCart(customerID, productId, qty, color, size);
        }

        public int pullCustomerRole()
        {
            return customerRole;
        }

        protected void addCommentBtn_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(Request.Cookies["UserInfo"].Value);
            int productId = Convert.ToInt32(Request.QueryString["productId"]);
            string title = titleBox.Text;
            string content = commentBox.Text;
            string ratingString = ratingBox.Text;
            float rating = float.Parse(ratingString);

            if (rating > 0 && rating <= 5 && title.Length > 5 && content.Length > 5)
            {
                ProductRepository.addNewComment(customerID, productId, title, content, rating);
                Response.Redirect(Request.Url.PathAndQuery);
            }

        }
    }
}