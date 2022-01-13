using System;
using BckGmmn.Core.Backgammon;
using BckGmmn.Core.Common;

namespace BckGmmn.Core
{
    internal static class Program
    {
        // just for check
        internal static void Main()
        {
            var generator = new SystemRandomDiceValueGenerator();

            var game = new BackgammonGame(GetPlayer(), GetPlayer()) as IGame;

            game.Start();

            DiceValue p1 = default;
            DiceValue p2 = default;
            while (p1 == p2)
            {
                p1 = game.PlayerA.DiceSet.Dice1.Roll();
                p2 = game.PlayerB.DiceSet.Dice1.Roll();
            }

            game.Turn = p1 > p2 ? PlayerId.PlayerA : PlayerId.PlayerB;

            while (game.GameState == GameState.InProcess)
            {
                switch (game.Turn)
                {
                    case PlayerId.PlayerA:
                    {
                        if (game.PlayerA.CanMove())
                        {
                            var moves = game.PlayerA.GetAvailableMoves();
                        }
                        break;
                    }
                    case PlayerId.PlayerB:
                    {
                        if (game.PlayerB.CanMove())
                        {

                        }
                        break;
                    }
                    default:
                        throw new ArgumentOutOfRangeException();
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

            IPlayer GetPlayer() => new Player(new DiceSet(new Dice(generator), new Dice(generator)));
        }
    }
}