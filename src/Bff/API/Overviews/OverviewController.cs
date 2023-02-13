using IA.Assessment.BFF.Core.Overviews;
using IA.Assessment.BFF.Core.Overviews.GetOverview;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IA.Assessment.BFF.API.Overviews;

[ApiController]
[Route("[Controller]")]
public class OverviewController : ControllerBase
{
    private readonly IMediator _mediator;

    public OverviewController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IEnumerable<Overview>> Get()
    {
        var request = new GetOverviewRequest();

        return await _mediator.Send(request);
    }
}
