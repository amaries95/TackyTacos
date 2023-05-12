
namespace Kitchen.Contracts.Dtos;

public class KitchenOrderDto
{
	public Guid Id { get; set; }
	public List<KitchenOrderStatusUpdateDto> OrderStatuses { get; set; } = new();
    public List<KitchenOrderItemDto> OrderItems { get; set; } = new();
}
