using Microsoft.AspNetCore.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Infrastructure.Middlewares
{
    public class VersionMiddleware
    {
        public VersionMiddleware(RequestDelegate next)
        {
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "no version";
            await context.Response
                .WriteAsJsonAsync(new { version = version, serviceName = "Merchandise Service" });
        }
    }
}
