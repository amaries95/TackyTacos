using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Payments.Contracts.Models;
using Payments.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Payments.Endpoints;

internal static class PaymentEndpoints
{
    internal static void MapPaymentEndpoints(this WebApplication app)
    {
        app.MapPost("/payment", async (PaymentService paymentService, [FromBody] OrderCheckoutDto orderCheckout) =>
        {
            await paymentService.RequestPayment(orderCheckout);
            return HttpStatusCode.OK;
        });
    }
}
