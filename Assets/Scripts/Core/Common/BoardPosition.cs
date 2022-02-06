using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BckGmmn.Core.Common
{
    public struct BoardPosition
    {
        private long _playerA;
        private long _playerB;
        private const int _Base = Constants.MaxPlayerCheckersCount;
        private const int _Count = Constants.ContainersCount;

        public PointPosition this[PointIndex index]
        {
            get
            {
                var a = _playerA % Math.Pow(_Base, index);
                var b = _playerB % Math.Pow(_Base, index);
                return PointPosition.FromCounts((int)a, (int)b);
            }
            set
            {
                var current = this[index];
                if (value == current)
                {
                    return;
                }

                switch (value.PlayerId)
                {
                    case PlayerId.PlayerA:
                    {
                        _playerA += (long)((value.Count - current.Count) * Math.Pow(_Base, index));
                        break;
                    }
                    case PlayerId.PlayerB:
                    {
                        _playerB += (long)((value.Count - current.Count) * Math.Pow(_Base, index));
                        break;
                    }
                }
            }
        }


        public Iterator GetEnumerator() => new Iterator(this);

        public IEnumerable<KeyValuePair<PointIndex, PointPosition>> ToEnumerable()
        {
            foreach (var item in this)
            {
                yield return item;
            }
        }

        public struct Iterator
        {
            private int _index;
            private long _nextA;
            private long _nextB;

            public Iterator(in BoardPosition position)
            {
                _index = 0;
                _nextA = position._playerA;
                _nextB = position._playerB;
            }

            public KeyValuePair<PointIndex, PointPosition> Current
            {
                get
                {
                    // todo: move calc to MoveNext()
                    var a = _nextA % _Base;
                    _nextA /= _Base;
                    var b = _nextB % _Base;
                    _nextB /= _Base;
                    return new (new PointIndex(_index), PointPosition.FromCounts((int)a,(int)b));
                }
            }
            public bool MoveNext()
            {
                if (_index < _Count)
                {
                    _index++;
                    return true;
                }

                return false;
            }
        }
    }
}
