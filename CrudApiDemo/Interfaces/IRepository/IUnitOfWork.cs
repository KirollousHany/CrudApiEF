using CrudApiDemo.Models;

namespace CrudApiDemo.Interfaces.IRepository
{
    public interface IUnitOfWork
    {
        public ICrudRepository<Client> ClientCrudRepo { get; }
        public ICrudRepository<Product> ProductCrudRepo { get; }
        public ICrudRepository<Order> OrderCrudRepo { get; }
        public IClientRepository ClientRepo { get; }
        public IProductRepository ProductRepo { get; }
        public IOrderRepository OrderRepo { get; }
        public IOrderItemRepository OrderItemRepo { get; }
        public Task<int> SaveChangesAsync();

    }
}
