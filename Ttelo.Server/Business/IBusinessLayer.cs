using System.Collections.Generic;
using Ttelo.Shared.Model;

namespace Ttelo.Server.Business
{
    public interface IBusinessLayer
    {
        int AdjustRatings(Player winner, Player loser);
        void Recalculate();
        Player CreatePlayer(string name);
        Match CreateMatch(int winner, int loser);
        void DeleteMatch(int matchId);
        IEnumerable<Player> GetPlayersByRank();
        IEnumerable<Player> GetPlayersByName();
        IEnumerable<Match> GetMatchesInSwedishTime();
        void SetName(Player player);
    }
}