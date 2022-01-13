using System;

namespace BckGmmn.Core
{
    public struct Cast : IEquatable<Cast>, IComparable<Cast>
    {
        public Cast(int value)
        {
            if (value is < 1 or > 6)
                throw new ArgumentOutOfRangeException(nameof(value), value,
                    "Die value must be between 1 and 6");
            Value = value;
        }

        public int Value { get; }

        public bool NoValue => Value == default;

        public string Sign => Value switch
        {
            1 => "⚀",
            2 => "⚁",
            3 => "⚂",
            4 => "⚃",
            5 => "⚄",
            6 => "⚅",
            _ => null
        };

        public bool Equals(Cast other)
        {
            return Value.Equals(other.Value);
        }

        public int CompareTo(Cast other)
        {
            return Value.CompareTo(other.Value);
        }

        public override bool Equals(object obj)
        {
            return obj is Cast dv && Equals(dv);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value);
        }

        public override string ToString()
        {
            if (Sign is { } sign)
                return Value + " : " + sign;
            return "NoValue";
        }

        public static explicit operator Cast(int value) => new Cast(value);
        public static implicit operator int(Cast value) => value.Value;

        public static bool operator ==(Cast left, Cast right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Cast left, Cast right)
        {
            return left.Equals(right) is false;
        }

        public static bool operator >(Cast left, Cast right)
        {
            return left.CompareTo(right) == 1;
        }
        public static bool operator <(Cast left, Cast right)
        {
            return left.CompareTo(right) == -1;
        }
    }
}