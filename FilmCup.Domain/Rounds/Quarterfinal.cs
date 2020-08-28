using FilmCup.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmCup.Domain.Rounds
{
    public sealed class Quarterfinal : Round
    {
        protected override int QuantityFilmsRound => 8;

        public override IEnumerable<Film> GetWinners()
        {
            var list = new List<Film>();

            var lastFilm = Films.Count();

            var orderList = Films.OrderBy(film => film.Title.Value);

            for (int i = 0; i < lastFilm; i++)
            {
                list.Add(Clash(orderList.ElementAt(i), orderList.ElementAt(--lastFilm)).First());
            }

            return list;
        }
    }
}