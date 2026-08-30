using CrudApiDemo.Interfaces.IRepository;
using CrudApiDemo.Interfaces.IService;
using CrudApiDemo.Models;
using CrudApiDemo.Repositories;
using CrudApiDemo.Services;

namespace CrudApiDemo.Extensions.DJ.ProductDJ
{
    public static class ProductServiceCollection
    {
        public static void AddProductServices(this IServiceCollection services)
        {
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ICrudRepository<Product>, ProductRepository>();
            services.AddScoped<ICrudService<Product>, ProductService>();
            services.AddScoped<IProductService, ProductService>();
        }
    }
}
