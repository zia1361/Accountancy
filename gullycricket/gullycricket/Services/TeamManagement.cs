using gullycricket.DB;
using gullycricket.ModalClasses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace gullycricket.Services
{
    public class TeamManagement
    {
        public void CreateTeam(TeamInfo oTeam)
        {
            try
            {
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    Team eTeam = new Team();
                    eTeam = eDataBase.Teams.Where(eTData => eTData.TeamName == oTeam.TeamName).FirstOrDefault();
                    if (eTeam != null)
                    {
                        throw new Exception("Team with the same name already exisits");
                    }
                    eTeam = new Team();
                    eTeam.UserId = oTeam.UserId;
                    eTeam.TeamName = oTeam.TeamName;
                    eTeam.RegisteredOn = DateTime.Now;
                    eDataBase.Teams.InsertOnSubmit(eTeam);
                    eDataBase.SubmitChanges();
                    oTeam.Id = eTeam.Id;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public List<TeamInfo> GetTeamListByUserId(int userId)
        {
            try
            {
                List<TeamInfo> oTeams = new List<TeamInfo>();
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    var eTeams = eDataBase.Teams.Where(eTData => eTData.UserId == userId).ToList();
                    foreach (var eTeam in eTeams)
                    {
                        TeamInfo oTeam = new TeamInfo();
                        oTeam.Id = eTeam.Id;
                        oTeam.TeamName = eTeam.TeamName;
                        oTeam.RegisteredOn = eTeam.RegisteredOn;
                        oTeam.RegisteredOnString = oTeam.RegisteredOn.ToString(ConfigurationManager.AppSettings["DateFormat"]);
                        oTeam.UserId = eTeam.UserId;
                        oTeam.NumberOfPlayers = eTeam.TeamPlayers.Count;
                        var eMatches = eDataBase.TournamentMatches.Where(eMData => eMData.Team1Id == eTeam.Id || eMData.Team2Id == eTeam.Id).ToList();
                        oTeam.NumberOfMatchesPlayed = eMatches.Count;
                        oTeam.NumberOfMatchesWon = eMatches.Where(eMData => eMData.WinnerTeamId == eTeam.Id).Count();
                        oTeam.NumberOfMatchesLost = oTeam.NumberOfMatchesPlayed - oTeam.NumberOfMatchesWon;
                        oTeam.NumberOfTournaments = eTeam.Tournaments.Count;
                        oTeams.Add(oTeam);
                    }
                }
                return oTeams;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void DeleteTeam(int teamId)
        {
            try
            {
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    var eTeam = eDataBase.Teams.Where(eTData => eTData.Id == teamId).FirstOrDefault();
                    if (eTeam == null)
                    {
                        throw new Exception("No record found");
                    }
                    eDataBase.Teams.DeleteOnSubmit(eTeam);
                    eDataBase.SubmitChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void BindTeams(DropDownList gList)
        {
            try
            {
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    var eTeams = eDataBase.Teams.ToList();
                    gList.DataSource = eTeams;
                    gList.DataTextField = "TeamName";
                    gList.DataValueField = "Id";
                    gList.DataBind();
                    gList.Items.Insert(0, new ListItem("Select Team", "0"));
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}