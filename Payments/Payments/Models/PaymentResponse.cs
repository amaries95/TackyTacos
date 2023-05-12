namespace Payments.Models;
internal class PaymentResponse
{
    public string OrderId { get; set; }
    public string AuthNumber { get; set; } = null;
    public decimal AmountRequested { get; set; }
}