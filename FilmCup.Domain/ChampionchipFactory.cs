using FilmCup.Domain.Contracts;
using FilmCup.Domain.Models;
using FilmCup.Domain.Rounds;
using System.Collections.Generic;
using System.Linq;

namespace FilmCup.Domain
{
    public static class ChampionchipFactory
    {
        public static IEnumerable<Film> Champions(this IEnumerable<Film> films)
        {
            var rounds = new List<IRound> { new Quarterfinal(), new Semifinal(), new Final() };

            rounds.ForEach(round =>
            {
                round.SetRound(films);
                films = round.GetWinners();
            });

            return films;
        }

        public static (Film First, Film Second) Podium(this IEnumerable<Film> films)
        {
            films = Champions(films);

            return (films.ElementAt(0), films.ElementAt(1));
        }
    }
}