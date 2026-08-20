using CrudApiDemo.Data;
using CrudApiDemo.Interfaces.IRepository;
using CrudApiDemo.Models;

namespace CrudApiDemo.Repositories
{
    public class ClientRepository : ICrudRepository<Client>, IClientRepository
    {
        private readonly AppDbContext context;

        public ClientRepository(AppDbContext _context)
        {
            context = _context;
        }
        public List<Client> GetAll()
        {
            return context.Clients.ToList();
        }
        public Client? GetById(int id)
        {
            return context.Clients.FirstOrDefault(c => c.Id == id);
        }
        public bool Add(Client item)
        {
            try
            {
                context.Clients.Add(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Delete(Client item)
        {
            try
            {
                context.Clients.Remove(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool EmailExists(string email)
        {
            return context.Clients.FirstOrDefault(c => c.Email == email) != null;
        }
        public bool UpdateName(Client client, string newName)
        {
            try
            {
                client.Name = newName;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdateEmail(Client client, string newEmail)
        {
            try
            {
                client.Email = newEmail;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool UpdatePassword(Client client, string newPassword)
        {
            try
            {
                client.Password = newPassword;
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
