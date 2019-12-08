using System;
using System.Threading;
using System.Threading.Tasks;

namespace UnfairCoin
{
    class Program
    {
        static void Main(string[] args)
        {
            var totalGames = 100000;
            var games = new Game[totalGames];
            Array.Fill(games, new Game());
            var secondLooseFirst = 0;
            var bothLooseTotal = 0;
            var gamesPlayed = 0;
            var setUp = new GameSetup(100, 51, 100000);
            Console.WriteLine(setUp);

            Parallel.ForEach(games, game =>
            {
                var result = game.Start(setUp);
                Interlocked.Increment(ref gamesPlayed);
                if (result.BothLoose)
                {
                    Interlocked.Increment(ref bothLooseTotal);
                    if(result.SecondLooseStep < result.FirstLooseStep)
                    {
                        Interlocked.Increment(ref secondLooseFirst);
                    }
                }

                Console.Write($" played : {gamesPlayed} Both {bothLooseTotal} Alice {bothLooseTotal - secondLooseFirst} Bob {secondLooseFirst} \r");

            });


            var resultMessage =
                $" played : {totalGames} Both {bothLooseTotal} Alice {bothLooseTotal - secondLooseFirst} Bob {secondLooseFirst}";
            Console.WriteLine(resultMessage);
        }
    }
}
