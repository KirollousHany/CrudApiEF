using CrudApiDemo.Dtos.OrderItemDto;
using FluentValidation;

namespace CrudApiDemo.Validators
{
    public class UpdateOrderItemQuantityDtoValidator : AbstractValidator<UpdateOrderItemQuantityDto>
    {
        public UpdateOrderItemQuantityDtoValidator()
        {
            RuleFor(x => x.NewQuantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }
    }
}