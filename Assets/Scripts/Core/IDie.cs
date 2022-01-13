namespace BckGmmn.Core
{
    public interface IDie
    {
        Cast CurrentValue { get; }
        Cast Roll();
        void Reset();
    }
}