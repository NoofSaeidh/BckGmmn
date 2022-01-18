using BckGmmn.Core.Common;

namespace BckGmmn.Core
{
    public interface ICheckerMove
    {
        PointIndex Start { get; }
        PointIndex End { get; }
        bool Available();
        void Apply();
    }
}
