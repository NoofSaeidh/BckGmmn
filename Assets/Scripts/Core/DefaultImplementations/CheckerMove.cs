using System;
using System.Linq;
using BckGmmn.Core.Common;

namespace BckGmmn.Core.DefaultImplementations
{
    public class CheckerMove : ICheckerMove
    {
        private PointIndex _start;
        private PointIndex _end;

        public CheckerMove(CheckerContainer start, CheckerContainer end)
        {
            Start = start;
            End = end;
        }

        public CheckerContainer Start { get; }

        PointIndex ICheckerMove.End => _end;

        PointIndex ICheckerMove.Start => _start;

        public CheckerContainer End { get; }

        public bool Available()
        {
            throw new NotImplementedException();
        }

        public void Apply()
        {
            var checker = Start.Checkers.FirstOrDefault();
            if (checker is null)
                throw new InvalidOperationException("Start container doesn't contain checkers");
            checker.MoveTo(End);
        }
    }
}
