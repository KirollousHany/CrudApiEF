using CrudApiDemo.Interfaces.IRepository;
using CrudApiDemo.Interfaces.IService;
using CrudApiDemo.Models;
using CrudApiDemo.ViewModels;

namespace CrudApiDemo.Services
{
    public class ClientService : ICrudService<Client>, IClientService
    {
        private readonly IUnitOfWork _uow;

        public ClientService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<Client>> GetAll()
        {
            return await _uow.ClientCrudRepo.GetAll();
        }

        public async Task<Client?> GetById(int id)
        {
            return await _uow.ClientCrudRepo.GetById(id);
        }

        public async Task<bool> Add(Client item)
        {
            if (await _uow.ClientRepo.EmailExists(item.Email)) return false;

            if (!await _uow.ClientCrudRepo.Add(item)) return false;

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
            var existing = await _uow.ClientCrudRepo.GetById(id);
            if (existing == null) return false;

            if (!await _uow.ClientCrudRepo.Delete(existing)) return false;

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

        public async Task<bool> UpdateName(int id, string newName)
        {
            var existing = await _uow.ClientCrudRepo.GetById(id);
            if (existing == null) return false;

            await _uow.ClientRepo.UpdateName(existing, newName);

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

        public async Task<bool> UpdateEmail(int id, string newEmail)
        {
            var existing = await _uow.ClientCrudRepo.GetById(id);
            if (existing == null) return false;

            await _uow.ClientRepo.UpdateEmail(existing, newEmail);

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

        public async Task<bool> UpdatePassword(int id, string newPassword)
        {
            var existing = await _uow.ClientCrudRepo.GetById(id);
            if (existing == null) return false;

            await _uow.ClientRepo.UpdatePassword(existing, newPassword);

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

        public async Task<ClientDetailsViewModel?> GetClientDetails(int id)
        {
            var client = await _uow.ClientCrudRepo.GetById(id);
            if (client == null) return null;

            var orders = await _uow.OrderRepo.GetOrdersByClientId(id);
            var orderSummaries = orders.Select(o => new ClientOrderSummary
            {
                OrderId = o.Id,
                Date = o.Date,
                ItemCount = o.OrderItems.Count,
                OrderTotal = o.OrderItems.Sum(oi => oi.Quantity * (oi.Product != null ? oi.Product.Price : 0))
            }).ToList();
            return new ClientDetailsViewModel
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email,
                TotalOrders = orderSummaries.Count,
                TotalSpent = orderSummaries.Sum(o => o.OrderTotal),
                Orders = orderSummaries
            };
        }
    }
}
