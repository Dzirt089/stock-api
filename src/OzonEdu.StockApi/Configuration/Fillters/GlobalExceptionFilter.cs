using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace OzonEdu.StockApi.Configuration.Fillters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            base.OnExceptionAsync(context);
            var resultObject = new
            {
                ExceptionType = context.Exception.GetType().FullName,
                Message = context.Exception.Message,
            };
            
            var jsonResult = new JsonResult(resultObject)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
            context.Result = jsonResult;
            Console.WriteLine(resultObject.Message);
        }
    }
}
