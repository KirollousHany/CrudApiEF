namespace CrudApiDemo.Interfaces.IService
{
    public interface IClientService
    {
        bool UpdateName(int id, string newName);
        bool UpdateEmail(int id, string newEmail);
        bool UpdatePassword(int id, string newPassword);
    }
}
