using FilmCup.Proxy.ViewObject;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmCup.Proxy
{
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

    }
}
