using CrudApiDemo.Data;
using CrudApiDemo.Interfaces.IRepository;
using CrudApiDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApiDemo.Repositories
{
    public class ClientRepository : ICrudRepository<Client>, IClientRepository
    {
        private readonly AppDbContext context;

        public ClientRepository(AppDbContext _context)
        {
            context = _context;
        }
        public async Task<List<Client>> GetAll()
        {
            return await context.Clients.ToListAsync();
        }

        public async Task<Client?> GetById(int id)
        {
            return await context.Clients.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<bool> EmailExists(string email)
        {
            return await context.Clients.AnyAsync(c => c.Email == email);
        }

        public async Task<bool> Add(Client item)
        {
            try
            {
                context.Clients.Add(item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(Client item)
        {
            try
            {
                context.Clients.Remove(item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateName(Client client, string newName)
        {
            client.Name = newName;
            return true;
        }

        public async Task<bool> UpdateEmail(Client client, string newEmail)
        {
            client.Email = newEmail;
            return true;
        }

        public async Task<bool> UpdatePassword(Client client, string newPassword)
        {
            client.Password = newPassword;
            return true;
        }

        public async Task<bool> ClientIdExists(int clientid)
        {
            return await context.Clients.AnyAsync(c => c.Id == clientid);

        }
    }
}
