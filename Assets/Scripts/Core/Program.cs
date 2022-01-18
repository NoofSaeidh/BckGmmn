using System;
using BckGmmn.Core.Backgammon;
using BckGmmn.Core.Common;
using BckGmmn.Core.DefaultImplementations;

namespace BckGmmn.Core
{
    internal static class Program
    {
        // todo: optimize foreaches

        // just for check
        internal static void Main()
        {

            var generator = new SystemRandomDiceValueGenerator();

            var game = new BackgammonGame(GetPlayer(), GetPlayer()) as IGame;

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

            void MovePlayer(IPlayer player)
            {
                if (player.CanMove())
                {
                    var moves = player.GetAvailableMoves();
                    foreach (var move in moves)
                    {
                        if (move.IsAvailableFor(player.PlayerId))
                        {
                            move.Apply();
                            break;
                        }
                    }
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

            IPlayer GetPlayer() => null; /*new Player(new Dice(new Die(generator), new Die(generator)));*/
        }
    }
}