using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BckGmmn.Core.Common
{
    public class Quadrant : IQuadrant
    {
        public Quadrant(QuadrantIndex index) //, IReadOnlyCollection<Point> points)
        {
            Index = index;
            //Points = points;
        }

        public QuadrantIndex Index { get; }

        // hack: need lazy initialization
        // todo: probably should refactor
        public IReadOnlyCollection<Point> Points { get; internal set; }
    }
}
