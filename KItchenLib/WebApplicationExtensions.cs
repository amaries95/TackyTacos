using KItchenLib.Hubs;
using KItchenLib.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace KItchenLib;

public static class WebApplicationExtensions
{
    public static WebApplication AddKitchenApp(this WebApplication app)
    {
        app.UseResponseCompression();
        app.MapHub<KitchenHub>("/kitchenhub");


        var kitchenListener = app.Services.GetRequiredService<KitchenListener>();
        var kitchenService = app.Services.GetRequiredService<KitchenSender>();

        return app;
    }
}
