using FilmCup.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace FilmCup.Domain.Rounds
{
    public sealed class Final : Round
    {
        protected override int QuantityFilmsRound => 2;

        public override IEnumerable<Film> GetWinners()
            => Clash(Films.ElementAt(0), Films.ElementAt(1));
    }
}