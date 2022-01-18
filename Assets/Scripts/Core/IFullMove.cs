using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BckGmmn.Core
{
    public interface IFullMove
    {
        IReadOnlyCollection<ICheckerMove> CheckerMoves { get; }
        bool IsAvailableFor(PlayerId player);
        void Apply();
    }
}
