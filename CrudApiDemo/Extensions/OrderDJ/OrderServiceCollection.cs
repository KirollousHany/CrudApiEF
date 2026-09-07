using Application.Interfaces.IRepository;
using Application.Interfaces.IService;
using Application.Services;
using Domain.Entities;
using Infrastructure.Repositories;

namespace Api.Extensions.OrderDJ
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
