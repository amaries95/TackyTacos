using Microsoft.AspNetCore.Builder;
using Orders.Endpoints;

namespace Orders;

public static class WebApplicationExtensions
{
    public static WebApplication AddOrderEndpoints(this WebApplication app)
    {
        app.MapOrderEndpoints();
        return app;
    }
}
