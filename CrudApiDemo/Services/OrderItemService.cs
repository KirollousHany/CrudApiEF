using CrudApiDemo.Interfaces.IRepository;
using CrudApiDemo.Interfaces.IService;
using CrudApiDemo.Models;

namespace CrudApiDemo.Services
{
    public class OrderItemService : IOrderItemService
    {
        private readonly IUnitOfWork _uow;

        public OrderItemService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<OrderItem>> GetAll()
        {
            return await _uow.OrderItemRepo.GetAll();
        }

        public async Task<OrderItem?> GetByCompositeKey(int orderId, int productId)
        {
            return await _uow.OrderItemRepo.GetByCompositeKey(orderId, productId);
        }

        public async Task<List<OrderItem>> GetByOrderId(int orderId)
        {
            return await _uow.OrderItemRepo.GetByOrderId(orderId);
        }

        public async Task<bool> Add(OrderItem item)
        {
            var existing = await _uow.OrderItemRepo.GetByCompositeKey(item.OrderId, item.ProductId);

            if (existing != null)
            {
                await _uow.OrderItemRepo.UpdateQuantity(existing, existing.Quantity + item.Quantity);
            }
            else
            {
                await _uow.OrderItemRepo.Add(item);
            }

            try
            {
                await _uow.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int orderId, int productId)
        {
            var existing = await _uow.OrderItemRepo.GetByCompositeKey(orderId, productId);
            if (existing == null) return false;

            if (!await _uow.OrderItemRepo.Delete(existing)) return false;

            try
            {
                await _uow.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateQuantity(int orderId, int productId, int newQuantity)
        {
            var existing = await _uow.OrderItemRepo.GetByCompositeKey(orderId, productId);
            if (existing == null) return false;

            await _uow.OrderItemRepo.UpdateQuantity(existing, newQuantity);

            try
            {
                await _uow.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
