using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Linq;

namespace FilmCup.Api.Controllers
{
    using Domain;
    using Domain.Models;
    using Proxy;
    using Requests;
    using Results;

    [ApiController]
    [Route("championchip")]
    public class ChampionchipController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ChampionchipController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Result), StatusCodes.Status404NotFound)]
        public ActionResult<Result> GetPodium(ListIdsRequest listIds)
        {
            var proxy = FontDataFilmProxy.FontData(_configuration.GetApiUrl());

            var filmsViewObject = proxy.GetByIds(listIds.Ids).Result;

            var films = filmsViewObject.Select(f => Film.GetInstance(f.Id, f.Title, f.Year, f.Score));

            var (First, Second) = Championchip.Podium(films);

            return Ok(new Result(StatusCodes.Status201Created, "Podium, primeiro e segundo colocado.", new { first = First.Title, second = Second.Title }));

        }
    }
}
