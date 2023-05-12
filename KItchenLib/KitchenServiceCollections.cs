using KItchenLib.Hubs;
using KItchenLib.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KItchenLib
{
    public static class KitchenServiceCollections
    {
        public static IServiceCollection AddKitchen(this IServiceCollection services, IConfiguration config)
        {
            services.AddSignalR();

            services.AddResponseCompression(opts =>
            {
                opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                    new[] { "application/octet-stream" });
            });

            services.AddSingleton<KitchenHub>();
            services.AddTransient<KitchenService>();
            services.AddTransient<KitchenListener>();

            return services;
        }
    }
}
