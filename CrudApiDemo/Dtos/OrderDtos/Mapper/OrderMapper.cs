using CrudApiDemo.Models;

namespace CrudApiDemo.Dtos.OrderDtos.Mapper
{
    public static class OrderMapper
    {
        public static OrderDto ToOrderDto(this Order order)
        {
            return new OrderDto
            {
                Id = order.Id,
                ClientId = order.ClientId,
                Date = order.Date,
            };
        }

        public static List<OrderDto> ToOrderDtoList(this List<Order> orders)
        {
            return orders.Select(o => o.ToOrderDto()).ToList();
        }

        public static Order ToOrderEntity(this CreateOrderDto dto)
        {
            return new Order
            {
                ClientId = dto.ClientId,
                Date = dto.Date
            };
        }
    }
}
