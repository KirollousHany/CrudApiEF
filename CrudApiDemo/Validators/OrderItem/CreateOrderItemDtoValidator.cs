using CrudApiDemo.Dtos.OrderItemDto;
using CrudApiDemo.Interfaces.IRepository;
using FluentValidation;

namespace CrudApiDemo.Validators
{
    public class CreateOrderItemDtoValidator : AbstractValidator<OrderItemDto>
    {
        public CreateOrderItemDtoValidator(IOrderRepository orderRepo, IProductRepository productRepo)
        {
            RuleFor(x => x.OrderId)
                .GreaterThan(0).WithMessage("OrderId must be a valid positive number.")
                .MustAsync(async (orderId, cancellation) => await orderRepo.OrderExists(orderId))
                .WithMessage("Order does not exists.");

            RuleFor(x => x.ProductId)
                .GreaterThan(0).WithMessage("ProductId must be a valid positive number.")
                .MustAsync(async (productId, cancellation) => await productRepo.ProductExists(productId))
                .WithMessage("Product does not exists."); ;

            RuleFor(x => x.Quantity)
                .GreaterThan(0).WithMessage("Quantity must be greater than 0.");
        }
    }
}