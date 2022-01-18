using System;
using System.Diagnostics;
using BckGmmn.Core.Common;

namespace BckGmmn.Core.Helpers
{
    public static class ConstantsHelper
    {
        // todo: check
        [Conditional("DEBUG")]
        public static void CheckContainerIndexRange(int index)
        {
            if (index is (< Constants.PointsMinIndex or > Constants.PointsCount)
                and not Constants.BarIndex and not Constants.BorneOffIndex)
                throw new ArgumentOutOfRangeException(nameof(index));
        }
    }
}
