using FluentValidation;

namespace MarketPlus.Application.Products.AddProduct
{
    public class AddProductValidator : AbstractValidator<AddProductCommand>
    {
        public AddProductValidator()
        {
            RuleFor(c => c.Name).NotEmpty().NotNull();
            RuleFor(c => c.Description).NotEmpty();
            RuleFor(c => c.Status).NotEmpty();
            RuleFor(c => c.Stock).NotEmpty();
        }
    }
}
