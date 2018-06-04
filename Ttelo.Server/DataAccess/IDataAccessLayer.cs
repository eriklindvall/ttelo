using System.Collections.Generic;
using Ttelo.Shared.Model;

namespace Ttelo.Server.DataAccess
{
    public interface IDataAccessLayer
    {
        IEnumerable<Player> GetAllPlayers();

        Player CreatePlayer(Player player);

        IEnumerable<Match> GetAllMatches(bool includePlayers = true);

        void SetName(Player player);

        Match CreateMatch(Match match);

        void UpdateRating(Player player);

        Player GetPlayer(int playerId);

        void DeleteMatch(int id);

        void Save();
    }
}