using Application.Interfaces.IRepository;
using Application.Interfaces.IService;
using Application.Services;
using Domain.Entities;
using Infrastructure.Repositories;

namespace Api.Extensions.ProductDJ
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
