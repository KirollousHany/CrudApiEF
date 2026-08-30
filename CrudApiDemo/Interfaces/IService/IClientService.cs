using CrudApiDemo.ViewModels;

namespace CrudApiDemo.Interfaces.IService
{
    public interface IClientService
    {
        Task<bool> UpdateName(int id, string newName);
        Task<bool> UpdateEmail(int id, string newEmail);
        Task<bool> UpdatePassword(int id, string newPassword);
        Task<ClientDetailsViewModel?> GetClientDetails(int id);
    }
}
