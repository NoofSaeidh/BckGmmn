using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BckGmmn.Core
{
    public class Checker
    {
        private CheckerContainer _container;
        public Point Point => _container as Point;
        public bool IsOnTheBar => _container is Bar;
        public bool IsBorneOff => _container is BorneOff;

        public void MoveTo(CheckerContainer container)
        {
            _container.RemoveInternal(this);
            MoveToInternal(container);
            _container.AddInternal(this);
        }

        internal void MoveToInternal(CheckerContainer container)
        {
            _container = container;
        }
    }
}
