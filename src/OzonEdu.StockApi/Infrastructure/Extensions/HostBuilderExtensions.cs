using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.OpenApi.Models;

using OzonEdu.StockApi.Infrastructure.Fillters;
using OzonEdu.StockApi.Infrastructure.Interceptions;
using OzonEdu.StockApi.Infrastructure.StartupFilters;
using OzonEdu.StockApi.Infrastructure.Swagger;

using System.Net;
using System.Reflection;

namespace OzonEdu.StockApi.Infrastructure.Extensions
{
	//TODO: Ещё раз разобраться с тем, как проходят регистрация всей инфраструктуры
	public static class HostBuilderExtensions
	{
		public static IServiceCollection AddInfrastructure(this IServiceCollection services)
		{
			services.AddSingleton<IStartupFilter, TerminalStartupFilter>();
			services.AddSingleton<IStartupFilter, SwaggerStartupFilter>();
			services.AddControllers(optionals => optionals.Filters.Add<GlobalExceptionFilter>());
			services.AddGrpc(options => options.Interceptors.Add<LoggingInterceptor>());

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

		public static WebApplicationBuilder ConfigurePorts(this WebApplicationBuilder builder)
		{
			var httpPortEnv = Environment.GetEnvironmentVariable("HTTP_PORT");
			if (!int.TryParse(httpPortEnv, out var httpPort))
				httpPort = 5000;

			var grpcPortEnv = Environment.GetEnvironmentVariable("GRPC_PORT");
			if (!int.TryParse(grpcPortEnv, out var grpcPort))
				grpcPort = 5002;

			builder.WebHost.ConfigureKestrel(options =>
			{
				Listen(options, httpPort, HttpProtocols.Http1);
				Listen(options, grpcPort, HttpProtocols.Http2);
			});

			return builder;
		}
		static void Listen(KestrelServerOptions kestrelServerOptions, int? port, HttpProtocols protocols)
		{
			if (port == null)
				return;

			var address = IPAddress.Any;


			kestrelServerOptions.Listen(address, port.Value, listenOptions => { listenOptions.Protocols = protocols; });
		}
	}
}
