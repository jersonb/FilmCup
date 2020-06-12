using System.Collections.Generic;
using System.Linq;

namespace FilmCup.Domain
{
    using Models;
    using Rounds;

    public static class Championchip
    {
        public static IEnumerable<Film> Champions(IEnumerable<Film> films)
        {
            films = Round.GetWinnersRound<Quarterfinal>(films);
            films = Round.GetWinnersRound<Semifinal>(films);
            films = Round.GetWinnersRound<Final>(films);
            return films;
        }

        public static (Film First, Film Second) Podium(IEnumerable<Film> films)
        {
            films = Champions(films);
           
            return (films.ElementAt(0), films.ElementAt(1));
        }
    }
}
