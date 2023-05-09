using Orders.Contracts.Dtos;
using Orders.Data;
using Orders.Entities;

namespace TackyTacos.Orders.Services;

internal class OrderService
{
    private readonly OrdersDbContext _dbcontext;
    public OrderService(OrdersDbContext dbcontext)
    {
        _dbcontext = dbcontext;

    }

    internal List<OrderDto> GetAllOrders()
    {
        return _dbcontext.Orders.Select(ord => new OrderDto().MapOrder(ord)).ToList();
    }

    internal OrderDto GetOrderByOrderId(Guid id)
    {
        return new OrderDto().MapOrder(_dbcontext.GetById(id));
    }

    internal bool CreateOrder(OrderDto order)
    {
        return _dbcontext.Create(new Order().MapOrderDto(order));
    }
    internal void UpdateOrderPaymentStatus(OrderDto order)
    {
        throw new NotImplementedException();
    }
}
