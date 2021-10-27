using Microsoft.AspNetCore.Http;
using System.Linq;

namespace OzonEdu.MerchandiseService.Infrastructure.Middlewares
{
    public class LoggingMiddleware
    {
        protected bool IsGrpc(HttpContext context) =>
            context.Request.Headers.Any(h => h.Key.ToLower() == "content-type" &&
                h.Value.Contains("application/grpc"));
    }
}