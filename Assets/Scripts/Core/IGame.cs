using BckGmmn.Core.Common;

namespace BckGmmn.Core
{
    public interface IGame
    {
        IPlayer PlayerA { get; }
        IPlayer PlayerB { get; }
        GameState GameState { get; }
        PlayerId Turn { get; set; }
        PlayerId Winner { get; }
        IBoard Board { get; }
        IRules Rules { get; }
        AllMoves AllMoves { get; }


        // void Initialize();
        void Start();
        void Abort();

        bool CanMove(PlayerId player, CheckerContainer start, CheckerContainer end);
    }
}