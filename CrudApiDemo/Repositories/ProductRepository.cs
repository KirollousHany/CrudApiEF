using CrudApiDemo.Data;
using CrudApiDemo.Interfaces.IRepository;
using CrudApiDemo.Models;

namespace CrudApiDemo.Repositories
{
    public class ProductRepository : ICrudRepository<Product>, IProductRepository
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext _context)
        {
            context = _context;
        }

        public List<Product> GetAll()
        {
            return context.Products.ToList();
        }

        public Product? GetById(int id)
        {
            return context.Products.FirstOrDefault(p => p.Id == id);
        }

        public bool Add(Product item)
        {
            try
            {
                context.Products.Add(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(Product item)
        {
            try
            {
                context.Products.Remove(item);
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateName(Product product, string newName)
        {
            try
            {
                product.Name = newName;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdatePrice(Product product, decimal newPrice)
        {
            try
            {
                product.Price = newPrice;
                context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
