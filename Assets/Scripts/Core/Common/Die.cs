namespace BckGmmn.Core.Common
{
    public class Die : IDie
    {
        private readonly IDiceValueGenerator _generator;

        public Die(IDiceValueGenerator generator)
        {
            _generator = generator;
        }

        public Cast CurrentValue { get; private set; }

        public Cast Roll()
        {
            return CurrentValue = _generator.Next();
        }

        public void Reset()
        {
            CurrentValue = default;
        }
    }
}