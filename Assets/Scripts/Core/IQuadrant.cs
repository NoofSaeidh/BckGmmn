using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BckGmmn.Core
{
    public interface IQuadrant
    {
        QuadrantIndex Index { get; }
        IReadOnlyCollection<Point> Points { get; }
    }
}
