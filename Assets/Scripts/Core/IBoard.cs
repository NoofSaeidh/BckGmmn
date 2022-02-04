using System.Collections.Generic;
using BckGmmn.Core.Common;

namespace BckGmmn.Core
{
    public interface IBoard
    {
        IReadOnlyCollection<Checker> Checkers { get; }
        IReadOnlyCollection<Point> Points { get; }
        Bar Bar { get; }
        BorneOff BorneOff { get; }

        CheckerContainer this[PointIndex index] { get; }

        void Reset();
    }
}