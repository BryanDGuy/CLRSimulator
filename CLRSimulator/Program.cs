using System;
using System.Collections.Generic;

namespace CLRSimulator
{
    class Program
    {
        public const int NUMBER_PLAYERS = 10;
        public const int STARTING_NUM_COINS = 4;
        public const int NUMBER_SIMULATIONS = 10000;

        static void Main()
        {
            Game newGame = new Game(NUMBER_PLAYERS, STARTING_NUM_COINS);
            Dictionary<int, int> winnerTracker = new Dictionary<int, int>(NUMBER_PLAYERS);
            for (int i = 0; i < NUMBER_PLAYERS; i++)
            {
                winnerTracker.Add(i, 0);
            }

            for (int i = 0; i < NUMBER_SIMULATIONS; i++)
            {
                int winnerIndex = newGame.PlayGame();
                winnerTracker[winnerIndex]++;
                Console.WriteLine($"The winner of game {i} is at index {winnerIndex}");
            }

            Console.WriteLine($"Results of {NUMBER_SIMULATIONS} games");
            foreach (var entry in winnerTracker)
            {
                Console.WriteLine($"{{{entry.Key}, {entry.Value}}}");
            }
        }
    }
}
