using gullycricket.Model_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gullycricket.UserControl
{
    public partial class Header : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                var oUser = SessionService.GetCurrentUser().oUser;
                if(oUser != null)
                {
                    userName.InnerText = oUser.Name != null && oUser.Name != "" ? oUser.Name : "User Name";
                    profileImage.Src = oUser.ImageURL != null && oUser.ImageURL != "" ? oUser.ImageURL : "../assets/assets/img/profile-img.jpg";
                }
                else
                {
                    userName.InnerText = "User Name";
                    profileImage.Src = "../assets/assets/img/profile-img.jpg";
                }
                
            }
            catch (Exception ex)
            {

               
            }
        }
    }
}