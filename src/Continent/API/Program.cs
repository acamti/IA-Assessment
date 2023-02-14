using IA.Assessment.Continent.Core;
using IA.Assessment.Continent.Core.GetContinentByName;
using IA.Assessment.Continent.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddTransient<IGetContinentsService, GetContinentsService>()
    .AddTransient<IGetCountryService, GetCountryService>()
    .AddMediatR(typeof(GetContinentByNameRequest).Assembly);

var app = builder.Build();

app.UseAuthorization();

app.MapControllers();

app.Run();
