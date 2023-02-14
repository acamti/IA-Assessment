using MediatR;

namespace IA.Assessment.Continent.Core.GetContinentByName;

public sealed class GetContinentByNameRequest : IRequest<string>
{
    public string CountryName { get; init; }
}
