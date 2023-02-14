using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IA.Assessment.Continent.Core.GetContinentByName;

public sealed class GetContinentByNameHandler : IRequestHandler<GetContinentByNameRequest, string>
{
    private readonly IGetContinentsService _continentsService;
    private readonly IGetCountryService _countryService;

    public GetContinentByNameHandler(
        IGetContinentsService continentsContinentsService,
        IGetCountryService countryService)
    {
        _continentsService = continentsContinentsService;
        _countryService = countryService;
    }

    public async Task<string> Handle(GetContinentByNameRequest request, CancellationToken cancellationToken)
    {
        var countryCode = await GetCountryCodeByName(request.CountryName);

        return countryCode is not null
            ? await _continentsService.GetContinentByCountryCode(countryCode)
            : string.Empty;
    }

    private async Task<string> GetCountryCodeByName(string countryName)
    {
        var countries = await _countryService.GetAllCountries();

        var foundCountry = countries.FirstOrDefault(country => country.Name?.Common == countryName);

        return foundCountry?.Iso3;
    }
}
