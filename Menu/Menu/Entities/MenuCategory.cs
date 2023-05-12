namespace Menu.Entities;

public partial class MenuCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<MenuItem> MenuItems { get; set; } = new List<MenuItem>();
}
