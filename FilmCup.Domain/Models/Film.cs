using System;

namespace FilmCup.Domain.Models
{
    public class Film
    {
        public string Id { get;  }

        public string Title { get;  }

        public int Year { get;  }

        public decimal Score { get;  }
    

        private Film(string id, string title, int year, decimal score)
        {
            Id = string.IsNullOrEmpty(id) ? throw new InvalidOperationException("Id Inválido"): id;
            Title = string.IsNullOrEmpty(title) ? throw new InvalidOperationException("Title Inválido"):title;
            Year = year <= 1800 ? throw new InvalidOperationException("Title Inválido") : year ;
            Score = score <= 0 ? throw new InvalidOperationException("Title Inválido") : score;
        }

        public static Film GetInstance(string id, string title, int year, decimal score)
            => new Film(id, title, year, score);

       
    }
}
