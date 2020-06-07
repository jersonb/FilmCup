using FilmCup.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmCup.Domain.Rounds
{
    public class Quarterfinal : Round
    {

        public override IEnumerable<Film> GetWinners()
        {
            var list = new List<Film>();

            var lastFilm = Films.Count();

            var orderList = Films.OrderBy(film => film.Title);

            for (int i = 0; i < lastFilm; i++)
            {
                list.Add(Clash(orderList.ElementAt(i), orderList.ElementAt(--lastFilm)).First());
            }

            return list;
        }

        public override void ValidateRound(IEnumerable<Film> films)
        {
            if (films.Count() != 8)
                throw new InvalidOperationException("Quantidade de filmes inválida para quartas de final, são necessários 8 filmes");
        }
    }
}
