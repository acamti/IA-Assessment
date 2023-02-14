using IA.Assessment.BFF.Core.Continents;
using IA.Assessment.BFF.Core.Exchanges;
using IA.Assessment.BFF.Core.Overviews.GetOverview;
using IA.Assessment.BFF.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddTransient<IGetExchangeService, ExchangeService>()
    .AddTransient<IGetContinentService, ContinentService>()
    .AddMediatR(typeof(GetOverviewRequest).Assembly);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin();
    });
});

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();
