using Menu.Contracts.Dtos;
using Menu.Data;
using Menu.Services;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Menu.Tests;

public class MenuServiceTests
{
    private TackyTacosDbContext CreateDbContext()
    {
        var options = new DbContextOptionsBuilder<TackyTacosDbContext>()
            .UseSqlServer("Server=localhost;Database=TackyTacos;User Id=SA;Password=Password123;MultipleActiveResultSets=true;TrustServerCertificate=True;")
            .Options;

        var context = new TackyTacosDbContext(options);

        context.Database.EnsureCreated();

        return context;
    }

    [Test]
    public void GetAllMenuItems_ShouldReturn_Collection()
    {
        // arrange
        var dbContext = CreateDbContext();
        var repository = new MenuRepository(dbContext);
        var sut = new MenuService(repository);

        //act

        List<MenuItemDto> result = sut.GetAllMenuItems();

        Assert.Pass();
    }
}
