using System;
using System.Collections.Generic;

namespace BckGmmn.Core.Common
{
    public struct OneNumberList
    {
        private long _value;
        public int Base { get; }
        public int Count { get; private set; }

        public OneNumberList(int @base)
        {
            Base = @base;
            Count = 0;
            _value = 0;
        }

        public Iterator GetEnumerator() => new Iterator(this);

        public IEnumerable<int> ToEnumerable()
        {
            foreach (var item in this)
            {
                yield return item;
            }
        }

        public void Add(int value)
        {
            if (value >= Base || value < 0)
                throw new ArgumentOutOfRangeException(nameof(value));

            _value = _value + (long)(value * Math.Pow(Base, Count++));
        }

        public struct Iterator
        {
            private readonly OneNumberList _list;
            private int _index;
            private long _nextValue;

            public Iterator(in OneNumberList list)
            {
                _list = list;
                _index = 0;
                _nextValue = _list._value;
            }

            public int Current
            {
                get
                {
                    var value = _nextValue % _list.Base;
                    _nextValue /= _list.Base;
                    return (int)value;
                }
            }
            public bool MoveNext()
            {
                if (_index < _list.Count)
                {
                    _index++;
                    return true;
                }

                return false;
            }
        }
    }
}
