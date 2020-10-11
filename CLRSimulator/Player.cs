using CLRSimulator.Interfaces;
using CLRSimulator.Models;
using System;
using System.Linq;

namespace CLRSimulator
{
    public class Player : IPotHolder
    {
        public bool IsPlayerActive => NumberCoins > 0;
        public int NumberCoins { get; set; }

        public Player(int startingNumberCoins)
        {
            NumberCoins = startingNumberCoins;
        }

        public void TakeTurn(IPotHolder center, IPotHolder lPlayer, IPotHolder rPlayer)
        {
            if (IsPlayerActive) 
            {
                int numberDiceToRoll = Math.Min(NumberCoins, 3);
                DiceFace[] rollOutcome = Dice.Roll(numberDiceToRoll);

                int numberCoinsToCenter = rollOutcome.Count(outcome => outcome == DiceFace.C);
                int numberCoinsToLeft = rollOutcome.Count(outcome => outcome == DiceFace.L);
                int numberCoinsToRight = rollOutcome.Count(outcome => outcome == DiceFace.R);
                
                NumberCoins -= numberCoinsToCenter + numberCoinsToLeft + numberCoinsToRight;
                center.NumberCoins += numberCoinsToCenter;
                lPlayer.NumberCoins += numberCoinsToLeft;
                rPlayer.NumberCoins += numberCoinsToRight;
            }
        }
    }
}
