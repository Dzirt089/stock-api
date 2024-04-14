using Grpc.Core;
using Grpc.Core.Interceptors;
using System.Text;
using System.Text.Json;

namespace OzonEdu.StockApi.Configuration.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly ILogger<RequestLoggingMiddleware> _logger;
        private readonly RequestDelegate _next;
        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await LogRequest(context);
            await _next(context);
        }

        private async Task LogRequest(HttpContext context)
        {
            try
            {
                if (context.Request.ContentLength > 0)
                {
                    context.Request.EnableBuffering();


                    var buffer = new byte[context.Request.ContentLength.Value];
                    await context.Request.Body.ReadAsync(buffer, 0, buffer.Length);
                    var bodyAsText = Encoding.UTF8.GetString(buffer);
                    _logger.LogInformation("Request logger");
                    _logger.LogInformation(bodyAsText);

                    context.Request.Body.Position = 0;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message, ex.StackTrace);
            }

        }
    }

    public class LoggingInterceptor : Interceptor
    {
        private readonly ILogger<LoggingInterceptor> _logger;

        public LoggingInterceptor(ILogger<LoggingInterceptor> logger)
        {
            _logger = logger;
        }

        public override Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request,
            ServerCallContext context,
            UnaryServerMethod<TRequest, TResponse> continuation)
        {
            try
            {
                var requestJson = JsonSerializer.Serialize(request);
                _logger.LogInformation(requestJson);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.StackTrace);
            }

            var response = base.UnaryServerHandler(request, context, continuation);
            try
            {
                var responseJson = JsonSerializer.Serialize(response);
                _logger.LogInformation(responseJson);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.StackTrace);
            }
            
            return response;
        }

        public override AsyncServerStreamingCall<TResponse> AsyncServerStreamingCall<TRequest, TResponse>(TRequest request,
            ClientInterceptorContext<TRequest, TResponse> context,
            AsyncServerStreamingCallContinuation<TRequest, TResponse> continuation)
        {
            _logger.LogInformation("Streaming has been called");

            return base.AsyncServerStreamingCall(request, context, continuation);
        }
    }
}
