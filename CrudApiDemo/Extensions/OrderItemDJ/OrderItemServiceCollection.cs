using Application.Interfaces.IRepository;
using Application.Interfaces.IService;
using Application.Services;
using Infrastructure.Repositories;

namespace Api.Extensions.OrderItemDJ
{
    public static class OrderItemServiceCollection
    {
        public static void AddOrderItemServices(this IServiceCollection services)
        {
            services.AddScoped<IOrderItemRepository, OrderItemRepository>();
            services.AddScoped<IOrderItemService, OrderItemService>();
        }
    }
}
