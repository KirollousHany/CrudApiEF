using Application.ViewModels;
using Domain.Entities;


namespace Application.Interfaces.IService
{
    public interface IOrderService
    {
        Task<bool> UpdateDate(int id, DateTime newDate);
        Task<List<Order>?> GetOrdersByClientId(int clientId);
        Task<bool> UserExists(int userId);
        Task<OrderDetailsViewModel?> GetOrderDetails(int id);
    }
}
