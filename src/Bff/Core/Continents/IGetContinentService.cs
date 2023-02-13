using System.Collections.Generic;
using System.Threading.Tasks;

namespace IA.Assessment.BFF.Core.Continents;

public interface IGetContinentService
{
    Task<IEnumerable<Continent>> GetContinentByCountryName(string countryName);
}
