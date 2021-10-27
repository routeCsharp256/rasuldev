using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace OzonEdu.MerchandiseService.Infrastructure
{
    public static class HostBuilderExtensions
    {
        public static IHostBuilder AddInfrastructure(this IHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                ConfigureStatusAndLogging(services);
                // Required for swagger
                services.AddMvc();
                ConfigureSwagger(services);
            });
            return builder;
        }

        private static void ConfigureStatusAndLogging(IServiceCollection services)
        {
            services.AddTransient<IStartupFilter, LoggingStartupFilter>();
            services.AddTransient<IStartupFilter, StatusStartupFilter>();
        }

        private static void ConfigureSwagger(IServiceCollection services)
        {
            services.AddTransient<IStartupFilter, SwaggerStartupFilter>();
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "OzonEdu.MerchandiseService", Version = "v1" });
                options.CustomSchemaIds(x => x.FullName);
                //var xmlFileName = Assembly.GetExecutingAssembly().GetName().Name + ".xml";
                //var xmlFilePath = Path.Combine(AppContext.BaseDirectory, xmlFileName);
                //options.IncludeXmlComments(xmlFilePath);
            });
            
        }
    }
}
