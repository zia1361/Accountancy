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
    public partial class AddTournamentTeam : System.Web.UI.Page
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
                new TeamManagement().BindTeams(TeamList);
            }
            int tournamentId = 0;
            int.TryParse(Request.QueryString["tId"], out tournamentId);
            if(tournamentId == 0)
            {
                Response.Redirect("pages-error-404.html");
            }
            MessageBox.ClearMessage();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int tournamentId = 0;
                int.TryParse(Request.QueryString["tId"], out tournamentId);
                if (tournamentId == 0)
                {
                    Response.Redirect("pages-error-404.html");
                }

                int teamId = 0;
                int.TryParse(TeamList.SelectedValue, out teamId);
                if (teamId == 0)
                {
                    MessageBox.ErrorMessage("Kindly select team");
                    return;
                }

                new TournamentManagement().AddTournamentTeam(tournamentId, teamId);
                MessageBox.SuccessMessage("Team registered for this tournament");
            }
            catch (Exception ex)
            {

                MessageBox.ErrorMessage(ex.Message);
            }
        }
    }
}