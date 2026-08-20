using CrudApiDemo.Data;
using CrudApiDemo.Interfaces.IRepository;
using CrudApiDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApiDemo.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly AppDbContext context;

        public OrderItemRepository(AppDbContext _context)
        {
            context = _context;
        }

        public List<OrderItem> GetAll()
        {
            return context.OrderItems
                .Include(oi => oi.Product)
                .ToList();
        }

        public OrderItem? GetByCompositeKey(int orderId, int productId)
        {
            return context.OrderItems
                .Include(oi => oi.Product)
                .FirstOrDefault(oi => oi.OrderId == orderId && oi.ProductId == productId);
        }

        public bool Add(OrderItem item)
        {
            try
            {
                context.OrderItems.Add(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(OrderItem item)
        {
            try
            {
                context.OrderItems.Remove(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateQuantity(OrderItem item, int newQuantity)
        {
            try
            {
                item.Quantity = newQuantity;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<OrderItem> GetByOrderId(int orderId)
        {
            return context.OrderItems
                .Include(oi => oi.Product)
                .Where(oi => oi.OrderId == orderId)
                .ToList();
        }
    }
}
