using gullycricket.Backbone;
using gullycricket.Model_Classes;
using gullycricket.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Accountancy
{
    public partial class Profile : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    
                    BindData();
                }
            }
            catch (Exception ex)
            {

                
            }
            MessageBox.ClearMessage();
        }
        private void BindData()
        {
            try
            {
                var oUser = SessionService.GetCurrentUser().oUser;
                userImageView.Src = oUser.ImageURL;
                userNameView.InnerText = oUser.Name;
                userNameOverView.InnerText = oUser.Name;
                emailOverView.InnerText = oUser.Email != null & oUser.Email != "" ? oUser.Email : "N/A";
                loginIdOverview.InnerText = oUser.LoginId;
                registerationDateVoverview.InnerText = oUser.RegisteredOnDateString;
                profileImageUpload.Src = oUser.ImageURL;
                userNameControl.Value = oUser.Name;
                userEmailcontrol.Value = oUser.Email != null & oUser.Email != "" ? oUser.Email : "";
                loginIdControl.Value = oUser.LoginId;

            }
            catch (Exception ex)
            {
                MessageBox.ErrorMessage(ex.Message);
                
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = userNameControl.Value.Trim();
                if (string.IsNullOrEmpty(userName))
                {
                    MessageBox.ErrorMessage("Kindly provide user name");
                    return;
                }
                string userEmail_ = userEmailcontrol.Value.Trim();
                if (string.IsNullOrEmpty(userEmail_))
                {
                    MessageBox.ErrorMessage("Kindly provide user email");
                    return;
                }
                string userLoginId = loginIdControl.Value.Trim();
                
                if (string.IsNullOrEmpty(userLoginId))
                {
                    MessageBox.ErrorMessage("Kindly provide login ID");
                    return;
                }
                string fileName = "";
                UserInfo oInfo = new UserInfo();
                oInfo.Id = SessionService.GetCurrentUser().oUser.Id;
                if (profileImageControl.HasFile)
                {
                    fileName = oInfo.Id + "-" + profileImageControl.FileName;
                    var extention = new FileInfo(fileName).Extension;
                    if(!new List<string>() { ".png", ".jpg", ".jpeg" }.Contains(extention.ToLower()))
                    {
                        MessageBox.ErrorMessage("Only .png, jpg, jpeg files are allowed");
                        return;
                    }
                    profileImageControl.SaveAs(Server.MapPath("/PROFILEIMAGES/" + fileName));
                    oInfo.ImageURL = fileName;

                }
                
                oInfo.Name = userName;
                oInfo.Email = userEmail_;
                oInfo.LoginId = userLoginId;
                new UserManagment().UpdateUser(oInfo);
                MessageBox.SuccessMessage("Profile updated successfully");
                BindData();
            }
            catch (Exception ex)
            {

                MessageBox.ErrorMessage(ex.Message);
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            try
            {
                string currentPassword = currentPasswordControl.Text.Trim();
                if (string.IsNullOrEmpty(currentPassword))
                {
                    MessageBox.ErrorMessage("Kindly provide current password");
                    return;
                }
                var user = SessionService.GetCurrentUser().oUser;
                if((user.Password != currentPassword))
                {
                    MessageBox.ErrorMessage("Current password is invalid");
                    return;
                }
                string newPassword = newPasswordControl.Text.Trim();
                if (string.IsNullOrEmpty(newPassword))
                {
                    MessageBox.ErrorMessage("Kindly provide new password");
                    return;
                }
                if ((newPassword == currentPassword))
                {
                    MessageBox.ErrorMessage("Kindly try different password other than current one.");
                    return;
                }
                string rePassword = renewPasswordControl.Text.Trim();

                if (string.IsNullOrEmpty(rePassword))
                {
                    MessageBox.ErrorMessage("Kindly re-type new password");
                    return;
                }
                if(newPassword != rePassword)
                {
                    MessageBox.ErrorMessage("Password mis-matched");
                    return;
                }
                new UserManagment().UpdatePasswordByUserId(user.Id, newPassword);
                MessageBox.SuccessMessage("Password updated successfully");
                currentPasswordControl.Text = "";
                newPasswordControl.Text = "";
                renewPasswordControl.Text = "";

            }
            catch (Exception ex)
            {

                MessageBox.ErrorMessage(ex.Message);
            }
        }
    }
}