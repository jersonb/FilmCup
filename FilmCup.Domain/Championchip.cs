using FilmCup.Domain.Contracts;
using FilmCup.Domain.Models;
using FilmCup.Domain.Rounds;
using System.Collections.Generic;

namespace FilmCup.Domain
{
    public static class Championchip
    {
        public static IEnumerable<Film> Champions(IEnumerable<Film> films)
        {
            var rounds = new List<IRound>
            {
                new Quarterfinal(),
                new Semifinal(),
                new Final()
            };

            rounds.ForEach(round =>
            {
                round.SetRound(films);
                films = round.GetWinners();
            });

            return films;
        }
    }
}
