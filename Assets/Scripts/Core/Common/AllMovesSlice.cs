using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BckGmmn.Core;
using BckGmmn.Core.Common;
using BckGmmn.Core.Helpers;

namespace BckGmmn.Assets.Scripts.Core.Common
{
    // specific version of OneNumberList
    public struct AllMovesSlice
    {
        private readonly AllMoves _allMoves;
        private long _value;
        private const int _base = 2;
        public int Count { get; private set; }

        public AllMovesSlice(AllMoves allMoves)
        {
            _allMoves = allMoves;
            Count = 0;
            _value = 0;
        }

        public Iterator GetEnumerator() => new Iterator(this);

        public IEnumerable<IFullMove> ToEnumerable()
        {
            foreach (var item in this)
            {
                yield return item;
            }
        }

        public void AddAt(int index)
        {
            ConstantsHelper.CheckContainerIndexRange(index);

            _value += (long)(Math.Pow(_base, Count++));
        }

        public struct Iterator
        {
            private readonly AllMovesSlice _listSlice;
            private int _index;
            private long _nextValue;

            public Iterator(in AllMovesSlice listSlice)
            {
                _listSlice = listSlice;
                _index = 0;
                _nextValue = _listSlice._value;
            }

            public IFullMove Current
            {
                get
                {
                    var value = _nextValue % _base;
                    _nextValue /= _base;
                    return _listSlice._allMoves[(int)value];
                }
            }
            public bool MoveNext()
            {
                if (_index < _listSlice.Count)
                {
                    _index++;
                    return true;
                }

                return false;
            }
        }
    }
}
