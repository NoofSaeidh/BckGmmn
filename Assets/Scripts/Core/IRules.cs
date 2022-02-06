using BckGmmn.Core.Common;

namespace BckGmmn.Core
{
    public interface IRules
    {
        bool HitEnabled { get; }
        int PlayerCheckersCount { get; } // must be not greater than Constants.MaxPlayerCheckersCount
        BoardPosition InitialPosition { get; }
        QuadrantIndex HomeForPlayerA { get; }
        QuadrantIndex HomeForPlayerB { get; }
    }
}