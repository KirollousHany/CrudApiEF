using CrudApiDemo.Models;

namespace CrudApiDemo.Interfaces.IRepository
{
    public interface IClientRepository
    {
        Task<bool> UpdateName(Client client, string newName);
        Task<bool> UpdateEmail(Client client, string newEmail);
        Task<bool> UpdatePassword(Client client, string newPassword);
        Task<bool> EmailExists(string email);
        Task<bool> ClientIdExists(int clientid);

    }
}
