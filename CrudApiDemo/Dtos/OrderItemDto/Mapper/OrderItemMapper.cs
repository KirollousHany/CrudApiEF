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
                Quantity = item.Quantity,
            };
        }

        public static List<OrderItemDto> ToOrderItemDtoList(this List<OrderItem> items)
        {
            return items.Select(i => i.ToOrderItemDto()).ToList();
        }

        public static OrderItem ToOrderItemEntity(this OrderItemDto dto)
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
