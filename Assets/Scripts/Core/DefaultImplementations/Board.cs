using System.Collections.Generic;
using BckGmmn.Core.Common;

namespace BckGmmn.Core.DefaultImplementations
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
