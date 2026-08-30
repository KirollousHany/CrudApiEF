using CrudApiDemo.Dtos.ProductDtos;
using FluentValidation;

namespace CrudApiDemo.Validators
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