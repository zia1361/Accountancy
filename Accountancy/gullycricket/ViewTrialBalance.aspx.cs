using gullycricket.Backbone;
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
    public partial class ViewTrialBalance : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageBox.ClearMessage();
            if (!IsPostBack)
            {

                
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