using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using OzonEdu.MerchandiseService.Infrastructure.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Infrastructure
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
