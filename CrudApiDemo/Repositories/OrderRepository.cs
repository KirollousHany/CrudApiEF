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

        public List<Order> GetAll()
        {
            return context.Orders.Include(o => o.Client).Include(o => o.OrderItems).ThenInclude(oi => oi.Product).ToList();
        }

        public Order? GetById(int id)
        {
            return context.Orders.Include(o => o.Client).Include(o => o.OrderItems).ThenInclude(oi => oi.Product).FirstOrDefault(o => o.Id == id);
        }

        public List<Order> GetOrdersByClientId(int clientId)
        {
            return context.Orders
                .Where(o => o.ClientId == clientId)
                .Include(o => o.Client)
                .Include(o => o.OrderItems)
                    .ThenInclude(oi => oi.Product)
                .ToList();
        }

        public bool Add(Order item)
        {
            try
            {
                context.Orders.Add(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Order item)
        {
            try
            {
                context.Orders.Remove(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateDate(Order order, DateTime newDate)
        {
            try
            {
                order.Date = newDate;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
