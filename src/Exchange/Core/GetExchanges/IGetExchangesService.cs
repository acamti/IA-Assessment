using System.Collections.Generic;
using System.Threading.Tasks;

namespace IA.Assessment.Exchange.Core.GetExchanges;

public interface IGetExchangesService
{
    Task<List<Exchange>> GetAllExchanges();
}
