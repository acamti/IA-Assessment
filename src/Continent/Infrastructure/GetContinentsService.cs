using IA.Assessment.Continent.Core;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IA.Assessment.Continent.Infrastructure;

public class GetContinentsService : IGetContinentsService
{
    private readonly ILogger<GetContinentsService> _logger;

    public GetContinentsService(ILogger<GetContinentsService> logger)
    {
        _logger = logger;
    }

    public async Task<string> GetContinentByCountryCode(string code)
    {
        using var client = new HttpClient();

        var response = await client.GetAsync($"https://www.worldpop.org/rest/data/pop/wpgp?iso3={code}");

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("Something went Wrong when Getting Country Details");

            return string.Empty;
        }

        var content = await response.Content.ReadAsStringAsync();

        var countryDetails = JsonConvert.DeserializeObject<CountriesResult>(content);

        if (countryDetails?.Countries is null || !countryDetails.Countries.Any())
            return string.Empty;

        return countryDetails.Countries
            .OrderBy(country => country.Year)
            .Last()
            .Continent;
    }
}
