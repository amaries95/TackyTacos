using Messaging.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Orders.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KItchenLib.Messaging;

public static class RegisterMessaging
{
    public static IServiceCollection AddOrderMessaging(this IServiceCollection services)
    {
        services.AddSingleton<IListener, OrdersDetailsRequestListener>();
        return services;
    }
}
