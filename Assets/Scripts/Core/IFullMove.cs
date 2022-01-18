using System.Collections.Generic;
using BckGmmn.Core.Common;

namespace BckGmmn.Core
{
    public interface IFullMove
    {
        IReadOnlyCollection<ICheckerMove> CheckerMoves { get; }
        bool IsAvailableFor(PlayerId player);
        void Apply();
    }
}
