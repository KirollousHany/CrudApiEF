using Application.Dtos.ClientDtos;
using Application.Interfaces.IRepository;
using FluentValidation;

namespace Application.Validators.Client
{
    public class UpdateEmailDtoValidator : AbstractValidator<UpdateEmailDto>
    {
        public UpdateEmailDtoValidator(IClientRepository clientRepo)
        {
            RuleFor(x => x.NewEmail)
                .NotEmpty().WithMessage("Email is required.")
                .EmailAddress().WithMessage("Invalid email format.")
                .MustAsync(async (email, cancellation) => !await clientRepo.EmailExists(email))
                .WithMessage("Email already exists.");
        }
    }
}
