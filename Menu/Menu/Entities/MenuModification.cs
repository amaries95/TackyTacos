namespace Menu.Entities;

public partial class MenuModification
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public virtual ICollection<MenuItemModification> MenuItemModifications { get; set; } = new List<MenuItemModification>();
}
