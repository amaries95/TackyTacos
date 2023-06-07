using Kitchen.Contracts.Dtos;
using Messaging.Contracts;
using Orders.Contracts.Dtos;
using Orders.Data;
using Orders.Entities;

namespace TackyTacos.Orders.Services;

internal class OrderService
{
    private readonly OrdersDbContext _dbcontext;
    private readonly IRabbitSender _rabbitSender;
    public OrderService(OrdersDbContext dbcontext, IRabbitSender rabbitSender)
    {
        _dbcontext = dbcontext;
        _rabbitSender = rabbitSender;
    }

    internal List<OrderDto> GetAllOrders()
    {
        return _dbcontext.Orders.Select(ord => new OrderDto().MapOrder(ord)).ToList();
    }

    internal OrderDto GetOrderByOrderId(Guid id)
    {
        return new OrderDto().MapOrder(_dbcontext.GetById(id));
    }

    internal Guid CreateOrder(OrderDto order)
    {
        return _dbcontext.Create(new Order().MapOrderDto(order));
    }
    internal void UpdateOrderPaymentStatus(OrderDto order)
    {
        throw new NotImplementedException();
    }

    internal void GetOrderDetailsOrderId(Guid id)
    {
        var order = GetOrderByOrderId(id);
        var kitchenOrder = new KitchenOrderDto().MapOrderDto(order);
        _rabbitSender.PublishMessage(kitchenOrder, RoutingKeys.OrderDetailsResponse);
    }
}
