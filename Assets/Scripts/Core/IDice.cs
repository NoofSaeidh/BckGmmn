namespace BckGmmn.Core
{
    public interface IDice
    {
        IDie Dice1 { get; }
        IDie Dice2 { get; }
        bool IsDoublet();
        (Cast Cast1, Cast Cast2) Roll();
        void Reset();
    }
}