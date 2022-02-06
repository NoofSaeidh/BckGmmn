using System;
using BckGmmn.Core.Common;
using Zenject;

namespace BckGmmn.Core.Backgammon
{
    public class BackgammonGame : IGame
    {
        private PlayerId _turn;
        public BackgammonGame(
            [Inject(Id = PlayerId.PlayerA)] IPlayer playerA,
            [Inject(Id = PlayerId.PlayerB)] IPlayer playerB,
            IBoard board, IRules rules, AllMoves allMoves)
        {
            PlayerA = playerA;
            PlayerB = playerB;
            Board = board;
            Rules = rules;
            AllMoves = allMoves;
            _turn = PlayerId.Undefined;
            Winner = PlayerId.Undefined;
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