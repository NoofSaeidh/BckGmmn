namespace BckGmmn.Core.Common
{
    public class Dice : IDice
    {
        private readonly IDiceValueGenerator _generator;

        public Dice(IDiceValueGenerator generator)
        {
            _generator = generator;
        }

        public DiceValue CurrentValue { get; private set; }

        public DiceValue Roll()
        {
            return CurrentValue = _generator.Next();
        }

        public void Reset()
        {
            CurrentValue = default;
        }
    }
}