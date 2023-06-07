using Microsoft.AspNetCore.Builder;
using Orders.Contracts.Dtos;
using Microsoft.AspNetCore.Mvc;

using TackyTacos.Orders.Services;
using Microsoft.AspNetCore.Http;

namespace Orders.Endpoints;

internal static class OrderEndpoints
{
    internal static void MapOrderEndpoints(this WebApplication app)
    {
        app.MapPost("/order", (OrderService orderService, [FromBody] OrderDto order) =>
        {
            IResult result;
            Guid orderId = orderService.CreateOrder(order);
            if (orderId != Guid.Empty)
            {
                result = TypedResults.Ok(orderId);
            }
            else
            {
                result = TypedResults.StatusCode(418);
            }

            return result;
        });
    }
}
