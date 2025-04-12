using OzonEdu.StockApi.GrpcServices;
using OzonEdu.StockApi.Infrastructure.Extensions;
using OzonEdu.StockApi.Infrastructure.Fillters;
using OzonEdu.StockApi.Infrastructure.Middlewares;
using OzonEdu.StockApi.Services;
using OzonEdu.StockApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(optionals => optionals.Filters.Add<GlobalExceptionFilter>());
builder.Services.AddGrpc(options => options.Interceptors.Add<LoggingInterceptor>());

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSingleton<IStockService, StockService>();
//builder.Services.AddScoped<IStockItemRepository, StockItemRepository>();

builder.Services.AddInfrastructure();
builder.Services.AddHttp();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseMiddleware<RequestLoggingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapGrpcService<StockApiGrpcService>();
app.MapControllers();

app.Run();
