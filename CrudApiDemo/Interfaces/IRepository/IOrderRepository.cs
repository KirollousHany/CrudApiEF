using CrudApiDemo.Models;

namespace CrudApiDemo.Interfaces.IRepository
{
    public interface IOrderRepository
    {
        Task<bool> UpdateDate(Order order, DateTime newDate);
        Task<List<Order>> GetOrdersByClientId(int clientId);
        Task<bool> OrderExists(int orderId);
    }
}
