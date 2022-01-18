using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BckGmmn.Core
{
    public readonly struct PointIndex : IEquatable<PointIndex>, IComparable<PointIndex>
    {
        public static readonly PointIndex Bar = new PointIndex(Constants.BarIndex);
        public static readonly PointIndex BorneOff = new PointIndex(Constants.BorneOffIndex);

        public static readonly PointIndex PointA1 = new PointIndex(Core.QuadrantIndex.A, 1);
        public static readonly PointIndex PointA2 = new PointIndex(Core.QuadrantIndex.A, 2);
        public static readonly PointIndex PointA3 = new PointIndex(Core.QuadrantIndex.A, 3);
        public static readonly PointIndex PointA4 = new PointIndex(Core.QuadrantIndex.A, 4);
        public static readonly PointIndex PointA5 = new PointIndex(Core.QuadrantIndex.A, 5);
        public static readonly PointIndex PointA6 = new PointIndex(Core.QuadrantIndex.A, 6);
        
        public static readonly PointIndex PointB1 = new PointIndex(Core.QuadrantIndex.B, 1);
        public static readonly PointIndex PointB2 = new PointIndex(Core.QuadrantIndex.B, 2);
        public static readonly PointIndex PointB3 = new PointIndex(Core.QuadrantIndex.B, 3);
        public static readonly PointIndex PointB4 = new PointIndex(Core.QuadrantIndex.B, 4);
        public static readonly PointIndex PointB5 = new PointIndex(Core.QuadrantIndex.B, 5);
        public static readonly PointIndex PointB6 = new PointIndex(Core.QuadrantIndex.B, 6);
        
        public static readonly PointIndex PointC1 = new PointIndex(Core.QuadrantIndex.C, 1);
        public static readonly PointIndex PointC2 = new PointIndex(Core.QuadrantIndex.C, 2);
        public static readonly PointIndex PointC3 = new PointIndex(Core.QuadrantIndex.C, 3);
        public static readonly PointIndex PointC4 = new PointIndex(Core.QuadrantIndex.C, 4);
        public static readonly PointIndex PointC5 = new PointIndex(Core.QuadrantIndex.C, 5);
        public static readonly PointIndex PointC6 = new PointIndex(Core.QuadrantIndex.C, 6);
        
        public static readonly PointIndex PointD1 = new PointIndex(Core.QuadrantIndex.D, 1);
        public static readonly PointIndex PointD2 = new PointIndex(Core.QuadrantIndex.D, 2);
        public static readonly PointIndex PointD3 = new PointIndex(Core.QuadrantIndex.D, 3);
        public static readonly PointIndex PointD4 = new PointIndex(Core.QuadrantIndex.D, 4);
        public static readonly PointIndex PointD5 = new PointIndex(Core.QuadrantIndex.D, 5);
        public static readonly PointIndex PointD6 = new PointIndex(Core.QuadrantIndex.D, 6);

        public PointIndex(int index)
        {
            if (index is (< Constants.PointsMinIndex or > Constants.PointsCount)
                      and not Constants.BarIndex and not Constants.BorneOffIndex)
                throw new ArgumentOutOfRangeException(nameof(index));

            Index = index;
        }

        public PointIndex(QuadrantIndex quadrant, int indexInQuadrant)
        {
            if (quadrant is < Core.QuadrantIndex.A or > Core.QuadrantIndex.D)
                throw new ArgumentOutOfRangeException(nameof(quadrant));
            if (indexInQuadrant is < Constants.PointsMinIndex or > Constants.PointsCountInQuadrant)
                throw new ArgumentOutOfRangeException(nameof(indexInQuadrant));
            Index = (int)quadrant * indexInQuadrant;
        }

        public int Index { get; }

        public QuadrantIndex Quadrant => (QuadrantIndex)(Index % 4);

        public int IndexInQuadrant => Index / 4;

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
            return $"{Index}, {nameof(Quadrant)}: {Quadrant}, {nameof(IndexInQuadrant)}: {IndexInQuadrant}";
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

    public enum QuadrantIndex
    {
        Undefined = 0,
        A = 1,
        B = 2,
        C = 3,
        D = 4
    }
}