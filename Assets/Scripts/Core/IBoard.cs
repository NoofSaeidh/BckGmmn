using System.Collections.Generic;

namespace BckGmmn.Core
{
    public interface IBoard
    {
        IReadOnlyCollection<Checker> Checkers { get; }

        IReadOnlyCollection<Point> Points { get; }
        Bar Bar { get; }
        BorneOff BorneOff { get; }

        void Reset();
    }
}