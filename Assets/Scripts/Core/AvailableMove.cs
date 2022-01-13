using System;
using System.Linq;

namespace BckGmmn.Core
{
    // represents the full move with ALL dice
    public struct AvailableMove
    {
        public AvailableMove(CheckerContainer start, CheckerContainer end)
        {
            Start = start;
            End = end;
        }

        public CheckerContainer Start { get; }
        public CheckerContainer End { get; }

        // todo: intermediate steps

        public void Apply()
        {
            var checker = Start.Checkers.FirstOrDefault();
            if (checker is null)
                throw new InvalidOperationException("Start container doesn't contain checkers");
            checker.MoveTo(End);
        }
    }
}