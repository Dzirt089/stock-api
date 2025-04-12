using Microsoft.OpenApi.Models;

using Swashbuckle.AspNetCore.SwaggerGen;

namespace OzonEdu.StockApi.Infrastructure.Swagger
{
	public class HeaderOperationFilter : IOperationFilter
	{
		/// <summary>
		/// Добавляет заголовок в Swagger UI
		/// </summary>
		/// <param name="operation"></param>
		/// <param name="context"></param>
		public void Apply(OpenApiOperation operation, OperationFilterContext context)
		{
			operation.Parameters ??= new List<OpenApiParameter>();
			operation.Parameters.Add(new OpenApiParameter
			{
				In = ParameterLocation.Header,
				Name = "our-header",
				Required = false,
				Schema = new OpenApiSchema
				{
					Type = "string"
				},
			});
		}
	}
}
