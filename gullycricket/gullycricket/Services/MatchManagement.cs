using gullycricket.DB;
using gullycricket.ModalClasses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace gullycricket.Services
{
    public class MatchManagement
    {
        public void AddMatch(MatchInfo oMatch)
        {
            try
            {
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    TournamentMatch eMatch = new TournamentMatch();
                    eMatch.TournamentId = oMatch.TournamentId;
                    eMatch.Team1Id = oMatch.Team1Id;
                    eMatch.Team2Id = oMatch.Team2Id;
                    eMatch.StartingDate = oMatch.StartingDate;
                    eMatch.MatchStatusId = 1;
                    eDataBase.TournamentMatches.InsertOnSubmit(eMatch);
                    eDataBase.SubmitChanges();
                    oMatch.Id = eMatch.Id;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public List<MatchInfo> GetMatchesByTournamentId(int tournamentId)
        {
            try
            {
                List<MatchInfo> oMatches = new List<MatchInfo>();
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    var eMatches = eDataBase.TournamentMatches.Where(eMData => eMData.TournamentId == tournamentId).ToList();
                    foreach (var eMatch in eMatches)
                    {
                        MatchInfo oMatch = new MatchInfo();
                        oMatch.Id = eMatch.Id;
                        oMatch.TournamentId = eMatch.TournamentId;
                        oMatch.TournamentName = eMatch.Tournament.TournamentName;
                        oMatch.Team1Id = eMatch.Team1Id;
                        oMatch.Team1Name = eMatch.Team.TeamName;
                        oMatch.Team2Id = eMatch.Team2Id;
                        oMatch.Team2Name = eMatch.Team1.TeamName;
                        oMatch.StartingDate = eMatch.StartingDate;
                        oMatch.StartingDateString = eMatch.StartingDate.ToString(ConfigurationManager.AppSettings["DateFormat"]);
                        oMatch.MatchStatusId = eMatch.MatchStatusId;
                        oMatch.MatchStatusName = eMatch.MatchStatus.MatchStatusName;
                        if (eMatch.WinnerTeamId.HasValue)
                        {
                            oMatch.WinnerTeamId = eMatch.WinnerTeamId.Value;
                            oMatch.WinnerTeamName = eMatch.Team4.TeamName;
                        }
                        else
                        {
                            oMatch.WinnerTeamName = "N/A";
                        }
                        if (eMatch.TossWinningTeamId.HasValue)
                        {
                            oMatch.TossWinningTeamId = eMatch.TossWinningTeamId.Value;
                            oMatch.TossWinningTeamName = eMatch.Team2.TeamName;
                        }
                        else
                        {
                            oMatch.TossWinningTeamName = "N/A";
                        }
                        if (eMatch.CurrentInningTeamId.HasValue)
                        {
                            oMatch.CurrentInningTeamId = eMatch.CurrentInningTeamId.Value;
                            oMatch.CurrentInningTeamName = eMatch.Team3.TeamName;
                        }
                        else
                        {
                            oMatch.CurrentInningTeamName = "N/A";
                        }
                        oMatch.TargetScore = eMatch.TargetScore.HasValue ? eMatch.TargetScore.Value : 0;
                        oMatches.Add(oMatch);

                    }
                }
                return oMatches;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void DeleteTournamentMatch(int matchId)
        {
            try
            {
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    var eMatch = eDataBase.TournamentMatches.Where(eMData => eMData.Id == matchId).FirstOrDefault();
                    if(eMatch == null)
                    {
                        throw new Exception("No Record found");
                    }
                    eDataBase.TournamentMatches.DeleteOnSubmit(eMatch);
                    eDataBase.SubmitChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}