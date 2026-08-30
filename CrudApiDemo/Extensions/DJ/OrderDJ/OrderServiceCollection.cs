using CrudApiDemo.Interfaces.IRepository;
using CrudApiDemo.Interfaces.IService;
using CrudApiDemo.Models;
using CrudApiDemo.Repositories;
using CrudApiDemo.Services;

namespace CrudApiDemo.Extensions.DJ.OrderDJ
{
    public static class OrderServiceCollection
    {
        public static void AddOrderServices(this IServiceCollection services)
        {
            services.AddScoped<ICrudRepository<Order>, OrderRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<ICrudService<Order>, OrderService>();
            services.AddScoped<IOrderService, OrderService>();
        }
    }
}
