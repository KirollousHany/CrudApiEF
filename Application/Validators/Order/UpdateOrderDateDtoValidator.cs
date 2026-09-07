using Application.Dtos.OrderDtos;
using FluentValidation;

namespace Application.Validators.Order
{
    public class UpdateOrderDateDtoValidator : AbstractValidator<UpdateOrderDateDto>
    {
        public UpdateOrderDateDtoValidator()
        {
            RuleFor(x => x.NewDate)
                .NotEmpty().WithMessage("Date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Order date cannot be in the future.");
        }
    }
}