using CrudApiDemo.Data;
using CrudApiDemo.Interfaces.IRepository;
using CrudApiDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApiDemo.Repositories
{
    public class OrderRepository : ICrudRepository<Order>, IOrderRepository
    {
        private readonly AppDbContext context;

        public OrderRepository(AppDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Order>> GetAll()
        {
            return await context.Orders.Include(o => o.Client).Include(o => o.OrderItems).ThenInclude(oi => oi.Product).ToListAsync();
        }

        public async Task<Order?> GetById(int id)
        {
            return await context.Orders.Include(o => o.Client).Include(o => o.OrderItems).ThenInclude(oi => oi.Product).FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<Order>> GetOrdersByClientId(int clientId)
        {
            return await context.Orders
                .Where(o => o.ClientId == clientId)
                .Include(o => o.Client)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .ToListAsync();
        }

        public async Task<bool> Add(Order item)
        {
            try
            {
                context.Orders.Add(item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(Order item)
        {
            try
            {
                context.Orders.Remove(item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateDate(Order order, DateTime newDate)
        {
            order.Date = newDate;
            return true;
        }

        public async Task<bool> OrderExists(int orderId)
        {
            return await context.Orders.AnyAsync(o => o.Id == orderId);
        }

    }
}
