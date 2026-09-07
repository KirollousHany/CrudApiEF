using Application.Dtos.ProductDtos;
using FluentValidation;

namespace Application.Validators.Product
{
    public class UpdateProductNameDtoValidator : AbstractValidator<UpdateProductNameDto>
    {
        public UpdateProductNameDtoValidator()
        {
            RuleFor(x => x.NewName)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");
        }
    }
}