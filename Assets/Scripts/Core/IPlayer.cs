using System.Collections.Generic;
using BckGmmn.Core.Common;

namespace BckGmmn.Core
{
    public interface IPlayer
    {
        IDice Dice { get; }
        bool CanMove();
        IReadOnlyList<AvailableMove> GetAvailableMoves();
    }
}