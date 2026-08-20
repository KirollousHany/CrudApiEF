using CrudApiDemo.Models;

namespace CrudApiDemo.Dtos.ClientDtos.Mappers
{
    public static class ClientMapper
    {
        public static ClientDto ToClientDto(this Client client)
        {
            return new ClientDto
            {
                Id = client.Id,
                Name = client.Name,
                Email = client.Email
            };
        }

        public static List<ClientDto> ToClientDtoList(this List<Client> clients)
        {
            return clients.Select(c => c.ToClientDto()).ToList();
        }
        public static Client ToClientEntity(this CreateClientDto dto)
        {
            return new Client
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password
            };
        }
    }
}
