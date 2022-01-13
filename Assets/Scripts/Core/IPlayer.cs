using System.Collections.Generic;
using BckGmmn.Core.Common;

namespace BckGmmn.Core
{
    public interface IPlayer
    {
        IDiceSet DiceSet { get; }
        bool CanMove();
        IReadOnlyList<Move> GetAvailableMoves();
    }
}