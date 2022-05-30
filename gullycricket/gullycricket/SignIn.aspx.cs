using gullycricket.Model_Classes;
using gullycricket.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gullycricket
{
    public partial class SignIn : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageBox.ClearMessage();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string userLoginId = loginId.Value.Trim();
                string userPassword = password.Value.Trim();
                if (string.IsNullOrEmpty(userLoginId))
                {
                    MessageBox.ErrorMessage("Kindly provide login ID");
                    return;
                }
                if (string.IsNullOrEmpty(userPassword))
                {
                    MessageBox.ErrorMessage("Kindly provide password");
                    return;
                }

                UserInfo oInfo = new UserInfo();
                oInfo.LoginId = userLoginId;
                oInfo.Password = userPassword;
                new UserManagment().SignInUser(oInfo);
                MessageBox.SuccessMessage("Successfully LoggedIn");
            }
            catch (Exception ex)
            {

                MessageBox.ErrorMessage(ex.Message);
            }
        }
    }
}