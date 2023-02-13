using MediatR;
using System.Collections.Generic;

namespace IA.Assessment.BFF.Core.Overviews.GetOverview;

public sealed class GetOverviewRequest : IRequest<IEnumerable<Overview>> { }
