namespace CLRSimulator.Models
{
    public class DiceOutcome
    {
        public DiceFace Outcome;
        public double Probability;
    }

    public enum DiceFace
    {
        Dot,
        C,
        L,
        R
    }
}
