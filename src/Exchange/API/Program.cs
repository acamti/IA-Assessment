using IA.Assessment.Exchange.Core.GetExchanges;
using IA.Assessment.Exchange.Infrastructure.Exchanges;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddTransient<IGetExchangesService, GetExchangesService>()
    .AddMediatR(typeof(GetExchangesRequest).Assembly);

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
