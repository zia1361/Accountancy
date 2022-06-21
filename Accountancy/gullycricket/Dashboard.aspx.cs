using gullycricket.Backbone;
using gullycricket.Model_Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Accountancy
{
    public partial class Dashboard : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                Response.Redirect("GeneralJournal.aspx");

            }
            
        }
    }
}