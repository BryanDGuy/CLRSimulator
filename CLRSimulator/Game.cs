using System.Collections.Generic;
using System.Linq;

namespace CLRSimulator
{
    public class Game
    {
        private readonly int _numberPlayers;
        private readonly int _startingPlayerCoins;

        public Game(int numberPlayers, int startingPlayerCoins)
        {
            _numberPlayers = numberPlayers;
            _startingPlayerCoins = startingPlayerCoins;
        }

        public int PlayGame()
        {
            CenterPot centerPot = new CenterPot();
            List<Player> allPlayers = new List<Player>(_numberPlayers);
            for (int i = 0; i < _numberPlayers; i++)
            {
                allPlayers.Add(new Player(_startingPlayerCoins));
            }

            int playerPointer = 0;
            while (allPlayers.Count(player => player.IsPlayerActive) > 1)
            {
                Player leftPlayer = playerPointer == 0 ? allPlayers[^1] : allPlayers[playerPointer - 1];
                Player rightPlayer = playerPointer == allPlayers.Count - 1 ? allPlayers[0] : allPlayers[playerPointer + 1];

                allPlayers[playerPointer].TakeTurn(centerPot, leftPlayer, rightPlayer);

                playerPointer++;
                if (playerPointer >= allPlayers.Count)
                {
                    playerPointer = 0;
                }
            }

            return allPlayers.FindIndex(player => player.IsPlayerActive);
        }
    }
}
