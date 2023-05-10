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
            bool isSuccess = orderService.CreateOrder(order);
            if (isSuccess)
            {
                result = TypedResults.Ok(200);
            }
            else
            {
                result = TypedResults.StatusCode(418);
            }

            return result;
        });
    }
}
