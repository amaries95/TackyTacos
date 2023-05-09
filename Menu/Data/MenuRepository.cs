using Menu.Entities;

namespace Menu.Data;

internal class MenuRepository
{
    private readonly TackyTacosDbContext _dbContext;

    public MenuRepository(TackyTacosDbContext tackyTacosDbContext)
    {
        _dbContext = tackyTacosDbContext;
    }

    internal IQueryable<MenuItem> GetAllMenuItems()
    {
        return _dbContext.MenuItems.AsQueryable();
    }
}
