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
    public partial class SignUp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
             new UserManagment().BindUserType(UserTypeList);
            MessageBox.ClearMessage();
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            try
            {
                if (UserTypeList.SelectedIndex == 0)
                {
                    MessageBox.ErrorMessage("Kindly select user type");
                    return;
                }
                string userName = username.Value.Trim();
                if (string.IsNullOrEmpty(userName))
                {
                    MessageBox.ErrorMessage("Kindly provide user name");
                    return;
                }
                string userEmail_ = userEmail.Value.Trim();
                if (string.IsNullOrEmpty(userEmail_))
                {
                    MessageBox.ErrorMessage("Kindly provide user email");
                    return;
                }
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
                oInfo.Name = userName;
                oInfo.Email = userEmail_;
                oInfo.LoginId = userLoginId;
                oInfo.Password = userPassword;
                oInfo.UserTypeId = Convert.ToInt32(UserTypeList.SelectedValue);
                new UserManagment().SignUpUser(oInfo);
                MessageBox.SuccessMessage("User successfully registered but you are in a pending state");
                UserTypeList.SelectedValue = "0";
                username.Value = "";
                userEmail.Value = "";
                loginId.Value = "";
                password.Value = "";


            }
            catch (Exception ex)
            {

                MessageBox.ErrorMessage(ex.Message);
            }
        }
    }
}