namespace Orders.Contracts.Dtos;
public class OrderStatusUpdateDto
{
    public OrderStatus Status { get; set; }
    public DateTime UpdatedTime { get; set; }
}