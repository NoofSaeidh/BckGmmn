using System;
using System.Collections.Generic;
using Codice.Client.Commands.CheckIn;

namespace BckGmmn.Core.Common
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

        public unsafe MovesSlice GetAvailableMoves()
        {
            // hack to avoid allocations for list
            long indexes = 0;
            int count = 0;
            for (var index = 1; index <= _game.AllMoves.Count; index++)
            {
                var move = _game.AllMoves[index];
                if (move.IsAvailableFor(PlayerId))
                {
                    indexes += index * _game.AllMoves.Count;
                    count++;
                }
            }

            Span<int> ar = stackalloc int[count];
            for (int i = 0; i < count; i++)
            {
                ar[i] = (int)(indexes % _game.AllMoves.Count);
            }
            return new MovesSlice(_game.AllMoves, stackalloc int[2]{1,2});
        }
    }
}