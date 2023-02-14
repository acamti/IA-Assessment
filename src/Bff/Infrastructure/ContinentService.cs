using IA.Assessment.BFF.Core.Continents;
using Microsoft.Extensions.Logging;
using System.Net.Http;
using System.Threading.Tasks;

namespace IA.Assessment.BFF.Infrastructure;

public class ContinentService : IGetContinentService
{
    private readonly ILogger<ContinentService> _logger;

    public ContinentService(ILogger<ContinentService> logger)
    {
        _logger = logger;
    }

    public async Task<string> GetContinentByCountryName(string name)
    {
        using var client = new HttpClient();

        var response = await client.GetAsync($"http://localhost:5002/Continent/{name}");

        if (response.IsSuccessStatusCode)
            return await response.Content.ReadAsStringAsync();

        _logger.LogError("Something went Wrong when Getting Continent Name");

        return string.Empty;
    }
}
