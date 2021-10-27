using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Infrastructure.Middlewares
{
    public class RequestLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestLoggingMiddleware> _logger;

        public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!IsGrpc())
                LogRequest(context);
            await _next(context);
        }

        private bool IsGrpc() => false;

        private void LogRequest(HttpContext context)
        {
            try
            {
                var request = context.Request;
                _logger.LogInformation(
                    $"Http request:\r\n" +
                    $"Path: {request.Path.Value}\r\n" +
                    $"Query: {request.QueryString.Value}\r\n" +
                    $"Headers: {JsonSerializer.Serialize(request.Headers)}");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Log request error");
            }
        }
    }
}
