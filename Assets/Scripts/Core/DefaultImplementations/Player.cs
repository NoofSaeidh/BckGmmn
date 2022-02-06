using System;
using System.Collections.Generic;
using BckGmmn.Assets.Scripts.Core.Common;
using BckGmmn.Core.Common;
using BckGmmn.Core.Helpers;

namespace BckGmmn.Core.DefaultImplementations
{
    public class Player : IPlayer
    {
        // cannot set in constructor because of circular reference
        internal IGame _game;

        public Player(PlayerId playerId, IDice dice,IReadOnlyCollection<Checker> checkers)
        {
            PlayerId = playerId;
            Dice = dice;
            _homes = new Lazy<(IQuadrant home, IQuadrant opponent)>(() =>
                (_game.Board.Quadrants[_game.Rules.HomeFor(playerId)],
                _game.Board.Quadrants[_game.Rules.HomeForOpponent(playerId)]));

            Checkers = checkers;
        }

        private Lazy<(IQuadrant home, IQuadrant opponent)> _homes;

        public PlayerId PlayerId { get; }
        public IDice Dice { get; }
        public IQuadrant Home => _homes.Value.home;
        public IQuadrant OpponentHome => _homes.Value.opponent;
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