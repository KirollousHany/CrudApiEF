using CrudApiDemo.Dtos.ClientDtos;
using CrudApiDemo.Interfaces.IRepository;
using FluentValidation;

namespace CrudApiDemo.Validators.Client
{
    public class CreateClientDtoValidator : AbstractValidator<CreateClientDto>
    {
        public CreateClientDtoValidator(IClientRepository clientRepo)
        {
            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Name is required.")
                .MaximumLength(50).WithMessage("Name cannot exceed 50 characters.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MustAsync(async (email, cancellation) => !await clientRepo.EmailExists(email))
                .WithMessage("Email already exists."); ;

            RuleFor(c => c.Password)
                .NotEmpty().WithMessage("Password is required.")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters.");
        }
    }
}
