using CrudApiDemo.Dtos.ClientDtos;
using FluentValidation;

namespace CrudApiDemo.Validators.Client
{
    public class UpdateNameDtoValidator : AbstractValidator<UpdateNameDto>
    {
        public UpdateNameDtoValidator()
        {
            RuleFor(x => x.NewName)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");
        }
    }
}
