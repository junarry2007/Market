using MarketPlus.Application.Abstractions.Messaging;

namespace MarketPlus.Application.Products.AddProduct
{
    public record AddProductCommand(
        string Name,
        string Description,
        bool Status,
        int Stock,
        decimal amount,
        string currency
    ) : ICommand<Guid>;
}
