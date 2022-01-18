using System.Collections.Generic;
using BckGmmn.Core.Common;

namespace BckGmmn.Core.DefaultImplementations
{
    public class FullMove : IFullMove
    {
        public IReadOnlyCollection<ICheckerMove> CheckerMoves { get; }
        public bool IsAvailableFor(PlayerId player)
        {
            throw new System.NotImplementedException();
        }

        public void Apply()
        {
            throw new System.NotImplementedException();
        }
    }
}
