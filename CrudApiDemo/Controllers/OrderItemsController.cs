using CrudApiDemo.Dtos.ClientDtos;
using CrudApiDemo.Dtos.OrderItemDto;
using CrudApiDemo.Dtos.OrderItemDto.Mapper;
using CrudApiDemo.Dtos.ProductDtos;
using CrudApiDemo.Interfaces.IService;
using CrudApiDemo.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CrudApiDemo.Controllers
{
    [Route("api/[controller]")]
    public class OrderItemsController : BaseApiController
    {
        private readonly IOrderItemService service;
        private readonly IValidator<OrderItemDto> createValidator;
        private readonly IValidator<UpdateOrderItemQuantityDto> quantityValidator;

        public OrderItemsController(
            IOrderItemService _service,
            IValidator<OrderItemDto> _createValidator,
            IValidator<UpdateOrderItemQuantityDto> _quantityValidator)
        {
            service = _service;
            createValidator = _createValidator;
            quantityValidator = _quantityValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var items = await service.GetAll();
            return Ok(BaseResponse<List<OrderItemDto>>.SuccessResponse(items.ToOrderItemDtoList()));
        }

        [HttpGet("{orderId}/{productId}")]
        public async Task<IActionResult> GetByCompositeKey(int orderId, int productId)
        {
            var item = await service.GetByCompositeKey(orderId, productId);
            if (item is null) return NotFound(BaseResponse<ProductDto>.FailResponse("Order item not found.", 404));
            return Ok(BaseResponse<OrderItemDto>.SuccessResponse(item.ToOrderItemDto(), 200));
        }

        [HttpGet("~/api/Orders/{orderId}/items")]
        public async Task<IActionResult> GetByOrderId(int orderId)
        {
            var items = await service.GetByOrderId(orderId);
            return Ok(BaseResponse<List<OrderItemDto>>.SuccessResponse(items.ToOrderItemDtoList()));
        }

        [HttpPost]
        public async Task<IActionResult> Add(OrderItemDto dto)
        {
            var invalid = await ValidateAsync(createValidator, dto);
            if (invalid != null) return invalid;

            var newItem = dto.ToOrderItemEntity();
            var success = await service.Add(newItem);

            if (!success)
                return BadRequest(BaseResponse<ClientDto>.FailResponse("Order or product does not exist, or this item already exists in the order.", 400));
            var orderItem = await service.GetByCompositeKey(newItem.OrderId, newItem.ProductId);

            return CreatedAtAction(nameof(GetByCompositeKey),
                new { orderId = newItem.OrderId, productId = newItem.ProductId },
                BaseResponse<OrderItemDto>.SuccessResponse(orderItem!.ToOrderItemDto(), 201));
        }

        [HttpDelete("{orderId}/{productId}")]
        public async Task<IActionResult> Delete(int orderId, int productId)
        {
            var success = await service.Delete(orderId, productId);
            return success
                ? Ok(BaseResponse<string>.SuccessResponse("Order item deleted successfully."))
                : NotFound(BaseResponse<string>.FailResponse("Order item not found.", 404));
        }

        [HttpPatch("{orderId}/{productId}/quantity")]
        public async Task<IActionResult> UpdateQuantity(int orderId, int productId, UpdateOrderItemQuantityDto newQuantity)
        {
            var invalid = Validate(quantityValidator, newQuantity);
            if (invalid != null) return invalid;

            var success = await service.UpdateQuantity(orderId, productId, newQuantity.NewQuantity);
            return success
                ? Ok(BaseResponse<string>.SuccessResponse("Quantity updated successfully."))
                : NotFound(BaseResponse<string>.FailResponse("Order item not found.", 404));
        }
    }
}
