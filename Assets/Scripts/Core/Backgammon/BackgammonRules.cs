using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BckGmmn.Core.Common;
using Zenject;

namespace BckGmmn.Core.Backgammon
{
    public class BackgammonRules : IRules
    {
        public bool HitEnabled => true;
        public int PlayerCheckersCount => 15;
        public QuadrantIndex HomeForPlayerA => QuadrantIndex.A;
        public QuadrantIndex HomeForPlayerB => QuadrantIndex.D;
        public BoardPosition InitialPosition { get; } = new()
        {
            [PointIndex.PointA1] = PointPosition.ForPlayerB(2),
            [PointIndex.PointA6] = PointPosition.ForPlayerA(5),
            [PointIndex.PointB2] = PointPosition.ForPlayerA(3),
            [PointIndex.PointB6] = PointPosition.ForPlayerB(5),
            [PointIndex.PointC1] = PointPosition.ForPlayerA(5),
            [PointIndex.PointC5] = PointPosition.ForPlayerB(3),
            [PointIndex.PointD1] = PointPosition.ForPlayerB(5),
            [PointIndex.PointD6] = PointPosition.ForPlayerA(2),
        };
    }
}
