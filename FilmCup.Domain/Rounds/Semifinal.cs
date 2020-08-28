using FilmCup.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace FilmCup.Domain.Rounds
{
    public sealed class Semifinal : Round
    {
        protected override int QuantityFilmsRound => 4;

        public override IEnumerable<Film> GetWinners()
            => new List<Film>
             {
                Clash(Films.ElementAt(0), Films.ElementAt(1)).First(),
                Clash(Films.ElementAt(2), Films.ElementAt(3)).First()
             };
    }
}