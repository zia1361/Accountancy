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
    public partial class ViewAllTournaments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var oUser = SessionService.GetCurrentUser().oUser;
                if (oUser == null)
                {
                    Response.Redirect("pages-error-404.html");
                }
            }
            MessageBox.ClearMessage();
            BindData();
        }
        
        private void BindData()
        {
            try
            {
                TournamentRepeater.DataSource = new TournamentManagement().GetTournamentListByUserId(SessionService.GetCurrentUser().oUser.Id);
                TournamentRepeater.DataBind();
            }
            catch (Exception ex)
            {

                MessageBox.ErrorMessage(ex.Message);
            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int tournamentId = 0;
                int.TryParse(((LinkButton)sender).CommandArgument, out tournamentId);
                if(tournamentId == 0)
                {
                    throw new Exception("Invalid or no ID found");
                }
                new TournamentManagement().DeleteTournament(tournamentId);
                MessageBox.SuccessMessage("Tournament deleted successfully");
                BindData();
            }
            catch (Exception ex)
            {

                MessageBox.ErrorMessage(ex.Message);
            }
        }
    }
}