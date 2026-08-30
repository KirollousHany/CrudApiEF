namespace CrudApiDemo.Interfaces.IService
{
    public interface IProductService
    {
        Task<bool> UpdateName(int id, string newName);
        Task<bool> UpdatePrice(int id, decimal newPrice);
    }
}
