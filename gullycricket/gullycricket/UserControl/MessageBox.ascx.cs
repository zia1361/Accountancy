using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gullycricket.UserControl
{
    public partial class MessageBox : System.Web.UI.UserControl
    {
        string iconTemplate = "<icon class='[:IconClass]'></icon>";
        string successMessage = "alert alert-success alert-dismissible fade show";
        string errorMessage = "alert alert-danger alert-dismissible fade show";
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void ClearMessage()
        {
            messageIcon.InnerHtml = "";
            messageText.Text = "";
            messageContainer.Attributes["class"] = "";
            messageContainer.Visible = false;
        }
        public void SuccessMessage(string message)
        {
            try
            {
                messageContainer.Visible = true;
                messageIcon.InnerHtml = iconTemplate.Replace("[:IconClass]", "icon-check");
                messageText.Text = message;
                messageContainer.Attributes["class"] = successMessage;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void ErrorMessage(string message)
        {
            try
            {
                messageContainer.Visible = true;
                messageIcon.InnerHtml = iconTemplate.Replace("[:IconClass]", "icon-ban");
                messageText.Text = message;
                messageContainer.Attributes["class"] = errorMessage;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}