using System.Collections.Generic;

namespace FilmCup.Domain.Contracts
{
    using Models;

    public interface IRound
    {
        IEnumerable<Film> GetWinners();

        void SetRound(IEnumerable<Film> films);

    }
}
