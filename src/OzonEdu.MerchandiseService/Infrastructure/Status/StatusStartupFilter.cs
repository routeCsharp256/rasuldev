using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using System;

namespace OzonEdu.MerchandiseService.Infrastructure.Status
{
    public class StatusStartupFilter : IStartupFilter
    {
        public Action<IApplicationBuilder> Configure(Action<IApplicationBuilder> next)
        {
            return builder =>
            {
                builder.Map("/version", b => b.UseMiddleware<VersionMiddleware>());
                builder.Map("/live", b => b.UseMiddleware<LiveMiddleware>());
                builder.Map("/ready", b => b.UseMiddleware<ReadyMiddleware>());
                next(builder);
            };
        }
    }
}
