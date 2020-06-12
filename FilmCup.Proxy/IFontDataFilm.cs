using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FilmCup.Proxy
{
    using ViewObject;

    public interface IFontDataFilm
    {
        [Get("/api/filmes")]
        Task<IEnumerable<FilmViewObject>> GetAllFilms();
    }
}
