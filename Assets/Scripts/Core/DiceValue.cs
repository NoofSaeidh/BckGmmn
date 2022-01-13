using System;

namespace BckGmmn.Core
{
    public struct DiceValue : IEquatable<DiceValue>, IComparable<DiceValue>
    {
        public DiceValue(int value)
        {
            if (value is < 1 or > 6)
                throw new ArgumentOutOfRangeException(nameof(value), value,
                    "Dice value must be between 1 and 6");
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

        public bool Equals(DiceValue other)
        {
            return Value.Equals(other.Value);
        }

        public int CompareTo(DiceValue other)
        {
            return Value.CompareTo(other.Value);
        }

        public override bool Equals(object obj)
        {
            return obj is DiceValue dv && Equals(dv);
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

        public static bool operator ==(DiceValue left, DiceValue right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DiceValue left, DiceValue right)
        {
            return left.Equals(right) is false;
        }

        public static bool operator >(DiceValue left, DiceValue right)
        {
            return left.CompareTo(right) == 1;
        }
        public static bool operator <(DiceValue left, DiceValue right)
        {
            return left.CompareTo(right) == -1;
        }
    }
}