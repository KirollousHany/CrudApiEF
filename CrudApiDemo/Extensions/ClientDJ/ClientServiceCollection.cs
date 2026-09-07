using Application.Interfaces.IRepository;
using Application.Interfaces.IService;
using Application.Services;
using Domain.Entities;
using Infrastructure.Repositories;


namespace Api.Extensions.ClientDJ
{
    public static class ClientServiceCollection
    {
        public static void AddClientServices(this IServiceCollection services)
        {
            services.AddScoped<ICrudRepository<Client>, ClientRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ICrudService<Client>, ClientService>();
            services.AddScoped<IClientService, ClientService>();
        }
    }
}
