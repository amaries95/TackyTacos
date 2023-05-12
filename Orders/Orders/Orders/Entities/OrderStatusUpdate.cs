using Orders.Contracts;

namespace Orders.Models;
public class OrderStatusUpdate
{
    internal OrderStatus Status { get; set; }
    internal DateTime UpdatedTime { get; set; }
    internal Guid OrderId { get; set; }
}
