using CrudApiDemo.Interfaces.IRepository;
using CrudApiDemo.Interfaces.IService;
using CrudApiDemo.Repositories;
using CrudApiDemo.Services;

namespace CrudApiDemo.Extensions.DJ.OrderItemDJ
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
