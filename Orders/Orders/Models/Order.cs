
namespace TackyTacos.Orders.Models;

internal class Order{
	internal Guid Id { get; set; }
	internal Guid UserId { get; set; }
	internal DateTime CreatedTime { get; set; }
	internal decimal TotalPrice { get; set; }
    internal bool OrderPaid { get; set; }    
}
