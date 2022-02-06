using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BckGmmn.Core.Common;

namespace BckGmmn.Core.Helpers
{
    public static class Extensions
    {
        public static QuadrantIndex HomeFor(this IRules rules, PlayerId player)
        {
            return player switch
            {
                PlayerId.PlayerA => rules.HomeForPlayerA,
                PlayerId.PlayerB => rules.HomeForPlayerB,
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        public static QuadrantIndex HomeForOpponent(this IRules rules, PlayerId player)
        {
            return HomeFor(rules, player == PlayerId.PlayerA ? PlayerId.PlayerB : PlayerId.PlayerA);
        }
    }
}
