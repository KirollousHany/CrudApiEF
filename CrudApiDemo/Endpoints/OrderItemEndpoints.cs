using CrudApiDemo.Dtos.OrderItemDto;
using CrudApiDemo.Dtos.OrderItemDto.Mapper;
using CrudApiDemo.Interfaces.IService;

namespace CrudApiDemo.Endpoints
{
    public static class OrderItemEndpoints
    {
        public static void MapOrderItemEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/getAllOrderItems", (IOrderItemService service) =>
            {
                return Results.Ok(service.GetAll().ToOrderItemDtoList());
            });

            app.MapGet("/getOrderItem/{orderId}/{productId}", (int orderId, int productId, IOrderItemService service) =>
            {
                var item = service.GetByCompositeKey(orderId, productId);
                return item is null
                    ? Results.NotFound(new { message = "Order item not found." })
                    : Results.Ok(item.ToOrderItemDto());
            });

            app.MapPost("/addOrderItem", (CreateOrderItemDto newItemDto, IOrderItemService service) =>
            {
                var newItem = newItemDto.ToOrderItemEntity();
                var success = service.Add(newItem);

                return success
                    ? Results.Created($"/getOrderItem/{newItem.OrderId}/{newItem.ProductId}", new { message = "Order item added successfully." })
                    : Results.BadRequest(new { message = "Order or product does not exist ." });
            });

            app.MapDelete("/deleteOrderItem/{orderId}/{productId}", (int orderId, int productId, IOrderItemService service) =>
            {
                return service.Delete(orderId, productId)
                    ? Results.Ok(new { message = "Order item deleted successfully." })
                    : Results.NotFound(new { message = "Order item not found." });
            });

            app.MapPatch("/updateOrderItemQuantity/{orderId}/{productId}", (int orderId, int productId, int newQuantity, IOrderItemService service) =>
            {
                return service.UpdateQuantity(orderId, productId, newQuantity)
                    ? Results.Ok(new { message = "Quantity updated successfully." })
                    : Results.NotFound(new { message = "Order item not found." });
            });
            app.MapGet("/orders/{orderId}/items", (int orderId, IOrderItemService service) =>
            {
                var items = service.GetByOrderId(orderId);
                return Results.Ok(items.ToOrderItemDtoList());
            });
        }
    }
}
