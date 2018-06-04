namespace Ttelo.Server.Business
{
    public interface IEloCalculator
    {
        int GetDelta(int winnerRating, int loserRating);
    }
}