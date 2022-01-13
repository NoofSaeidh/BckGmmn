using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BckGmmn.Core
{
    public class Point : CheckerContainer
    {
        public Point(PointIndex index)
        {
            Index = index;
        }

        public PointIndex Index { get; }
    }
}
