namespace Orders.Entities;
public class OrderItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public List<OrderItem> Modifications { get; set; } = new();
}