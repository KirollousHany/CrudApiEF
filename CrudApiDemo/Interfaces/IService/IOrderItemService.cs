using CrudApiDemo.Models;

namespace CrudApiDemo.Interfaces.IService
{
    public interface IOrderItemService
    {
        List<OrderItem> GetAll();
        OrderItem? GetByCompositeKey(int orderId, int productId);
        bool Add(OrderItem item);
        bool Delete(int orderId, int productId);
        bool UpdateQuantity(int orderId, int productId, int newQuantity);
        public bool OrderExists(int orderId);
        public bool ProductExists(int productId);
        List<OrderItem> GetByOrderId(int orderId);

    }
}
