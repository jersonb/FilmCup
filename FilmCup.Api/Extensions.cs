using Microsoft.Extensions.Configuration;

namespace FilmCup.Api
{
    public static class Extensions
    {
        public static string GetApiUrl(this IConfiguration configuration)
            => configuration.GetValue<string>("ApiProxy");
    }
}
