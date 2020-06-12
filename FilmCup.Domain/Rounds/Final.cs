using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmCup.Domain.Rounds
{
    using Models;

    public class Final : Round
    {

        public override IEnumerable<Film> GetWinners()
            => Clash(Films.ElementAt(0), Films.ElementAt(1));

        public override void ValidateRound(IEnumerable<Film> films)
        {
            if (films.Count() != 2)
                throw new InvalidOperationException("Quantidade de filmes inválida para rodada final, são necessários 2 filmes");
        }

    }
}
