using System.Collections.Generic;
using BckGmmn.Core.Common;

namespace BckGmmn.Core
{
    public interface IBoard
    {
        IReadOnlyCollection<Checker> Checkers { get; }

        IReadOnlyDictionary<PointIndex, CheckerContainer> Containers { get; }
        IReadOnlyCollection<Point> Points { get; }
        Bar Bar { get; }
        BorneOff BorneOff { get; }

        void Reset();
    }
}