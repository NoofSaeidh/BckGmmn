namespace BckGmmn.Core.Common
{
    public class Checker
    {

        public Checker(PlayerId player)
        {
            Player = player;
        }

        public CheckerContainer Container { get; private set; }
        public Point Point => Container as Point;
        public bool IsOnTheBar => Container is Bar;
        public bool IsBorneOff => Container is BorneOff;
        public PlayerId Player { get; }

        public void MoveTo(CheckerContainer container)
        {
            Container.RemoveInternal(this);
            MoveToInternal(container);
            Container.AddInternal(this);
        }

        internal void MoveToInternal(CheckerContainer container)
        {
            Container = container;
        }
    }
}
