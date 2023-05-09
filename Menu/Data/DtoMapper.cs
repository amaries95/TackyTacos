using Menu.Entities;

namespace Menu.Data;

internal static class DtoMapper
{
    internal static MenuItemDto MapMenuItem(this MenuItemDto dto, MenuItem menuItem, List<MenuModification> mods)
    {

        dto.Id = menuItem.Id;
        dto.Name = menuItem.Name;
        dto.Description = menuItem.Description;
        dto.Category = menuItem.Category.Name;
        dto.Price = menuItem.Price;
        dto.MenuModifications = mods
            .Select(mod => new MenuModificationDto().MapMenuModification(mod)).ToList();

        return dto;
    }

    internal static MenuModificationDto MapMenuModification(this MenuModificationDto dto, MenuModification menuMod)
    {
        dto.Id = menuMod.Id;
        dto.Name = menuMod.Name;
        dto.Description = menuMod.Description;
        dto.Price = menuMod.Price;

        return dto;
    }
}
