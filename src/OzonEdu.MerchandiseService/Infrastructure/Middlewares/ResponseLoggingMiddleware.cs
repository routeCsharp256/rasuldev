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
    public class ResponseLoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ResponseLoggingMiddleware> _logger;

        public ResponseLoggingMiddleware(RequestDelegate next, ILogger<ResponseLoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
            if (!IsGrpc())
                LogResponse(context);
        }

        private bool IsGrpc() => false;

        private void LogResponse(HttpContext context)
        {
            try
            {
                var response = context.Response;
                _logger.LogInformation(
                    $"Http response:\r\n" + 
                    $"Status code: {response.StatusCode}\r\n" +
                    $"Headers: {JsonSerializer.Serialize(response.Headers)}");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Log response error");
            }
        }
    }
}
