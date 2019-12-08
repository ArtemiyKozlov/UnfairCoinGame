namespace UnfairCoin
{
    public class GameSetup
    {
        public int StartScore { get; }
        public int FirstWinPercentage { get; }
        public int MaxSteps { get; }

        public GameSetup(int startScore, int percentage, int maxSteps)
        {
            StartScore = startScore;
            FirstWinPercentage = percentage;
            MaxSteps = maxSteps;
        }
    }
}
