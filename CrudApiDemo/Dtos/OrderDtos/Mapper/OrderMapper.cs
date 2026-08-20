using CrudApiDemo.Models;

namespace CrudApiDemo.Dtos.OrderDtos.Mapper
{
    public static class OrderMapper
    {
        public static OrderDto ToOrderDto(this Order order)
        {
            var total = order.OrderItems?.Sum(oi => oi.Quantity * (oi.Product != null ? oi.Product.Price : 0)) ?? 0;

            return new OrderDto
            {
                Id = order.Id,
                ClientId = order.ClientId,
                ClientName = order.Client != null ? order.Client.Name : "",
                Date = order.Date,
                TotalAmount = total
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
