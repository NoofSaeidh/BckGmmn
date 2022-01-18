using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BckGmmn.Core.Common
{
    public class CheckerMove : ICheckerMove
    {
        public CheckerMove(CheckerContainer start, CheckerContainer end)
        {
            Start = start;
            End = end;
        }

        public CheckerContainer Start { get; }
        public CheckerContainer End { get; }

        public void Apply()
        {
            var checker = Start.Checkers.FirstOrDefault();
            if (checker is null)
                throw new InvalidOperationException("Start container doesn't contain checkers");
            checker.MoveTo(End);
        }
    }
}
