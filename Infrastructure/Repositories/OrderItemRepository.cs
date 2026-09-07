using Application.Interfaces.IRepository;
using Domain.Entities;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class OrderItemRepository : IOrderItemRepository
    {
        private readonly AppDbContext context;

        public OrderItemRepository(AppDbContext _context)
        {
            context = _context;
        }

        public async Task<List<OrderItem>> GetAll()
        {
            return await context.OrderItems.Include(oi => oi.Product).ToListAsync();
        }

        public async Task<OrderItem?> GetByCompositeKey(int orderId, int productId)
        {
            return await context.OrderItems
                .Include(oi => oi.Product)
                .FirstOrDefaultAsync(oi => oi.OrderId == orderId && oi.ProductId == productId);
        }

        public async Task<List<OrderItem>> GetByOrderId(int orderId)
        {
            return await context.OrderItems
                .Include(oi => oi.Product)
                .Where(oi => oi.OrderId == orderId)
                .ToListAsync();
        }

        public async Task<bool> Add(OrderItem item)
        {
            try
            {
                context.OrderItems.Add(item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(OrderItem item)
        {
            try
            {
                context.OrderItems.Remove(item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateQuantity(OrderItem item, int newQuantity)
        {
            item.Quantity = newQuantity;
            return true;
        }
    }
}
