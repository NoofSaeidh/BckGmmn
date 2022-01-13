namespace BckGmmn.Core.Common
{
    public class Player : IPlayer
    {
        public Player(IDice dice)
        {
            Dice = dice;
        }
        public IDice Dice { get; }
    }
}