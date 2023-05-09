using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Orders.Entities;

namespace Orders.Data;

internal class OrdersDbContext
{
    private readonly ILogger<OrdersDbContext> _logger;
    private readonly IMongoDatabase _database = null;
    private readonly MongoDbSettings _settings;

    private IMongoCollection<Order> _ordersCollection => _database.GetCollection<Order>(_settings.OrdersCollectionName);

    public OrdersDbContext(ILogger<OrdersDbContext> logger, IMongoClient mongoClient, MongoDbSettings settings)
    {
        _logger = logger;
        _settings = settings;
        _database = mongoClient.GetDatabase(_settings.Database);
    }

    internal List<Order> Orders => _ordersCollection.Find(o => true).ToList();

    internal Order GetById(Guid id)
    {
        Order order = new Order();

        try
        {
            order = _ordersCollection.Find(d => d.Id == id).FirstOrDefault();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return order;
    }

    internal bool Create(Order order)
    {
        bool IsSuccessful = false;

        try
        {
            _ordersCollection.InsertOne(order);
            _logger.LogInformation("Record inserted");
            IsSuccessful = true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return IsSuccessful;
    }

    internal bool Update(Order updatedOrder)
    {
        bool IsSuccessful = false;

        try
        {
            _ordersCollection.ReplaceOne(order => order.Id == updatedOrder.Id, updatedOrder);
            _logger.LogInformation("Record updated");
            IsSuccessful = true;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }
        return IsSuccessful;
    }

}
