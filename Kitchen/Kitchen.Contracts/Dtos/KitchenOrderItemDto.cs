namespace Kitchen.Contracts.Dtos;
public class KitchenOrderItemDto
{
	public string Name { get; set; }
	public List<KitchenOrderItemDto> Modifications { get; set; } = new();
}

