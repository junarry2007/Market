using MarketPlus.Application.Abstractions.Messaging;

namespace MarketPlus.Application.Products.UpdateProduct
{
    public record UpdateProductCommand(
        Guid Id,
        string Name,
        string Description,
        bool Status,
        int Stock,
        decimal amount,
        string currency
    ) : ICommand<Guid>;
}
