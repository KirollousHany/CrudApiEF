using CrudApiDemo.Interfaces.IRepository;
using CrudApiDemo.Interfaces.IService;
using CrudApiDemo.Models;

namespace CrudApiDemo.Services
{
    public class ProductService : ICrudService<Product>, IProductService
    {
        private readonly IUnitOfWork _uow;

        public ProductService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<List<Product>> GetAll()
        {
            return await _uow.ProductCrudRepo.GetAll();
        }

        public async Task<Product?> GetById(int id)
        {
            Product? product = await _uow.ProductCrudRepo.GetById(id);
            return product;
        }

        public async Task<bool> Add(Product item)
        {
            if (!await _uow.ProductCrudRepo.Add(item)) return false;

            try
            {
                await _uow.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var existing = await _uow.ProductCrudRepo.GetById(id);
            if (existing == null) return false;

            if (!await _uow.ProductCrudRepo.Delete(existing)) return false;

            try
            {
                await _uow.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateName(int id, string newName)
        {
            var existing = await _uow.ProductCrudRepo.GetById(id);
            if (existing == null) return false;

            await _uow.ProductRepo.UpdateName(existing, newName);

            try
            {
                await _uow.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdatePrice(int id, decimal newPrice)
        {
            var existing = await _uow.ProductCrudRepo.GetById(id);
            if (existing == null) return false;

            await _uow.ProductRepo.UpdatePrice(existing, newPrice);

            try
            {
                await _uow.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
