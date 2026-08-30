using CrudApiDemo.Interfaces.IRepository;
using CrudApiDemo.Interfaces.IService;
using CrudApiDemo.Models;
using CrudApiDemo.ViewModels;

namespace CrudApiDemo.Services
{
    public class OrderService : ICrudService<Order>, IOrderService
    {
        private readonly IUnitOfWork _uow;

        public OrderService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<Order>> GetAll()
        {
            return await _uow.OrderCrudRepo.GetAll();
        }

        public async Task<Order?> GetById(int id)
        {
            return await _uow.OrderCrudRepo.GetById(id);
        }

        public async Task<List<Order>?> GetOrdersByClientId(int clientId)
        {
            if (!await _uow.ClientRepo.ClientIdExists(clientId)) return null;
            return await _uow.OrderRepo.GetOrdersByClientId(clientId);
        }

        public async Task<bool> Add(Order item)
        {
            if (!await _uow.OrderCrudRepo.Add(item)) return false;

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

        public async Task<bool> Delete(int id)
        {
            var existing = await _uow.OrderCrudRepo.GetById(id);
            if (existing == null) return false;
            if (!await _uow.OrderCrudRepo.Delete(existing))
                return false;

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

        public async Task<bool> UpdateDate(int id, DateTime newDate)
        {
            var existing = await _uow.OrderCrudRepo.GetById(id);
            if (existing == null) return false;
            await _uow.OrderRepo.UpdateDate(existing, newDate);
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
        public async Task<bool> UserExists(int userId)
        {
            var isValid = await _uow.ClientCrudRepo.GetById(userId);
            return isValid != null;
        }

        public async Task<OrderDetailsViewModel?> GetOrderDetails(int id)
        {
            var order = await _uow.OrderCrudRepo.GetById(id);
            if (order == null) return null;

            var items = await _uow.OrderItemRepo.GetByOrderId(id);
            var itemLines = items.Select(oi => new OrderItemLine
            {
                ProductId = oi.ProductId,
                ProductName = oi.Product != null ? oi.Product.Name : "",
                UnitPrice = oi.Product != null ? oi.Product.Price : 0,
                Quantity = oi.Quantity,
                TotalPrice = oi.Quantity * (oi.Product != null ? oi.Product.Price : 0)
            }).ToList();
            return new OrderDetailsViewModel
            {
                Id = order.Id,
                Date = order.Date,
                ClientId = order.ClientId,
                ClientName = order.Client != null ? order.Client.Name : "",
                ClientEmail = order.Client != null ? order.Client.Email : "",
                Items = itemLines,
                TotalItems = itemLines.Sum(i => i.Quantity),
                TotalPrice = itemLines.Sum(i => i.TotalPrice)
            };
        }
    }
}
