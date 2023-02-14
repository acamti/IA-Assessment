using System.Threading.Tasks;

namespace IA.Assessment.BFF.Core.Continents;

public interface IGetContinentService
{
    Task<string> GetContinentByCountryName(string countryName);
}
