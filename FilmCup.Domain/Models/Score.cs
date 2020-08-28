namespace FilmCup.Domain.Models
{
    public struct Score
    {
        private const int MIN_VALUE = 0;
        private const int MAX_VALUE = 10;

        public decimal Value { get; }
        internal bool IsValid { get; }

        private Score(decimal value)
        {
            Value = value;
            IsValid = value >= MIN_VALUE && value <= MAX_VALUE;
        }

        public static implicit operator Score(decimal score)
            => new Score(score);

        public override string ToString()
            => Value.ToString();
    }
}