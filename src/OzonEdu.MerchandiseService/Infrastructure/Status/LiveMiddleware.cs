using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Infrastructure.Status
{
    public class LiveMiddleware
    {
        public LiveMiddleware(RequestDelegate next)
        {
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("Ok");
        }
    }
}
