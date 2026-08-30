using CrudApiDemo.Data;
using CrudApiDemo.Interfaces.IRepository;
using CrudApiDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace CrudApiDemo.Repositories
{
    public class ProductRepository : ICrudRepository<Product>, IProductRepository
    {
        private readonly AppDbContext context;

        public ProductRepository(AppDbContext _context)
        {
            context = _context;
        }

        public async Task<List<Product>> GetAll()
        {
            return await context.Products.ToListAsync();
        }

        public async Task<Product?> GetById(int id)
        {
            return await context.Products.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> Add(Product item)
        {
            try
            {
                context.Products.Add(item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> Delete(Product item)
        {
            try
            {
                context.Products.Remove(item);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateName(Product product, string newName)
        {
            product.Name = newName;
            return true;
        }

        public async Task<bool> UpdatePrice(Product product, decimal newPrice)
        {
            product.Price = newPrice;
            return true;
        }

        public async Task<bool> ProductExists(int productId)
        {
            return await context.Products.AnyAsync(p => p.Id == productId);

        }
    }
}
