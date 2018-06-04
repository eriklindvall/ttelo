using System;
using System.Linq;
using Ttelo.Server.DataAccess;
using Ttelo.Shared.Model;

namespace Ttelo.Server.Business
{
    public class BusinessLayer : IBusinessLayer
    {
        private const int k = 50;
        private const int initialRating = 1500;

        private readonly IEloCalculator eloCalculator = new EloCalculator(k);
        private readonly IDataAccessLayer _dataAccessLayer;

        public BusinessLayer(IDataAccessLayer dataAccessLayer)
        {
            _dataAccessLayer = dataAccessLayer;
        }

        public int AdjustRatings(Player winner, Player loser)
        {
            int delta = eloCalculator.GetDelta(winner.Rating, loser.Rating);
            winner.Rating += delta;
            loser.Rating -= delta;
            _dataAccessLayer.UpdateRating(winner);
            _dataAccessLayer.UpdateRating(loser);
            return delta;
        }

        public Player CreatePlayer(string name)
        {
            var player = new Player() { Name = name, Rating = initialRating };
            return _dataAccessLayer.CreatePlayer(player);
        }

        public Match CreateMatch(int winner, int loser)
        {
            var winningPlayer = _dataAccessLayer.GetPlayer(winner);
            var losingPlayer = _dataAccessLayer.GetPlayer(loser);
            
            var delta = AdjustRatings(winningPlayer, losingPlayer);
            
            var match = new Match() { Winner = winningPlayer, Loser = losingPlayer, Time = DateTime.UtcNow, Delta = delta };
            match = _dataAccessLayer.CreateMatch(match);

            return match;
        }

        public void Recalculate()
        {
            var playerLookup = _dataAccessLayer.GetAllPlayers().ToDictionary(player => player.PlayerId);
            foreach (var player in playerLookup.Values)
            {
                player.Rating = initialRating;
            }
            var matches = _dataAccessLayer.GetAllMatches(false).OrderBy(match => match.Time);
            foreach (var match in matches)
            {
                var delta = AdjustRatings(playerLookup[match.Winner.PlayerId], playerLookup[match.Loser.PlayerId]);
                match.Delta = delta;
            }
            _dataAccessLayer.Save();
        }

        public void DeleteMatch(int matchId)
        {
            _dataAccessLayer.DeleteMatch(matchId);
            Recalculate();
        }
    }
}
