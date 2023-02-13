using IA.Assessment.Exchange.Core.GetExchanges;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IA.Assessment.Exchange.API.Exchanges;

[ApiController]
[Route("[Controller]")]
public class ExchangeController : ControllerBase
{
    private readonly IMediator _mediator;

    public ExchangeController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IEnumerable<Core.Exchange>> GetAll()
    {
        var request = new GetExchangesRequest();

        return await _mediator.Send(request);
    }
}
