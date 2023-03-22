
using TackyTacos.Orders.Models;

namespace TackyTacos.Orders.Data;
internal class OrdersRepository
{

    internal async Task<Order> AddOrUpdateAsync(Order order)
    {
        throw new NotImplementedException();
    }

    internal async Task<Order> ReplaceOrderItemAsync(Order order)
    {
        throw new NotImplementedException();
    }

    internal async Task<Order> GetByIdAsync(Order order)
    {
        throw new NotImplementedException();
    }


    internal async Task<List<Order>> GetAllByIdAsync(string id, bool excludePaid = false)
    {
        throw new NotImplementedException();
    }

    internal async Task<List<Order>> GetAllNotPaidAsync()
    {
        throw new NotImplementedException();
    }


    internal async Task DeleteOrderItemAsync(Order order)
    {
        throw new NotImplementedException();
    }

}