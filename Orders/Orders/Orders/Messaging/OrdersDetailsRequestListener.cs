using Messaging.Contracts;
using Newtonsoft.Json;
using Payments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TackyTacos.Orders.Services;

namespace Orders.Messaging
{
    internal class OrdersDetailsRequestListener : IListener
    {
        private readonly string _routingKey = RoutingKeys.OrderDetailsRequest;
        private readonly OrderService _orderService;

        public OrdersDetailsRequestListener(OrderService orderService)
        {    
            _orderService = orderService;
        }

        public string RoutingKey { get => _routingKey; }

        public Task ProcessMessage(string message, string routingkey)
        {
            //implementation
            PaymentResponse paymentResponse = JsonConvert.DeserializeObject<PaymentResponse>(message);
            _orderService.GetOrderDetailsOrderId(Guid.Parse(paymentResponse?.OrderId));

            return Task.CompletedTask;
        }
    }
}
