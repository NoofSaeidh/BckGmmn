using System;

namespace BckGmmn.Core.Common
{
    public class SystemRandomDiceValueGenerator : IDiceValueGenerator
    {
        private readonly Random _random = new ();

        public DiceValue Next()
        {
            return new (_random.Next(1, 6));
        }
    }
}