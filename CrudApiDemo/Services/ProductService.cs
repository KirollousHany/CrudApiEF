using CrudApiDemo.Interfaces.IRepository;
using CrudApiDemo.Interfaces.IService;
using CrudApiDemo.Models;

namespace CrudApiDemo.Services
{
    public class ProductService : ICrudService<Product>, IProductService
    {
        private readonly ICrudRepository<Product> crudRepo;
        private readonly IProductRepository productRepo;

        public ProductService(ICrudRepository<Product> _crudRepo, IProductRepository _productRepo)
        {
            crudRepo = _crudRepo;
            productRepo = _productRepo;
        }

        public List<Product> GetAll()
        {
            return crudRepo.GetAll();
        }

        public bool Add(Product item)
        {
            return crudRepo.Add(item);
        }

        public bool Delete(int id)
        {
            var product = crudRepo.GetById(id);
            return product != null ? crudRepo.Delete(product) : false;
        }


        public Product? GetById(int id)
        {
            return crudRepo.GetById(id);
        }

        public bool UpdateName(int id, string newName)
        {
            var product = crudRepo.GetById(id);
            return product != null ? productRepo.UpdateName(product, newName) : false;
        }

        public bool UpdatePrice(int id, decimal newPrice)
        {
            var product = crudRepo.GetById(id);
            return product != null ? productRepo.UpdatePrice(product, newPrice) : false;
        }
    }
}
