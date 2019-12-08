using System;
using System.Threading;
using System.Threading.Tasks;

namespace UnfairCoin
{
    class Program
    {
        static void Main(string[] args)
        {
            var totalGames = 1000;
            var games = new Game[totalGames];
            Array.Fill(games, new Game());
            var secondLooseFirst = 0;
            var bothLooseTotal = 0;
            var gamesPlayed = 0;

            Parallel.ForEach(games, game =>
            {
                var result = game.Start(new GameSetup(20, 51, int.MaxValue / 10));
                Interlocked.Increment(ref gamesPlayed);
                if (result.BothLoose)
                {
                    Interlocked.Increment(ref bothLooseTotal);
                    if(result.SecondLooseStep < result.FirstLooseStep)
                    {
                        Interlocked.Increment(ref secondLooseFirst);
                    }
                }

                Console.Write($" total : {totalGames} Both {bothLooseTotal} Alice {bothLooseTotal - secondLooseFirst} Bob {secondLooseFirst} \r");

            });


            var resultMessage =
                $" total : {totalGames} Both {bothLooseTotal} Alice {bothLooseTotal - secondLooseFirst} Bob {secondLooseFirst}";
            Console.WriteLine(resultMessage);
        }
    }
}
