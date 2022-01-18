using BckGmmn.Core.Common;

namespace BckGmmn.Core.DefaultImplementations
{
    public class Dice : IDice
    {
        public Dice(IDie dice1, IDie dice2)
        {
            Dice1 = dice1;
            Dice2 = dice2;
        }

        public bool SupportDoubles()
        {
            return true;
        }

        public bool IsDoublet()
        {
            return Dice1.CurrentValue == Dice2.CurrentValue;
        }

        public IDie Dice1 { get; }
        public IDie Dice2 { get; }

        public (Cast Cast1, Cast Cast2) Roll()
        {
            return (Dice1.Roll(), Dice2.Roll());
        }

        public void Reset()
        {
            Dice1.Reset();
            Dice2.Reset();
        }
    }
}