using Payments.Data;
using Payments.Contracts.Models;
using System.Text.Json;
using Payments.Models;

namespace Payments.Services;
internal class PaymentService
{
    private readonly HttpClient _httpClient;
    private readonly TableDbContext _context;
    internal PaymentService(HttpClient client, TableDbContext dbContext)
    {
        _httpClient = client ?? throw new ArgumentNullException(nameof(client));
        _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
    }

    internal async Task RequestPayment(OrderCheckoutDto orderCheckout)
    {
        // make call to flaky API

        _httpClient.BaseAddress = new Uri("https://localhost:5091");
        string json = JsonSerializer.Serialize(orderCheckout);
        StringContent httpContent = new(json, System.Text.Encoding.UTF8, "application/json");
        HttpResponseMessage resp = await _httpClient.PostAsync("/payme", httpContent);
        string content = await resp.Content.ReadAsStringAsync();

        PaymentResponse paymentResponse = JsonSerializer.Deserialize<PaymentResponse>(content);
        var paymentResult = await CreatePaymentRecord(paymentResponse);


        // update order status

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
