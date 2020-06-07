using FilmCup.Proxy.ViewObject;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmCup.Proxy
{
    public interface IFontDataFilm
    {
        [Get("/api/filmes")]
        Task<IEnumerable<FilmViewObject>> GetAllFilms();
    }
}
