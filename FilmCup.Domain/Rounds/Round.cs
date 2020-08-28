using FilmCup.Domain.Contracts;
using FilmCup.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FilmCup.Domain.Rounds
{
    public abstract class Round : IRound
    {
        protected abstract int QuantityFilmsRound { get; }
        public IEnumerable<Film> Films { get; private set; }

        public abstract IEnumerable<Film> GetWinners();

        public virtual void ValidateRound()
        {
            if (Films.Count() != QuantityFilmsRound)
                throw new InvalidOperationException($"Quantidade de filmes inválida para esta rodada, são necessários {QuantityFilmsRound} filmes");
        }

        protected IEnumerable<Film> Clash(Film film1, Film film2)
        {
            var result = new List<Film> { film1, film2 };

            return result.OrderByDescending(x => x.Score.Value)
                         .ThenBy(x => x.Title.Value);
        }

        public void SetRound(IEnumerable<Film> films)
        {
            Films = films;
            ValidateRound();
        }
    }
}