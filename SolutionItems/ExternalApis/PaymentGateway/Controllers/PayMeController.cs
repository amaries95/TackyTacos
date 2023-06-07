using Microsoft.AspNetCore.Mvc;
using Payments.Contracts.Models;
using System;

namespace PaymentGateway.Controllers;

[ApiController]
[Route("payme")]
public class PayMeController : Controller
{
	[HttpPost]
	public IActionResult Post([FromBody] OrderCheckoutDto orderCheckout)
	{
		var paymentResponse = new PaymentResponse
		{
			OrderId = orderCheckout.Id.ToString(),
			AmountRequested = orderCheckout.TotalAmount,
			AuthNumber = "Auth-TRUE",
		};

		return Ok(paymentResponse);
	}
}