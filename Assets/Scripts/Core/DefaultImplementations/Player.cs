using System;
using System.Collections.Generic;
using BckGmmn.Assets.Scripts.Core.Common;
using BckGmmn.Core.Common;

namespace BckGmmn.Core.DefaultImplementations
{
    public class Player : IPlayer
    {
        private readonly IGame _game;

        public Player(PlayerId playerId, IDice dice, IGame game, IQuadrant home, IQuadrant opponentHome, IReadOnlyCollection<Checker> checkers)
        {
            PlayerId = playerId;
            Dice = dice;
            _game = game;
            Home = home;
            OpponentHome = opponentHome;
            Checkers = checkers;
        }

        public PlayerId PlayerId { get; }
        public IDice Dice { get; }
        public IQuadrant Home { get; }
        public IQuadrant OpponentHome { get; }
        public IReadOnlyCollection<Checker> Checkers { get; }

        public bool CanMove()
        {
            foreach (var checker in Checkers)
            {
                if (checker.IsOnTheBar)
                {
                    foreach (var point in OpponentHome.Points)
                    {
                        if (_game.CanMove(PlayerId, checker.Container, point))
                        {
                            return true;
                        }
                    }

                    return false;
                }
            }

            return true;
        }

        public AllMovesSlice GetAvailableMoves()
        {
            var slice = new AllMovesSlice(_game.AllMoves);
            for (var index = 0; index <= _game.AllMoves.Count; index++)
            {
                var move = _game.AllMoves[index];
                if (move.IsAvailableFor(PlayerId))
                {
                    slice.AddAt(index);
                }
            }

            return slice;
        }
    }
}