using TackyTacos.Orders.Models;

namespace TackyTacos.Orders.Services;

internal class OrderService
{
    internal async Task<IEnumerable<Order>> GetAllOrdersAsync()
    {
        throw new NotImplementedException();
    }

    internal async Task<Order> GetOrderByOrderIdAsync()
    {
        throw new NotImplementedException();
    }

    internal async Task CreateOrderAsync(Order order)
	{
        throw new NotImplementedException();
    }

    internal async Task UpdateOrderPaymentStatusAsync(Order order)
	{
        throw new NotImplementedException();
    }
}
