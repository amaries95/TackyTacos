using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Orders.Models;

namespace Orders.Entities;

public class Order
{
    [BsonId]
    [BsonRepresentation(BsonType.String)]
    public Guid Id { get; set; }
    public string CustomerName { get; set; }
    public string CustomerEmail { get; set; }
    public decimal TotalPrice { get; set; }
    public List<OrderStatusUpdate> OrderStatuses { get; set; }
    public List<OrderItem> OrderItems { get; set; } = new();
}