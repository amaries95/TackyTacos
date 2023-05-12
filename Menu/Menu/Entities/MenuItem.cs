namespace Menu.Entities;

public partial class MenuItem
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int CategoryId { get; set; }

    public decimal Price { get; set; }

    public virtual MenuCategory Category { get; set; } = null!;

    public virtual ICollection<MenuItemModification> MenuItemModifications { get; set; } = new List<MenuItemModification>();
}
