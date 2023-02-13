using IA.Assessment.BFF.Core.Continents;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IA.Assessment.BFF.Infrastructure.Continents;

public class ContinentService : IGetContinentService
{
    public Task<IEnumerable<Continent>> GetContinentByCountryName(string countryName) =>
        throw new NotImplementedException();
}
