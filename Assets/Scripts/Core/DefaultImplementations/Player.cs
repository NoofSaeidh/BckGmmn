using System;
using System.Collections.Generic;
using BckGmmn.Assets.Scripts.Core.Common;
using BckGmmn.Core.Common;
using BckGmmn.Core.Helpers;
using Zenject;

namespace BckGmmn.Core.DefaultImplementations
{
    public class Player : IPlayer
    {
        // cannot set in constructor because of circular reference
        private readonly LazyInject<IGame> _game;
        private readonly Lazy<(IQuadrant home, IQuadrant opponent)> _homes;

        public Player(PlayerId playerId, IDice dice, LazyInject<IGame> game, IReadOnlyCollection<Checker> checkers)
        {
            PlayerId = playerId;
            Dice = dice;
            _game = game;
            _homes = new Lazy<(IQuadrant home, IQuadrant opponent)>(() =>
                (Game.Board.Quadrants[Game.Rules.HomeFor(playerId)],
                Game.Board.Quadrants[Game.Rules.HomeForOpponent(playerId)]));

            Checkers = checkers;
        }

        internal IGame Game => _game.Value;

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
                        if (Game.CanMove(PlayerId, checker.Container, point))
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
            var slice = new AllMovesSlice(Game.AllMoves);
            for (var index = 0; index <= Game.AllMoves.Count; index++)
            {
                var move = Game.AllMoves[index];
                if (move.IsAvailableFor(PlayerId))
                {
                    slice.AddAt(index);
                }
            }

            return slice;
        }
    }
}