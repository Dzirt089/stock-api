using Npgsql;

using OzonEdu.StockApi.Application.Handlers.StockItemAggregate;
using OzonEdu.StockApi.Domain.AggregationModels.DeliveryRequestAggregate;
using OzonEdu.StockApi.Domain.AggregationModels.StockItemAggregate;
using OzonEdu.StockApi.Domain.Contracts;
using OzonEdu.StockApi.GrpcServices;
using OzonEdu.StockApi.Infrastructure.Configurations;
using OzonEdu.StockApi.Infrastructure.Extensions;
using OzonEdu.StockApi.Infrastructure.Middlewares;
using OzonEdu.StockApi.Infrastructure.Repositories.Implementation;
using OzonEdu.StockApi.Infrastructure.Repositories.Infrastructure;
using OzonEdu.StockApi.Infrastructure.Repositories.Infrastructure.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateStockItemCommandHandler).Assembly));
builder.Services.AddEndpointsApiExplorer();


builder.Services.AddInfrastructure();
builder.Services.AddHttp();

Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
builder.Services.Configure<DatabaseConnectionOptions>(builder.Configuration.GetSection(nameof(DatabaseConnectionOptions)));

builder.Services.AddScoped<IDbConnectionFactory<NpgsqlConnection>, NpgsqlConnectionFactory>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IChangeTracker, ChangeTracker>();

builder.Services.AddScoped<IStockItemRepository, StockItemRepository>();
builder.Services.AddScoped<IDeliveryRequestRepository, DeliveryRequestRepository>();

// Для демонстрации.
builder.Services.AddScoped<IItemTypeRepository, ItemTypeRepository>();
builder.ConfigurePorts();
var app = builder.Build();

app.UseMiddleware<RequestLoggingMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapGrpcService<StockApiGrpcService>();
app.MapControllers();

app.Run();
