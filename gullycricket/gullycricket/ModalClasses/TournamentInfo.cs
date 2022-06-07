using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gullycricket.ModalClasses
{
    public class TournamentInfo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TournamentName { get; set; }
        public DateTime RegisteredOn { get; set; }
        public string RegisteredOnString { get; set; }
        public int WinnerId { get; set; }
        public string WinnerTeamName { get; set; }
        public int NumberOfTeams { get; set; }
    }
}