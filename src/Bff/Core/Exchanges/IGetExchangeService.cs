using System.Collections.Generic;
using System.Threading.Tasks;

namespace IA.Assessment.BFF.Core.Exchanges;

public interface IGetExchangeService
{
    Task<IEnumerable<Exchange>> GetAllExchanges();
}
