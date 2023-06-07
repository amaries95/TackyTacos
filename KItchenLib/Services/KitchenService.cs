using Kitchen.Contracts.Dtos;
using KItchenLib.Hubs;
using Messaging.Contracts;
using Payments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KItchenLib.Services;

internal class KitchenService
{
    private readonly KitchenHub _hub;
    private readonly IRabbitSender _rabbitSender;

    public KitchenService(KitchenHub hub, IRabbitSender rabbitSender)
    {
        _hub = hub;
        _rabbitSender = rabbitSender;
    }
    internal async Task OrderReceived(KitchenOrderDto order)
    {
        Console.WriteLine($"Order: {order.Id} received");
        await _hub.SendMessage(order);
    }

    internal void RequestOrderDetails(PaymentResponse orderId)
    {
        _rabbitSender.PublishMessage(orderId, RoutingKeys.OrderDetailsRequest);
    }
}
