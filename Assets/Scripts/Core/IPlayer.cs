using System.Collections.Generic;
using BckGmmn.Core.Common;

namespace BckGmmn.Core
{
    public interface IPlayer
    {
        PlayerId PlayerId { get; }
        IDice Dice { get; }
        IQuadrant Home { get; }
        IQuadrant OpponentHome { get; }
        IReadOnlyCollection<Checker> Checkers { get; }
        bool CanMove();
        MovesSlice GetAvailableMoves();
    }
}