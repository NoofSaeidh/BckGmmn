using System.Collections;
using System.Collections.Generic;

namespace BckGmmn.Core.Common
{
    public class AllMoves : IReadOnlyList<IFullMove>
    {
        private readonly IReadOnlyList<IFullMove> _moves;

        public AllMoves(IReadOnlyList<IFullMove> moves)
        {
            _moves = moves;
        }

        public IFullMove this[int index] => ((IReadOnlyList<IFullMove>)_moves)[index];

        public int Count => ((IReadOnlyCollection<IFullMove>)_moves).Count;

        public IEnumerator<IFullMove> GetEnumerator()
        {
            return ((IEnumerable<IFullMove>)_moves).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)_moves).GetEnumerator();
        }
    }
}
