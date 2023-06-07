using Messaging.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KItchenLib.Messaging;

public static class RegisterMessaging
{
    public static IServiceCollection AddKitchenMessaging(this IServiceCollection services)
    {
        services.AddSingleton<IListener, KitchenNewOrderListener>();
        services.AddSingleton<IListener, OrderDetailsListener>();
        return services;
    }
}
