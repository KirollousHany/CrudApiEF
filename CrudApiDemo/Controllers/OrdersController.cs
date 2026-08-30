using CrudApiDemo.Dtos.OrderDtos;
using CrudApiDemo.Dtos.OrderDtos.Mapper;
using CrudApiDemo.Interfaces.IService;
using CrudApiDemo.Models;
using CrudApiDemo.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CrudApiDemo.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : BaseApiController
    {
        private readonly ICrudService<Order> service;
        private readonly IOrderService orderService;
        private readonly IValidator<CreateOrderDto> createValidator;
        private readonly IValidator<UpdateOrderDateDto> dateValidator;

        public OrdersController(
            ICrudService<Order> _service,
            IOrderService _orderService,
            IValidator<CreateOrderDto> _createValidator,
            IValidator<UpdateOrderDateDto> _dateValidator)
        {
            service = _service;
            orderService = _orderService;
            createValidator = _createValidator;
            dateValidator = _dateValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var orders = await service.GetAll();
            return Ok(BaseResponse<List<OrderDto>>.SuccessResponse(orders.ToOrderDtoList()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var order = await service.GetById(id);
            if (order is null) return NotFound(BaseResponse<OrderDto>.FailResponse("Invalid order ID.", 404));
            return Ok(BaseResponse<OrderDto>.SuccessResponse(order.ToOrderDto(), 200));
        }

        [HttpGet("~/api/Clients/{clientId}/orders")]
        public async Task<IActionResult> GetByClientId(int clientId)
        {
            var orders = await orderService.GetOrdersByClientId(clientId);
            if (orders == null) return NotFound(BaseResponse<OrderDto>.FailResponse("Invalid client ID.", 404));
            return Ok(BaseResponse<List<OrderDto>>.SuccessResponse(orders.ToOrderDtoList()));
        }

        [HttpGet("{id}/details")]
        public async Task<IActionResult> GetDetails(int id)
        {
            var details = await orderService.GetOrderDetails(id);
            if (details is null) return NotFound(BaseResponse<object>.FailResponse("Invalid order ID.", 404));
            return Ok(BaseResponse<object>.SuccessResponse(details));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateOrderDto dto)
        {
            var invalid = await ValidateAsync(createValidator, dto);
            if (invalid != null) return invalid;

            var newOrder = dto.ToOrderEntity();
            var success = await service.Add(newOrder);

            if (!success) return BadRequest(BaseResponse<OrderDto>.FailResponse("Client does not exist, or the order could not be created.", 400));

            return CreatedAtAction(nameof(GetById), new { id = newOrder.Id },
                BaseResponse<OrderDto>.SuccessResponse(newOrder.ToOrderDto(), 201));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await service.Delete(id);
            return success
                ? Ok(BaseResponse<string>.SuccessResponse("Order deleted successfully."))
                : NotFound(BaseResponse<string>.FailResponse("Invalid order ID.", 404));
        }

        [HttpPatch("{id}/date")]
        public async Task<IActionResult> UpdateDate(int id, UpdateOrderDateDto newDate)
        {
            var invalid = Validate(dateValidator, newDate);
            if (invalid != null) return invalid;

            var success = await orderService.UpdateDate(id, newDate.NewDate);
            return success
                ? Ok(BaseResponse<string>.SuccessResponse("Order date updated successfully."))
                : NotFound(BaseResponse<string>.FailResponse("Invalid order ID.", 404));
        }
    }
}