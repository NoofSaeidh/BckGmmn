using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BckGmmn.Core
{
    public struct PointIndex : IEquatable<PointIndex>, IComparable<PointIndex>
    {
        public PointIndex(int index)
        {
            if (index is < Constants.PointsMinIndex or > Constants.PointsCount)
                throw new ArgumentOutOfRangeException(nameof(index));

            Index = index;
        }

        public PointIndex(Quadrant quadrant, int quadrantIndex)
        {
            if (quadrant is < Quadrant.A or > Quadrant.D)
                throw new ArgumentOutOfRangeException(nameof(quadrant));
            if (quadrantIndex is < Constants.PointsMinIndex or > Constants.PointsCountInQuadrant)
                throw new ArgumentOutOfRangeException(nameof(quadrantIndex));
            Index = (int)quadrant * quadrantIndex;
        }

        public int Index { get; }

        public Quadrant Quadrant => (Quadrant)(Index % 4);

        public int QuadrantIndex => Index / 4;

        public bool Equals(PointIndex other)
        {
            return Index.Equals(other.Index);
        }

        public int CompareTo(PointIndex other)
        {
            return Index.CompareTo(other.Index);
        }

        public override bool Equals(object other)
        {
            return other is PointIndex point && Equals(point);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Index);
        }

        public override string ToString()
        {
            return $"{Index}, {nameof(Quadrant)}: {Quadrant}, {nameof(QuadrantIndex)}: {QuadrantIndex}";
        }

        public static explicit operator PointIndex(int value) => new PointIndex(value);
        public static implicit operator int(PointIndex value) => value.Index;

        public static bool operator ==(PointIndex left, PointIndex right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(PointIndex left, PointIndex right)
        {
            return left.Equals(right) is false;
        }

        public static bool operator >(PointIndex left, PointIndex right)
        {
            return left.CompareTo(right) == 1;
        }
        public static bool operator <(PointIndex left, PointIndex right)
        {
            return left.CompareTo(right) == -1;
        }
    }

    public enum Quadrant
    {
        Undefined = 0,
        A = 1,
        B = 2,
        C = 3,
        D = 4
    }
}