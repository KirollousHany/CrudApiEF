using CrudApiDemo.Interfaces.IRepository;
using CrudApiDemo.Interfaces.IService;
using CrudApiDemo.Models;

namespace CrudApiDemo.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IOrderItemRepository repo;
        private readonly ICrudRepository<Order> orderRepo;
        private readonly ICrudRepository<Product> productRepo;

        public OrderItemService(IOrderItemRepository _repo, ICrudRepository<Order> _orderRepo, ICrudRepository<Product> _productRepo)
        {
            repo = _repo;
            orderRepo = _orderRepo;
            productRepo = _productRepo;
        }

        public List<OrderItem> GetAll()
        {
            return repo.GetAll();
        }

        public OrderItem? GetByCompositeKey(int orderId, int productId)
        {
            return repo.GetByCompositeKey(orderId, productId);
        }

        public bool Add(OrderItem item)
        {
            if (!OrderExists(item.OrderId) || !ProductExists(item.ProductId)) return false;

            var alreadyExists = repo.GetByCompositeKey(item.OrderId, item.ProductId);
            if (alreadyExists != null)
            {
                return repo.UpdateQuantity(alreadyExists, alreadyExists.Quantity + item.Quantity);
            }
            return repo.Add(item);
        }

        public bool Delete(int orderId, int productId)
        {
            var existing = repo.GetByCompositeKey(orderId, productId);
            if (existing == null) return false;
            return repo.Delete(existing);
        }

        public bool UpdateQuantity(int orderId, int productId, int newQuantity)
        {
            var existing = repo.GetByCompositeKey(orderId, productId);
            if (existing == null) return false;
            return repo.UpdateQuantity(existing, newQuantity);
        }
        public bool OrderExists(int orderId)
        {
            return orderRepo.GetById(orderId) != null;
        }
        public bool ProductExists(int productId)
        {
            return productRepo.GetById(productId) != null;
        }
        public List<OrderItem> GetByOrderId(int orderId)
        {
            return repo.GetByOrderId(orderId);
        }
    }
}
