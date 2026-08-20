using CrudApiDemo.Interfaces.IRepository;
using CrudApiDemo.Interfaces.IService;
using CrudApiDemo.Models;

namespace CrudApiDemo.Services
{
    public class ClientService : ICrudService<Client>, IClientService
    {
        private readonly ICrudRepository<Client> crudRepo;
        private readonly IClientRepository clientRepo;

        public ClientService(ICrudRepository<Client> _crudRepo, IClientRepository _clientRepo)
        {
            crudRepo = _crudRepo;
            clientRepo = _clientRepo;
        }

        public bool Add(Client item)
        {
            return clientRepo.EmailExists(item.Email) ? false : crudRepo.Add(item);
        }

        public bool Delete(int id)
        {
            var client = crudRepo.GetById(id);
            return client != null ? crudRepo.Delete(client) : false;
        }

        public List<Client> GetAll()
        {
            return crudRepo.GetAll();
        }

        public Client? GetById(int id)
        {
            return crudRepo.GetById(id);
        }

        public bool UpdateEmail(int id, string newEmail)
        {
            var client = crudRepo.GetById(id);
            return client != null ? clientRepo.UpdateEmail(client, newEmail) : false;
        }

        public bool UpdateName(int id, string newName)
        {
            var client = crudRepo.GetById(id);
            return client != null ? clientRepo.UpdateName(client, newName) : false;
        }

        public bool UpdatePassword(int id, string newPassword)
        {
            var client = crudRepo.GetById(id);
            return client != null ? clientRepo.UpdatePassword(client, newPassword) : false;
        }
    }
}
