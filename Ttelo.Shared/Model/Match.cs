using System;

namespace Ttelo.Shared.Model
{
    public class Match
    {
        public int MatchId { get; set; }

        public Player Winner { get; set; }

        public Player Loser { get; set; }

        public DateTime Time { get; set; }

        public int Delta { get; set; }
    }
}
