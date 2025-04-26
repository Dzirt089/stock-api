using Microsoft.OpenApi.Models;

using OzonEdu.StockApi.Infrastructure.Fillters;
using OzonEdu.StockApi.Infrastructure.Handlers.StockItemAggregate;
using OzonEdu.StockApi.Infrastructure.StartupFilters;
using OzonEdu.StockApi.Infrastructure.Swagger;

using System.Reflection;

namespace OzonEdu.StockApi.Infrastructure.Extensions
{
	public static class HostBuilderExtensions
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{

			services.AddSingleton<IStartupFilter, TerminalStartupFilter>();
			services.AddSingleton<IStartupFilter, SwaggerStartupFilter>();

			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateStockItemCommandHandler).Assembly));

			services.AddSwaggerGen(options =>
			{
				options.SwaggerDoc("v1", new OpenApiInfo { Title = "OzonEdu.StockApi", Version = "v1" });

				options.CustomSchemaIds(x => x.FullName);

				var xmlFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
				var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
				options.IncludeXmlComments(xmlFilePath);

				options.OperationFilter<HeaderOperationFilter>();
			});

			return services;
		}

		public static IServiceCollection AddHttp(this IServiceCollection services)
		{
			services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
			return services;
		}
	}
}
