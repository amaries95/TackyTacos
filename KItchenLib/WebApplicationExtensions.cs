using Kitchen.Contracts.Dtos;
using KItchenLib.Hubs;
using KItchenLib.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KItchenLib;

public static class WebApplicationExtensions
{
    public static WebApplication AddKitchenApp(this WebApplication app)
    {
        app.UseResponseCompression();
        app.MapHub<KitchenHub>("/kitchenhub");

        var connection = new HubConnectionBuilder().WithUrl("https://localhost:7116/kitchenhub").Build();
        var kitchenListener = app.Services.GetRequiredService<KitchenListener>();
        var kitchenService = app.Services.GetRequiredService<KitchenService>();

        connection.On<KitchenOrderDto>("UpdateOrder", (order) =>
        {
            kitchenListener.OrderUpdated(order);
        });

        connection.On<KitchenOrderDto>("OrderReceived", async (order) =>
        {
            await kitchenService.OrderReceived(order);
        });

        return app;
    }
}
