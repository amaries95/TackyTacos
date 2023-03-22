namespace Orders.Models;
internal class OrderStatusUpdate
{
    internal OrderStatus Status { get; set; }
    internal DateTime UpdatedTime { get; set; }
    internal Guid OrderId { get; set; }
}
