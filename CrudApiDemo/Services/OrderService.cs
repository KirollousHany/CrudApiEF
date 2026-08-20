using CrudApiDemo.Interfaces.IRepository;
using CrudApiDemo.Interfaces.IService;
using CrudApiDemo.Models;

namespace CrudApiDemo.Services
{
    public class OrderService : ICrudService<Order>, IOrderService
    {
        private readonly ICrudRepository<Order> crudRepo;
        private readonly IOrderRepository orderRepo;
        private readonly ICrudRepository<Client> clientRepo;


        public OrderService(ICrudRepository<Order> _crudRepo, IOrderRepository _orderRepo, ICrudRepository<Client> _clientRepo)
        {
            crudRepo = _crudRepo;
            orderRepo = _orderRepo;
            clientRepo = _clientRepo;
        }

        public List<Order> GetAll()
        {
            return crudRepo.GetAll();
        }

        public Order? GetById(int id)
        {
            return crudRepo.GetById(id);
        }

        public List<Order> GetOrdersByClientId(int clientId)
        {
            return orderRepo.GetOrdersByClientId(clientId);
        }

        public bool Add(Order item)
        {
            return UserExists(item.ClientId) ? crudRepo.Add(item) : false;
        }

        public bool Delete(int id)
        {
            var order = crudRepo.GetById(id);
            return order != null ? crudRepo.Delete(order) : false;
        }

        public bool UpdateDate(int id, DateTime newDate)
        {
            var order = crudRepo.GetById(id);
            return order != null ? orderRepo.UpdateDate(order, newDate) : false;
        }
        public bool UserExists(int userId)
        {
            return clientRepo.GetById(userId) != null;
        }
    }
}
