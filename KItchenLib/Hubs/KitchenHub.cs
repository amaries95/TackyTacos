using Kitchen.Contracts.Dtos;
using KItchenLib.Services;
using Microsoft.AspNetCore.SignalR;
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
    public async Task UpdateOrder(KitchenOrderDto order)
    {
        _listener.OrderUpdated(order);
    }

    public async Task SendMessage(KitchenOrderDto order)
    {
        await _context.Clients.All.SendAsync("OrderReceived", order);
    }
}
