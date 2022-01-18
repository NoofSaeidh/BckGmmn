using System.Collections.Generic;

namespace BckGmmn.Core.Common
{
    public abstract class CheckerContainer
    {
        protected readonly HashSet<Checker> _checkers;

        protected CheckerContainer()
        {
            _checkers = new HashSet<Checker>(8);
        }

        public IReadOnlyCollection<Checker> Checkers => _checkers;

        public void Add(Checker checker)
        {
            AddInternal(checker);
            checker.MoveToInternal(this);
        }

        internal void AddInternal(Checker checker)
        {
            _checkers.Add(checker);
        }

        internal void RemoveInternal(Checker checker)
        {
            _checkers.Remove(checker);
        }
    }
}