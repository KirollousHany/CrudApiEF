using CrudApiDemo.Extensions.DJ.ClientDJ;
using CrudApiDemo.Extensions.DJ.OrderDJ;
using CrudApiDemo.Extensions.DJ.OrderItemDJ;
using CrudApiDemo.Extensions.DJ.ProductDJ;
using CrudApiDemo.Interfaces.IRepository;
using CrudApiDemo.Repositories;

namespace CrudApiDemo.Extensions.DJ
{
    public static class ApplicationServices
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddClientServices();
            services.AddProductServices();
            services.AddOrderServices();
            services.AddOrderItemServices();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
