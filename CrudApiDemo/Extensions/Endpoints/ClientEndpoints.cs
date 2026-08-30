//using CrudApiDemo.Dtos.ClientDtos;
//using CrudApiDemo.Dtos.ClientDtos.Mappers;
//using CrudApiDemo.Interfaces.IService;
//using CrudApiDemo.Models;

//namespace CrudApiDemo.Extensions.Endpoints
//{
//    public static class ClientEndpoints
//    {
//        public static void MapClientEndpoints(this IEndpointRouteBuilder app)
//        {
//            app.MapGet("/getAllClients", (ICrudService<Client> service) =>
//            {
//                return Results.Ok(service.GetAll().ToClientDtoList());
//            });
//            app.MapGet("/getClient/{id}", (int id, ICrudService<Client> service) =>
//            {
//                var client = service.GetById(id);
//                return client is null ? Results.NotFound(new
//                { message = "Invalid client ID." }) : Results.Ok(client.ToClientDto());
//            });
//            app.MapPost("/addNewClient", (CreateClientDto newClientDto, ICrudService<Client> service) =>
//            {
//                var newClient = newClientDto.ToClientEntity();
//                var success = service.Add(newClient);

//                return success
//                    ? Results.Created($"/getClient/{newClient.Id}", new { message = "Client added successfully." })
//                    : Results.BadRequest(new { message = "Email already exists." });
//            });
//            app.MapDelete("/deleteClient/{id}", (int id, ICrudService<Client> service) =>
//            {
//                return service.Delete(id) ? Results.Ok(new { message = "Client deleted successfully." }) : Results.NotFound(new { message = "Invalid client ID." });
//            });
//            app.MapPatch("/updateClientName/{id}", (int id, string newName, IClientService service) =>
//            {
//                return service.UpdateName(id, newName) ? Results.Ok(new { message = "Client name updated successfully." }) : Results.NotFound(new { message = "Invalid client ID." });
//            });
//            app.MapPatch("/updateClientEmail/{id}", (int id, string newEmail, IClientService service) =>
//            {
//                return service.UpdateEmail(id, newEmail) ? Results.Ok(new { message = "Client email updated successfully." }) : Results.NotFound(new { message = "Invalid client ID." });
//            });
//            app.MapPatch("/changePassword/{id}", (int id, string newPassword, IClientService service) =>
//            {
//                return service.UpdatePassword(id, newPassword) ? Results.Ok(new { message = "Client password updated successfully." }) : Results.NotFound(new { message = "Invalid client ID." });
//            });
//        }
//    }
//}
