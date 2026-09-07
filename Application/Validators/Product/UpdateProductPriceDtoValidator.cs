using Application.Dtos.ProductDtos;
using FluentValidation;

namespace Application.Validators.Product
{
    public class UpdateProductPriceDtoValidator : AbstractValidator<UpdateProductPriceDto>
    {
        public UpdateProductPriceDtoValidator()
        {
            RuleFor(x => x.NewPrice)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");
        }
    }
}