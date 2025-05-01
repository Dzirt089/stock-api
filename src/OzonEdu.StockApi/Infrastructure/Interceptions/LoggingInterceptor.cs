﻿using Grpc.Core;
using Grpc.Core.Interceptors;

using System.Text.Json;

namespace OzonEdu.StockApi.Infrastructure.Interceptions
{
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
