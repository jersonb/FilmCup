using FilmCup.Domain.Models;
using System.Collections.Generic;

namespace FilmCup.Domain.Contracts
{
    public interface IRound
    {
        IEnumerable<Film> GetWinners();

        void SetRound(IEnumerable<Film> films);

    }
}
