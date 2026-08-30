using CrudApiDemo.Data;
using CrudApiDemo.Interfaces.IRepository;
using CrudApiDemo.Models;

namespace CrudApiDemo.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICrudRepository<Client> ClientCrudRepo { get; }

        public ICrudRepository<Product> ProductCrudRepo { get; }

        public ICrudRepository<Order> OrderCrudRepo { get; }

        public IClientRepository ClientRepo { get; }

        public IProductRepository ProductRepo { get; }

        public IOrderRepository OrderRepo { get; }

        public IOrderItemRepository OrderItemRepo { get; }
        private readonly AppDbContext context;

        public UnitOfWork(ICrudRepository<Client> clientCrudRepo, ICrudRepository<Product> productCrudRepo, ICrudRepository<Order> orderCrudRepo, IClientRepository clientRepo, IProductRepository productRepo, IOrderRepository orderRepo, IOrderItemRepository orderItemRepo, AppDbContext _context)
        {
            ClientCrudRepo = clientCrudRepo;
            ProductCrudRepo = productCrudRepo;
            OrderCrudRepo = orderCrudRepo;
            ClientRepo = clientRepo;
            ProductRepo = productRepo;
            OrderRepo = orderRepo;
            OrderItemRepo = orderItemRepo;
            context = _context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await context.SaveChangesAsync();
        }
    }
}
