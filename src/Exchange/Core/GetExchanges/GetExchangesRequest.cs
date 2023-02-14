using MediatR;
using System.Collections.Generic;

namespace IA.Assessment.Exchange.Core.GetExchanges;

public sealed class GetExchangesRequest : IRequest<List<Exchange>> { }
