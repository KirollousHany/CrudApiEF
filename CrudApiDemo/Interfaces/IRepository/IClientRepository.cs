using CrudApiDemo.Models;

namespace CrudApiDemo.Interfaces.IRepository
{
    public interface IClientRepository
    {
        bool UpdateName(Client client, string newName);
        bool UpdateEmail(Client client, string newEmail);
        bool UpdatePassword(Client client, string newPassword);
        bool EmailExists(string email);
    }
}
