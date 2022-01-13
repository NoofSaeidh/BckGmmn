using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BckGmmn.Core.Common
{
    public class Board : IBoard
    {
        public Board()
        {
            var points = new Point[Constants.PointsCount];
            for (int i = 0, index = Constants.PointsMinIndex; i < points.Length; i++, index++)
            {
                points[i] = new Point(new PointIndex(index));
            }
            Points = points;
        }

        public IReadOnlyCollection<Point> Points { get; }
    }
}
