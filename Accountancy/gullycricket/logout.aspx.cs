using gullycricket.Model_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Accountancy
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SessionService.Remove(SessionService.Keys.AuthenticationInfo);
            Response.Redirect("SignIn.aspx");
        }
    }
}