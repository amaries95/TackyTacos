using KItchenLib.Services;
using Microsoft.AspNetCore.SignalR;
using Orders.Contracts.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KItchenLib.Hubs;

internal class KitchenHub : Hub
{
    private readonly KitchenListener _listener;
    private readonly IHubContext<KitchenHub> _context;

    public KitchenHub(KitchenListener listener, IHubContext<KitchenHub> context)
    {
        _listener = listener;
        _context = context;
    }
    public async Task UpdateOrder(OrderDto order)
    {
        
        _listener.OrderUpdated(order);
    }

    public async Task OrderPlaced(OrderDto orderDto)
    {
        await _context.Clients.All.SendAsync("OrderReceived", orderDto);
    }
}
