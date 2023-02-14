using System.Collections.Generic;
using System.Threading.Tasks;

namespace IA.Assessment.Continent.Core.GetContinentByName;

public interface IGetCountryService
{
    Task<List<Country>> GetAllCountries();
}
