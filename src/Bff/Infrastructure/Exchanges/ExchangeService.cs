using IA.Assessment.BFF.Core.Exchanges;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IA.Assessment.BFF.Infrastructure.Exchanges;

public sealed class ExchangeService : IGetExchangeService
{
    public Task<IEnumerable<Exchange>> GetAllExchanges()
    {
        throw new System.NotImplementedException();
    }
}
