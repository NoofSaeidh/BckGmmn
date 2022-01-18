namespace BckGmmn.Core.Common
{
    public class Point : CheckerContainer
    {
        public Point(PointIndex index)
        {
            Index = index;
        }

        public PointIndex Index { get; }
    }
}
