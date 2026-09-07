using Application.Dtos.OrderItemDto;
using FluentValidation;

namespace Application.Validators.OrderItem
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