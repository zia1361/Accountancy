using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gullycricket.ModalClasses
{
    public class MatchInfo
    {
        public int Id { get; set; }
        public string EncryptedId { get; set; }
        public int TournamentId { get; set; }
        public string TournamentName { get; set; }
        public int Team1Id { get; set; }
        public string Team1Name { get; set; }
        public int Team2Id { get; set; }
        public string Team2Name { get; set; }
        public DateTime StartingDate { get; set; }
        public string StartingDateString { get; set; }
        public int MatchStatusId { get; set; }
        public string MatchStatusName { get; set; }
        public int TossWinningTeamId { get; set; }
        public string TossWinningTeamName { get; set; }
        public int WinnerTeamId { get; set; }
        public string WinnerTeamName { get; set; }
        public int TargetScore { get; set; }
        public int CurrentInningTeamId { get; set; }
        public string CurrentInningTeamName { get; set; }
    }
}