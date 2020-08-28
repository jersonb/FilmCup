using FilmCup.Domain.Models;
using FilmCup.Domain.Rounds;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FilmCup.Test
{
    public class FinalTest
    {
        [Fact]
        public void ErrorInstanceOneFilmsTest()
        {
            try
            {
                var films = new List<Film> {
                    Film.GetInstance("p1", "Pânico 1", 1990, 7)
                };

                new Final().SetRound(films);

                Assert.True(false);
            }
            catch (Exception ex)
            {
                Assert.Equal("Quantidade de filmes inválida para esta rodada, são necessários 2 filmes", ex.Message);
            }
        }

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

                new Final().SetRound(films);

                Assert.True(false);
            }
            catch (Exception ex)
            {
                Assert.Equal("Quantidade de filmes inválida para esta rodada, são necessários 2 filmes", ex.Message);
            }
        }

        [Fact]
        public void InstanceFilmsTest()
        {
            try
            {
                var films = new List<Film> {
                    Film.GetInstance("p1", "Pânico 1", 1990, 7),
                    Film.GetInstance("p2", "Pânico 2", 1992, 6)
                };

                var final = new Final();

                final.SetRound(films);

                Assert.True(final.GetWinners().Count() == 2);
            }
            catch (Exception ex)
            {
                Assert.Null(ex);
            }
        }

        [Fact]
        public void ChampionByScoreTest()
        {
            try
            {
                var films1 = new List<Film> {
                    Film.GetInstance("p2", "Pânico 2", 1992, 2),
                    Film.GetInstance("p1", "Pânico 1", 1990, 1)
                };

                var films2 = new List<Film> {
                    Film.GetInstance("p2", "Pânico 2", 1992, 2),
                    Film.GetInstance("p1", "Pânico 1", 1990, 1)
                };

                var final1 = new Final();
                var final2 = new Final();

                final1.SetRound(films1);
                final2.SetRound(films2);

                var first1 = final1.GetWinners().ElementAt(0);
                var first2 = final2.GetWinners().ElementAt(0);

                Assert.Equal(first1.Id.Value, first2.Id.Value);
                Assert.Equal("p2", first1.Id.Value);
            }
            catch (Exception ex)
            {
                Assert.Null(ex);
            }
        }

        [Fact]
        public void ChampionByTiebreakerTest()
        {
            try
            {
                var films1 = new List<Film> {
                    Film.GetInstance("p2", "Pânico 2", 1992, 1),
                    Film.GetInstance("p1", "Pânico 1", 1990, 1)
                };

                var films2 = new List<Film> {
                    Film.GetInstance("p2", "Pânico 2", 1992, 1),
                    Film.GetInstance("p1", "Pânico 1", 1990, 1)
                };

                var final1 = new Final();
                final1.SetRound(films1);

                var final2 = new Final();
                final2.SetRound(films2);

                var first1 = final1.GetWinners().ElementAt(0);
                var first2 = final2.GetWinners().ElementAt(0);

                Assert.Equal(first1.Id.Value, first2.Id.Value);
                Assert.Equal("p1", first1.Id.Value);
            }
            catch (Exception ex)
            {
                Assert.Null(ex);
            }
        }
    }
}