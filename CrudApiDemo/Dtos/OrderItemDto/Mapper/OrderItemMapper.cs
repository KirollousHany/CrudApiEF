using CrudApiDemo.Models;

namespace CrudApiDemo.Dtos.OrderItemDto.Mapper
{
    public static class OrderItemMapper
    {
        public static OrderItemDto ToOrderItemDto(this OrderItem item)
        {
            return new OrderItemDto
            {
                OrderId = item.OrderId,
                ProductId = item.ProductId,
                ProductName = item.Product != null ? item.Product.Name : "",
                ProductPrice = item.Product != null ? item.Product.Price : 0,
                Quantity = item.Quantity,
                Total = item.Product != null ? item.Product.Price * item.Quantity : 0
            };
        }

        public static List<OrderItemDto> ToOrderItemDtoList(this List<OrderItem> items)
        {
            return items.Select(i => i.ToOrderItemDto()).ToList();
        }

        public static OrderItem ToOrderItemEntity(this CreateOrderItemDto dto)
        {
            return new OrderItem
            {
                OrderId = dto.OrderId,
                ProductId = dto.ProductId,
                Quantity = dto.Quantity
            };
        }
    }
}
