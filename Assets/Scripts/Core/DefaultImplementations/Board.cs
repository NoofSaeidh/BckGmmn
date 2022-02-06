using System;
using System.Collections.Generic;
using System.Linq;
using BckGmmn.Core.Common;
using Zenject;

namespace BckGmmn.Core.DefaultImplementations
{
    public class Board : IBoard
    {
        private readonly IRules _rules;

        public Board(IRules rules,
            Bar bar,
            BorneOff borneOff,
            IReadOnlyCollection<Point> points,
            IReadOnlyCollection<Checker> checkers,
            [Inject(Id = QuadrantIndex.A)] IQuadrant quadrantA,
            [Inject(Id = QuadrantIndex.A)] IQuadrant quadrantB,
            [Inject(Id = QuadrantIndex.A)] IQuadrant quadrantC,
            [Inject(Id = QuadrantIndex.A)] IQuadrant quadrantD)
        {
            _rules = rules;


            Bar = bar;
            BorneOff = borneOff;

            Points = points;
            Checkers = checkers;
            Quadrants = new Dictionary<QuadrantIndex, IQuadrant>
            {
                [QuadrantIndex.A] = quadrantA,
                [QuadrantIndex.B] = quadrantB,
                [QuadrantIndex.C] = quadrantC,
                [QuadrantIndex.D] = quadrantD,
            };
        }

        public static IReadOnlyCollection<Point> GetPoints()
        {
            var points = new Point[Constants.PointsCount];
            for (int i = 0, index = Constants.PointsMinIndex; i < points.Length; i++, index++)
            {
                points[i] = new Point(new PointIndex(index));
            }
            return points;
        }

        public static IReadOnlyCollection<Checker> GetCheckers(IRules rules)
        {

            var checkers = new Checker[rules.PlayerCheckersCount * 2];
            for (int i = 0; i < checkers.Length; i++)
            {
                checkers[i] = new Checker(PlayerId.PlayerA);
                checkers[i] = new Checker(PlayerId.PlayerB);
            }

            return checkers;
        }

        public IReadOnlyCollection<Checker> Checkers { get; }
        public IReadOnlyCollection<Point> Points { get; }
        public IReadOnlyDictionary<QuadrantIndex, IQuadrant> Quadrants { get; }
        public Bar Bar { get; }
        public BorneOff BorneOff { get; }

        public CheckerContainer this[PointIndex index]
        {
            get
            {
                return index switch
                {
                    { Index: Constants.BarIndex } => Bar,
                    { Index: Constants.BorneOffIndex } => BorneOff,
                    { Index: >= Constants.PointsMinIndex and <= Constants.PointsMinIndex } =>
                        Points.FirstOrDefault(p => p.Index == index), // todo: check allocations
                    _ => throw new ArgumentOutOfRangeException(nameof(index)),
                };
            }
        }
        public void Reset()
        {
            using var a = Checkers.GetEnumerator();
            using var b = Checkers.GetEnumerator();
            foreach (var (index, position) in _rules.InitialPosition)
            {
                var container = this[index];
                if (position.IsEmpty())
                    continue;
                var enumerator = position.PlayerId switch
                {
                    PlayerId.PlayerA => a,
                    PlayerId.PlayerB => b,
                    _ => throw new NotSupportedException(),
                };
                for (int i = 0; i < position.Count; i++)
                {
                    if(enumerator.MoveNext())
                        container.Add(enumerator.Current);
                }
            }
        }
    }
}
