using System.Collections.Generic;
using BckGmmn.Core.Common;

namespace BckGmmn.Core
{
    public interface IQuadrant
    {
        QuadrantIndex Index { get; }
        IReadOnlyCollection<Point> Points { get; }
    }
}
