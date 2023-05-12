namespace Menu.Entities;

public partial class MenuItemModification
{
    public int Id { get; set; }

    public int MenuItemId { get; set; }

    public int MenuModificationId { get; set; }

    public virtual MenuItem MenuItem { get; set; } = null!;

    public virtual MenuModification MenuModification { get; set; } = null!;
}
