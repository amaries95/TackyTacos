namespace Orders.Contracts.Dtos;

public class OrderDto
{
    public Guid Id { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public decimal TotalPrice { get; set; }
    public List<OrderStatusUpdateDto> OrderStatuses { get; set; }
    public List<OrderItemDto> OrderItems { get; set; } = new();
}