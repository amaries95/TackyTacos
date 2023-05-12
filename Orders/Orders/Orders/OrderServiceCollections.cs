using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using Orders.Contracts;
using Orders.Data;
using System.Text.Json.Serialization;
using System.Text.Json;
using TackyTacos.Orders.Services;

namespace Orders;

public static class OrderServiceCollections
{
    public static IServiceCollection AddOrders(this IServiceCollection services, IConfiguration config)
    {
        var configSection = config.GetSection("MongoDB");
        var mongoDbSettings = new MongoDbSettings();
        configSection.Bind(mongoDbSettings);

        services.AddSingleton<MongoDbSettings>(mongoDbSettings);
        services.AddLogging();
        services.AddSingleton<IMongoClient>(new MongoClient(mongoDbSettings.ConnectionString));
        services.AddSingleton<OrderService>();
        services.AddSingleton<OrdersDbContext>();

        services.AddSingleton(sp => new JsonSerializerOptions
        {
            Converters =
            {
                new EnumConvertor<OrderStatus>()
            },
            ReferenceHandler = ReferenceHandler.IgnoreCycles
        });

        return services;
    }
}
