using FilmCup.Domain.Contracts;
using FilmCup.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace FilmCup.Domain.Rounds
{
    public abstract class Round : IRound
    {
        private IEnumerable<Film> _films;

        public IEnumerable<Film> Films => _films;

        public abstract IEnumerable<Film> GetWinners();

       public abstract void ValidateRound(IEnumerable<Film> films);
       
        protected IEnumerable<Film> Clash(Film film1, Film film2)
        {
            var result = new List<Film> { film1, film2 };

            return result.OrderByDescending(x => x.Score)
                         .ThenBy(x => x.Title) ;
        }

        public void SetRound(IEnumerable<Film> films)
        {
            ValidateRound(films);
            _films = films;
        }


    }
}
