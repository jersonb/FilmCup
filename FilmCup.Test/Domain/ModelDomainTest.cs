using FilmCup.Domain.Models;
using System;
using Xunit;

namespace FilmCup.Test
{
    public class ModelDomainTest
    {
        [Theory]
        [InlineData(null, null, 0, 0)]
        [InlineData("", "", 1, 1)]
        [InlineData("a", "b", 1800, 1)]
        [InlineData("a", "b", 1801, 0)]
        public void FilmNotValidInstanceTest(string id, string title, int year, decimal score)
        {
            try
            {
                var film = Film.GetInstance(id, title, year, score);

                Assert.Null(film);
            }
            catch (Exception ex)
            {
                Assert.IsType<InvalidOperationException>(ex);
            }
        }

        
        [Theory]
        [InlineData("a", "b", 1801, 1)]
        [InlineData("avdqnf", "a volta dos que não foram", 2020, 10)]
        public void FilmValidInstanceTest(string id, string title, int year, decimal score)
        {
            try
            {
                var film = Film.GetInstance(id, title, year, score);

                Assert.NotNull(film);
            }
            catch (Exception ex)
            {
                Assert.Null(ex);
            }
        }


    }
}
