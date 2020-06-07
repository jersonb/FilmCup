using FilmCup.Domain.Rounds;
using FilmCup.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FilmCup.Test
{
    public class QuarterfinalTest
    {
        [Fact]
        public void ErrorInstanceSevenFilmsTest()
        {
            try
            {
                var films = new List<Film> {
                    Film.GetInstance("p1", "Pânico 1", 1990, 7),
                    Film.GetInstance("p2", "Pânico 2", 1992, 6),
                    Film.GetInstance("p3", "Pânico 3", 1993, 5),
                    Film.GetInstance("p4", "Pânico 4", 1995, 6),
                    Film.GetInstance("p5", "Pânico 5", 1996, 3),
                    Film.GetInstance("p6", "Pânico 6", 1998, 2),
                    Film.GetInstance("p7", "Pânico 7", 2000, 1)
                };

                new Quarterfinal().SetRound(films);

                Assert.True(false);
            }
            catch (Exception ex)
            {
                Assert.Equal("Quantidade de filmes inválida para quartas de final, são necessários 8 filmes", ex.Message);
            }

        }

        [Fact]
        public void ErrorInstanceNineFilmsTest()
        {
            try
            {
                var films = new List<Film> {
                    Film.GetInstance("p1", "Pânico 1", 1990, 7),
                    Film.GetInstance("p2", "Pânico 2", 1992, 6),
                    Film.GetInstance("p3", "Pânico 3", 1993, 5),
                    Film.GetInstance("p4", "Pânico 4", 1995, 6),
                    Film.GetInstance("p5", "Pânico 5", 1996, 3),
                    Film.GetInstance("p6", "Pânico 6", 1998, 2),
                    Film.GetInstance("p7", "Pânico 7", 2002, 8),
                    Film.GetInstance("p8", "Pânico 8", 2005, 1),
                    Film.GetInstance("p9", "Pânico 9", 2009, 3)
                };

                new Quarterfinal().SetRound(films);

                Assert.True(false);
            }
            catch (Exception ex)
            {
                Assert.Equal("Quantidade de filmes inválida para quartas de final, são necessários 8 filmes", ex.Message);
            }

        }

        [Fact]
        public void InstanceFilmsTest()
        {
            try
            {
                var films = new List<Film> {
                    Film.GetInstance("p1", "Pânico 1", 1990, 7),
                    Film.GetInstance("p2", "Pânico 2", 1992, 6),
                    Film.GetInstance("p3", "Pânico 3", 1993, 5),
                    Film.GetInstance("p4", "Pânico 4", 1995, 6),
                    Film.GetInstance("p5", "Pânico 5", 1996, 3),
                    Film.GetInstance("p6", "Pânico 6", 1998, 2),
                    Film.GetInstance("p7", "Pânico 7", 2002, 8),
                    Film.GetInstance("p8", "Pânico 8", 2005, 1)
                };

                var quarterfinal = new Quarterfinal();
                quarterfinal.SetRound(films);

                var winners = quarterfinal.GetWinners();

                Assert.True(winners.Count() == 4);

                Assert.Contains(winners, x => x.Id.Equals("p1"));
                Assert.Contains(winners, x => x.Id.Equals("p7"));
                Assert.Contains(winners, x => x.Id.Equals("p3"));
                Assert.Contains(winners, x => x.Id.Equals("p4"));

            }
            catch (Exception ex)
            {
                Assert.Null(ex);
            }

        }



    }
}
