using System.Threading.Tasks;

namespace IA.Assessment.Continent.Core;

public interface IGetContinentsService
{
    Task<string> GetContinentByCountryCode(string code);
}
