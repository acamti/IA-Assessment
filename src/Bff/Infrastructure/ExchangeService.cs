using IA.Assessment.BFF.Core.Exchanges;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IA.Assessment.BFF.Infrastructure;

public sealed class ExchangeService : IGetExchangeService
{
    private readonly ILogger<ExchangeService> _logger;

    public ExchangeService(ILogger<ExchangeService> logger)
    {
        _logger = logger;
    }

    public async Task<IEnumerable<Exchange>> GetAllExchanges()
    {
        using var client = new HttpClient();

        var response = await client.GetAsync("http://localhost:5001/Exchange");

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("Something went Wrong when Getting Exchanges");

            return new List<Exchange>();
        }

        var content = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<List<Exchange>>(content);

        return result ?? new List<Exchange>();
    }
}
