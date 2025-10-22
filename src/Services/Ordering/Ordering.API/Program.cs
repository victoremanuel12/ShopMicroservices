using Ordering.API;
using Ordering.Application;
using Ordering.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddApplicationServices()
    .AddApiServices()
    .AddInfrastructureServices(builder.Configuration);

var app = builder.Build();


app.Run();
