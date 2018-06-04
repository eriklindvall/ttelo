using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Ttelo.Shared.Model;

namespace Ttelo.Server.DataAccess
{
    public class DataAccessLayer : IDataAccessLayer
    {
        private readonly TteloContext _db;

        public DataAccessLayer(TteloContext db)
        {
            _db = db;
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return _db.Players;
        }

        public Player CreatePlayer(Player player)
        {
            _db.Players.Add(player);
            _db.SaveChanges();
            return player;
        }

        public IEnumerable<Match> GetAllMatches(bool includePlayers = true)
        {
            if (includePlayers)
            {
                return _db.Matches.Include(match => match.Winner).Include(Match => Match.Loser);
            }
            return _db.Matches;
            
        }

        public void SetName(Player player)
        {
            var existing = _db.Players.SingleOrDefault(p => p.PlayerId == player.PlayerId);
            if (existing == null)
            {
                return;
            }
            existing.Name = player.Name;
            _db.SaveChanges();
        }

        public Match CreateMatch(Match match)
        {
            _db.Matches.Add(match);
            _db.SaveChanges();
            return match;
        }

        public void UpdateRating(Player player)
        {
            var p = GetPlayer(player.PlayerId);
            p.Rating = player.Rating;
            _db.SaveChanges();
        }

        public Player GetPlayer(int playerId)
        {
            return _db.Players.SingleOrDefault(p => p.PlayerId == playerId);
        }

        public void DeleteMatch(int id)
        {
            var match = _db.Matches.SingleOrDefault(m => m.MatchId == id);
            if (match != null)
            {
                _db.Matches.Remove(match);
                _db.SaveChanges();
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
