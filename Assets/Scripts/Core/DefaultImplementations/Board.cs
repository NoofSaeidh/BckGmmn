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

        public IReadOnlyCollection<Checker> Checkers { get; }
        public IReadOnlyDictionary<PointIndex, CheckerContainer> Containers { get; }
        public IReadOnlyCollection<Point> Points { get; }
        public Bar Bar { get; }
        public BorneOff BorneOff { get; }
        public void Reset()
        {
            throw new System.NotImplementedException();
        }
    }
}
