//using CrudApiDemo.Dtos.OrderDtos;
//using CrudApiDemo.Dtos.OrderDtos.Mapper;
//using CrudApiDemo.Interfaces.IService;
//using CrudApiDemo.Models;

//namespace CrudApiDemo.Extensions.Endpoints
//{
//    public static class OrderEndpoints
//    {
//        public static void MapOrderEndpoints(this IEndpointRouteBuilder app)
//        {
//            app.MapGet("/getAllOrders", (ICrudService<Order> service) =>
//            {
//                return Results.Ok(service.GetAll().ToOrderDtoList());
//            });

//            app.MapGet("/getOrder/{id}", (int id, ICrudService<Order> service) =>
//            {
//                var order = service.GetById(id);
//                return order is null
//                    ? Results.NotFound(new { message = "Invalid order ID." })
//                    : Results.Ok(order.ToOrderDto());
//            });

//            app.MapGet("/clients/{clientId}/orders", (int clientId, IOrderService service) =>
//            {
//                var orders = service.GetOrdersByClientId(clientId);
//                return orders is null
//                    ? Results.NotFound(new { message = "No orders found for the specified client." })
//                    : Results.Ok(orders.ToOrderDtoList());
//            });

//            app.MapPost("/addNewOrder", (CreateOrderDto newOrderDto, ICrudService<Order> service) =>
//            {
//                var newOrder = newOrderDto.ToOrderEntity();
//                return service.Add(newOrder)
//                    ? Results.Created($"/getOrder/{newOrder.Id}", new { message = "Order created successfully." })
//                    : Results.BadRequest(new { message = "Client does not exist, or the order could not be created." });
//            });

//            app.MapDelete("/deleteOrder/{id}", (int id, ICrudService<Order> service) =>
//            {
//                return service.Delete(id)
//                    ? Results.Ok(new { message = "Order deleted successfully." })
//                    : Results.NotFound(new { message = "Invalid order ID." });
//            });

//            app.MapPatch("/updateOrderDate/{id}", (int id, DateTime newDate, IOrderService service) =>
//            {
//                return service.UpdateDate(id, newDate)
//                    ? Results.Ok(new { message = "Order date updated successfully." })
//                    : Results.NotFound(new { message = "Invalid order ID." });
//            });
//        }
//    }
//}
