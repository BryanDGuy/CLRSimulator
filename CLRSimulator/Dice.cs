using CLRSimulator.Models;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CLRSimulator
{
    public class Dice
    {
        private static readonly DiceOutcome[] _clrOutcomes = new DiceOutcome[]
        {
            new DiceOutcome { Outcome = DiceFace.Dot, Probability = 3.0/6.0 },
            new DiceOutcome { Outcome = DiceFace.C, Probability = 1.0/6.0 },
            new DiceOutcome { Outcome = DiceFace.L, Probability = 1.0/6.0 },
            new DiceOutcome { Outcome = DiceFace.R, Probability = 1.0/6.0 },
        };

        public static DiceFace[] Roll(int numberDice)
        {
            Task<DiceFace>[] rollingTasks = new Task<DiceFace>[numberDice];
            for (int i = 0; i < rollingTasks.Length; i++)
            {
                rollingTasks[i] = Task.Run(RollOneDice);
            }

            Task.WaitAll(rollingTasks);
            return rollingTasks.Select(roll => roll.Result).ToArray();
        }

        private static DiceFace RollOneDice()
        {
            double threshold = 0;
            double rolledValue = new Random().NextDouble();
            DiceFace rolledFace = _clrOutcomes[0].Outcome;
            foreach (var outcome in _clrOutcomes)
            {
                threshold += outcome.Probability;
                if (rolledValue <= threshold)
                {
                    rolledFace = outcome.Outcome;
                    break;
                }
            }

            return rolledFace;
        }
    }
}
