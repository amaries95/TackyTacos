using KItchenLib.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KItchenLib.Services;

internal class KitchenSender
{
    private readonly KitchenHub _hub;
    public KitchenSender(KitchenHub hub)
    {
        _hub = hub;
    }
    //internal async Task OnOrderPlaced(KitchenOrderDto order)
    //{
    //    Console.WriteLine($"Order: {order.Id} received");
    //    await _hub.OrderReceived(order);
    //}
}
