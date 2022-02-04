namespace BckGmmn.Core
{
    public interface IRules
    {
        bool HitEnabled { get; }
        int PlayerCheckersCount { get; } // must be not greater than Constants.MaxPlayerCheckersCount
    }
}