using Kitchen.Contracts.Dtos;
using KItchenLib.Services;
using Messaging.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace KItchenLib.Messaging
{
    internal class OrderDetailsListener : IListener
    {
        private readonly KitchenService _kitchenService;
        private readonly string _routingKey = RoutingKeys.OrderDetailsResponse;

        public OrderDetailsListener(KitchenService kitchenService)
        {
            _kitchenService = kitchenService;
        }
        public string RoutingKey { get => _routingKey; }

        public async Task ProcessMessage(string message, string routingKey)
        {
            var kitchenOrderDto = JsonSerializer.Deserialize<KitchenOrderDto>(message);
            await _kitchenService.OrderReceived(kitchenOrderDto);
        }
    }
}
