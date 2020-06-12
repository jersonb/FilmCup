using System.Collections.Generic;

namespace FilmCup.Api.Requests
{
    public struct ListIdsRequest
    {
        public IEnumerable<string> Ids { get; set; }
    }
}
