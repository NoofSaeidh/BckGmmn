namespace BckGmmn.Core
{
    public interface IDice
    {
        DiceValue CurrentValue { get; }
        DiceValue Roll();
        void Reset();
    }
}