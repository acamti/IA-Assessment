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

    public GetOverviewHandler(
        IGetExchangeService exchangeService,
        IGetContinentService continentService)
    {
        _exchangeService = exchangeService;
        _continentService = continentService;
    }

    public async Task<IEnumerable<Overview>> Handle(GetOverviewRequest request, CancellationToken cancellationToken)
    {
        await Task.Yield();

        return Enumerable.Empty<Overview>();
    }
}
