using System;

namespace FilmCup.Domain.Models
{
    public struct Film
    {
        public Id Id { get; }

        public Title Title { get; }

        public Year Year { get; }

        public Score Score { get; }

        private Film(string id, string title, int year, decimal score)
        {
            Id = id;
            Title = title;
            Year = year;
            Score = score;

            if (!Id.IsValid)
                throw new InvalidOperationException("Id is invalid");

            if (!Title.IsValid)
                throw new InvalidOperationException("Titlle is invalid");
        }

        public static Film GetInstance(string id, string title, int year, decimal score)
            => new Film(id, title, year, score);
    }
}