namespace BckGmmn.Core.Common
{
    public class Player : IPlayer
    {
        public Player(IDiceSet diceSet)
        {
            DiceSet = diceSet;
        }
        public IDiceSet DiceSet { get; }
    }
}