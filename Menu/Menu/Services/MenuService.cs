using Menu.Data;
using Microsoft.EntityFrameworkCore;

namespace Menu.Services;

internal class MenuService
{
    private readonly MenuRepository _menuRepository;

    public MenuService(MenuRepository menuRepository)
    {
        _menuRepository = menuRepository;
    }

    internal List<MenuItemDto> GetAllMenuItems()
    {
        var menuItemsQuery = _menuRepository.GetAllMenuItems()
                  .Include(mi => mi.Category)
                  .Include(mi => mi.MenuItemModifications)
                  .ThenInclude(m => m.MenuModification);

        return menuItemsQuery
                  .Select(item =>
                  new MenuItemDto().MapMenuItem(item, item.MenuItemModifications.Select(m => m.MenuModification).ToList())).ToList();
    }
}
