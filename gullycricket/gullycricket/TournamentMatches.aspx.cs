using gullycricket.ModalClasses;
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
    public partial class TournamentMatches : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int tournamentId = 0;
            int.TryParse(Request.QueryString["tId"], out tournamentId);
            if (tournamentId == 0)
            {
                Response.Redirect("pages-error-404.html");
            }
            MessageBox.ClearMessage();
            if (!IsPostBack)
            {
                var oUser = SessionService.GetCurrentUser().oUser;
                if (oUser == null)
                {
                    Response.Redirect("pages-error-404.html");
                }
                try
                {
                    new TeamManagement().BindTeamsByTournamentId(TeamList, tournamentId);
                    new TeamManagement().BindTeamsByTournamentId(TeamList2, tournamentId);
                }
                catch (Exception ex)
                {

                    MessageBox.ErrorMessage(ex.Message);
                    return;
                }
                BindData();
            }
        }
        private void BindData()
        {
            try
            {
                int tournamentId = 0;
                int.TryParse(Request.QueryString["tId"], out tournamentId);
                if (tournamentId == 0)
                {
                    Response.Redirect("pages-error-404.html");
                }
                MatchRepeater.DataSource = new MatchManagement().GetMatchesByTournamentId(tournamentId);
                MatchRepeater.DataBind();
            }
            catch (Exception ex)
            {

                MessageBox.ErrorMessage(ex.Message);
            }
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

                int team1Id = 0;
                int.TryParse(TeamList.SelectedValue, out team1Id);
                if(team1Id == 0)
                {
                    MessageBox.ErrorMessage("Kindly select team 1");
                    return;
                }

                int team2Id = 0;
                int.TryParse(TeamList2.SelectedValue, out team2Id);
                if (team2Id == 0)
                {
                    MessageBox.ErrorMessage("Kindly select team 2");
                    return;
                }

                if(team1Id == team2Id)
                {
                    MessageBox.ErrorMessage("Kindly select different opponents");
                    return;
                }

                string startingDateValue = startDate.Value.Trim();
                if(startingDateValue == "")
                {
                    MessageBox.ErrorMessage("Kindly select starting date");
                    return;
                }
                MatchInfo oMatch = new MatchInfo();
                oMatch.Team1Id = team1Id;
                oMatch.Team2Id = team2Id;
                oMatch.StartingDate = Convert.ToDateTime(startingDateValue);
                oMatch.TournamentId = tournamentId;
                new MatchManagement().AddMatch(oMatch);
                TeamList.SelectedValue = "0";
                TeamList2.SelectedValue = "0";
                startDate.Value = "";
                MessageBox.SuccessMessage("New Match added");
                BindData();

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
                int matchId = 0;
                int.TryParse(((LinkButton)sender).CommandArgument, out matchId);
                if(matchId == 0)
                {
                    throw new Exception("Invalid or no ID found");
                }
                new MatchManagement().DeleteTournamentMatch(matchId);
                MessageBox.SuccessMessage("Match deleted");
                BindData();
            }
            catch (Exception ex)
            {

                MessageBox.ErrorMessage(ex.Message);
            }
        }
    }
}