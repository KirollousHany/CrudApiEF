using CrudApiDemo.Models;

namespace CrudApiDemo.Interfaces.IRepository
{
    public interface IOrderItemRepository
    {
        OrderItem? GetByCompositeKey(int orderId, int productId);
        List<OrderItem> GetAll();
        bool Add(OrderItem item);
        bool Delete(OrderItem item);
        bool UpdateQuantity(OrderItem item, int newQuantity);
        List<OrderItem> GetByOrderId(int orderId);
    }
}
