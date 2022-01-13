namespace BckGmmn.Core.Common
{
    public class DiceSet : IDiceSet
    {
        public DiceSet(IDice dice1, IDice dice2)
        {
            Dice1 = dice1;
            Dice2 = dice2;
        }

        public bool SupportDoubles()
        {
            return true;
        }

        public bool IsDouble()
        {
            return Dice1.CurrentValue == Dice2.CurrentValue;
        }

        public IDice Dice1 { get; }
        public IDice Dice2 { get; }

        public (DiceValue Dice1, DiceValue Dice2) Roll()
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