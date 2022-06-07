using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gullycricket.ModalClasses
{
    public class TeamInfo
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string TeamName { get; set; }
        public DateTime RegisteredOn { get; set; }
        public string RegisteredOnString { get; set; }
        public int NumberOfPlayers { get; set; }
        public int NumberOfTournaments { get; set; }
        public int NumberOfMatchesPlayed { get; set; }
        public int NumberOfMatchesWon { get; set; }
        public int NumberOfMatchesLost { get; set; }

    }
}