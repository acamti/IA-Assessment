using IA.Assessment.Continent.Core;
using IA.Assessment.Continent.Core.GetContinentByName;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IA.Assessment.Continent.Infrastructure;

public class GetCountryService : IGetCountryService
{
    private readonly ILogger<GetCountryService> _logger;

    public GetCountryService(ILogger<GetCountryService> logger)
    {
        _logger = logger;
    }

    public async Task<List<Country>> GetAllCountries()
    {
        using var client = new HttpClient();

        var response = await client.GetAsync("https://restcountries.com/v3.1/all");

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("Something went Wrong when Getting Exchanges");

            return new List<Country>();
        }

        var content = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<List<Country>>(content);

        return result ?? new List<Country>();
    }
}
