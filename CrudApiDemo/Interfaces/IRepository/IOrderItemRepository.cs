using CrudApiDemo.Models;

namespace CrudApiDemo.Interfaces.IRepository
{
    public interface IOrderItemRepository
    {
        Task<List<OrderItem>> GetAll();
        Task<OrderItem?> GetByCompositeKey(int orderId, int productId);
        Task<List<OrderItem>> GetByOrderId(int orderId);
        Task<bool> Add(OrderItem item);
        Task<bool> Delete(OrderItem item);
        Task<bool> UpdateQuantity(OrderItem item, int newQuantity);
    }
}
