using CrudApiDemo.Dtos.ProductDtos;
using FluentValidation;

namespace CrudApiDemo.Validators
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