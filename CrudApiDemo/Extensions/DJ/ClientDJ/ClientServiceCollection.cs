using CrudApiDemo.Interfaces.IRepository;
using CrudApiDemo.Interfaces.IService;
using CrudApiDemo.Models;
using CrudApiDemo.Repositories;
using CrudApiDemo.Services;

namespace CrudApiDemo.Extensions.DJ.ClientDJ
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
