using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Orders.Contracts;
using Orders.Models;
using Orders.Entities;

namespace Orders.Tests;
internal class OrderDbContextTests
{
    private OrdersDbContext _sut;
    private IMongoDatabase _database;
    private IMongoCollection<Order> _ordersCollection;
    private List<Order> _expectedOrders;
    private Order _order;
    [SetUp]
    public void Setup()
    {
        MongoDbSettings mongoDbSettings = new MongoDbSettings()
        {
            ConnectionString = "mongodb://user:password123@localhost:27017/",
            Database = "Test",
            OrdersCollectionName = "Orders"
        };
        var serviceProvider = new ServiceCollection()
    .AddLogging()
    .BuildServiceProvider();

        var factory = serviceProvider.GetService<ILoggerFactory>();

        var logger = factory.CreateLogger<OrdersDbContext>();
        var mongoClient = new MongoClient(mongoDbSettings.ConnectionString);
        _database = mongoClient.GetDatabase(mongoDbSettings.Database);
        _ordersCollection = _database.GetCollection<Order>(mongoDbSettings.OrdersCollectionName);
        _sut = new OrdersDbContext(logger, mongoClient, mongoDbSettings);

        var id = Guid.NewGuid();
        _order = new Order()
        {
            Id = id,
            CustomerName = "Test Name",
            CustomerEmail = "test@test.com",
            TotalPrice = 12.99M,
            OrderStatuses = new List<OrderStatusUpdate>() {
            new OrderStatusUpdate() {
                OrderId = id,
                Status = OrderStatus.Default,
                UpdatedTime = DateTime.UtcNow
            } },
            OrderItems = new() {
            new OrderItem() {
                Id = 1,
                Name = "beef taco",
                Price = 10.00M,
                Modifications = new() {
                    new() {
                        Id = 1,
                        Name = "lettuce",
                        Price = 0M
                },
                    new() {
                        Id = 1,
                        Name = "cheese",
                        Price = 2.99M
                    }
                }
            }

        }
        };

        _expectedOrders = new List<Order> { _order, new Order { Id = Guid.NewGuid() } };
    }

    [TearDown]
    public void Teardown()
    {
        _database.DropCollection("Orders");
    }


    [Test]
    public void OrdersDbContext_Orders_ReturnsListOfOrders()
    {

        _ordersCollection.InsertMany(_expectedOrders);
        // Act
        var actualOrders = _sut.Orders;

        actualOrders.Should().NotBeEmpty()
         .And.HaveCount(2);

        actualOrders.Should().BeEquivalentTo(_expectedOrders, options =>
        {
            options.Using<DateTime>(ctx => ctx.Subject.Should().BeCloseTo(ctx.Expectation, TimeSpan.FromMinutes(1))).WhenTypeIs<DateTime>();
            return options;
        });

    }

    [Test]
    public void OrdersDbContext_GetById_ReturnsOrderWithGivenId()
    {
        // Arrange
        var id = Guid.NewGuid();
        var expectedOrder = new Order { Id = id };
        _ordersCollection.InsertOne(expectedOrder);
        // Act
        var actualOrder = _sut.GetById(id);

        // Assert
        actualOrder.Should().BeEquivalentTo(expectedOrder);

    }

    [Test]
    public void OrdersDbContext_Create_ShouldAddOrder()
    {
        // Arrange
        var id = Guid.NewGuid();
        var actualOrder = new Order { Id = id };
        _ordersCollection.InsertOne(actualOrder);
        // Act
        _sut.Create(actualOrder);

        var expectedOrder = _ordersCollection.Find(d => d.Id == id).FirstOrDefault();
        // Assert
        actualOrder.Should().BeEquivalentTo(expectedOrder);

    }

    [Test]
    public void OrdersDbContext_Update_ShouldUpdateRecord()
    {
        // arrange
        _ordersCollection.InsertOne(_order);

        _order.CustomerName = "Updated Name";

        //act
        _sut.Update(_order);

        // assert
        var actualOrder = _ordersCollection.Find(d => d.Id == _order.Id).FirstOrDefault();

        actualOrder.Should().BeEquivalentTo(_order, options =>
        {
            options.Using<DateTime>(ctx => ctx.Subject.Should().BeCloseTo(ctx.Expectation, TimeSpan.FromMinutes(1))).WhenTypeIs<DateTime>();
            return options;
        });
    }
}