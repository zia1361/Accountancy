using gullycricket.DB;
using gullycricket.ModalClasses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace gullycricket.Services
{
    public class TournamentManagement
    {
        public void CreateTournament(TournamentInfo oTournament)
        {
            try
            {
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    Tournament eTournament = new Tournament();
                    eTournament = eDataBase.Tournaments.Where(eTData => eTData.TournamentName == oTournament.TournamentName).FirstOrDefault();
                    if(eTournament != null)
                    {
                        throw new Exception("Tournament with the same name already exisits");
                    }
                    eTournament = new Tournament();
                    eTournament.UserId = oTournament.UserId;
                    eTournament.TournamentName = oTournament.TournamentName;
                    eTournament.RegisteredOn = DateTime.Now;
                    eDataBase.Tournaments.InsertOnSubmit(eTournament);
                    eDataBase.SubmitChanges();
                    oTournament.Id = eTournament.Id;
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public List<TournamentInfo> GetTournamentListByUserId(int userId)
        {
            try
            {
                List<TournamentInfo> oTournaments = new List<TournamentInfo>();
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    var eTournaments = eDataBase.Tournaments.Where(eTData => eTData.UserId == userId).ToList();
                    foreach (var eTournament in eTournaments)
                    {
                        TournamentInfo oTournament = new TournamentInfo();
                        oTournament.Id = eTournament.Id;
                        oTournament.TournamentName = eTournament.TournamentName;
                        oTournament.RegisteredOn = eTournament.RegisteredOn;
                        oTournament.RegisteredOnString = oTournament.RegisteredOn.ToString(ConfigurationManager.AppSettings["DateFormat"]);
                        oTournament.UserId = eTournament.UserId;
                        oTournament.NumberOfTeams = eTournament.TournamentTeams.Count;
                        oTournament.NumberOfMatches = eTournament.TournamentMatches.Count;

                        if (eTournament.WinnerId.HasValue)
                        {
                            oTournament.WinnerId = eTournament.WinnerId.Value;
                            oTournament.WinnerTeamName = eTournament.Team.TeamName;
                        }
                        else
                        {
                            oTournament.WinnerTeamName = "N/A";
                        }
                        oTournaments.Add(oTournament);
                    }
                }
                return oTournaments;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void DeleteTournament(int tournamentId)
        {
            try
            {
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    var eTournament = eDataBase.Tournaments.Where(eTData => eTData.Id == tournamentId).FirstOrDefault();
                    if(eTournament == null)
                    {
                        throw new Exception("No record found");
                    }
                    eDataBase.Tournaments.DeleteOnSubmit(eTournament);
                    eDataBase.SubmitChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public void AddTournamentTeam(int tournamentId, int teamId)
        {
            try
            {
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    var record = eDataBase.TournamentTeams.Where(eTData => eTData.TournamentId == tournamentId & eTData.TeamId == teamId).FirstOrDefault();
                    if(record != null)
                    {
                        throw new Exception("This team is already added in this tournament");
                    }
                    TournamentTeam eTeam = new TournamentTeam();
                    eTeam.TournamentId = tournamentId;
                    eTeam.TeamId = teamId;
                    eDataBase.TournamentTeams.InsertOnSubmit(eTeam);
                    eDataBase.SubmitChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        public List<TeamInfo> GetTeamsByTournamentId(int tournamanetId)
        {
            try
            {
                List<TeamInfo> oTeams = new List<TeamInfo>();
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    var eTeams = eDataBase.TournamentTeams.Where(eTData => eTData.TournamentId == tournamanetId).ToList();
                    foreach (var eTeam in eTeams)
                    {
                        TeamInfo oTeam = new TeamInfo();
                        oTeam.Id = eTeam.Id;
                        oTeam.TeamName = eTeam.Team.TeamName;
                        oTeam.NumberOfPlayers = eTeam.Team.TeamPlayers.Count;
                        var eMatches = eTeam.Tournament.TournamentMatches.Where(eMData => eMData.Team1Id == eTeam.Id || eMData.Team2Id == eTeam.Id).ToList();
                        oTeam.NumberOfMatchesPlayed = eMatches.Count;
                        oTeam.NumberOfMatchesWon = eMatches.Where(eMData => eMData.WinnerTeamId == eTeam.Id).Count();
                        oTeam.NumberOfMatchesLost = oTeam.NumberOfMatchesPlayed - oTeam.NumberOfMatchesWon;
                        oTeam.NumberOfTournaments = eTeam.Team.Tournaments.Count;
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
        public void DeleteTournamentTeam(int teamId)
        {
            try
            {
                using (DataClasses1DataContext eDataBase = new DataClasses1DataContext())
                {
                    var eTeam = eDataBase.TournamentTeams.Where(eTData => eTData.Id == teamId).FirstOrDefault();
                    if(eTeam == null)
                    {
                        throw new Exception("No record found");
                    }
                    eDataBase.TournamentTeams.DeleteOnSubmit(eTeam);
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