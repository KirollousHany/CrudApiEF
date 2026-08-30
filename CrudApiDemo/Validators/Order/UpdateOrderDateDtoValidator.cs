using CrudApiDemo.Dtos.OrderDtos;
using FluentValidation;

namespace CrudApiDemo.Validators
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