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
    public partial class ViewTrialBalance : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageBox.ClearMessage();
            if (!IsPostBack)
            {

                var oUser = SessionService.GetCurrentUser().oUser;
                if (oUser == null)
                {
                    Response.Redirect("pages-error-404.html");
                }
                BindData();
            }
            
        }

        private void BindData()
        {
            try
            {
                int userId = SessionService.GetCurrentUser().oUser.Id;
                TrialBalanceRepeater.DataSource = new SheetsManagement().GetTrialBalanceByUserId(userId);
                TrialBalanceRepeater.DataBind();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}