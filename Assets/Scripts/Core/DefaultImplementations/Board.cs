using System;
using System.Collections.Generic;
using System.Linq;
using BckGmmn.Core.Common;

namespace BckGmmn.Core.DefaultImplementations
{
    public class Board : IBoard
    {
        private readonly IGame _game;

        public Board(IGame game)
        {
            _game = game;
            var points = new Point[Constants.PointsCount];
            for (int i = 0, index = Constants.PointsMinIndex; i < points.Length; i++, index++)
            {
                points[i] = new Point(new PointIndex(index));
            }
            Points = points;

            Bar = new Bar();
            BorneOff = new BorneOff();

            var checkers = new Checker[_game.Rules.PlayerCheckersCount * 2];
            for (int i = 0; i < checkers.Length; i++)
            {
                checkers[i] = new Checker(PlayerId.PlayerA);
                checkers[i] = new Checker(PlayerId.PlayerB);
            }

            Checkers = checkers;
        }

        public IReadOnlyCollection<Checker> Checkers { get; }
        public IReadOnlyCollection<Point> Points { get; }
        public Bar Bar { get; }
        public BorneOff BorneOff { get; }

        public CheckerContainer this[PointIndex index]
        {
            get
            {
                return index switch
                {
                    {Index: Constants.BarIndex} => Bar,
                    {Index: Constants.BorneOffIndex} => BorneOff,
                    {Index: >= Constants.PointsMinIndex and <= Constants.PointsMinIndex} =>
                        Points.FirstOrDefault(p => p.Index == index), // todo: check allocations
                    _ => throw new ArgumentOutOfRangeException(nameof(index)),
                };
            }
        }
        public void Reset()
        {
            throw new System.NotImplementedException();
        }
    }
}
