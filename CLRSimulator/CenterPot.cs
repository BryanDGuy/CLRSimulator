using CLRSimulator.Interfaces;

namespace CLRSimulator
{
    public class CenterPot : IPotHolder
    {
        public int NumberCoins { get; set; }

        public CenterPot()
        {
            NumberCoins = 0;
        }
    }
}
