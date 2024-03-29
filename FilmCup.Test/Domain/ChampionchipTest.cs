﻿using System.Collections.Generic;
using System.Linq;
using Xunit;
using FilmCup.Domain;
using FilmCup.Domain.Models;
using FilmCup.Domain.Rounds;

namespace FilmCup.Test.Domain
{
    public class ChampionchipTest
    {
        private IEnumerable<Film> _films;

        public ChampionchipTest()
        {
            _films = ProxyTest.GetAllFilms();
        }

        [Theory]
        [InlineData("Vingadores: Guerra Infinita", "Os Incríveis 2")]
        [InlineData("Hereditário", "Upgrade")]
        public void ChampionNormalCaseTest(string name1, string name2)
        {
            var list1 = new List<Film>
            {
                _films.First(film => film.Title.Equals(name1)),
                _films.First(film => film.Title.Equals(name2))
            };

            var list2 = new List<Film>
            {
                _films.First(film => film.Title.Equals(name2)),
                _films.First(film => film.Title.Equals(name1))
            };

            var final1 = new Final();
            final1.SetRound(list1);
            var championRound1 = final1.GetWinners();

            var final2 = new Final();
            final2.SetRound(list2);
            var championRound2 = final2.GetWinners();

            Assert.True(championRound1.ElementAt(0).Title.Equals(name1));
            Assert.True(championRound2.ElementAt(0).Title.Equals(name1));
        }

        [Fact]
        public void AllOpertationTest()
        {
            _films = ChampionchipFactory.Champions(_films.Take(8));

            Assert.Equal(2, _films.Count());

            var (film1, film2) = (_films.ElementAt(0), _films.ElementAt(1));

            Assert.True(film1.Title.Equals("Vingadores: Guerra Infinita"));
            Assert.True(film2.Title.Equals("Os Incríveis 2"));
        }
    }
}