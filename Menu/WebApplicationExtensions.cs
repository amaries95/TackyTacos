using Menu.Endpoints;
using Microsoft.AspNetCore.Builder;

namespace Menu;

public static class WebApplicationExtensions
{
    public static WebApplication AddMenuEndpoints(this WebApplication app)
    {
        app.MapMenuEndpoints();
        return app;
    }
}
