using KItchenLib.Services;
using Messaging.Contracts;
using Newtonsoft.Json;
using Payments.Models;

namespace KItchenLib.Messaging
{
    internal class KitchenNewOrderListener : IListener
    {
        private readonly KitchenService _kitchenService;
        private readonly string _routingKey = RoutingKeys.OrderUpdatePaid;
        public KitchenNewOrderListener(KitchenService kitchenService)
        {
            _kitchenService = kitchenService;
        }

        public string RoutingKey { get => _routingKey; }

        public Task ProcessMessage(string message, string routingKey)
        {
            PaymentResponse paymentResponse = JsonConvert.DeserializeObject<PaymentResponse>(message);

            _kitchenService.RequestOrderDetails(paymentResponse);
            return Task.CompletedTask;
        }
    }
}
