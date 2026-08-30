using CrudApiDemo.Dtos.ProductDtos;
using CrudApiDemo.Dtos.ProductDtos.Mappers;
using CrudApiDemo.Interfaces.IService;
using CrudApiDemo.Models;
using CrudApiDemo.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CrudApiDemo.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : BaseApiController
    {
        private readonly ICrudService<Product> service;
        private readonly IProductService productService;
        private readonly IValidator<CreateProductDto> createValidator;
        private readonly IValidator<UpdateProductNameDto> nameValidator;
        private readonly IValidator<UpdateProductPriceDto> priceValidator;

        public ProductsController(
            ICrudService<Product> _service,
            IProductService _productService,
            IValidator<CreateProductDto> _createValidator,
            IValidator<UpdateProductNameDto> _nameValidator,
            IValidator<UpdateProductPriceDto> _priceValidator)
        {
            service = _service;
            productService = _productService;
            createValidator = _createValidator;
            nameValidator = _nameValidator;
            priceValidator = _priceValidator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await service.GetAll();
            return Ok(BaseResponse<List<ProductDto>>.SuccessResponse(products.ToProductDtoList()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await service.GetById(id);
            if (product is null) return NotFound(BaseResponse<ProductDto>.FailResponse("Invalid product ID.", 404));
            return Ok(BaseResponse<ProductDto>.SuccessResponse(product.ToProductDto(), 200));
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateProductDto dto)
        {
            var invalid = Validate(createValidator, dto);
            if (invalid != null) return invalid;

            var newProduct = dto.ToProductEntity();
            var success = await service.Add(newProduct);

            if (!success) return BadRequest(BaseResponse<ProductDto>.FailResponse("Could not add product.", 400));

            return CreatedAtAction(nameof(GetById), new { id = newProduct.Id },
                BaseResponse<ProductDto>.SuccessResponse(newProduct.ToProductDto(), 201));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await service.Delete(id);
            return success
                ? Ok(BaseResponse<string>.SuccessResponse("Product deleted successfully."))
                : NotFound(BaseResponse<string>.FailResponse("Invalid product ID.", 404));
        }

        [HttpPatch("{id}/name")]
        public async Task<IActionResult> UpdateName(int id, UpdateProductNameDto newName)
        {
            var invalid = Validate(nameValidator, newName);
            if (invalid != null) return invalid;

            var success = await productService.UpdateName(id, newName.NewName);
            return success
                ? Ok(BaseResponse<string>.SuccessResponse($"Product name updated to {newName.NewName}."))
                : NotFound(BaseResponse<string>.FailResponse("Invalid product ID.", 404));
        }

        [HttpPatch("{id}/price")]
        public async Task<IActionResult> UpdatePrice(int id, UpdateProductPriceDto newPrice)
        {
            var invalid = Validate(priceValidator, newPrice);
            if (invalid != null) return invalid;

            var success = await productService.UpdatePrice(id, newPrice.NewPrice);
            return success
                ? Ok(BaseResponse<string>.SuccessResponse($"Product price updated to {newPrice.NewPrice}."))
                : NotFound(BaseResponse<string>.FailResponse("Invalid product ID.", 404));
        }
    }
}