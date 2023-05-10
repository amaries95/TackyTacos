using Menu.Services;
using Microsoft.AspNetCore.Builder;

namespace Menu.Endpoints;

internal static class Endpoints
{
    internal static void MapMenuEndpoints(this WebApplication app)
    {
        app.MapGet("/menu", (MenuService menuService) =>
        {
            return menuService.GetAllMenuItems();
        });
    }
}
