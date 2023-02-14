using IA.Assessment.Continent.Core.GetContinentByName;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace IA.Assessment.Continent.API.Continents;

[ApiController]
[Route("[Controller]")]
public class ContinentController : ControllerBase
{
    private readonly IMediator _mediator;

    public ContinentController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{name}")]
    public async Task<IActionResult> GetContinentByCountryName([FromRoute] string name)
    {
        var request = new GetContinentByNameRequest
        {
            CountryName = name
        };

        var response = await _mediator.Send(request);

        return response is null or ""
            ? NotFound()
            : new OkObjectResult(response);
    }
}
