using CrudApiDemo.Dtos.OrderDtos;
using CrudApiDemo.Interfaces.IRepository;
using FluentValidation;

namespace CrudApiDemo.Validators
{
    public class CreateOrderDtoValidator : AbstractValidator<CreateOrderDto>
    {
        public CreateOrderDtoValidator(IClientRepository clientRepo)
        {
            RuleFor(o => o.ClientId)
                .GreaterThan(0).WithMessage("ClientId must be a valid positive number.")
                .MustAsync(async (clientId, c) => await clientRepo.ClientIdExists(clientId))
                .WithMessage("Client Id does not exist.");

            RuleFor(o => o.Date)
                .NotEmpty().WithMessage("Date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Order date cannot be in the future.");
        }
    }
}