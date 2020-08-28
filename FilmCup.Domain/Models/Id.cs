namespace FilmCup.Domain.Models
{
    public struct Id
    {
        private const int MIN_SIZE = 1;
        private const int MAX_SIZE = 9;

        public string Value { get; }
        internal bool IsValid { get; }

        private Id(string value) : this()
        {
            Value = value;
            IsValid = value?.Length >= MIN_SIZE && value?.Length <= MAX_SIZE;
        }

        public static implicit operator Id(string id)
            => new Id(id);

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