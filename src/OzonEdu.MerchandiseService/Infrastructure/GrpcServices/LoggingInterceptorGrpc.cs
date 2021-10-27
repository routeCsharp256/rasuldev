using Grpc.Core;
using Grpc.Core.Interceptors;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Infrastructure.GrpcServices
{
    public class LoggingInterceptorGrpc : Interceptor
    {
        private readonly ILogger<LoggingInterceptorGrpc> _logger;

        public LoggingInterceptorGrpc(ILogger<LoggingInterceptorGrpc> logger)
        {
            _logger = logger;
        }

        public override async Task<TResponse> UnaryServerHandler<TRequest, TResponse>(TRequest request, ServerCallContext context, UnaryServerMethod<TRequest, TResponse> continuation)
        {
            var requestJson = JsonSerializer.Serialize(request);
            _logger.LogInformation($"Grpc request: {requestJson}");

            var response = await base.UnaryServerHandler(request, context, continuation);

            var responseJson = JsonSerializer.Serialize(response);
            _logger.LogInformation($"Grpc response: {responseJson}");

            return response;
        }
    }
}
