using CrudApiDemo.Models;

namespace CrudApiDemo.Interfaces.IRepository
{
    public interface IProductRepository
    {
        bool UpdateName(Product product, string newName);
        bool UpdatePrice(Product product, decimal newPrice);
    }
}
