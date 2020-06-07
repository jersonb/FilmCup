using FilmCup.Domain.Rounds;
using FilmCup.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FilmCup.Test
{
    public class SemifinalTest
    {
        [Fact]
        public void ErrorInstanceTreeFilmsTest()
        {
            try
            {
                var films = new List<Film> {
                    Film.GetInstance("p1", "Pânico 1", 1990, 7),
                    Film.GetInstance("p2", "Pânico 2", 1992, 6),
                    Film.GetInstance("p3", "Pânico 3", 1994, 5)
                };

                new Semifinal().SetRound(films);

                Assert.True(false);

            }
            catch (Exception ex)
            {

                Assert.Equal("Quantidade de filmes inválida para rodada semifinal, são necessários 4 filmes", ex.Message);
            }
        }

        [Fact]
        public void ErrorInstanceFiveFilmsTest()
        {
            try
            {
                var films = new List<Film> {
                    Film.GetInstance("p1", "Pânico 1", 1990, 7),
                    Film.GetInstance("p2", "Pânico 2", 1992, 6),
                    Film.GetInstance("p3", "Pânico 3", 1994, 5),
                    Film.GetInstance("p4", "Pânico 4", 1992, 6),
                    Film.GetInstance("p5", "Pânico 5", 1992, 6)
                };

                new Semifinal().SetRound(films);

                Assert.True(false);

            }
            catch (Exception ex)
            {

                Assert.Equal("Quantidade de filmes inválida para rodada semifinal, são necessários 4 filmes", ex.Message);
            }
        }

        [Fact]
        public void InstanceFilmsTest()
        {
            try
            {
                var films = new List<Film>
                {
                    Film.GetInstance("p1", "Pânico 1", 1990, 7),
                    Film.GetInstance("p2", "Pânico 2", 1992, 6),
                    Film.GetInstance("p3", "Pânico 3", 1994, 5),
                    Film.GetInstance("p4", "Pânico 4", 1992, 6)
                };

                var semifinal = new Semifinal();
                semifinal.SetRound(films);

                var winners = semifinal.GetWinners();

                Assert.True(winners.Count() == 2);
                Assert.Contains(winners, x => x.Id.Equals("p1"));
                Assert.Contains(winners, x => x.Id.Equals("p4"));
            }
            catch (Exception ex)
            {
                Assert.Null(ex);
            }
        }

    }
}
