namespace BckGmmn.Core
{
    public interface IDiceSet
    {
        IDice Dice1 { get; }
        IDice Dice2 { get; }
        bool SupportDoubles();
        bool IsDouble();
        (DiceValue Dice1, DiceValue Dice2) Roll();
        void Reset();
    }
}