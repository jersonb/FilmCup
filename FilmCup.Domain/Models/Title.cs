namespace FilmCup.Domain.Models
{
    public struct Title
    {
        private const int MIN_SIZE = 2;
        private const int MAX_SIZE = 200;

        public string Value { get; }
        internal bool IsValid { get; }

        private Title(string value)
        {
            Value = value;
            IsValid = value?.Length >= MIN_SIZE && value?.Length <= MAX_SIZE;
        }

        public static implicit operator Title(string title)
            => new Title(title);

        public override string ToString()
            => Value;

        public override bool Equals(object obj)
        {
            return obj.GetHashCode().Equals(Value.GetHashCode());
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}