using IA.Assessment.Exchange.Core.GetExchanges;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace IA.Assessment.Exchange.Infrastructure;

public sealed class GetExchangesService : IGetExchangesService
{
    private readonly ILogger<GetExchangesService> _logger;

    public GetExchangesService(ILogger<GetExchangesService> logger)
    {
        _logger = logger;
    }

    public async Task<List<Core.Exchange>> GetAllExchanges()
    {
        using var client = new HttpClient();

        var response = await client.GetAsync("https://api.coingecko.com/api/v3/exchanges");

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("Something went Wrong when Getting Exchanges");

            return new List<Core.Exchange>();
        }

        var content = await response.Content.ReadAsStringAsync();

        var result = JsonConvert.DeserializeObject<List<Core.Exchange>>(content);

        return result ?? new List<Core.Exchange>();
    }
}
