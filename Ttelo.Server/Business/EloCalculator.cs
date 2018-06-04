using System;

namespace Ttelo.Server.Business
{
    public class EloCalculator : IEloCalculator
    {
        private int _k;
        public EloCalculator(int k)
        {
            _k = k;
        }

        public int GetDelta(int winnerRating, int loserRating)
        {
            double expected = 1 / (1 + Math.Pow(10, ((double)loserRating - (double)winnerRating) / 400));
            return (int) Math.Round(_k * (1 - expected));
        }
    }
}
