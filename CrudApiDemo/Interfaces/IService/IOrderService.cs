namespace CrudApiDemo.Interfaces.IService
{
    public interface IOrderService
    {
        bool UpdateDate(int id, DateTime newDate);
        List<Models.Order> GetOrdersByClientId(int clientId);
        bool UserExists(int userId);

    }
}
