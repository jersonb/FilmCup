using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmCup.Domain.Rounds
{
    using Models;

    public class Semifinal : Round
    {
        public override IEnumerable<Film> GetWinners()
            => new List<Film>
             {
                Clash(Films.ElementAt(0), Films.ElementAt(1)).First(),
                Clash(Films.ElementAt(2), Films.ElementAt(3)).First()
             };


        public override void ValidateRound(IEnumerable<Film> films)
        {
            if (films.Count() != 4)
                throw new InvalidOperationException("Quantidade de filmes inválida para rodada semifinal, são necessários 4 filmes");
        }
    }
}
