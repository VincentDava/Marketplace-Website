using Nusama.Controller;
using Nusama.Factory;
using Nusama.Handler;
using Nusama.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Nusama.View
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            string name = nameBox.Text;
            string email = emailBox.Text;
            string pass = passBox.Value;
            string cpass = cPassBox.Value;
            string address = addressBox.Text;

            bool validInput = CustomerValidation.validateRegister(name, email, pass, cpass);

            if (validInput)
            {
                int nextId = IdGenerator.GenerateCustomerID();
                Customer newCustomer = CustomerFactory.CreateCustomer(nextId, name, email, pass, address);
            }
        }
    }
}