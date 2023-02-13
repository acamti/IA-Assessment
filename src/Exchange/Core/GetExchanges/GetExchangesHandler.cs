using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace IA.Assessment.Exchange.Core.GetExchanges;

public class GetExchangesHandler : IRequestHandler<GetExchangesRequest, List<Exchange>>
{
    private readonly IGetExchangesService _service;

    public GetExchangesHandler(IGetExchangesService service)
    {
        _service = service;
    }

    public Task<List<Exchange>> Handle(GetExchangesRequest request, CancellationToken cancellationToken) =>
        _service.GetAllExchanges();
}
