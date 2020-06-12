using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmCup.Proxy
{
    using System.Linq;
    using ViewObject;

    public class FontDataFilmProxy
    {
        private readonly string _urlBase;
        private FontDataFilmProxy(string urlBase)
        {
            _urlBase = urlBase;
        }

        public static FontDataFilmProxy FontData(string urlBase)
            => new FontDataFilmProxy(urlBase);


        public async Task<IEnumerable<FilmViewObject>> GetAll()
            => await RestService.For<IFontDataFilm>(_urlBase).GetAllFilms();

        public async Task<IEnumerable<FilmViewObject>> GetByIds(IEnumerable<string> ids)
        {
            var all = await GetAll();
            return all.Where(film => ids.Contains(film.Id))
                      .AsEnumerable();
        }

        //public async Task<object> GetByIds(IEnumerable<string> ids)
        //{
        //    var all = await GetAll();
        //    return all.Where(film => ids.Contains(film.Id))
        //              .AsEnumerable();

        //}

    }
}
