using System;

namespace BckGmmn.Core.Common
{
    public ref struct MovesSlice
    {
        private readonly AllMoves _allMoves;
        private readonly ReadOnlySpan<int> _indexes;

        public MovesSlice(AllMoves allMoves, in ReadOnlySpan<int> indexes)
        {
            _allMoves = allMoves;
            _indexes = indexes;
        }

        public int Count => _indexes.Length;

        public Iterator GetEnumerator()
        {
            return new Iterator(this);
        }

        public ref struct Iterator
        {
            private readonly MovesSlice _slice;
            private int _index;

            public Iterator(in MovesSlice slice)
            {
                _slice = slice;
                _index = 0;
            }

            public IFullMove Current => _slice._allMoves[_slice._indexes[_index]];
            public bool MoveNext()
            {
                if (_index < _slice._indexes.Length)
                {
                    _index++;
                    return true;
                }

                return false;
            }
        }
    }
}
