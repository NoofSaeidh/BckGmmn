using System;
using System.Runtime.CompilerServices;
using BckGmmn.Core.Backgammon;
using BckGmmn.Core.Common;
using BckGmmn.Core.DefaultImplementations;
using Zenject;

[assembly: InternalsVisibleTo("BckGmmn.App")]

namespace BckGmmn.Core
{
    internal static class Program
    {
        // todo: optimize foreaches

        // just for check
        internal static void Main()
        {

            var generator = new SystemRandomDiceValueGenerator();

            IGame game = new BackgammonGame(
                GetPlayer(PlayerId.PlayerA, QuadrantIndex.A, QuadrantIndex.D),
                GetPlayer(PlayerId.PlayerB, QuadrantIndex.D, QuadrantIndex.A),
                null,
                null,
                null);
            //(game.PlayerA as Player).Game = game;
            //(game.PlayerB as Player).Game = game;

            game.Start();

            Cast p1 = default;
            Cast p2 = default;
            while (p1 == p2)
            {
                p1 = game.PlayerA.Dice.Dice1.Roll();
                p2 = game.PlayerB.Dice.Dice1.Roll();
            }

            game.Turn = p1 > p2 ? PlayerId.PlayerA : PlayerId.PlayerB;

            while (game.GameState == GameState.InProcess)
            {
                Console.WriteLine($"Player {game.Turn} turn.");
                switch (game.Turn)
                {
                    case PlayerId.PlayerA:
                    {
                        MovePlayer(game.PlayerA);
                        break;
                    }
                    case PlayerId.PlayerB:
                    {
                        MovePlayer(game.PlayerB);
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            Console.WriteLine($"Player {game.Winner} won!");

            void MovePlayer(IPlayer player)
            {
                if (player.CanMove())
                {
                    var moves = player.GetAvailableMoves();
                    foreach (var move in moves)
                    {
                        if (move.IsAvailableFor(player.PlayerId))
                        {
                            Console.WriteLine($"Player {player} moves {move}.");
                            move.Apply();
                            break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"Player {player} cannot move.");
                }
            }

            switch (game.Winner)
            {
                case PlayerId.PlayerA:
                {
                    break;
                }
                case PlayerId.PlayerB:
                {
                    break;
                }
                default:
                    throw new ArgumentOutOfRangeException();
            }



            game.Abort();

            IPlayer GetPlayer(PlayerId player, QuadrantIndex homeQuadrant, QuadrantIndex opponentHomeQuadrant) => new Player(
                player,
                new Dice(new Die(generator), new Die(generator)),
                null,
                null);
        }
    }
}