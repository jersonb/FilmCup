using FilmCup.Domain.Models;
using FilmCup.Proxy;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace FilmCup.Test
{
    public class ProxyTest
    {
        public static IEnumerable<Film> GetAllFilms()
        {
            var list = new List<Film>();

            var filmViewObjects = FontDataFilmProxy.FontData("http://copafilmes.azurewebsites.net").GetAll().Result;

            filmViewObjects.ToList().ForEach(vo => list.Add(Film.GetInstance(id: vo.Id, vo.Title, vo.Year, vo.Score)));

            return list;
        }


        [Fact]
        public static void GetAllFilmsTest()
        {
            Assert.Equal(16, GetAllFilms().Count());
        }

        public IEnumerable<Film> FirstEigth
            => GetAllFilms().Take(8).OrderBy(x => x.Title);


        public IEnumerable<string> AllIds
           => GetAllFilms().Select(film => film.Id);


        private IEnumerable<string> FirstEightFilmNames
            => new List<string>
            {
                 "Os Incríveis 2"
                ,"Jurassic World: Reino Ameaçado"
                ,"Oito Mulheres e um Segredo"
                ,"Hereditário"
                ,"Vingadores: Guerra Infinita"
                ,"Deadpool 2"
                ,"Han Solo: Uma História Star Wars"
                ,"Thor: Ragnarok"
            };


        private IEnumerable<string> FirstEightFilmNamesInOrder
            => new List<string>
            {
                "Deadpool 2"
                , "Han Solo: Uma História Star Wars"
                , "Hereditário"
                , "Jurassic World: Reino Ameaçado"
                , "Oito Mulheres e um Segredo"
                , "Os Incríveis 2"
                , "Thor: Ragnarok"
                , "Vingadores: Guerra Infinita"
            };

        public IEnumerable<string> GenerateAllIds
         => GetAllFilms().Select(film => film.Id);

        [Fact]
        public void FirstEightTest()
        {
            var nameFilms = GetAllFilms().Take(8).Select(film => film.Title);

            Assert.True(FirstEightFilmNames.SequenceEqual(nameFilms));
            Assert.False(FirstEightFilmNamesInOrder.SequenceEqual(nameFilms));
        }


        [Fact]
        public void OrderTest()
        {
            var listflmOrderByName = FirstEigth.Select(film => film.Title);

            Assert.True(FirstEightFilmNamesInOrder.SequenceEqual(listflmOrderByName));
            Assert.False(FirstEightFilmNames.SequenceEqual(listflmOrderByName));
        }



    }
}
