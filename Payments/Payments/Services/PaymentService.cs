using TackyTacos.Payments.Models;

namespace Payments.Services;
internal class PaymentService
{
    private readonly HttpClient _httpClient;
    public PaymentService(HttpClient client)
    {
        _httpClient = client ?? throw new ArgumentNullException(nameof(client));
    }

    internal async Task RequestPayment(OrderCheckout orderCheckout)
    {
        // make call to flaky API
        // update order status
    }
}
