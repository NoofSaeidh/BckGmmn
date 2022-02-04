using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BckGmmn.Core.Common
{
    public class Board : IBoard
    {
        private readonly Dictionary<PointIndex, CheckerContainer> _containers;
        public Board(IReadOnlyCollection<Checker> checkers, IReadOnlyCollection<Point> points, Bar bar, BorneOff borneOff)
        {
            Checkers = checkers;
            Points = points;
            Bar = bar;
            BorneOff = borneOff;
            _containers = Points.ToDictionary(i => i.Index, i => (CheckerContainer)i);
            _containers[PointIndex.Bar] = Bar;
            _containers[PointIndex.BorneOff] = BorneOff;
        }

        public IReadOnlyCollection<Checker> Checkers { get; }

        public IReadOnlyCollection<Point> Points { get; }
        public Bar Bar { get; }
        public BorneOff BorneOff { get; }

        public CheckerContainer this[PointIndex index] => _containers[index];

        public void Reset()
        {
            throw new NotImplementedException();
        }
    }
}
