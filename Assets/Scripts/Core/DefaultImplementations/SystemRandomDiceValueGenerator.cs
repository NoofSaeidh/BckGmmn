using System;
using BckGmmn.Core.Common;

namespace BckGmmn.Core.DefaultImplementations
{
    public class SystemRandomDiceValueGenerator : IDiceValueGenerator
    {
        private readonly Random _random = new ();

        public Cast Next()
        {
            return new (_random.Next(1, 6));
        }
    }
}