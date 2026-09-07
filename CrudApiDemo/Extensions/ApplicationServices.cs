using Api.Extensions.ClientDJ;
using Api.Extensions.OrderDJ;
using Api.Extensions.OrderItemDJ;
using Api.Extensions.ProductDJ;
using Application.Extensions;
using Application.Interfaces.IRepository;
using Infrastructure.UnitOfWork;

namespace Api.Extensions
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
            services.AddApplication();
        }
    }
}
