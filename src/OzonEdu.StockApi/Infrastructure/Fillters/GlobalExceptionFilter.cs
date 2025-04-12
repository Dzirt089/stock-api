using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OzonEdu.StockApi.Infrastructure.Fillters
{
	public class GlobalExceptionFilter : ExceptionFilterAttribute
	{
		public override void OnException(ExceptionContext context)
		{
			// base.OnExceptionAsync(context);
			var resultObject = new
			{
				ExceptionType = context.Exception.GetType().FullName,
				context.Exception.Message,
			};

			var jsonResult = new JsonResult(resultObject)
			{
				StatusCode = StatusCodes.Status500InternalServerError
			};
			context.Result = jsonResult;
		}
	}
}
