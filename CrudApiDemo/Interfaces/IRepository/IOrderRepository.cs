using CrudApiDemo.Models;

namespace CrudApiDemo.Interfaces.IRepository
{
    public interface IOrderRepository
    {
        bool UpdateDate(Order order, DateTime newDate);
        List<Order> GetOrdersByClientId(int clientId);
    }
}
