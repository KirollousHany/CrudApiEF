using CrudApiDemo.Models;

namespace CrudApiDemo.Interfaces.IService
{
    public interface IOrderItemService
    {
        Task<List<OrderItem>> GetAll();
        Task<OrderItem?> GetByCompositeKey(int orderId, int productId);
        Task<bool> Add(OrderItem item);
        Task<bool> Delete(int orderId, int productId);
        Task<bool> UpdateQuantity(int orderId, int productId, int newQuantity);
        Task<List<OrderItem>> GetByOrderId(int orderId);

    }
}
