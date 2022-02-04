using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BckGmmn.Core.Common
{
    public struct PointPosition : IEquatable<PointPosition>
    {
        public static readonly PointPosition Empty = new (default, 0);
        public static PointPosition ForPlayerA(int count) => new (PlayerId.PlayerA, count);
        public static PointPosition ForPlayerB(int count) => new (PlayerId.PlayerB, count);
        public static PointPosition FromCounts(int countA, int countB)
        {
            if (countA == 0)
                return ForPlayerB(countB);
            if (countB == 0)
                return ForPlayerA(countA);
            return new PointPosition(PlayerId.Undefined, countA + countB);
        }

        public PointPosition(PlayerId playerId, int count)
        {
            PlayerId = playerId;
            Count = count;
        }

        public PlayerId PlayerId { get; } // todo: for future use
        public int Count { get; }
        public bool IsEmpty() => Count == 0;


        public bool Equals(PointPosition other)
        {
            return PlayerId == other.PlayerId && Count == other.Count;
        }

        public override bool Equals(object obj)
        {
            return obj is PointPosition other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine((int) PlayerId, Count);
        }

        public static bool operator ==(PointPosition left, PointPosition right) => left.Equals(right);
        public static bool operator !=(PointPosition left, PointPosition right) => left.Equals(right) is false;
    }

    // if we want allow to stack need to rewrite board position
    //public struct PointPosition
    //{
    //    public static readonly PointPosition Empty = new PointPosition(default, 0, 0);
    //    public static PointPosition ForPlayerA(int count) => new PointPosition(PlayerId.PlayerA, count, 0);
    //    public static PointPosition ForPlayerB(int count) => new PointPosition(PlayerId.PlayerB, 0, count);

    //    public PointPosition(PlayerId activePlayer, int playerACount, int playerBCount)
    //    {
    //        ActivePlayer = activePlayer;
    //        PlayerACount = playerACount;
    //        PlayerBCount = playerBCount;
    //    }

    //    public PlayerId ActivePlayer { get; } // todo: for future use
    //    public int PlayerACount { get; }
    //    public int PlayerBCount { get; }
    //    public bool IsEmpty() => PlayerACount == 0 && PlayerBCount == 0;
    //}
}
