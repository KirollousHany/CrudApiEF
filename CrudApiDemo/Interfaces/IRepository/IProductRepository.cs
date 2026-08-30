using CrudApiDemo.Models;

namespace CrudApiDemo.Interfaces.IRepository
{
    public interface IProductRepository
    {
        Task<bool> UpdateName(Product product, string newName);
        Task<bool> UpdatePrice(Product product, decimal newPrice);
        Task<bool> ProductExists(int productId);

    }
}
