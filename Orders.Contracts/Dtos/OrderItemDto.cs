namespace Orders.Contracts.Dtos;
public class OrderItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public List<OrderItemDto> Modifications { get; set; } = new();
}