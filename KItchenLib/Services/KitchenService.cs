using Kitchen.Contracts.Dtos;
using KItchenLib.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KItchenLib.Services;

internal class KitchenService
{
    private readonly KitchenHub _hub;
    public KitchenService(KitchenHub hub)
    {
        _hub = hub;
    }
    internal async Task OrderReceived(KitchenOrderDto order)
    {
        Console.WriteLine($"Order: {order.Id} received");
        await _hub.SendMessage(order);
    }
}
