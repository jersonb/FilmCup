using FilmCup.Domain.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace FilmCup.Domain.Rounds
{
    using Models;

    public abstract class Round : IRound
    {
        public IEnumerable<Film> Films { get; private set; }

        public abstract IEnumerable<Film> GetWinners();

        public abstract void ValidateRound(IEnumerable<Film> films);

        protected IEnumerable<Film> Clash(Film film1, Film film2)
        {
            var result = new List<Film> { film1, film2 };

            return result.OrderByDescending(x => x.Score)
                         .ThenBy(x => x.Title);
        }

        public static IEnumerable<Film> GetWinnersRound<T>(IEnumerable<Film> films) where T : IRound, new()
        {
            var rund = new T();
            rund.SetRound(films);

            return rund.GetWinners();
        }

        public void SetRound(IEnumerable<Film> films)
        {
            ValidateRound(films);
            Films = films;
        }

    }
}
