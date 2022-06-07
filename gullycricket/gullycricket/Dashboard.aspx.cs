using gullycricket.Model_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace gullycricket
{
    public partial class Dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var oUser = SessionService.GetCurrentUser().oUser;
                if(oUser == null)
                {
                    Response.Redirect("pages-error-404.html");
                }
            }
            
        }
    }
}