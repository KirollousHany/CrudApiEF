using CrudApiDemo.ViewModels;

namespace CrudApiDemo.Interfaces.IService
{
    public interface IOrderService
    {
        Task<bool> UpdateDate(int id, DateTime newDate);
        Task<List<Models.Order>?> GetOrdersByClientId(int clientId);
        Task<bool> UserExists(int userId);
        Task<OrderDetailsViewModel?> GetOrderDetails(int id);
    }
}
