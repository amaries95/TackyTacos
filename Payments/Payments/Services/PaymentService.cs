using Payments.Data;
using Payments.Contracts.Models;
using System.Text.Json;
using Payments.Models;
using Messaging.Contracts;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace Payments.Services;
internal class PaymentService
{
    private readonly HttpClient _httpClient;
    private readonly TableDbContext _context;
    private readonly IRabbitSender _rabbitSender;

    public PaymentService(HttpClient client, TableDbContext dbContext, IRabbitSender rabbitSender)
    {
        _httpClient = client ?? throw new ArgumentNullException(nameof(client));
        _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        _rabbitSender = rabbitSender ?? throw new ArgumentNullException(nameof(rabbitSender));
    }

    internal async Task RequestPayment(OrderCheckoutDto orderCheckout)
    {
        // make call to flaky API

        _httpClient.BaseAddress = new Uri("https://localhost:5091");
        string json = JsonConvert.SerializeObject(orderCheckout);
        StringContent httpContent = new(json, System.Text.Encoding.UTF8, "application/json");
        HttpResponseMessage resp = await _httpClient.PostAsync("/payme", httpContent);

        if (resp.IsSuccessStatusCode)
        {
            var content = await resp.Content.ReadAsStringAsync();
            PaymentResponse paymentResponse = JsonConvert.DeserializeObject<PaymentResponse>(content);

            _rabbitSender.PublishMessage(paymentResponse, RoutingKeys.OrderUpdatePaid);
        }
    }

    internal async Task<Payment> CreatePaymentRecord(PaymentResponse response)
    {
        Payment result = new();
        Payment payment = new()
        {
            RowKey = response.OrderId,
            Authorisation = response.AuthNumber,
            IsSuccessful = string.IsNullOrEmpty(response.AuthNumber),
        };
        try
        {
            result = await _context.InsertOrMergeEntityAsync(payment);

        }
        catch (Exception ex)
        {

        }
        return result;
    }

    internal async Task<Payment> GetPaymentByID(Payment payment)
    {
        return await _context.GetEntityAsync(payment);
    }

}
