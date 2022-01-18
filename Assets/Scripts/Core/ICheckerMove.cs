using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BckGmmn.Core
{
    public interface ICheckerMove
    {
        PointIndex Start { get; }
        PointIndex End { get; }
        bool Available();
        void Apply();
    }
}
