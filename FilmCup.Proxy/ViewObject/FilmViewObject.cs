using Newtonsoft.Json;

namespace FilmCup.Proxy.ViewObject
{
    public class FilmViewObject
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "titulo")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "ano")]
        public int Year { get; set; }

        [JsonProperty(PropertyName = "nota")]
        public decimal Score { get; set; }
    }
}
