using System;

namespace FilmCup.Domain.Models
{
    public struct Year
    {
        private const int MIN_YEAR = 1950;
        private static readonly int MAX_YEAR = DateTime.Now.Year;

        public int Value { get; }
        internal bool IsValid { get; }

        private Year(int value)
        {
            Value = value;
            IsValid = value >= MIN_YEAR && value < MAX_YEAR;
        }

        public static implicit operator Year(int year)
            => new Year(year);

        public override string ToString()
            => Value.ToString();
    }
}