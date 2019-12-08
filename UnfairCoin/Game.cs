using System;

namespace UnfairCoin
{
    class Game
    {
        public Result Start(GameSetup setup)
        {
            var result = new Result();
            var step = 0;
            var firstScore = setup.StartScore;
            var secondScore = setup.StartScore;

            var random = new Random(Guid.NewGuid().GetHashCode());

            while (step < setup.MaxSteps && !result.BothLoose && firstScore < 1000000)
            {
                var val = random.Next(1, 101);
                bool looseFirst = false, looseSecons = false;
                var score = val <= setup.FirstWinPercentage ? 1 : -1;
                firstScore += score;
                secondScore -= score;

                //Console.Write($"step {step} val {val} first {firstScore} second {secondScore} \r");

                if (!looseFirst && firstScore == 0) result.FirstLooseStep = step;
                if (!looseSecons && secondScore == 0) result.SecondLooseStep = step;

                step++;
            }

            return result;
        }
    }
}
