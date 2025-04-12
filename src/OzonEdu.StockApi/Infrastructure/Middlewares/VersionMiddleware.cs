using System.Reflection;

namespace OzonEdu.StockApi.Infrastructure.Middlewares
{
	public class VersionMiddleware(RequestDelegate next)
	{
		public async Task InvokeAsync(HttpContext context)
		{
			var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "no version";
			await context.Response.WriteAsync(version);
		}
	}

}
