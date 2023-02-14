using IA.Assessment.BFF.Core.Continents;
using IA.Assessment.BFF.Core.Exchanges;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace IA.Assessment.BFF.Core.Overviews.GetOverview;

public sealed class GetOverviewHandler : IRequestHandler<GetOverviewRequest, IEnumerable<Overview>>
{
    private readonly IGetContinentService _continentService;
    private readonly IGetExchangeService _exchangeService;
    private Dictionary<string, string> _countries;

    public GetOverviewHandler(
        IGetExchangeService exchangeService,
        IGetContinentService continentService)
    {
        _exchangeService = exchangeService;
        _continentService = continentService;
    }

    public async Task<IEnumerable<Overview>> Handle(GetOverviewRequest request, CancellationToken cancellationToken)
    {
        _countries = new Dictionary<string, string>();

        var allExchanges = await _exchangeService.GetAllExchanges();

        return allExchanges
            .Where(exchange => exchange.Country is not null or "")
            .GroupBy(exchange => FindContinentForCountry(exchange.Country).Result)
            .Select(exchangeGroup =>
            {
                return new Overview
                {
                    ContinentName = exchangeGroup.Key,
                    Countries = exchangeGroup.Select(exchange => new Overview.CountryOverview
                    {
                        CountryName = exchange.Country,
                        ExchangeName = exchange.Name,
                        HasIncentive = exchange.HasTradingIncentive,
                        TradeVolume = exchange.TradeVolume,
                        YearEstablished = exchange.YearEstablished,
                        CountryFlagURL = "https://flagcdn.com/48x36/_.png"
                    })
                };
            });
    }

    private async Task<string> FindContinentForCountry(string countryName)
    {
        if (countryName is null)
            return string.Empty;

        if (_countries.TryGetValue(countryName, out var value))
            return value;

        var continent = await _continentService.GetContinentByCountryName(countryName);
        _countries.Add(countryName, continent);

        return continent;
    }
}
