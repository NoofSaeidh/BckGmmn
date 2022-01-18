using System;
using BckGmmn.Core.Common;

namespace BckGmmn.Core.Backgammon
{
    public class BackgammonGame : IGame
    {
        private PlayerId _turn;
        public BackgammonGame(IPlayer player1, IPlayer player2)
        {
            PlayerA = player1;
            PlayerB = player2;
            _turn = PlayerId.Undefined;
        }

        public IPlayer PlayerA { get; }
        public IPlayer PlayerB { get; }
        public GameState GameState { get; private set; }

        public PlayerId Turn
        {
            get => _turn;
            set
            {
                if (value is < PlayerId.PlayerA or > PlayerId.PlayerB)
                {
                    throw new ArgumentException("Only PlayerA or PlayerB can be set manually.", nameof(Turn));
                }

                _turn = value;
            }
        }

        public PlayerId Winner { get; }
        public IBoard Board { get; }
        public IRules Rules { get; }
        public AllMoves AllMoves { get; }

        public void Start()
        {
            GameState = GameState.InProcess;
        }

        public void Abort()
        {
            GameState = GameState.Finished;
            _turn = PlayerId.Undefined;
        }

        public bool CanMove(PlayerId player, CheckerContainer start, CheckerContainer end)
        {
            throw new NotImplementedException();
        }

        // public void Initialize()
        // {
        //     throw new NotImplementedException();
        // }
    }
}