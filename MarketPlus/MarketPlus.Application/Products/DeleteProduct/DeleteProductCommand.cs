using MarketPlus.Application.Abstractions.Messaging;

namespace MarketPlus.Application.Products.DeleteProduct
{
    public record DeleteProductCommand(Guid id) : ICommand<Guid>;
}
