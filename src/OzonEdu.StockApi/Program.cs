using OzonEdu.StockApi.Configuration.Fillters;
using OzonEdu.StockApi.Configuration.Middlewares;
using OzonEdu.StockApi.GrpcServices;
using OzonEdu.StockApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(optionals => optionals.Filters.Add<GlobalExceptionFilter>());
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IStockService, StockService>();
builder.Services.AddGrpc();

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
