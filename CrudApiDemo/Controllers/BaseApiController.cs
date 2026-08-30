using CrudApiDemo.Responses;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace CrudApiDemo.Controllers
{
    [ApiController]
    public abstract class BaseApiController : ControllerBase
    {
        protected async Task<IActionResult?> ValidateAsync<T>(IValidator<T> validator, T dto)
        {
            var result = await validator.ValidateAsync(dto);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(BaseResponse<string>.FailResponse(string.Join(" ", errors), 400));
            }
            return null;
        }
        protected IActionResult? Validate<T>(IValidator<T> validator, T dto)
        {
            var result = validator.Validate(dto);
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();
                return BadRequest(BaseResponse<string>.FailResponse(string.Join(" ", errors), 400));
            }
            return null;
        }
    }
}
